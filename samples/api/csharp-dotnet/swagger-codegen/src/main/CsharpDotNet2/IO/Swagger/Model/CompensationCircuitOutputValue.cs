using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Model {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class CompensationCircuitOutputValue {
    /// <summary>
    /// Gets or Sets MeasuredValue
    /// </summary>
    [DataMember(Name="MeasuredValue", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "MeasuredValue")]
    public PhysicalQuantity MeasuredValue { get; set; }

    /// <summary>
    /// Gets or Sets NominalValue
    /// </summary>
    [DataMember(Name="NominalValue", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "NominalValue")]
    public PhysicalQuantity NominalValue { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class CompensationCircuitOutputValue {\n");
      sb.Append("  MeasuredValue: ").Append(MeasuredValue).Append("\n");
      sb.Append("  NominalValue: ").Append(NominalValue).Append("\n");
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
