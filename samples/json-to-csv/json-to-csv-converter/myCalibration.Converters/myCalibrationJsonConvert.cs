using System.Data;
using System.Text;
using KellerSensorDataExchange;
using Newtonsoft.Json.Linq;

namespace myCalibration.Converters
{
    public static class MyCalibrationJsonConvert
    {
        const int TextAlignmentDistance = -21;
        const string Version1 = "1.0.0";

        private static KellerSensorData ConvertJsonTextToObject(string jsonText)
        {
            JObject obj = JObject.Parse(jsonText);
            string? version = obj["version"]?.ToString();
            if (version != null && !version.Equals(Version1))
            {
                throw new VersionNotFoundException(
                    $"File has not version '{Version1}'. It has version {version}. This converter library can not convert this newer version.");
            }

            KellerSensorData kellerSensorData = KellerSensorData.FromJson(jsonText);
            return kellerSensorData;
        }

        /// <summary>
        /// Converts a myCalibration-JSON-string to the measurement-CSV and the coefficients-CSV
        /// </summary>
        /// <param name="jsonText"></param>
        /// <returns>1st string = measurement-CSV-content, 2nd string = coefficients-CSV-content</returns>
        public static (string, string) JsonTextToCsvText(string jsonText)
        {
            KellerSensorData kellerSensorData = ConvertJsonTextToObject(jsonText);
            return (jsonText, "");
        }

        /// <summary>
        /// Converts a myCalibration-JSON-string to the measurement-TXT and the coefficients-TXT
        /// </summary>
        /// <param name="jsonText"></param>
        /// <returns>1st string = measurement-TXT-content, 2nd string = coefficients-TXT-content</returns>
        public static (string, string) JsonTextToTxtText(string jsonText)
        {
            KellerSensorData kellerSensorData = ConvertJsonTextToObject(jsonText);

            var coefficientsTextBuilder = CreateTextBuilderWithHeaderInfo(kellerSensorData);

            if (kellerSensorData.CompensationMethods?.MathematicalModels != null)
            {
                var mathMod = kellerSensorData.CompensationMethods.MathematicalModels.First().Value; //todo For all MM, not just the first

                void DisplayCoefficients(string physicalMeasureResultName)
                {
                    if ((bool)mathMod.Parts?.ContainsKey(physicalMeasureResultName))
                    {
                        var description  = mathMod.Parts[physicalMeasureResultName].Description;
                        var coefficients = mathMod.Parts[physicalMeasureResultName].Coefficients;
                        var inputs       = mathMod.Parts[physicalMeasureResultName].Inputs;
                        var output       = mathMod.Parts[physicalMeasureResultName].Output;

                        // coefficientsTextBuilder.AppendLine($"{$"{description}",TextAlignmentDistance}{$"temp",8}{$"Rb'",8}{$"sig",8}{$"press",8}{$"p calc",8}{$"deviat",8}");
                        // coefficientsTextBuilder.AppendLine($"{$"",TextAlignmentDistance}{$"[]",8}{$"[]",8}{$"[]",8}{$"[]",8}{$"[]",8}{$"[%Fs]",8}");
                        coefficientsTextBuilder.Append($"{$"model type",TextAlignmentDistance}{description}");
                        if (physicalMeasureResultName == "pressure")
                        {
                            coefficientsTextBuilder.Append($"; {inputs[1]}=Rb");
                        }
                        coefficientsTextBuilder.AppendLine();
                        coefficientsTextBuilder.AppendLine($"{$"",TextAlignmentDistance}{output} = a *{inputs[0]}^0 +b *{inputs[0]}^1 +c *{inputs[0]}^2 +... ");
                        coefficientsTextBuilder.AppendLine($"{$"",TextAlignmentDistance}a = a0*{inputs[1]}^0   +a1*{inputs[1]}^1   +a2*{inputs[1]}^2   +... ");
                        coefficientsTextBuilder.AppendLine($"{$"",TextAlignmentDistance}b = b0*{inputs[1]}^0   +b1*{inputs[1]}^1   +b2*{inputs[1]}^2   +... ");
                        coefficientsTextBuilder.AppendLine($"{$"",TextAlignmentDistance}c = .....");
                        coefficientsTextBuilder.AppendLine();
                        coefficientsTextBuilder.AppendLine($"{$"coefficients",TextAlignmentDistance}{description}");
                        if (physicalMeasureResultName == "pressure")
                        {
                            coefficientsTextBuilder.Append($"; {inputs[1]}=Rb");
                        }
                        coefficientsTextBuilder.AppendLine();

                        int firstPolynomeCount = coefficients.Count;
                        int SecondPolynomeCount = coefficients.First().Count;

                        coefficientsTextBuilder.AppendLine($"{$"",TextAlignmentDistance}pressure polynomial    {firstPolynomeCount-1}. degree");
                        coefficientsTextBuilder.AppendLine($"{$"",TextAlignmentDistance}temperature polynomial  {SecondPolynomeCount-1}. degree");
                        coefficientsTextBuilder.AppendLine();

                        char coefficientParameterLetter = 'a';
                        foreach (var coefficientSet in coefficients)
                        {
                            foreach (var coefficient in coefficientSet)
                            {
                                if (coefficient < 0)
                                {
                                    coefficientsTextBuilder.AppendLine(
                                        $"{$"",TextAlignmentDistance}{coefficientParameterLetter} {coefficient:E11}");
                                }
                                else
                                {
                                    // align to respect the minus sign
                                    coefficientsTextBuilder.AppendLine(
                                        $"{$"",TextAlignmentDistance}{coefficientParameterLetter}  {coefficient:E11}");
                                }
                            }

                            coefficientsTextBuilder.AppendLine();
                            coefficientParameterLetter++;
                        }
                    }
                    coefficientsTextBuilder.AppendLine();
                }

                DisplayCoefficients("pressure");
                DisplayCoefficients("temperature");
                DisplayCoefficients("supply"); //todo: Used?
            }


            var measurementsTextBuilder = CreateTextBuilderWithHeaderInfo(kellerSensorData);
            if (kellerSensorData.Measurements != null && kellerSensorData.Measurements.Count>0)
            {
                List<Measurement> testRunMeasurements = kellerSensorData.Measurements;

                void DisplayMeasurements(string physicalMeasureResultName)
                {
                    List<double> allTemperatureValues = new List<double>();
                    List<double> allPressureValues    = new List<double>();
                    foreach (var meas in testRunMeasurements)
                    {
                        var tempValue  = meas.EnvironmentTarget["temperature"].Magnitude;
                        var pressValue = meas.EnvironmentTarget["pressure"].Magnitude;
                        if (!allTemperatureValues.Contains(tempValue))
                        {
                            allTemperatureValues.Add(tempValue);
                        }
                        if (!allPressureValues.Contains(pressValue))
                        {
                            allPressureValues.Add(pressValue);
                        }
                    }//todo: Take all with LINQ and distinct and order

                    //int firstPolynomeCount = coefficients.Count;
                    //int SecondPolynomeCount = coefficients.First().Count;
                    Measurement[,] measurementsOrderedByPressureAndTemperature = new Measurement[allPressureValues.Count, allTemperatureValues.Count];

                    var x = allPressureValues.OrderBy(_ => _).ToArray();
                    var y = allTemperatureValues.OrderBy(_ => _).ToArray();

                    for (int i=0; i < allPressureValues.Count; i++)
                    {
                        for (int j = 0; j < allTemperatureValues.Count; j++)
                        {
                            measurementsOrderedByPressureAndTemperature[i, j] = testRunMeasurements
                                .SingleOrDefault(_ => _.EnvironmentTarget["pressure"].Magnitude == x[i] &&
                                                      _.EnvironmentTarget["temperature"].Magnitude == y[i]);
                        }
                    }

                    var xwww = (Measurement)measurementsOrderedByPressureAndTemperature[0, 0];
                    /*
                    if ((bool)testRunMeasurements.ContainsKey(physicalMeasureResultName))
                    {
                        var description = testRunMeasurements.Parts[physicalMeasureResultName].Description;
                        var coefficients = testRunMeasurements.Parts[physicalMeasureResultName].Coefficients;
                        var inputs = testRunMeasurements.Parts[physicalMeasureResultName].Inputs;
                        var output = testRunMeasurements.Parts[physicalMeasureResultName].Output;

                        // measurementsTextBuilder.AppendLine($"{$"{description}",TextAlignmentDistance}{$"temp",8}{$"Rb'",8}{$"sig",8}{$"press",8}{$"p calc",8}{$"deviat",8}");
                        // measurementsTextBuilder.AppendLine($"{$"",TextAlignmentDistance}{$"[]",8}{$"[]",8}{$"[]",8}{$"[]",8}{$"[]",8}{$"[%Fs]",8}");
                        measurementsTextBuilder.Append($"{$"model type",TextAlignmentDistance}{description}");
                        if (physicalMeasureResultName == "pressure")
                        {
                            measurementsTextBuilder.Append($"; {inputs[1]}=Rb");
                        }
                        measurementsTextBuilder.AppendLine();
                        measurementsTextBuilder.AppendLine($"{$"",TextAlignmentDistance}{output} = a *{inputs[0]}^0 +b *{inputs[0]}^1 +c *{inputs[0]}^2 +... ");
                        measurementsTextBuilder.AppendLine($"{$"",TextAlignmentDistance}a = a0*{inputs[1]}^0   +a1*{inputs[1]}^1   +a2*{inputs[1]}^2   +... ");
                        measurementsTextBuilder.AppendLine($"{$"",TextAlignmentDistance}b = b0*{inputs[1]}^0   +b1*{inputs[1]}^1   +b2*{inputs[1]}^2   +... ");
                        measurementsTextBuilder.AppendLine($"{$"",TextAlignmentDistance}c = .....");
                        measurementsTextBuilder.AppendLine();
                        measurementsTextBuilder.AppendLine($"{$"coefficients",TextAlignmentDistance}{description}");
                        if (physicalMeasureResultName == "pressure")
                        {
                            measurementsTextBuilder.Append($"; {inputs[1]}=Rb");
                        }
                        measurementsTextBuilder.AppendLine();
                        measurementsTextBuilder.AppendLine($"{$"",TextAlignmentDistance}pressure polynomial    ?. degree");
                        measurementsTextBuilder.AppendLine($"{$"",TextAlignmentDistance}temperature polynomial ?. degree");
                        measurementsTextBuilder.AppendLine();

                        char coefficientParameterLetter = 'a';
                        foreach (var coefficientSet in coefficients)
                        {
                            foreach (var coefficient in coefficientSet)
                            {
                                if (coefficient < 0)
                                {
                                    measurementsTextBuilder.AppendLine(
                                        $"{$"",TextAlignmentDistance}{coefficientParameterLetter} {coefficient:E11}");
                                }
                                else
                                {
                                    // align to respect the minus sign
                                    measurementsTextBuilder.AppendLine(
                                        $"{$"",TextAlignmentDistance}{coefficientParameterLetter}  {coefficient:E11}");
                                }
                            }

                            measurementsTextBuilder.AppendLine();
                            coefficientParameterLetter++;
                        }
                    }
                    measurementsTextBuilder.AppendLine();
                    
                    */
                }


                DisplayMeasurements("pressure");
                DisplayMeasurements("temperature");
                DisplayMeasurements("supply"); //todo: Used?

            }


            var measurementsText = measurementsTextBuilder.ToString();
            var coefficientsText = coefficientsTextBuilder.ToString();
            return (measurementsText, coefficientsText);

        }

        private static StringBuilder CreateTextBuilderWithHeaderInfo(KellerSensorData kellerSensorData)
        {
            var textBuilder = new StringBuilder();

            textBuilder.AppendLine("mathematical model");

            var typeText = $"{kellerSensorData.Header.PressureType.ToString().ToUpper()}-{kellerSensorData.Header.ProductSeries} / {kellerSensorData.Header.CompensatedPressureRange.Max}{kellerSensorData.Header.CompensatedPressureRange.Unit.ToString().ToUpper()}";
            var mathModName = "";
            if (kellerSensorData.CompensationMethods?.MathematicalModels != null)
            {
                var d = kellerSensorData.CompensationMethods.MathematicalModels.Keys.ToArray();
                if (d.Length > 0)
                {
                    mathModName = String.Join("/", d);
                }
            }

            textBuilder.AppendLine($"{"type",TextAlignmentDistance}{typeText} {mathModName} / ██-█████-██"); //todo: what is 00-00000-00?

            textBuilder.AppendLine($"{"sn",TextAlignmentDistance}{kellerSensorData.Header.SerialNumber}");

            var temperatureRange = $"{kellerSensorData.Header.CompensatedTemperatureRange.Min:F1} .. {kellerSensorData.Header.CompensatedTemperatureRange.Max:F1}{Units.ToString(kellerSensorData.Header.CompensatedTemperatureRange.Unit).ToUpper()}";
            textBuilder.AppendLine($"{"temperature range",TextAlignmentDistance}{temperatureRange}");

            //todo: decide if 'rel' or 'abs' depending on sensor type
            var pressureRange = $"{kellerSensorData.Header.CompensatedPressureRange.Min:F1} .. {kellerSensorData.Header.CompensatedPressureRange.Max:F1}{Units.ToString(kellerSensorData.Header.CompensatedPressureRange.Unit)}";
            textBuilder.AppendLine($"{"pressure range",TextAlignmentDistance}{pressureRange} ███");

            textBuilder.AppendLine();

            textBuilder.AppendLine($"{"date",TextAlignmentDistance}{kellerSensorData.Header.CreationDate:dd.MM.yy}");
            if (kellerSensorData.Header.ElectricSupply.Magnitude.HasValue)
            {
                textBuilder.AppendLine($"{"excitation",TextAlignmentDistance}{kellerSensorData.Header.ElectricSupply.Magnitude}{Units.ToString(kellerSensorData.Header.ElectricSupply.Unit)}");
            }
            else if (kellerSensorData.Header.ElectricSupply.Min.HasValue)
            {
                var excitationRange = $"{kellerSensorData.Header.ElectricSupply.Min:F1} .. {kellerSensorData.Header.ElectricSupply.Min:F1}{Units.ToString(kellerSensorData.Header.ElectricSupply.Unit)}";
                textBuilder.AppendLine($"{"excitation",TextAlignmentDistance}{excitationRange}");
            }

            textBuilder.AppendLine();

            textBuilder.AppendLine($"{"Version",TextAlignmentDistance}████████"); //todo: replace unknown with something known
            textBuilder.AppendLine("-----------------------------------------------------------------------");
            textBuilder.AppendLine();
            return textBuilder;
        }


        /// <summary>
        /// Converts a myCalibration-JSON-string to the text contents of the measurement-CSV, the coefficients-CSV, the measurement-TXT, the coefficients-TXT
        /// </summary>
        /// <param name="jsonText"></param>
        /// <returns>CalibrationDataAsTexts that contains the measurement-CSV, the coefficients-CSV, the measurement-TXT, the coefficients-TXT</returns>
        public static CalibrationDataAsTexts JsonTextToAll(string jsonText)
        {
            var calibrationDataAsTexts = new CalibrationDataAsTexts
            {
                InputJsonText = jsonText
            };
            KellerSensorDataExchange.KellerSensorData kellerSensorData = KellerSensorDataExchange.KellerSensorData.FromJson(jsonText);

            StringBuilder stringBuilder = new StringBuilder();

            return calibrationDataAsTexts;
        }


    }

    internal static class Units
    {
        public static string ToString(PhysicalUnit value)
        {
            switch (value)
            {
                case PhysicalUnit.Empty:
                    return "";
                case PhysicalUnit.Fs:
                    return "%FS";
                case PhysicalUnit.A:
                    return "A";
                case PhysicalUnit.K:
                    return "K";
                case PhysicalUnit.MOhm:
                    return "MOhm";
                case PhysicalUnit.MPa:
                    return "MPa";
                case PhysicalUnit.Ohm:
                    return "Ohm";
                case PhysicalUnit.Pa:
                    return "Pa";
                case PhysicalUnit.Torr:
                    return "Torr";
                case PhysicalUnit.V:
                    return "V";
                case PhysicalUnit.VDC:
                    return "VDC";
                case PhysicalUnit.Atm:
                    return "atm";
                case PhysicalUnit.Bar:
                    return "bar";
                case PhysicalUnit.CmH2O:
                    return "cmH2O";
                case PhysicalUnit.CmHg:
                    return "cmHg";
                case PhysicalUnit.FtH2O:
                    return "ftH2O";
                case PhysicalUnit.HPa:
                    return "hPa";
                case PhysicalUnit.InH2O:
                    return "inH2O";
                case PhysicalUnit.InHg:
                    return "inHg";
                case PhysicalUnit.KNM2:
                    return "kN/m2";
                case PhysicalUnit.KOhm:
                    return "kOhm";
                case PhysicalUnit.KPa:
                    return "kPa";
                case PhysicalUnit.KpCm2:
                    return "kp/cm2";
                case PhysicalUnit.LbfFt2:
                    return "lbf/ft2";
                case PhysicalUnit.MA:
                    return "mA";
                case PhysicalUnit.MH2O:
                    return "mH2O";
                case PhysicalUnit.MV:
                    return "mV";
                case PhysicalUnit.MVV:
                    return "mV/V";
                case PhysicalUnit.MVMA:
                    return "mV/mA";
                case PhysicalUnit.Mbar:
                    return "mbar";
                case PhysicalUnit.MmH2O:
                    return "mmH2O";
                case PhysicalUnit.MmHg:
                    return "mmHg";
                case PhysicalUnit.Psi:
                    return "psi";
                case PhysicalUnit.C:
                    return "°C";
            }
            throw new Exception("Cannot marshal type PhysicalUnit");
        }
    }

    public class CalibrationDataAsTexts
    {
        public string InputJsonText { get; set; }
        public string MeasurementsTxtText { get; set; }
        public string CoefficientsTxtText { get; set; }
        public string MeasurementsCSVText { get; set; }
        public string CoefficientsCSVText { get; set; }
    }
}