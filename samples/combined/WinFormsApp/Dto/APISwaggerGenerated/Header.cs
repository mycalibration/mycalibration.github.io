using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Model {

  /// <summary>
  /// Header data
  /// </summary>
  [DataContract]
  public class Header {
    /// <summary>
    /// File creation date
    /// </summary>
    /// <value>File creation date</value>
    [DataMember(Name="CreationDate", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "CreationDate")]
    public DateTime? CreationDate { get; set; }

    /// <summary>
    /// Gets or Sets Remarks
    /// </summary>
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
    /// Gets or Sets PressureType
    /// </summary>
    [DataMember(Name="PressureType", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "PressureType")]
    public PressureType PressureType { get; set; }

    /// <summary>
    /// KELLER product series
    /// </summary>
    /// <value>KELLER product series</value>
    [DataMember(Name="ProductSeries", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "ProductSeries")]
    public string ProductSeries { get; set; }

    /// <summary>
    /// Gets or Sets CompensatedTemperatureRange
    /// </summary>
    [DataMember(Name="CompensatedTemperatureRange", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "CompensatedTemperatureRange")]
    public PhysicalQuantityRange CompensatedTemperatureRange { get; set; }

    /// <summary>
    /// Gets or Sets CompensatedPressureRange
    /// </summary>
    [DataMember(Name="CompensatedPressureRange", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "CompensatedPressureRange")]
    public PhysicalQuantityRange CompensatedPressureRange { get; set; }

    /// <summary>
    /// Gets or Sets ElectricSupply
    /// </summary>
    [DataMember(Name="ElectricSupply", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "ElectricSupply")]
    public HeaderElectricSupply ElectricSupply { get; set; }

    /// <summary>
    /// KELLER purchase order number
    /// </summary>
    /// <value>KELLER purchase order number</value>
    [DataMember(Name="OrderNumber", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "OrderNumber")]
    public long? OrderNumber { get; set; }

    /// <summary>
    /// KELLER purchase order position
    /// </summary>
    /// <value>KELLER purchase order position</value>
    [DataMember(Name="OrderPosition", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "OrderPosition")]
    public long? OrderPosition { get; set; }

    /// <summary>
    /// Targeted dispatch date of the order
    /// </summary>
    /// <value>Targeted dispatch date of the order</value>
    [DataMember(Name="OrderTargetDispatchDate", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "OrderTargetDispatchDate")]
    public DateTime? OrderTargetDispatchDate { get; set; }

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
    public long? CustomerNumber { get; set; }

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
      sb.Append("class Header {\n");
      sb.Append("  CreationDate: ").Append(CreationDate).Append("\n");
      sb.Append("  Remarks: ").Append(Remarks).Append("\n");
      sb.Append("  SerialNumber: ").Append(SerialNumber).Append("\n");
      sb.Append("  ProductNumber: ").Append(ProductNumber).Append("\n");
      sb.Append("  ProductType: ").Append(ProductType).Append("\n");
      sb.Append("  PressureType: ").Append(PressureType).Append("\n");
      sb.Append("  ProductSeries: ").Append(ProductSeries).Append("\n");
      sb.Append("  CompensatedTemperatureRange: ").Append(CompensatedTemperatureRange).Append("\n");
      sb.Append("  CompensatedPressureRange: ").Append(CompensatedPressureRange).Append("\n");
      sb.Append("  ElectricSupply: ").Append(ElectricSupply).Append("\n");
      sb.Append("  OrderNumber: ").Append(OrderNumber).Append("\n");
      sb.Append("  OrderPosition: ").Append(OrderPosition).Append("\n");
      sb.Append("  OrderTargetDispatchDate: ").Append(OrderTargetDispatchDate).Append("\n");
      sb.Append("  CustomerName: ").Append(CustomerName).Append("\n");
      sb.Append("  CustomerNumber: ").Append(CustomerNumber).Append("\n");
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
