using System.Text;
using KellerSensorDataExchange;

namespace myCalibration.Converters.Mapping;

public static class JsonTextToCsvText
{
    /// <summary>
    /// Converts a myCalibration-JSON-string to the measurement-CSV and the coefficients-CSV
    /// </summary>
    /// <param name="jsonText"></param>
    /// <param name="separator"></param>
    /// <returns>1st string = measurement-CSV-content, 2nd string = coefficients-CSV-content</returns>
    public static (string, string) Convert(string jsonText, char separator = ';')
    {
        KellerSensorData kellerSensorData = ConvertJsonToObject.Convert(jsonText);
        return Convert(kellerSensorData, separator);
    }


    /// <summary>
    /// Converts a myCalibration-JSON-string to the measurement-CSV and the coefficients-CSV
    /// </summary>
    /// <param name="kellerSensorData"></param>
    /// <param name="separator"></param>
    /// <returns>1st string = measurement-CSV-content, 2nd string = coefficients-CSV-content</returns>
    public static (string, string) Convert(KellerSensorData kellerSensorData, char separator = ';')
    {
        var coefficientsTextBuilder = CreateTextBuilderWithHeaderInfo(kellerSensorData, separator);
        if (kellerSensorData.CompensationMethods?.MathematicalModels != null)
        {
            var mathMod = kellerSensorData.CompensationMethods.MathematicalModels.First().Value; //For now, we support only one MathModel per JSON

            int modelNumber = 1;
            DisplayCoefficients("bridgeResistance");
            DisplayCoefficients("pressure");
            DisplayCoefficients("temperature");

            void DisplayCoefficients(string physicalMeasureResultName)
            {
                if (mathMod.Parts.ContainsKey(physicalMeasureResultName))
                {
                    coefficientsTextBuilder.AppendLine("{" + $"model{modelNumber++}" + "}");

                    var modelTypeText = TryExtractModelTypeText(kellerSensorData, physicalMeasureResultName);
                    coefficientsTextBuilder.AppendLine($"model type{separator}{modelTypeText}");

                    var coefficients = mathMod.Parts[physicalMeasureResultName].Coefficients;
                    int firstPolynomialCount = coefficients.Count - 1;
                    coefficientsTextBuilder.AppendLine($"degree x{separator}{firstPolynomialCount}");
                    
                    int secondPolynomialCount = coefficients.First().Count - 1;
                    coefficientsTextBuilder.AppendLine($"degree z{separator}{secondPolynomialCount}");
                    

                    char coefficientParameterLetter = 'a';
                    foreach (var coefficientSet in coefficients)
                    {
                        for (var i = 0; i < coefficientSet.Count; i++)
                        {
                            var coefficient = coefficientSet[i];
                            coefficientsTextBuilder.Append($"{coefficientParameterLetter}");
                            if (secondPolynomialCount > 0)
                            {
                                coefficientsTextBuilder.Append($"{i}");
                            }

                            var kellerScientificNotation = $"{coefficient:E11}".Replace("E+0","E+").Replace("E-0", "E-");
                            if (coefficient > 0)
                            {
                                coefficientsTextBuilder.AppendLine($"{separator} {kellerScientificNotation}");
                            }
                            else
                            {
                                coefficientsTextBuilder.AppendLine($"{separator}{kellerScientificNotation}");
                            }
                        }

                        coefficientParameterLetter++; // switch to the next letter in the alphabet
                    }
                }
            }
        }
        else
        {
            coefficientsTextBuilder.AppendLine();
            coefficientsTextBuilder.AppendLine("This JSON contains no MathMod calibration data nor reported measurements errors.");
        }
        coefficientsTextBuilder.AppendLine();



        var measurementsTextBuilder = CreateTextBuilderWithHeaderInfo(kellerSensorData, separator);
        if (kellerSensorData.Measurements != null 
            && kellerSensorData.Measurements.Count > 0 
            && kellerSensorData.Measurements.All(_=>_.Raw != null))
        {
            List<Measurement> testRunMeasurements = kellerSensorData.Measurements;

            double[] allPossibleTemperatureValuesOrdered = testRunMeasurements.Select(_ => _.EnvironmentTarget["temperature"].Magnitude).Distinct().OrderBy(_ => _).ToArray();
            double[] allPossiblePressureValuesOrdered = testRunMeasurements.Select(_ => _.EnvironmentTarget["pressure"].Magnitude).Distinct().OrderBy(_ => _).ToArray();
            Measurement[,] measurementsOrderedByPressureAndTemperature = new Measurement[allPossiblePressureValuesOrdered.Length, allPossibleTemperatureValuesOrdered.Length];
            for (var p = 0; p < allPossiblePressureValuesOrdered.Length; p++)
            {
                for (var t = 0; t < allPossibleTemperatureValuesOrdered.Length; t++)
                {
                    // Here we use First() because we measure the same pressure/temperature point multiple times and show it in the JSON.
                    // Normally, we exclude the extra measurements (hysteresis measurements) in the JSON but in rare case they are here.
                    // We consider the first measurement as the reference measurement point
                    measurementsOrderedByPressureAndTemperature[p, t] = testRunMeasurements
                        .First(_ => _.EnvironmentTarget["pressure"].Magnitude == allPossiblePressureValuesOrdered[p] &&
                                     _.EnvironmentTarget["temperature"].Magnitude == allPossibleTemperatureValuesOrdered[t]);
                }
            }

            var sample = measurementsOrderedByPressureAndTemperature[0, 0];
            var unit1 = Units.ToString(sample.EnvironmentTarget["temperature"].Unit); // Should be '°C'
            var unit2 = Units.ToString(sample.Raw["bridgeResistance"].Unit); // Should be 'Ohm'
            var unit3 = Units.ToString(sample.Raw["signal"].Unit); // Should be 'mV'
            var unit4 = Units.ToString(sample.EnvironmentTarget["pressure"].Unit); // Should be 'bar'
            var unit5 = "%Fs";

            int modelNumber = 1;

            string? description = TryExtractModelTypeFormula(kellerSensorData, "bridgeResistance");
            if (description != null)
            {
                measurementsTextBuilder.AppendLine("{" + $"model{modelNumber++}" + "}");
                measurementsTextBuilder.AppendLine($"model type{separator}{description}");


                measurementsTextBuilder.AppendLine($"temp{separator}sig{separator}Rb{separator}Rb' calc{separator}deviat");
                measurementsTextBuilder.AppendLine($"[{unit1}]{separator}[{unit3}]{separator}[{unit2}]{separator}[{unit2}]{separator}[{unit2}]");
                for (var t = 0; t < allPossibleTemperatureValuesOrdered.Length; t++)
                {
                    for (var p = 0; p < allPossiblePressureValuesOrdered.Length; p++)
                    {
//todo check with more data/unit tests
                        var measurement = measurementsOrderedByPressureAndTemperature[p, t];
                        var value1 = measurement.Environment["temperature"].Magnitude;
                        var value2 = measurement.Raw["bridgeResistance"].Magnitude;
                        var value3 = measurement.Raw["signal"].Magnitude;
                        var value5 = measurement.Compensated.MathematicalModels?.First().Value["bridgeResistance"].Output.Magnitude;
                        var value6 = measurement.Compensated.MathematicalModels?.First().Value["bridgeResistance"].Error.Magnitude;
                        measurementsTextBuilder.AppendLine($"{$"{value1:F1}",10}{separator}{$"{value3:F4}",10}{separator}{$"{value2:F1}",10}{separator}{$"{value5:F1}",10}{separator}{$"{value6:F1}",10}");
                    }
                }
                measurementsTextBuilder.AppendLine();
            }


            description = TryExtractModelTypeFormula(kellerSensorData, "pressure");
            if (description != null)
            {
                measurementsTextBuilder.AppendLine("{" + $"model{modelNumber++}" + "}");
                measurementsTextBuilder.AppendLine($"model type{separator}{description}");


                measurementsTextBuilder.AppendLine($"temp{separator}Rb'{separator}sig{separator}press{separator}p calc{separator}deviat");
                measurementsTextBuilder.AppendLine($"[{unit1}]{separator}[{unit2}]{separator}[{unit3}]{separator}[{unit4}]{separator}[{unit4}]{separator}[{unit5}]");
                for (var t = 0; t < allPossibleTemperatureValuesOrdered.Length; t++)
                {
                    for (var p = 0; p < allPossiblePressureValuesOrdered.Length; p++)
                    {
                        var measurement = measurementsOrderedByPressureAndTemperature[p, t];
                        var value1 = measurement.Environment["temperature"].Magnitude;
                        var value2 = measurement.Raw["bridgeResistance"].Magnitude;
                        var value3 = measurement.Raw["signal"].Magnitude;
                        var value4 = measurement.Environment["pressure"].Magnitude;
                        var value5 = measurement.Compensated.MathematicalModels?.First().Value["pressure"].Output.Magnitude;
                        var value6 = measurement.Compensated.MathematicalModels?.First().Value["pressure"].Error.Magnitude;
                        measurementsTextBuilder.AppendLine($"{$"{value1:F1}",10}{separator}{$"{value2:F1}",10}{separator}{$"{value3:F3}",10}{separator}{$"{value4:F3}",10}{separator}{$"{value5:F3}",10}{separator}{$"{value6:F2}",10}");
                    }
                }
                measurementsTextBuilder.AppendLine();
            }

            description = TryExtractModelTypeFormula(kellerSensorData, "temperature");
            if (description != null)
            {
                measurementsTextBuilder.AppendLine("{" + $"model{modelNumber++}" + "}");
                measurementsTextBuilder.AppendLine($"model type{separator}{description}");

                measurementsTextBuilder.AppendLine($"press{separator}Rb'{separator}t meas{separator}t calc{separator}deviat");
                measurementsTextBuilder.AppendLine($"[{unit4}]{separator}[{unit2}]{separator}[{unit1}]{separator}[{unit1}]{separator}[{unit1}]");
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

                        measurementsTextBuilder.AppendLine($"{$"{value1:F4}",10}{separator}{$"{value2:F1}",10}{separator}{$"{value3:F1}",10}{separator}{$"{value4:F1}",10}{separator}{$"{value5:F1}",10}");
                    }
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

    private static StringBuilder CreateTextBuilderWithHeaderInfo(KellerSensorData kellerSensorData, char sep)
    {
        var textBuilder = new StringBuilder();

        var typeText = $"{kellerSensorData.Header.PressureType.ToString().ToUpper()}-{kellerSensorData.Header.ProductSeries.ToUpper()}/{kellerSensorData.Header.CompensatedPressureRange.Max}{kellerSensorData.Header.CompensatedPressureRange.Unit.ToString().ToUpper()}";
        var mathModName = "";
        if (kellerSensorData.CompensationMethods?.MathematicalModels != null)
        {
            var d = kellerSensorData.CompensationMethods.MathematicalModels.Keys.ToArray();
            if (d.Length > 0)
            {
                mathModName = string.Join("/", d);
            }
        }
        textBuilder.AppendLine($"type{sep}{typeText} {mathModName}/██-█████-██"); //Internal numbers are not present in the JSON

        textBuilder.AppendLine($"note {sep}{kellerSensorData.Header.Remarks}");

        textBuilder.AppendLine($"sn{sep}{kellerSensorData.Header.SerialNumber}");

        var temperatureRange = $"{kellerSensorData.Header.CompensatedTemperatureRange.Min} .. {kellerSensorData.Header.CompensatedTemperatureRange.Max}{Units.ToString(kellerSensorData.Header.CompensatedTemperatureRange.Unit).ToUpper()}";
        textBuilder.AppendLine($"temp range{sep}{temperatureRange}");

        var pressureRange = $"{kellerSensorData.Header.CompensatedPressureRange.Min} .. {kellerSensorData.Header.CompensatedPressureRange.Max}{Units.ToString(kellerSensorData.Header.CompensatedPressureRange.Unit)}";
        textBuilder.AppendLine($"pressure range{sep}{pressureRange} ███");  //The information whether 'rel' or 'abs' is used when testing is not part in version 1 of the JSON

        textBuilder.AppendLine($"date{sep}{kellerSensorData.Header.CreationDate:dd.MM.yy}");

        if (kellerSensorData.Header.ElectricSupply.Magnitude.HasValue)
        {
            textBuilder.AppendLine($"supply{sep}{kellerSensorData.Header.ElectricSupply.Magnitude:F3} {Units.ToString(kellerSensorData.Header.ElectricSupply.Unit)}");
        }
        else if (kellerSensorData.Header.ElectricSupply.Min.HasValue)
        {
            var excitationRange = $"{kellerSensorData.Header.ElectricSupply.Min} .. {kellerSensorData.Header.ElectricSupply.Min}{Units.ToString(kellerSensorData.Header.ElectricSupply.Unit)}";
            textBuilder.AppendLine($"supply{sep}{excitationRange}");
        }
        textBuilder.AppendLine($"Version{sep}V██.█.█.███"); //MathMod.exe's version number is not stored inside the JSON
        textBuilder.AppendLine($"res{sep}"); //todo: What does this mean?
        return textBuilder;
    }

    private static string TryExtractModelTypeText(KellerSensorData data, string physicalMeasureResultName)
    {
        string result = "No mathematical model stored." + Environment.NewLine;

        if (data.CompensationMethods?.MathematicalModels != null && data.CompensationMethods.MathematicalModels.Any())
        {
            if (data.CompensationMethods.MathematicalModels.First().Value.Parts.ContainsKey(physicalMeasureResultName)) //todo: Should we support more than one MathModel?
            {
                var formula = data.CompensationMethods.MathematicalModels.First().Value.Parts[physicalMeasureResultName].Description;

                var formulaWithoutWhitespace = formula.Replace(" ", "");
                result = formulaWithoutWhitespace switch
                {
                    "Rb'=Rb-f(Sig)" => "Rb' = Rb -f(Sig)",
                    "P=f(Sig,R)" => "P  = f(Sig,R); R=Rb",
                    "P=f(Sig,Rb')" => "P = f(Sig,Rb')",
                    "T=f(R,Sig)" => "T  = f(R,Sig)",
                    "T=f(R)" => "T = f(R); R=Rb",
                    "T=f(Rb')" => "T = f(Rb')",
                    _ => $"{formula}"
                };
            }
        }

        return result;
    }

    private static string? TryExtractModelTypeFormula(KellerSensorData data, string physicalMeasureResultName)
    {
        //string result = "No mathematical model stored.";
        string? result = null;

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