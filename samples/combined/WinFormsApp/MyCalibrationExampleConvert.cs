using KellerSensorDataExchange;
using Newtonsoft.Json;
using myCalibration.Converters;

namespace WinFormsApp
{
    // Uses nuget library 'myCalibration.Converters' to convert the data
    internal class MyCalibrationExampleConvert
    {
        public static void FromJson(string jsonText)
        {
            List<KellerSensorData> calibrationData;
            try
            {
                calibrationData = JsonConvert.DeserializeObject<List<KellerSensorData>>(jsonText, Converter.Settings);
            }
            catch (Exception e)
            {
                var message = $"Could not parse data with content {Environment.NewLine}{jsonText}";
                Console.WriteLine(message + " - " + e);
                return;
            }

            if (calibrationData == null)
            {
                var message = $"Could not parse data with content {Environment.NewLine}{jsonText}";
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

                // It is also possible to revert this to the JSON content
                string singleCalibrationDataAsJsonText = sampleData.ToJson();
                
                
                // And, of course to convert to the obsolete Text version (TestRun.txt)
                (string singleObsoleteTextVersion1, string singleObsoleteTextVersion2) = MyCalibrationJsonConvert.JsonTextToTxtText(singleCalibrationDataAsJsonText);

                Console.WriteLine(singleObsoleteTextVersion1 + Environment.NewLine);
                Console.WriteLine(singleObsoleteTextVersion2 + Environment.NewLine);
            }
        }
    }
}
