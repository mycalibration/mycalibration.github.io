using System.Data;
using KellerSensorDataExchange;

namespace myCalibration.Converters;

public static class ConvertJsonToObject
{
    private const string Version1 = "1.0.0";

    public static KellerSensorData Convert(string jsonText)
    {
        var obj = Newtonsoft.Json.Linq.JObject.Parse(jsonText);
        string? version = obj["version"]?.ToString();
        if (version != null && !version.Equals(Version1))
        {
            throw new VersionNotFoundException(
                $"File has not version '{Version1}'. It has version {version}. This converter library can not convert this newer version.");
        }

        KellerSensorData kellerSensorData = KellerSensorData.FromJson(jsonText);
        return kellerSensorData;
    }
}
