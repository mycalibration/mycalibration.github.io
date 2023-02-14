using Newtonsoft.Json;
using KellerSensorDataExchange;

namespace WinFormsApp
{
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
                    //Does not work
                    var headers2 = JsonConvert.DeserializeObject<List<IO.Swagger.Model.Header>>(responseText, KellerSensorDataExchange.Converter.Settings);
                    
                    var headers = JsonConvert.DeserializeObject<List<object>>(responseText);

                    if (headers != null && headers.Count > 0)
                    {
                        var sampleHeaderJsonData = headers.First();
                        richTextBox1.Text += $"{DateTime.Now:s} | FIRST HEADER META INFO: \n{sampleHeaderJsonData}\n";
                    }
                }
                catch (Exception exception)
                {
                    richTextBox1.Text += $"{DateTime.Now:s} | Deserialization is not possible : \n {exception}\n";
                }
            }

        }

        private void buttonCallApiForJsonData_Click(object sender, EventArgs e)
        {
             //
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
}