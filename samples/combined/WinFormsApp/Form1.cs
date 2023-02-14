using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WinFormsApp.Dto;

namespace WinFormsApp;

public partial class Form1 : Form
{
    private readonly GetDataFromMyCalibration _getter;

    public Form1()
    {
        InitializeComponent();
        _getter = new GetDataFromMyCalibration();
        richTextBox1.Text += $"{DateTime.Now:s} | Started at {DateTime.Now:R}\n";
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
                var extractedHeaderInfos = new List<ExtractedHeaderInfo>();
                foreach (JObject header in headers)
                {
                    var extractedHeaderInfo = new ExtractedHeaderInfo
                    {
                        OrderNumber   = header["orderNumber"].ToString(),
                        OrderPosition = header["orderPosition"].ToString(),
                        SerialNumber  = header["serialNumber"].ToString()
                    };
                    extractedHeaderInfos.Add(extractedHeaderInfo);
                }

                treeView1.BeginUpdate();

                // https://sharegpt.com/c/RfeXuP9
                var orderNumberGroups = extractedHeaderInfos.GroupBy(info => info.OrderNumber);
                foreach (var orderNumberGroup in orderNumberGroups)
                {
                    var orderNumberNode = new TreeNode(orderNumberGroup.Key);

                    foreach (var orderPosition in orderNumberGroup.Select(info => info.OrderPosition).Distinct())
                    {
                        var orderPositionNode = new TreeNode(orderPosition);

                        foreach (var serialNumber in orderNumberGroup.Where(info => info.OrderPosition == orderPosition).Select(info => info.SerialNumber))
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
            catch (Exception exception)
            {
                richTextBox1.Text += $"{DateTime.Now:s} | Deserialization is not possible : \n {exception}\n";
            }
        }

    }

    private void buttonCallApiForJsonData_Click(object sender, EventArgs e)
    {
        // MyCalibrationExampleConvert.FromJson();
    }

    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        // A possible permanent access key has been added. 
        // Let's enable the buttons.
        richTextBox1.Text += $"{DateTime.Now:s} | New Permanent Access Token added: {textBox1.Text}\n";

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

}