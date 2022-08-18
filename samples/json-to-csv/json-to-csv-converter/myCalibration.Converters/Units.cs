using KellerSensorDataExchange;

namespace myCalibration.Converters;

internal static class Units
{
    public static string ToString(PhysicalUnit? value)
    {
        return value switch
        {
            PhysicalUnit.Empty => "",
            PhysicalUnit.Fs => "%FS",
            PhysicalUnit.A => "A",
            PhysicalUnit.K => "K",
            PhysicalUnit.MOhm => "MOhm",
            PhysicalUnit.MPa => "MPa",
            PhysicalUnit.Ohm => "Ohm",
            PhysicalUnit.Pa => "Pa",
            PhysicalUnit.Torr => "Torr",
            PhysicalUnit.V => "V",
            PhysicalUnit.VDC => "VDC",
            PhysicalUnit.Atm => "atm",
            PhysicalUnit.Bar => "bar",
            PhysicalUnit.CmH2O => "cmH2O",
            PhysicalUnit.CmHg => "cmHg",
            PhysicalUnit.FtH2O => "ftH2O",
            PhysicalUnit.HPa => "hPa",
            PhysicalUnit.InH2O => "inH2O",
            PhysicalUnit.InHg => "inHg",
            PhysicalUnit.KNM2 => "kN/m2",
            PhysicalUnit.KOhm => "kOhm",
            PhysicalUnit.KPa => "kPa",
            PhysicalUnit.KpCm2 => "kp/cm2",
            PhysicalUnit.LbfFt2 => "lbf/ft2",
            PhysicalUnit.MA => "mA",
            PhysicalUnit.MH2O => "mH2O",
            PhysicalUnit.MV => "mV",
            PhysicalUnit.MVV => "mV/V",
            PhysicalUnit.MVMA => "mV/mA",
            PhysicalUnit.Mbar => "mbar",
            PhysicalUnit.MmH2O => "mmH2O",
            PhysicalUnit.MmHg => "mmHg",
            PhysicalUnit.Psi => "psi",
            PhysicalUnit.C => "°C",
            null => "█",
            _ => throw new Exception("Cannot marshal type PhysicalUnit")
        };
    }
}