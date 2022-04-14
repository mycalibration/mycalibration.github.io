using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MyCalibrationDataModel
{
    using J = JsonPropertyAttribute;
    using N = NullValueHandling;

    /// <summary>JSON Schema for KELLER sensor calibration data</summary>
    public class ExchangeDataContext
    {
        /// <summary>
        /// Version of the corresponding JSON Schema
        /// </summary>
        [J("version", Order = 0)] public string Version { get; set; }
        
        [J("header", Order = 1)] public Header Header { get; set; }
        
        [J("compensationMethods", NullValueHandling = N.Ignore, Order = 2)] public CompensationMethods CompensationMethods { get; set; }

        /// <summary>
        /// Array of individual measurements. Item order corresponds to order in measurement sequence.
        /// </summary>
        [J("measurements", Order = 3)] public List<Measurement> Measurements { get; set; }
    }


    /// <summary>Header data</summary>
    public class Header
    {
        /// <summary>
        /// Pressure range over which the sensors characteristics have been compensated
        /// </summary>
        [J("compensatedPressureRange")] public PhysicalQuantityRange CompensatedPressureRange { get; set; }

        /// <summary>
        /// Temperature range over which the sensors characteristics have been compensated
        /// </summary>
        [J("compensatedTemperatureRange")] public PhysicalQuantityRange CompensatedTemperatureRange { get; set; }

        /// <summary>
        /// File creation date
        /// </summary>
        [J("creationDate", NullValueHandling = N.Ignore)] public string CreationDate { get; set; }

        /// <summary>
        /// Customer name
        /// </summary>
        [J("customerName")] public string CustomerName { get; set; }

        /// <summary>
        /// KELLER customer identification number
        /// </summary>
        [J("customerNumber")] public long CustomerNumber { get; set; }

        /// <summary>
        /// Customer internal purchase order number
        /// </summary>
        [J("customerOrderNumber")] public string CustomerOrderNumber { get; set; }

        /// <summary>
        /// Customer internal product type
        /// </summary>
        [J("customerProductType")] public string CustomerProductType { get; set; }

        /// <summary>
        /// Customer internal reference number
        /// </summary>
        [J("customerReferenceNumber")] public string CustomerReferenceNumber { get; set; }

        /// <summary>
        /// Nominal electric supply
        /// </summary>
        [J("electricSupply")] public HeaderElectricSupply ElectricSupply { get; set; }

        /// <summary>
        /// KELLER purchase order number
        /// </summary>
        [J("orderNumber")] public long OrderNumber { get; set; }

        /// <summary>
        /// KELLER purchase order position
        /// </summary>
        [J("orderPosition")] public long OrderPosition { get; set; }

        /// <summary>
        /// Targeted dispatch date of the order
        /// </summary>
        [J("orderTargetDispatchDate")] public string OrderTargetDispatchDate { get; set; }

        /// <summary>
        /// KELLER product pressure type
        /// </summary>
        [J("pressureType")] public PressureType PressureType { get; set; }
        [J("productNumber")] public string ProductNumber { get; set; }

        /// <summary>
        /// KELLER product series
        /// </summary>
        [J("productSeries")] public string ProductSeries { get; set; }

        /// <summary>
        /// KELLER product type
        /// </summary>
        [J("productType")] public string ProductType { get; set; }

        [J("remarks")] public string Remarks { get; set; }

        /// <summary>
        /// KELLER product serial number
        /// </summary>
        [J("serialNumber")] public string SerialNumber { get; set; }
    }


    /// <summary>Information on different compensation methods</summary>
    public class CompensationMethods
    {
        [J("compensationCircuit", NullValueHandling = N.Ignore)] public CompensationCircuit CompensationCircuit { get; set; }
        [J("mathematicalModels", NullValueHandling = N.Ignore)] public Dictionary<string, MathematicalModel> MathematicalModels { get; set; }
    }

    /// <summary>Compensation circuit</summary>
    public class CompensationCircuit
    {
        [J("description")] public string Description { get; set; }

        /// <summary>
        /// Outputs of the compensation circuit
        /// </summary>
        [J("outputs")] public Dictionary<string, CompensationCircuitOutput> Outputs { get; set; }
    }

    /// <summary>Compensation circuit output</summary>
    public class CompensationCircuitOutput
    {
        [J("description")] public string Description { get; set; }
    }

    /// <summary>A mathematical compensation model</summary>
    public class MathematicalModel
    {
        /// <summary>
        /// Pressure range of the mathematical compensation model
        /// </summary>
        [J("compensatedPressureRange", NullValueHandling = N.Ignore)] public PhysicalQuantityRange CompensatedPressureRange { get; set; }

        /// <summary>
        /// Temperature range of the mathematical compensation model
        /// </summary>
        [J("compensatedTemperatureRange", NullValueHandling = N.Ignore)] public PhysicalQuantityRange CompensatedTemperatureRange { get; set; }
        
        /// <summary>
        /// Nominal electric supply of the mathematical compensation model
        /// </summary>
        [J("electricSupply", NullValueHandling = N.Ignore)] public PhysicalQuantity ElectricSupply { get; set; }
        [J("modelType", NullValueHandling = N.Ignore)] public string ModelType { get; set; }
        [J("parts")] public Dictionary<string, MathematicalModelPart> Parts { get; set; }
        [J("productNumber", NullValueHandling = N.Ignore)] public string ProductNumber { get; set; }
    }

    /// <summary>Pressure range of the mathematical compensation model; ; Range of physical quantities consisting of a minimum and maximum magnitude and a unit of; measurement; ; Temperature range of the mathematical compensation model; ; Pressure range over which the sensors characteristics have been compensated; ; Temperature range over which the sensors characteristics have been compensated</summary>
    public class PhysicalQuantityRange
    {
        [J("min", Order = 0)] public double Min { get; set; }
        [J("max", Order = 1)] public double Max { get; set; }
        [J("unit", Order = 2)] public PhysicalUnit Unit { get; set; }
    }

    /// <summary>Nominal electric supply of the mathematical compensation model; ; Physical quantity consisting of a magnitude and a unit of measurement</summary>
    public class PhysicalQuantity
    {
        [J("magnitude")] public double Magnitude { get; set; }
        [J("unit")] public PhysicalUnit Unit { get; set; }
    }

    /// <summary>Part of mathematical compensation model that generates of compensated output</summary>
    public class MathematicalModelPart
    {
        [J("coefficients")] public List<List<double>> Coefficients { get; set; }
        [J("description")] public string Description { get; set; }
        /// <summary>
        /// Input variables of the model part
        /// </summary>
        [J("inputs")][JsonConverter(typeof(DecodeArrayConverter))] public List<string> Inputs { get; set; }

        /// <summary>
        /// Output variable of the model part
        /// </summary>
        [J("output")][JsonConverter(typeof(MinMaxLengthCheckConverter))] public string Output { get; set; }
    }


    /// <summary>Nominal electric supply; ; Nominal electric supply of the mathematical compensation model; ; Physical quantity consisting of a magnitude and a unit of measurement; ; Pressure range of the mathematical compensation model; ; Range of physical quantities consisting of a minimum and maximum magnitude and a unit of; measurement; ; Temperature range of the mathematical compensation model; ; Pressure range over which the sensors characteristics have been compensated; ; Temperature range over which the sensors characteristics have been compensated</summary>
    public class HeaderElectricSupply
    { 
        [J("min", NullValueHandling = N.Ignore, Order = 0)] public double? Min { get; set; }
        [J("max", NullValueHandling = N.Ignore, Order = 1)] public double? Max { get; set; }
        [J("unit", Order = 2)] public PhysicalUnit Unit { get; set; }
        [J("magnitude", Order = 3, NullValueHandling = N.Ignore)] public double? Magnitude { get; set; }
    }

    /// <summary>One measurement point</summary>
    public class Measurement
    {
        [J("compensated", NullValueHandling = N.Ignore)] public MeasurementCompensated Compensated { get; set; }
        [J("environment")] public Dictionary<string, PhysicalQuantity> Environment { get; set; }
        [J("environmentTarget", NullValueHandling = N.Ignore)] public Dictionary<string, PhysicalQuantity> EnvironmentTarget { get; set; }
        [J("raw", NullValueHandling = N.Ignore)] public Dictionary<string, PhysicalQuantity> Raw { get; set; }
        [J("reference")] public string Reference { get; set; }
    }

    /// <summary>Compensated measurement data by different compensation methods</summary>
    public class MeasurementCompensated
    {
        [J("compensationCircuitOutputs", NullValueHandling = N.Ignore)] public Dictionary<string, CompensationCircuitOutputValue> CompensationCircuitOutputs { get; set; }
        [J("mathematicalModels", NullValueHandling = N.Ignore)] public Dictionary<string, Dictionary<string, MeasurementCompensatedMathematicalModelPart>> MathematicalModels { get; set; }
    }

    public class CompensationCircuitOutputValue
    {
        [J("measuredValue")] public PhysicalQuantity MeasuredValue { get; set; }
        [J("nominalValue")] public PhysicalQuantity NominalValue { get; set; }
    }

    /// <summary>Compensated measurement data by a part of a mathematical compensation model</summary>
    public class MeasurementCompensatedMathematicalModelPart
    {
        [J("error")] public PhysicalQuantity Error { get; set; }
        [J("output")] public PhysicalQuantity Output { get; set; }
    }

    /// <summary>Unit of measurement</summary>
    public enum PhysicalUnit { A, Atm, Bar, C, CmH2O, CmHg, Empty, Fs, FtH2O, HPa, InH2O, InHg, K, KNM2, KOhm, KPa, KpCm2, LbfFt2, MA, MH2O, MOhm, MPa, MV, MVMA, MVV, Mbar, MmH2O, MmHg, Ohm, Pa, Psi, Torr, V, VDC}

    /// <summary>
    /// KELLER product pressure type
    /// 
    /// Pressure type
    /// </summary>
    public enum PressureType { Empty, Pa, Paa, Pd, Pr, Prd }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                PhysicalUnitConverter.Singleton,
                PressureTypeConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class PhysicalUnitConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(PhysicalUnit) || t == typeof(PhysicalUnit?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "":
                    return PhysicalUnit.Empty;
                case "%FS":
                    return PhysicalUnit.Fs;
                case "A":
                    return PhysicalUnit.A;
                case "K":
                    return PhysicalUnit.K;
                case "MOhm":
                    return PhysicalUnit.MOhm;
                case "MPa":
                    return PhysicalUnit.MPa;
                case "Ohm":
                    return PhysicalUnit.Ohm;
                case "Pa":
                    return PhysicalUnit.Pa;
                case "Torr":
                    return PhysicalUnit.Torr;
                case "V":
                    return PhysicalUnit.V;
                case "VDC":
                    return PhysicalUnit.VDC;
                case "atm":
                    return PhysicalUnit.Atm;
                case "bar":
                    return PhysicalUnit.Bar;
                case "cmH2O":
                    return PhysicalUnit.CmH2O;
                case "cmHg":
                    return PhysicalUnit.CmHg;
                case "ftH2O":
                    return PhysicalUnit.FtH2O;
                case "hPa":
                    return PhysicalUnit.HPa;
                case "inH2O":
                    return PhysicalUnit.InH2O;
                case "inHg":
                    return PhysicalUnit.InHg;
                case "kN/m2":
                    return PhysicalUnit.KNM2;
                case "kOhm":
                    return PhysicalUnit.KOhm;
                case "kPa":
                    return PhysicalUnit.KPa;
                case "kp/cm2":
                    return PhysicalUnit.KpCm2;
                case "lbf/ft2":
                    return PhysicalUnit.LbfFt2;
                case "mA":
                    return PhysicalUnit.MA;
                case "mH2O":
                    return PhysicalUnit.MH2O;
                case "mV":
                    return PhysicalUnit.MV;
                case "mV/V":
                    return PhysicalUnit.MVV;
                case "mV/mA":
                    return PhysicalUnit.MVMA;
                case "mbar":
                    return PhysicalUnit.Mbar;
                case "mmH2O":
                    return PhysicalUnit.MmH2O;
                case "mmHg":
                    return PhysicalUnit.MmHg;
                case "psi":
                    return PhysicalUnit.Psi;
                case "°C":
                    return PhysicalUnit.C;
            }
            throw new Exception("Cannot unmarshal type PhysicalUnit");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (PhysicalUnit)untypedValue;
            switch (value)
            {
                case PhysicalUnit.Empty:
                    serializer.Serialize(writer, "");
                    return;
                case PhysicalUnit.Fs:
                    serializer.Serialize(writer, "%FS");
                    return;
                case PhysicalUnit.A:
                    serializer.Serialize(writer, "A");
                    return;
                case PhysicalUnit.K:
                    serializer.Serialize(writer, "K");
                    return;
                case PhysicalUnit.MOhm:
                    serializer.Serialize(writer, "MOhm");
                    return;
                case PhysicalUnit.MPa:
                    serializer.Serialize(writer, "MPa");
                    return;
                case PhysicalUnit.Ohm:
                    serializer.Serialize(writer, "Ohm");
                    return;
                case PhysicalUnit.Pa:
                    serializer.Serialize(writer, "Pa");
                    return;
                case PhysicalUnit.Torr:
                    serializer.Serialize(writer, "Torr");
                    return;
                case PhysicalUnit.V:
                    serializer.Serialize(writer, "V");
                    return;
                case PhysicalUnit.VDC:
                    serializer.Serialize(writer, "VDC");
                    return;
                case PhysicalUnit.Atm:
                    serializer.Serialize(writer, "atm");
                    return;
                case PhysicalUnit.Bar:
                    serializer.Serialize(writer, "bar");
                    return;
                case PhysicalUnit.CmH2O:
                    serializer.Serialize(writer, "cmH2O");
                    return;
                case PhysicalUnit.CmHg:
                    serializer.Serialize(writer, "cmHg");
                    return;
                case PhysicalUnit.FtH2O:
                    serializer.Serialize(writer, "ftH2O");
                    return;
                case PhysicalUnit.HPa:
                    serializer.Serialize(writer, "hPa");
                    return;
                case PhysicalUnit.InH2O:
                    serializer.Serialize(writer, "inH2O");
                    return;
                case PhysicalUnit.InHg:
                    serializer.Serialize(writer, "inHg");
                    return;
                case PhysicalUnit.KNM2:
                    serializer.Serialize(writer, "kN/m2");
                    return;
                case PhysicalUnit.KOhm:
                    serializer.Serialize(writer, "kOhm");
                    return;
                case PhysicalUnit.KPa:
                    serializer.Serialize(writer, "kPa");
                    return;
                case PhysicalUnit.KpCm2:
                    serializer.Serialize(writer, "kp/cm2");
                    return;
                case PhysicalUnit.LbfFt2:
                    serializer.Serialize(writer, "lbf/ft2");
                    return;
                case PhysicalUnit.MA:
                    serializer.Serialize(writer, "mA");
                    return;
                case PhysicalUnit.MH2O:
                    serializer.Serialize(writer, "mH2O");
                    return;
                case PhysicalUnit.MV:
                    serializer.Serialize(writer, "mV");
                    return;
                case PhysicalUnit.MVV:
                    serializer.Serialize(writer, "mV/V");
                    return;
                case PhysicalUnit.MVMA:
                    serializer.Serialize(writer, "mV/mA");
                    return;
                case PhysicalUnit.Mbar:
                    serializer.Serialize(writer, "mbar");
                    return;
                case PhysicalUnit.MmH2O:
                    serializer.Serialize(writer, "mmH2O");
                    return;
                case PhysicalUnit.MmHg:
                    serializer.Serialize(writer, "mmHg");
                    return;
                case PhysicalUnit.Psi:
                    serializer.Serialize(writer, "psi");
                    return;
                case PhysicalUnit.C:
                    serializer.Serialize(writer, "°C");
                    return;
            }
            throw new Exception("Cannot marshal type PhysicalUnit");
        }

        public static readonly PhysicalUnitConverter Singleton = new PhysicalUnitConverter();
    }

    internal class DecodeArrayConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(List<string>);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            reader.Read();
            var value = new List<string>();
            while (reader.TokenType != JsonToken.EndArray)
            {
                var converter = MinMaxLengthCheckConverter.Singleton;
                var arrayItem = (string)converter.ReadJson(reader, typeof(string), null, serializer);
                value.Add(arrayItem);
                reader.Read();
            }
            return value;
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (List<string>)untypedValue;
            writer.WriteStartArray();
            foreach (var arrayItem in value)
            {
                var converter = MinMaxLengthCheckConverter.Singleton;
                converter.WriteJson(writer, arrayItem, serializer);
            }
            writer.WriteEndArray();
        }

        public static readonly DecodeArrayConverter Singleton = new DecodeArrayConverter();
    }

    internal class MinMaxLengthCheckConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(string);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            var value = serializer.Deserialize<string>(reader);
            if (value.Length >= 1)
            {
                return value;
            }
            throw new Exception("Cannot unmarshal type string");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (string)untypedValue;
            if (value.Length >= 1)
            {
                serializer.Serialize(writer, value);
                return;
            }
            throw new Exception("Cannot marshal type string");
        }

        public static readonly MinMaxLengthCheckConverter Singleton = new MinMaxLengthCheckConverter();
    }

    internal class PressureTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(PressureType) || t == typeof(PressureType?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "":
                    return PressureType.Empty;
                case "PA":
                    return PressureType.Pa;
                case "PAA":
                    return PressureType.Paa;
                case "PD":
                    return PressureType.Pd;
                case "PR":
                    return PressureType.Pr;
                case "PRD":
                    return PressureType.Prd;
            }
            throw new Exception("Cannot unmarshal type PressureType");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (PressureType)untypedValue;
            switch (value)
            {
                case PressureType.Empty:
                    serializer.Serialize(writer, "");
                    return;
                case PressureType.Pa:
                    serializer.Serialize(writer, "PA");
                    return;
                case PressureType.Paa:
                    serializer.Serialize(writer, "PAA");
                    return;
                case PressureType.Pd:
                    serializer.Serialize(writer, "PD");
                    return;
                case PressureType.Pr:
                    serializer.Serialize(writer, "PR");
                    return;
                case PressureType.Prd:
                    serializer.Serialize(writer, "PRD");
                    return;
            }
            throw new Exception("Cannot marshal type PressureType");
        }

        public static readonly PressureTypeConverter Singleton = new PressureTypeConverter();
    }
}
