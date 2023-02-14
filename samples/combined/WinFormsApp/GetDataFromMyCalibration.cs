using System.Diagnostics;

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


    public async Task<string> GetDataWithFilter(string permanentAccessToken, List<string> filters)
    {
        using var client = new HttpClient();
        var baseUrl = "https://mycalibrationapi.azurewebsites.net/v1/CalibrationData";

        // Example Query which 
        //  - filters only calibration data of product type "17SHX"
        //  - filters only calibration data from the year 2022 or older (order dispatch date)
        // https://mycalibration.github.io/
        var filterParameters = "?DateFilterType=greaterThan&Date=2022-06-01";

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
}