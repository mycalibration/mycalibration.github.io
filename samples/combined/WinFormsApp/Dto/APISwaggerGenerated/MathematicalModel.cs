using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Model {

  /// <summary>
  /// A mathematical compensation model
  /// </summary>
  [DataContract]
  public class MathematicalModel {
    /// <summary>
    /// Gets or Sets ModelType
    /// </summary>
    [DataMember(Name="ModelType", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "ModelType")]
    public string ModelType { get; set; }

    /// <summary>
    /// Gets or Sets ProductNumber
    /// </summary>
    [DataMember(Name="ProductNumber", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "ProductNumber")]
    public string ProductNumber { get; set; }

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
    public PhysicalQuantity ElectricSupply { get; set; }

    /// <summary>
    /// Gets or Sets Parts
    /// </summary>
    [DataMember(Name="Parts", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "Parts")]
    public Dictionary<string, MathematicalModelPart> Parts { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class MathematicalModel {\n");
      sb.Append("  ModelType: ").Append(ModelType).Append("\n");
      sb.Append("  ProductNumber: ").Append(ProductNumber).Append("\n");
      sb.Append("  CompensatedTemperatureRange: ").Append(CompensatedTemperatureRange).Append("\n");
      sb.Append("  CompensatedPressureRange: ").Append(CompensatedPressureRange).Append("\n");
      sb.Append("  ElectricSupply: ").Append(ElectricSupply).Append("\n");
      sb.Append("  Parts: ").Append(Parts).Append("\n");
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
