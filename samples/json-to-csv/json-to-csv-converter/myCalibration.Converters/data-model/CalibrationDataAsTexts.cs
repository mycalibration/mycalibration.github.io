namespace myCalibration.Converters.data_model;

public class CalibrationDataAsTexts
{
    public CalibrationDataAsTexts(string inputJsonText)
    {
        InputJsonText = inputJsonText;
        MeasurementsTxtText = "";
        CoefficientsTxtText = "";
        MeasurementsCsvText = "";
        CoefficientsCsvText = "";
    }

    public CalibrationDataAsTexts()
    {
        InputJsonText       = "";
        MeasurementsTxtText = "";
        CoefficientsTxtText = "";
        MeasurementsCsvText = "";
        CoefficientsCsvText = "";
    }

    public string InputJsonText { get; set; }
    public string MeasurementsTxtText { get; set; }
    public string CoefficientsTxtText { get; set; }
    public string MeasurementsCsvText { get; set; }
    public string CoefficientsCsvText { get; set; }
}