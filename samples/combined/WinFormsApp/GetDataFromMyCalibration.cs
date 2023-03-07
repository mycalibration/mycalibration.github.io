using System.Diagnostics;
using System.IO;
using System.Net;

namespace WinFormsApp;

internal class GetDataFromMyCalibration
{

    public async Task<string> GetCountAsync(string permanentAccessToken)
    {
        using var client = new HttpClient();
        var url = "https://mycalibrationapi.azurewebsites.net/v1/CalibrationData/Count";
        try
        {
            client.DefaultRequestHeaders.Add("userOid", permanentAccessToken);
            string responseBody = await client.GetStringAsync(url);

            Debug.WriteLine(responseBody);
            return responseBody;
        }
        catch (HttpRequestException e)
        {
            Debug.WriteLine($@"Exception Caught! Message :{e.Message}");
            return $@"Exception Caught! Message :{e.Message}";
        }
    }

    public async Task<string> GetHeaderDataAsync(string permanentAccessToken)
    {
        using var client = new HttpClient();
        var url = "https://mycalibrationapi.azurewebsites.net/v1/CalibrationData/Headers";
        try
        {
            client.DefaultRequestHeaders.Add("userOid", permanentAccessToken);
            string responseBody = await client.GetStringAsync(url);

            Debug.WriteLine(responseBody);
            return responseBody;
        }
        catch (HttpRequestException e)
        {
            Debug.WriteLine($@"Exception Caught! Message :{e.Message}");
            return $@"Exception Caught! Message :{e.Message}";
        }
    }


    public async Task<string> GetSingleJsonAsync(string permanentAccessToken, string orderNumber, string position, string serialNumber)
    {
        using var client = new HttpClient();
        var baseUrl = "https://mycalibrationapi.azurewebsites.net/v1/CalibrationData";

        var filterParameters = $"?OrderNumbers={orderNumber}&OrderPositions={position}&SerialNumberSearchText={serialNumber}";
        // Side note: Theoretically, this might replies with multiple calibration data sets because it searches for the given serial number text.
        // This means a serialNumber of "12" might target a sensor with serial number "12" but also "120" or "121" ..

        var url = baseUrl + filterParameters;

        try
        {
            client.DefaultRequestHeaders.Add("userOid", permanentAccessToken);
            string responseBody = await client.GetStringAsync(url);

            Debug.WriteLine(responseBody);
            return responseBody;
        }
        catch (HttpRequestException e)
        {
            Debug.WriteLine($@"Exception Caught! Message :{e.Message}");
            return $@"Exception Caught! Message :{e.Message}";
        }
    }

    public async Task<bool> GetZippedFilesWithCustomerOrderNumberAsync(string permanentAccessToken, string customerOrderNumber, string filePath)
    {
        var baseUrl = "https://mycalibrationapi.azurewebsites.net/v1/CalibrationData";
        var filterParameters = $"/Export?fileType=3&CustomerOrderNumberSearchText={customerOrderNumber}";
        // Side note: This is a search text. Example: Searching for "order-123" gives back all orders with numbers that looks like this "order-123-01" and "order-123-02" and "my-order-123"
        var url = baseUrl + filterParameters;

        using var client = new HttpClient();
        client.DefaultRequestHeaders.Add("userOid", permanentAccessToken);

        try
        {
            await using var stream = await client.GetStreamAsync(url);
            await using var file = File.OpenWrite(filePath);
            await stream.CopyToAsync(file);
            return true; //success
        }
        catch (HttpRequestException e)
        {
            Debug.WriteLine($@"Exception Caught! Message :{e.Message}");
            throw;
        }
    }
}