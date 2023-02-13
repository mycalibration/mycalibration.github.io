using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Model {

  /// <summary>
  /// Mefisto &#x3D; MEtainfo for FIle STOrage  DTO with the Database entries for the header data without some fileds that are irrelevant tot he table.
  /// </summary>
  [DataContract]
  public class MefistoViewModel {
    /// <summary>
    /// internal id
    /// </summary>
    /// <value>internal id</value>
    [DataMember(Name="Id", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "Id")]
    public int? Id { get; set; }

    /// <summary>
    /// Customer name
    /// </summary>
    /// <value>Customer name</value>
    [DataMember(Name="CustomerName", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "CustomerName")]
    public string CustomerName { get; set; }

    /// <summary>
    /// KELLER customer identification number
    /// </summary>
    /// <value>KELLER customer identification number</value>
    [DataMember(Name="CustomerNumber", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "CustomerNumber")]
    public int? CustomerNumber { get; set; }

    /// <summary>
    /// KELLER customer identification number for a customer of a customer
    /// </summary>
    /// <value>KELLER customer identification number for a customer of a customer</value>
    [DataMember(Name="SubCustomerNumber", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "SubCustomerNumber")]
    public int? SubCustomerNumber { get; set; }

    /// <summary>
    /// File creation date (UTC)
    /// </summary>
    /// <value>File creation date (UTC)</value>
    [DataMember(Name="Remarks", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "Remarks")]
    public string Remarks { get; set; }

    /// <summary>
    /// KELLER product serial number
    /// </summary>
    /// <value>KELLER product serial number</value>
    [DataMember(Name="SerialNumber", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "SerialNumber")]
    public string SerialNumber { get; set; }

    /// <summary>
    /// KELLER product number
    /// </summary>
    /// <value>KELLER product number</value>
    [DataMember(Name="ProductNumber", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "ProductNumber")]
    public string ProductNumber { get; set; }

    /// <summary>
    /// KELLER product type
    /// </summary>
    /// <value>KELLER product type</value>
    [DataMember(Name="ProductType", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "ProductType")]
    public string ProductType { get; set; }

    /// <summary>
    /// KELLER product pressure type
    /// </summary>
    /// <value>KELLER product pressure type</value>
    [DataMember(Name="PressureType", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "PressureType")]
    public string PressureType { get; set; }

    /// <summary>
    /// KELLER product series
    /// </summary>
    /// <value>KELLER product series</value>
    [DataMember(Name="ProductSeries", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "ProductSeries")]
    public string ProductSeries { get; set; }

    /// <summary>
    /// Temperature range over which the sensors characteristics have been compensated  Min
    /// </summary>
    /// <value>Temperature range over which the sensors characteristics have been compensated  Min</value>
    [DataMember(Name="CompensatedTemperatureRangeMin", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "CompensatedTemperatureRangeMin")]
    public double? CompensatedTemperatureRangeMin { get; set; }

    /// <summary>
    /// Temperature range over which the sensors characteristics have been compensated  Max
    /// </summary>
    /// <value>Temperature range over which the sensors characteristics have been compensated  Max</value>
    [DataMember(Name="CompensatedTemperatureRangeMax", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "CompensatedTemperatureRangeMax")]
    public double? CompensatedTemperatureRangeMax { get; set; }

    /// <summary>
    /// Temperature range over which the sensors characteristics have been compensated  Unit
    /// </summary>
    /// <value>Temperature range over which the sensors characteristics have been compensated  Unit</value>
    [DataMember(Name="CompensatedTemperatureRangeUnit", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "CompensatedTemperatureRangeUnit")]
    public string CompensatedTemperatureRangeUnit { get; set; }

    /// <summary>
    /// Pressure range over which the sensors characteristics have been compensated  Min
    /// </summary>
    /// <value>Pressure range over which the sensors characteristics have been compensated  Min</value>
    [DataMember(Name="CompensatedPressureRangeMin", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "CompensatedPressureRangeMin")]
    public double? CompensatedPressureRangeMin { get; set; }

    /// <summary>
    /// Pressure range over which the sensors characteristics have been compensated  Max
    /// </summary>
    /// <value>Pressure range over which the sensors characteristics have been compensated  Max</value>
    [DataMember(Name="CompensatedPressureRangeMax", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "CompensatedPressureRangeMax")]
    public double? CompensatedPressureRangeMax { get; set; }

    /// <summary>
    /// Pressure range over which the sensors characteristics have been compensated  Unit
    /// </summary>
    /// <value>Pressure range over which the sensors characteristics have been compensated  Unit</value>
    [DataMember(Name="CompensatedPressureRangeUnit", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "CompensatedPressureRangeUnit")]
    public string CompensatedPressureRangeUnit { get; set; }

    /// <summary>
    /// Nominal electric supply  Min
    /// </summary>
    /// <value>Nominal electric supply  Min</value>
    [DataMember(Name="ElectricSupplyMin", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "ElectricSupplyMin")]
    public double? ElectricSupplyMin { get; set; }

    /// <summary>
    /// Nominal electric supply  Max
    /// </summary>
    /// <value>Nominal electric supply  Max</value>
    [DataMember(Name="ElectricSupplyMax", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "ElectricSupplyMax")]
    public double? ElectricSupplyMax { get; set; }

    /// <summary>
    /// Nominal electric supply  Magnitude
    /// </summary>
    /// <value>Nominal electric supply  Magnitude</value>
    [DataMember(Name="ElectricSupplyMagnitude", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "ElectricSupplyMagnitude")]
    public double? ElectricSupplyMagnitude { get; set; }

    /// <summary>
    /// Nominal electric supply  Unit
    /// </summary>
    /// <value>Nominal electric supply  Unit</value>
    [DataMember(Name="ElectricSupplyUnit", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "ElectricSupplyUnit")]
    public string ElectricSupplyUnit { get; set; }

    /// <summary>
    /// KELLER purchase order number
    /// </summary>
    /// <value>KELLER purchase order number</value>
    [DataMember(Name="OrderNumber", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "OrderNumber")]
    public int? OrderNumber { get; set; }

    /// <summary>
    /// KELLER purchase order position
    /// </summary>
    /// <value>KELLER purchase order position</value>
    [DataMember(Name="OrderPosition", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "OrderPosition")]
    public int? OrderPosition { get; set; }

    /// <summary>
    /// Targeted dispatch date of the order
    /// </summary>
    /// <value>Targeted dispatch date of the order</value>
    [DataMember(Name="OrderTargetDispatchDate", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "OrderTargetDispatchDate")]
    public DateTime? OrderTargetDispatchDate { get; set; }

    /// <summary>
    /// Customer internal purchase order number
    /// </summary>
    /// <value>Customer internal purchase order number</value>
    [DataMember(Name="CustomerOrderNumber", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "CustomerOrderNumber")]
    public string CustomerOrderNumber { get; set; }

    /// <summary>
    /// Customer internal reference number
    /// </summary>
    /// <value>Customer internal reference number</value>
    [DataMember(Name="CustomerReferenceNumber", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "CustomerReferenceNumber")]
    public string CustomerReferenceNumber { get; set; }

    /// <summary>
    /// Customer internal product type
    /// </summary>
    /// <value>Customer internal product type</value>
    [DataMember(Name="CustomerProductType", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "CustomerProductType")]
    public string CustomerProductType { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class MefistoViewModel {\n");
      sb.Append("  Id: ").Append(Id).Append("\n");
      sb.Append("  CustomerName: ").Append(CustomerName).Append("\n");
      sb.Append("  CustomerNumber: ").Append(CustomerNumber).Append("\n");
      sb.Append("  SubCustomerNumber: ").Append(SubCustomerNumber).Append("\n");
      sb.Append("  Remarks: ").Append(Remarks).Append("\n");
      sb.Append("  SerialNumber: ").Append(SerialNumber).Append("\n");
      sb.Append("  ProductNumber: ").Append(ProductNumber).Append("\n");
      sb.Append("  ProductType: ").Append(ProductType).Append("\n");
      sb.Append("  PressureType: ").Append(PressureType).Append("\n");
      sb.Append("  ProductSeries: ").Append(ProductSeries).Append("\n");
      sb.Append("  CompensatedTemperatureRangeMin: ").Append(CompensatedTemperatureRangeMin).Append("\n");
      sb.Append("  CompensatedTemperatureRangeMax: ").Append(CompensatedTemperatureRangeMax).Append("\n");
      sb.Append("  CompensatedTemperatureRangeUnit: ").Append(CompensatedTemperatureRangeUnit).Append("\n");
      sb.Append("  CompensatedPressureRangeMin: ").Append(CompensatedPressureRangeMin).Append("\n");
      sb.Append("  CompensatedPressureRangeMax: ").Append(CompensatedPressureRangeMax).Append("\n");
      sb.Append("  CompensatedPressureRangeUnit: ").Append(CompensatedPressureRangeUnit).Append("\n");
      sb.Append("  ElectricSupplyMin: ").Append(ElectricSupplyMin).Append("\n");
      sb.Append("  ElectricSupplyMax: ").Append(ElectricSupplyMax).Append("\n");
      sb.Append("  ElectricSupplyMagnitude: ").Append(ElectricSupplyMagnitude).Append("\n");
      sb.Append("  ElectricSupplyUnit: ").Append(ElectricSupplyUnit).Append("\n");
      sb.Append("  OrderNumber: ").Append(OrderNumber).Append("\n");
      sb.Append("  OrderPosition: ").Append(OrderPosition).Append("\n");
      sb.Append("  OrderTargetDispatchDate: ").Append(OrderTargetDispatchDate).Append("\n");
      sb.Append("  CustomerOrderNumber: ").Append(CustomerOrderNumber).Append("\n");
      sb.Append("  CustomerReferenceNumber: ").Append(CustomerReferenceNumber).Append("\n");
      sb.Append("  CustomerProductType: ").Append(CustomerProductType).Append("\n");
      sb.Append("}\n");
      return sb.ToString();
    }

    /// <summary>
    /// Get the JSON string presentation of the object
    /// </summary>
    /// <returns>JSON string presentation of the object</returns>
    public string ToJson() {
      return JsonConvert.SerializeObject(this, Formatting.Indented);
    }

}
}
