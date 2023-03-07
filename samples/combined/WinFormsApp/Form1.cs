using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO.Compression;
using WinFormsApp.Dto;

namespace WinFormsApp;

public partial class Form1 : Form
{
    private readonly GetDataFromMyCalibration _getter;
    private List<ExtractedHeaderInfo> _extractedHeaderInfos;

    public Form1()
    {
        InitializeComponent();
        _getter = new GetDataFromMyCalibration();
        richTextBox1.Text += $"{DateTime.Now:s} | Started at {DateTime.Now:R}\n";
    }

    private async void testApiButton_Click(object sender, EventArgs e)
    {
        var permanentAccessToken = textBox1.Text;
        if (permanentAccessToken == null || permanentAccessToken.Length < 200)
        {
            richTextBox1.Text += "{DateTime.Now:s} | Permanent Access Token is wrong.\n";
        }
        else
        {
            var responseText = await _getter.GetCountAsync(permanentAccessToken);
            richTextBox1.Text += $"{DateTime.Now:s} | API Call successfull. There are calibration data of {responseText} sensors available.\n";
        }
    }


    private async void buttonCallApiForHeaders_Click(object? sender, EventArgs e)
    {
        var permanentAccessToken = textBox1.Text;
        if (permanentAccessToken == null || permanentAccessToken.Length < 200)
        {
            richTextBox1.Text += $"{DateTime.Now:s} | Permanent Access Token is wrong.\n";
        }
        else
        {
            var responseText = await _getter.GetHeaderDataAsync(permanentAccessToken);
            richTextBox1.Text += $"{DateTime.Now:s} | API Call successfull. Data:\n {responseText}\n";

            //You can also deserialize the meta information
            try
            {
                //Does not work with auto-generated swagger dto
                //var headers2 = JsonConvert.DeserializeObject<List<IO.Swagger.Model.Header>>(responseText, KellerSensorDataExchange.Converter.Settings);
                    
                var headers = JsonConvert.DeserializeObject<List<object>>(responseText);
                if (headers != null && headers.Count > 0)
                {
                    var sampleHeaderJsonData = headers.First();
                    richTextBox1.Text += $"{DateTime.Now:s} | FIRST HEADER META INFO: \n{sampleHeaderJsonData}\n";
                }


                //Now, let's populate the lists in the Form
                _extractedHeaderInfos = new List<ExtractedHeaderInfo>();
                foreach (JObject header in headers)
                {
                    var extractedHeaderInfo = new ExtractedHeaderInfo
                    {
                        OrderNumber   = header["orderNumber"].ToString(),
                        OrderPosition = header["orderPosition"].ToString(),
                        SerialNumber  = header["serialNumber"].ToString()
                    };
                    _extractedHeaderInfos.Add(extractedHeaderInfo);
                }

                PopulateTreeView();
            }
            catch (Exception exception)
            {
                richTextBox1.Text += $"{DateTime.Now:s} | Deserialization is not possible : \n {exception}\n";
            }
        }
    }

    private async void buttonCallApiForJsonData_Click(object sender, EventArgs e)
    {
        if (!treeView1.SelectedNode.IsSelected || treeView1.SelectedNode.Level != 2)
        {
            return;
        }

        var serialNumber = treeView1.SelectedNode.Text;
        var position = treeView1.SelectedNode.Parent.Text;
        var orderNumber = treeView1.SelectedNode.Parent.Parent.Text;
        var permanentAccessToken = textBox1.Text;

        try
        {
            var responseText = await _getter.GetSingleJsonAsync(permanentAccessToken, orderNumber, position, serialNumber);
            richTextBox1.Text += $"{DateTime.Now:s} | API Call successfull. Data:\n {responseText}\n";

            (var dataAsFormattedJson, var obsoleteTextVersion1, var obsoleteTextVersion2) = MyCalibrationExampleConvert.FromJson(responseText);

            richTextBox2.Text = dataAsFormattedJson;
            richTextBox3.Text = obsoleteTextVersion1;
            richTextBox4.Text = obsoleteTextVersion2;

        }
        catch (Exception exception)
        {
            richTextBox1.Text += $"{DateTime.Now:s} | Loading data from API not possible : \n {exception}\n";
        }

    }

    private void PopulateTreeView()
    {
        treeView1.BeginUpdate();

        // https://sharegpt.com/c/RfeXuP9
        var orderNumberGroups = _extractedHeaderInfos.GroupBy(info => info.OrderNumber);
        foreach (var orderNumberGroup in orderNumberGroups)
        {
            var orderNumberNode = new TreeNode(orderNumberGroup.Key);

            foreach (var orderPosition in orderNumberGroup.Select(info => info.OrderPosition).Distinct())
            {
                var orderPositionNode = new TreeNode(orderPosition);

                foreach (var serialNumber in orderNumberGroup.Where(info => info.OrderPosition == orderPosition)
                             .Select(info => info.SerialNumber))
                {
                    var serialNumberNode = new TreeNode(serialNumber);
                    orderPositionNode.Nodes.Add(serialNumberNode);
                }

                orderNumberNode.Nodes.Add(orderPositionNode);
            }

            treeView1.Nodes.Add(orderNumberNode);
        }

        treeView1.EndUpdate();
    }



    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        testApiButton.Enabled = false;
        buttonCallApiForHeaders.Enabled = false;

        // A possible permanent access key has been added. 
        richTextBox1.Text += $"{DateTime.Now:s} | New Permanent Access Token added: {textBox1.Text}\n";

        // Let's enable the buttons.
        var permanentAccessToken = textBox1.Text;
        if (permanentAccessToken != null && permanentAccessToken.Length > 200)
        {
            testApiButton.Enabled = true;
            buttonCallApiForHeaders.Enabled = true;
        }
    }




    private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
    {
        buttonCallApiForJsonData.Enabled = false;

        //Check if a SerialNumber is chosen
        if (_extractedHeaderInfos == null || _extractedHeaderInfos.Count == 0)
        {
            return;
        }

        richTextBox1.Text += $"{DateTime.Now:s} | Selected {treeView1.SelectedNode.Text}.\n";

        if (treeView1.SelectedNode.Level != 2) // Is not a grand-child (serial number)
        {
            return;
        }

        //Allow Button 3)
        buttonCallApiForJsonData.Enabled = true;

    }

    private async void button1_Click(object sender, EventArgs e)
    {
        const string basePath = @"C:/temp/";

        var customerOrderNumber = "12345678-0";
        var permanentAccessToken = textBox1.Text;

        var fileName = $"download_{customerOrderNumber}.zip";
        var filePath = Path.Combine(basePath, fileName);

        try
        {
            await _getter.GetZippedFilesWithCustomerOrderNumberAsync(permanentAccessToken, customerOrderNumber, filePath);

            int fileCountInZipFile;
            using (ZipArchive archive = ZipFile.OpenRead(filePath))
            {
                fileCountInZipFile = archive.Entries.Count;
            }

            richTextBox1.Text += $"{DateTime.Now:s} | API Call successfull. Data:\n {fileCountInZipFile} files in {Path.GetFullPath(filePath)}\n";

        }
        catch (Exception exception)
        {
            richTextBox1.Text += $"{DateTime.Now:s} | Loading data from API not possible : \n {exception}\n";
        }
    }
}