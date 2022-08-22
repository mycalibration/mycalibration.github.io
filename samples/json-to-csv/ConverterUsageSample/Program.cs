// To use the converter it is necessary to have: 
//    - .NET6
//    - the converter library (myCalibration.Converters.dll)
//    - Newtonsoft.Json nuget v13.0.1 https://www.nuget.org/packages/Newtonsoft.Json/


namespace ConverterUsageSample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var jsonText = File.ReadAllText("sample-data/PAA-9L_123021.1804_43345.json");

            KellerSensorDataExchange.KellerSensorData dataStoredInJsonFile = myCalibration.Converters.ConvertJsonToObject.Convert(jsonText);
            Console.WriteLine("This is the data from a " + dataStoredInJsonFile.Header.ProductType + " with serial number " + dataStoredInJsonFile.Header.SerialNumber + Environment.NewLine);

            myCalibration.Converters.data_model.CalibrationDataAsTexts convertedData = myCalibration.Converters.MyCalibrationJsonConvert.JsonTextToAll(jsonText, separator:',');

            Console.WriteLine("The measurement data (Testrun) : " + Environment.NewLine + convertedData.MeasurementsTxtText + Environment.NewLine);
            Console.WriteLine("The MathMod coefficient data   : " + Environment.NewLine + convertedData.CoefficientsTxtText + Environment.NewLine);

            Console.WriteLine("The measurement data (Testrun) as CSV : " + Environment.NewLine + convertedData.MeasurementsCsvText + Environment.NewLine);
            Console.WriteLine("The MathMod coefficient data   as CSV : " + Environment.NewLine + convertedData.CoefficientsCsvText + Environment.NewLine);
        }
    }
}