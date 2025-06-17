using System;
using System.Collections.Generic;
using System.Net;
using System.IO;
using System.Linq;
using KellerSensorDataExchange;
using Newtonsoft.Json;

namespace myCalibrationAPISimpleSample
{
  internal class Program
  {
    private const string PermanentAccessToken = "bqCrDAQABACUKUpXST6JCEgPeStCyeHhfmNz/+yE29F+VbVeKl7eU....  ASK engineering@keller-pressure.com for your permanent acces token or look into the profile settings at https://mycalibration.azurewebsites.net/";
    
    static void Main(string[] args)
    {
      var baseUrl       = "https://mycalibrationapi.azurewebsites.net/v1/CalibrationData";
      var baseUrlExport = "https://mycalibrationapi.azurewebsites.net/v1/CalibrationData/Export";
      var baseUrlCount  = "https://mycalibrationapi.azurewebsites.net/v1/CalibrationData/Count";


      // Example Query which 
      //  - filters only calibration data of product type "17SHX"
      //  - filters only calibration data from the year 2022 or older (order dispatch date)
      // https://mycalibration.github.io/
      var filterParameters = "?DateFilterType=greaterThan&Date=2022-04-01&ProductSeries=17SHX";
      //filterParameters = "?ProductSeries=9L"; //9L often have MathMod data

      // Generally, try to avoid loading more than 1000 calibration data as the query gets quite slow due to the serialization on the backend side. Exporting to a zip is faster (no serialization).
      // If unsure there is the possibility to quickly check for the amount of calibration data available with the /Count endpoint:
      // var httpRequest = (HttpWebRequest)WebRequest.Create($"{baseUrlCount}{filterParameters}"); 

      var url = baseUrl + filterParameters;

      var httpRequest = (HttpWebRequest)WebRequest.Create(url);

      // Add the permanent access token to the header with the userOid key
      httpRequest.Headers["userOid"] = PermanentAccessToken;

      // Use httpRequest.Method = "PUT"; when using PUT instead of GET

      // C# alternatives to HttpWebRequest:
      // HttpClient : HttpClient.DefaultRequestHeaders.Add("userOid", PermanentAccessToken);
      // WebClient  : WebClient.Headers.Add("userOid", PermanentAccessToken);

      string resultText;
      HttpWebResponse httpResponse;
      try
      {
        httpResponse = (HttpWebResponse)httpRequest.GetResponse();
      }
      catch (System.Net.WebException e)
      {
        using WebResponse response = e.Response;
        httpResponse = (HttpWebResponse)response;
        Console.WriteLine("Error code: {0}", httpResponse.StatusCode);
        Console.WriteLine("Request is not successful. Please check your permanent access token or ask engineering@keller-pressure.com");
        return;
      }

      using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
      {
        resultText = streamReader.ReadToEnd();
      }

      List<KellerSensorData> calibrationData;
      try
      {
        calibrationData = JsonConvert.DeserializeObject<List<KellerSensorData>>(resultText, Converter.Settings);
      }
      catch (Exception e)
      {
        var message = $"Could not parse data with content {Environment.NewLine}{resultText}";
        Console.WriteLine(message + " - " + e);
        return;
      }

      if (calibrationData == null)
      {
        var message = $"Could not parse data with content {Environment.NewLine}{resultText}";
        Console.WriteLine(message);
        return;
      }

      Console.WriteLine($"Loaded calibration data from {calibrationData.Count} sensors.");
      if (calibrationData.Count > 0)
      {
        var sampleData = calibrationData.First();
        Console.WriteLine($"The first sensor has the following calibration data: ");
        Console.WriteLine($" |");
        Console.WriteLine($" |- Order Number  : {sampleData.Header.OrderNumber}");
        Console.WriteLine($" |- Dispatch Date : {sampleData.Header.OrderTargetDispatchDate:d}");
        Console.WriteLine($" |- Position      : {sampleData.Header.OrderPosition}");
        if (!string.IsNullOrEmpty(sampleData.Header.CustomerProductType))
        {
          Console.WriteLine($" |- Customer Product Type : {sampleData.Header.CustomerProductType}");
        }
        Console.WriteLine($" |- Product Series: {sampleData.Header.ProductSeries}");
        Console.WriteLine($" |- Product Number: {sampleData.Header.ProductNumber}");
        Console.WriteLine($" |- Serial Number : {sampleData.Header.SerialNumber}");
        Console.WriteLine($" |- Calibrated    : From {sampleData.Header.CompensatedPressureRange.Min:F}..{sampleData.Header.CompensatedPressureRange.Max:F} {sampleData.Header.CompensatedPressureRange.Unit}");
        Console.WriteLine($" |- Calibrated    : From {sampleData.Header.CompensatedTemperatureRange.Min:F}..{sampleData.Header.CompensatedTemperatureRange.Max:F} {sampleData.Header.CompensatedTemperatureRange.Unit}");

        if (sampleData.CompensationMethods?.MathematicalModels != null)
        {
          Console.Write($" |- MathMods      : {sampleData.CompensationMethods.MathematicalModels.Count} MathMods stored");
          Console.WriteLine(sampleData.CompensationMethods.MathematicalModels.Count > 0
              ? $": {string.Join(" & ", sampleData.CompensationMethods.MathematicalModels.Keys)}"
              : ".");
          Console.WriteLine($"{sampleData.CompensationMethods.MathematicalModels.Keys.First()} data looks like this:");
          Console.WriteLine($"{JsonConvert.SerializeObject(sampleData.CompensationMethods.MathematicalModels.Values.First().Parts, Formatting.Indented)}");

          // JSON data can also be extracted with JObject or JArray from Json.NET:
          // var jsonArray = JArray.Parse(resultText);
          // var coefficients = jsonArray.First()["compensationMethods"]?["mathematicalModels"]?["MM0123"]?["parts"]?["pressure"]?["coefficients"]?.ToList();
        }
        else
        {
          Console.WriteLine($" |- No MathMod data stored");
        }

        if (sampleData.Measurements?.First()?.Compensated?.CompensationCircuitOutputs != null)
        {
          Console.WriteLine($" |- {sampleData.Measurements.Count} Calibration measure points with the first {sampleData.Measurements.Count} starting with measurement:");
          Console.WriteLine($"{JsonConvert.SerializeObject(sampleData.Measurements.First().Compensated.CompensationCircuitOutputs, Formatting.Indented)}");
        }
        else
        {
          Console.Write($" |- No calibration measure points stored.");
        }
      }

      Console.ReadLine();

      /*
       The output might look like this:

Loaded calibration data from 20 sensors.
The first sensor has the following calibration data:
|
|- Order Number  : 9990994
|- Dispatch Date : 01.04.2022
|- Position      : 1
|- Product Series: 17SHX
|- Product Number: 123856.1117
|- Serial Number : 11143
|- Calibrated    : From 0.00..1.00 Bar
|- Calibrated    : From 15.00..70.00 C
|- MathMods      : 0 MathMod data stored 
|- 36 Calibration measure points with the first 36 starting with measurement:
{
"P1": {
"measuredValue": {
"magnitude": 0.02999749,
"unit": 3
},
"nominalValue": {
"magnitude": 0.02999921,
"unit": 3
}
},
"TOB1": {
"measuredValue": {
"magnitude": 14.62817,
"unit": 4
},
"nominalValue": {
"magnitude": 14.6466,
"unit": 4
}
}
}

or

Loaded calibration data from 154 sensors.
The first sensor has the following calibration data:
|
|- Order Number  : 9990266
|- Dispatch Date : 02.06.2022
|- Position      : 3
|- Customer Product Type : 123021-1804 Rev.AA
|- Product Series: 9L
|- Product Number: 123021.1804
|- Serial Number : 98179
|- Calibrated    : From 0.00..0.35 Bar
|- Calibrated    : From -10.00..80.00 C
|- MathMods      : 1 MathMods stored: MM0123
MM0123 data looks like this:
{
"pressure": {
"inputs": [
"Sig",
"R"
],
"output": "P",
"description": "P = f(Sig,R)",
"coefficients": [
[
  4.35267481863,
  -0.00444626982344,
  1.68299038242E-06,
  -2.85113112289E-10,
  1.80922267473E-14
],
[
  -0.15970215925,
  0.000172303971364,
  -6.6444421343E-08,
  1.1383121852E-11,
  -7.32345565979E-16
],
[
  0.000119143747343,
  -1.00485268512E-07,
  3.07989703307E-11,
  -3.90376291468E-15,
  1.57898526225E-19
]
]
},
"temperature": {
"inputs": [
"R",
"Sig"
],
"output": "T",
"description": "T = f(R,Sig)",
"coefficients": [
[
  -7616.4070442,
  -14.5612821123,
  0.154221427499
],
[
  7.53210189702,
  0.0169770613583,
  -0.000169823124228
],
[
  -0.0028606873499,
  -7.31522450745E-06,
  6.98746721308E-08
],
[
  4.92715023042E-07,
  1.38920525812E-09,
  -1.27393622862E-11
],
[
  -3.20352705241E-11,
  -9.80919206768E-14,
  8.68653819205E-16
]
]
}
}
|- No calibration measure points stored.

*/
    }
  }
}
