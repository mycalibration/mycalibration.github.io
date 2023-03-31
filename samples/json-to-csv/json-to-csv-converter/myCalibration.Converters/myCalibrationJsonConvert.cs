using KellerSensorDataExchange;
using myCalibration.Converters.data_model;

namespace myCalibration.Converters
{
    public static class MyCalibrationJsonConvert
    {
        /// <summary>
        /// Converts a myCalibration-JSON-string to the measurement-CSV and the coefficients-CSV
        /// </summary>
        /// <param name="jsonText"></param>
        /// <returns>1st string = measurement-CSV-content, 2nd string = coefficients-CSV-content</returns>
        public static (string, string) JsonTextToCsvText(string jsonText)
        {
            var (convertedCoefficientTxtText, convertedMeasurementsTxtText) = Mapping.JsonTextToCsvText.Convert(jsonText);
            return (convertedCoefficientTxtText, convertedMeasurementsTxtText);
        }

        /// <summary>
        /// Converts a myCalibration-JSON-string to the measurement-TXT and the coefficients-TXT
        /// </summary>
        /// <param name="jsonText"></param>
        /// <returns>1st string = measurement-TXT-content, 2nd string = coefficients-TXT-content</returns>
        public static (string, string) JsonTextToTxtText(string jsonText)
        {
            var (convertedCoefficientTxtText, convertedMeasurementsTxtText) = Mapping.JsonTextToTxtText.Convert(jsonText);
            return (convertedCoefficientTxtText, convertedMeasurementsTxtText);
        }


        /// <summary>
        /// Converts a myCalibration-JSON-string to the text contents of the measurement-CSV, the coefficients-CSV, the measurement-TXT, the coefficients-TXT
        /// </summary>
        /// <param name="jsonText"></param>
        /// <param name="separator"></param>
        /// <returns>CalibrationDataAsTexts that contains the measurement-CSV, the coefficients-CSV, the measurement-TXT, the coefficients-TXT</returns>
        public static CalibrationDataAsTexts JsonTextToAll(string jsonText, char separator = ';')
        {
            KellerSensorData kellerSensorData = ConvertJsonToObject.Convert(jsonText); //Let's do this only once

            var calibrationDataAsTexts = new CalibrationDataAsTexts(jsonText);

            var (measurementsText, coefficientsText) = Mapping.JsonTextToTxtText.Convert(kellerSensorData);
            calibrationDataAsTexts.CoefficientsTxtText = coefficientsText;
            calibrationDataAsTexts.MeasurementsTxtText = measurementsText;

            var (measurementsCsv, coefficientsCsv) = Mapping.JsonTextToCsvText.Convert(kellerSensorData, separator);
            calibrationDataAsTexts.CoefficientsCsvText = coefficientsCsv;
            calibrationDataAsTexts.MeasurementsCsvText = measurementsCsv;

            return calibrationDataAsTexts;
        }


        /// <summary>
        /// Converts a myCalibration-KellerSensorData-object to the measurement-CSV and the coefficients-CSV
        /// </summary>
        /// <param name="kellerSensorData"></param>
        /// <returns>1st string = measurement-CSV-content, 2nd string = coefficients-CSV-content</returns>
        public static (string, string) KellerSensorDataToCsvText(KellerSensorData kellerSensorData)
        {
            var (convertedCoefficientCsvText, convertedMeasurementsCsvText) = Mapping.JsonTextToCsvText.Convert(kellerSensorData);
            return (convertedCoefficientCsvText, convertedMeasurementsCsvText);
        }

        /// <summary>
        /// Converts a myCalibration-KellerSensorData-object to the measurement-TXT and the coefficients-TXT
        /// </summary>
        /// <param name="kellerSensorData"></param>
        /// <returns>1st string = measurement-TXT-content, 2nd string = coefficients-TXT-content</returns>
        public static (string, string) KellerSensorDataToTxtText(KellerSensorData kellerSensorData)
        {
            var (convertedCoefficientTxtText, convertedMeasurementsTxtText) = Mapping.JsonTextToTxtText.Convert(kellerSensorData);
            return (convertedCoefficientTxtText, convertedMeasurementsTxtText);
        }
    }
}
