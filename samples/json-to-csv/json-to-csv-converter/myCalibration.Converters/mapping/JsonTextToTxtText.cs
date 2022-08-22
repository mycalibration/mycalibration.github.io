using System.Text;
using KellerSensorDataExchange;

namespace myCalibration.Converters.Mapping;

public static class JsonTextToTxtText
{
    private const int TextAlignmentDistanceHeader = -21;
    private const int TextAlignmentDistance = -20;

    /// <summary>
    /// Converts a myCalibration-JSON-string to the measurement-CSV and the coefficients-CSV
    /// </summary>
    /// <param name="jsonText"></param>
    /// <returns>1st string = measurement-CSV-content, 2nd string = coefficients-CSV-content</returns>
    public static (string, string) Convert(string jsonText)
    {
        KellerSensorData kellerSensorData = ConvertJsonToObject.Convert(jsonText);
        return Convert(kellerSensorData);
    }


    /// <summary>
    /// Converts a myCalibration-JSON-string to the measurement-TXT and the coefficients-TXT
    /// </summary>
    /// <param name="kellerSensorData"></param>
    /// <returns>1st string = measurement-TXT-content, 2nd string = coefficients-TXT-content</returns>
    public static (string, string) Convert(KellerSensorData kellerSensorData)
    {
        var coefficientsTextBuilder = CreateTextBuilderWithHeaderInfo(kellerSensorData);

        if (kellerSensorData.CompensationMethods?.MathematicalModels != null)
        {
            var mathMod = kellerSensorData.CompensationMethods.MathematicalModels.First().Value; //todo: For all MM, not just the first

            DisplayCoefficients("bridgeResistance");
            DisplayCoefficients("pressure");
            DisplayCoefficients("temperature");

            void DisplayCoefficients(string physicalMeasureResultName)
            {
                if (mathMod.Parts.ContainsKey(physicalMeasureResultName))
                {
                    var modelTypeText = TryExtractModelTypeText(kellerSensorData, physicalMeasureResultName);
                    coefficientsTextBuilder.AppendLine($"{modelTypeText}");
                    coefficientsTextBuilder.AppendLine();

                    var description = TryExtractModelTypeFormula(kellerSensorData, physicalMeasureResultName);
                    var coefficients = mathMod.Parts[physicalMeasureResultName].Coefficients;
                    int firstPolynomialCount = coefficients.Count - 1;
                    coefficientsTextBuilder.AppendLine($"{$"coefficients",TextAlignmentDistance}{description}");
                    coefficientsTextBuilder.AppendLine($"{$"",TextAlignmentDistance}pressure polynomial    {firstPolynomialCount}. degree");
                    int secondPolynomialCount = coefficients.First().Count - 1;
                    if (secondPolynomialCount > 0)
                    {
                        coefficientsTextBuilder.AppendLine($"{$"",TextAlignmentDistance}temperature polynomial {secondPolynomialCount}. degree");
                    }
                    coefficientsTextBuilder.AppendLine();

                    char coefficientParameterLetter = 'a';
                    foreach (var coefficientSet in coefficients)
                    {
                        for (var i = 0; i < coefficientSet.Count; i++)
                        {
                            var coefficient = coefficientSet[i];
                            coefficientsTextBuilder.Append($"{$"",TextAlignmentDistance}{coefficientParameterLetter}");
                            if (secondPolynomialCount > 0)
                            {
                                coefficientsTextBuilder.Append($"{i}");
                            }
                            coefficientsTextBuilder.AppendLine($"{$"{coefficient:E11}",20}");

                        }

                        coefficientsTextBuilder.AppendLine();
                        coefficientParameterLetter++; // switch to the next letter in the alphabet
                    }
                    coefficientsTextBuilder.AppendLine();
                }
            }
        }
        else
        {
            coefficientsTextBuilder.AppendLine();
            coefficientsTextBuilder.AppendLine("This JSON contains no MathMod calibration data nor reported measurements errors.");
        }


        var measurementsTextBuilder = CreateTextBuilderWithHeaderInfo(kellerSensorData);
        if (kellerSensorData.Measurements != null && kellerSensorData.Measurements.Count > 0 && kellerSensorData.Measurements.All(_ => _.Raw != null))
        {
            List<Measurement> testRunMeasurements = kellerSensorData.Measurements;

            double[] allPossibleTemperatureValuesOrdered = testRunMeasurements.Select(_ => _.EnvironmentTarget["temperature"].Magnitude).Distinct().OrderBy(_ => _).ToArray();
            double[] allPossiblePressureValuesOrdered = testRunMeasurements.Select(_ => _.EnvironmentTarget["pressure"].Magnitude).Distinct().OrderBy(_ => _).ToArray();

            Measurement[,] measurementsOrderedByPressureAndTemperature = new Measurement[allPossiblePressureValuesOrdered.Length, allPossibleTemperatureValuesOrdered.Length];

            for (var p = 0; p < allPossiblePressureValuesOrdered.Length; p++)
            {
                for (var t = 0; t < allPossibleTemperatureValuesOrdered.Length; t++)
                {
                    measurementsOrderedByPressureAndTemperature[p, t] = testRunMeasurements
                        .Single(_ => _.EnvironmentTarget["pressure"].Magnitude == allPossiblePressureValuesOrdered[p] &&
                                     _.EnvironmentTarget["temperature"].Magnitude == allPossibleTemperatureValuesOrdered[t]);
                }
            }

            var description = TryExtractModelTypeFormula(kellerSensorData, "pressure");

            var sample = measurementsOrderedByPressureAndTemperature[0, 0];

            var unit1 = Units.ToString(sample.EnvironmentTarget["temperature"].Unit); // Should be '°C'
            var unit2 = Units.ToString(sample.Raw["bridgeResistance"].Unit); // Should be 'Ohm'
            var unit3 = Units.ToString(sample.Raw["signal"].Unit); // Should be 'mV'
            var unit4 = Units.ToString(sample.EnvironmentTarget["pressure"].Unit); // Should be 'bar'
            var unit5 = "%Fs";

            measurementsTextBuilder.AppendLine($"{$"{description}",TextAlignmentDistanceHeader}{$"temp",0}{$"Rb'",10}{$"sig",10}{$"press",10}{$"p calc",10}{$"deviat",10}");
            measurementsTextBuilder.AppendLine($"{$"",TextAlignmentDistanceHeader}{$"[{unit1}]",0}{$"[{unit2}]",10}{$"[{unit3}]",10}{$"[{unit4}]",10}{$"[{unit4}]",10}{$"[{unit5}]",10}");

            for (int t = 0; t < allPossibleTemperatureValuesOrdered.Length; t++)
            {
                for (int p = 0; p < allPossiblePressureValuesOrdered.Length; p++)
                {
                    var measurement = measurementsOrderedByPressureAndTemperature[p, t];
                    var value1 = measurement.Environment["temperature"].Magnitude;
                    var value2 = measurement.Raw["bridgeResistance"].Magnitude;
                    var value3 = measurement.Raw["signal"].Magnitude;
                    var value4 = measurement.Environment["pressure"].Magnitude;
                    var value5 = measurement.Compensated.MathematicalModels?.First().Value["pressure"].Output.Magnitude;
                    var value6 = measurement.Compensated.MathematicalModels?.First().Value["pressure"].Error.Magnitude;
                    if (p == 0)
                    {
                        measurementsTextBuilder.AppendLine($"{$"",TextAlignmentDistance}{$"{value1:F1}",5}{$"{value2:F1}",10}{$"{value3:F3}",10}{$"{value4:F3}",10}{$"{value5:F3}",10}{$"{value6:F2}",10}");
                    }
                    else
                    {
                        measurementsTextBuilder.AppendLine($"{$"",TextAlignmentDistance}{$"{value2:F1}",15}{$"{value3:F3}",10}{$"{value4:F3}",10}{$"{value5:F3}",10}{$"{value6:F2}",10}");
                    }
                }
                measurementsTextBuilder.AppendLine();
            }
            measurementsTextBuilder.AppendLine();
            measurementsTextBuilder.AppendLine();

            description = TryExtractModelTypeFormula(kellerSensorData, "temperature");

            measurementsTextBuilder.AppendLine($"{$"{description}",TextAlignmentDistanceHeader}{$"press",10}{$"Rb'",10}{$"t meas",10}{$"t calc",10}{$"deviat",10}");
            measurementsTextBuilder.AppendLine($"{$"",TextAlignmentDistanceHeader}{$"[{unit4}]",10}{$"[{unit2}]",10}{$"[{unit1}]",10}{$"[{unit1}]",10}{$"[{unit4}]",10}");

            for (int t = 0; t < allPossibleTemperatureValuesOrdered.Length; t++)
            {
                for (int p = 0; p < allPossiblePressureValuesOrdered.Length; p++)
                {
                    var measurement = measurementsOrderedByPressureAndTemperature[p, t];

                    var value1 = measurement.Environment["pressure"].Magnitude;
                    var value2 = measurement.Raw["bridgeResistance"].Magnitude;
                    var value3 = measurement.Environment["temperature"].Magnitude;

                    var value4 = measurement.Compensated.MathematicalModels?.First().Value["temperature"].Output.Magnitude;
                    var value5 = measurement.Compensated.MathematicalModels?.First().Value["temperature"].Error.Magnitude;

                    measurementsTextBuilder.AppendLine($"{$"",TextAlignmentDistanceHeader}{$"{value1:F3}",10}{$"{value2:F1}",10}{$"{value3:F1}",10}{$"{value4:F1}",10}{$"{value5:F1}",10}");
                }
                measurementsTextBuilder.AppendLine();
            }
        }
        else
        {
            measurementsTextBuilder.AppendLine();
            measurementsTextBuilder.AppendLine("This JSON contains no MathMod calibration data nor reported measurements errors.");
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
                mathModName = string.Join("/", d);
            }
        }

        textBuilder.AppendLine($"{"type",TextAlignmentDistanceHeader}{typeText} {mathModName} / ██-█████-██");  //Internal numbers are not present in the JSON

        textBuilder.AppendLine($"{"sn",TextAlignmentDistanceHeader}{kellerSensorData.Header.SerialNumber}");

        var temperatureRange = $"{kellerSensorData.Header.CompensatedTemperatureRange.Min} .. {kellerSensorData.Header.CompensatedTemperatureRange.Max}{Units.ToString(kellerSensorData.Header.CompensatedTemperatureRange.Unit).ToUpper()}";
        textBuilder.AppendLine($"{"temperature range",TextAlignmentDistanceHeader}{temperatureRange}");


        var pressureRange = $"{kellerSensorData.Header.CompensatedPressureRange.Min} .. {kellerSensorData.Header.CompensatedPressureRange.Max}{Units.ToString(kellerSensorData.Header.CompensatedPressureRange.Unit)}";
        textBuilder.AppendLine($"{"pressure range",TextAlignmentDistanceHeader}{pressureRange} ███"); //todo: decide if 'rel' or 'abs' depending on sensor type

        textBuilder.AppendLine();

        textBuilder.AppendLine($"{"date",TextAlignmentDistanceHeader}{kellerSensorData.Header.CreationDate:dd.MM.yy}");
        if (kellerSensorData.Header.ElectricSupply.Magnitude.HasValue)
        {
            textBuilder.AppendLine($"{"excitation",TextAlignmentDistanceHeader}{kellerSensorData.Header.ElectricSupply.Magnitude}{Units.ToString(kellerSensorData.Header.ElectricSupply.Unit)}");
        }
        else if (kellerSensorData.Header.ElectricSupply.Min.HasValue)
        {
            var excitationRange = $"{kellerSensorData.Header.ElectricSupply.Min:F1} .. {kellerSensorData.Header.ElectricSupply.Min:F1}{Units.ToString(kellerSensorData.Header.ElectricSupply.Unit)}";
            textBuilder.AppendLine($"{"excitation",TextAlignmentDistanceHeader}{excitationRange}");
        }

        textBuilder.AppendLine();

        textBuilder.AppendLine($"{"Version",TextAlignmentDistanceHeader}V██.█.█.███"); //MathMod.exe's version number is not stored inside the JSON
        textBuilder.AppendLine("-----------------------------------------------------------------------");
        textBuilder.AppendLine();
        return textBuilder;
    }

    private static string TryExtractModelTypeText(KellerSensorData data, string physicalMeasureResultName)
    {
        string result = "No mathematical model stored.";

        if (data.CompensationMethods?.MathematicalModels != null && data.CompensationMethods.MathematicalModels.Any())
        {
            if (data.CompensationMethods.MathematicalModels.First().Value.Parts.ContainsKey(physicalMeasureResultName)) //todo: Should we support more than one MathModel?
            {
                var formula = data.CompensationMethods.MathematicalModels.First().Value.Parts[physicalMeasureResultName].Description;

                var formulaWithoutWhitespace = formula.Replace(" ", "");
                result = formulaWithoutWhitespace switch
                {
                    "Rb'=Rb-f(Sig)" => "model type          Rb' = Rb -f(Sig)\r\n                    Rb' = Rb -(a +b*Sig +c*Sig^2 +... )",
                    "P=f(Sig,R)" => "model type          P  = f(Sig,R); R=Rb\r\n                    P = a *Sig^0 +b*Sig^1 +c*Sig^2 +... \r\n                    a = a0*R^0   +a1*R^1  +a2*R^2  +... \r\n                    b = b0*R^0   +b1*R^1  +b2*R^2  +... \r\n                    c = .....",
                    "P=f(Sig,Rb')" => "model type          P = f(Sig,Rb')\r\n                    P = a  +b*Sig +c*Sig^2 +... \r\n                    a = a0 +a1*Rb' +a2*Rb'^2  +... \r\n                    b = b0 +b1*Rb' +b2*Rb'^2  +... \r\n                    c = .....",
                    "T=f(R,Sig)" => "model type          T  = f(R,Sig)\r\n                    T = a *R^0   +b*R^1    +c*R^2    +... \r\n                    a = a0*Sig^0 +a1*Sig^1 +a2*Sig^2 +... \r\n                    b = b0*Sig^0 +b1*Sig^1 +b2*Sig^2 +... \r\n                    c = .....",
                    "T=f(R)" => "model type          T = f(R); R=Rb\r\n                    T = a *R^0 +b*R^1 +c*R^2 +... ",
                    "T=f(Rb')" => "model type          T = f(Rb')\r\n                    T = a  +b*Rb' +c*Rb'^2 +... ",
                    _ => $"model type          {formula}"
                };
            }
        }

        return result;
    }

    private static string TryExtractModelTypeFormula(KellerSensorData data, string physicalMeasureResultName)
    {
        string result = "No mathematical model stored.";

        if (data.CompensationMethods?.MathematicalModels != null && data.CompensationMethods.MathematicalModels.Any())
        {
            if (data.CompensationMethods.MathematicalModels.First().Value.Parts.ContainsKey(physicalMeasureResultName)) //todo: Should we support more than one MathModel?
            {
                result = data.CompensationMethods.MathematicalModels.First().Value.Parts[physicalMeasureResultName].Description;

                var formulaWithoutWhitespace = result.Replace(" ", "");
                if (formulaWithoutWhitespace == "P=f(Sig,R)")
                {
                    result += "; R=Rb";
                }
            }
        }

        return result;
    }
}