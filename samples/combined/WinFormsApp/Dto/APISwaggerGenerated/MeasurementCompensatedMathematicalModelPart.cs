using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Model {

  /// <summary>
  /// Compensated measurement data by a part of a mathematical compensation model
  /// </summary>
  [DataContract]
  public class MeasurementCompensatedMathematicalModelPart {
    /// <summary>
    /// Gets or Sets Output
    /// </summary>
    [DataMember(Name="Output", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "Output")]
    public PhysicalQuantity Output { get; set; }

    /// <summary>
    /// Gets or Sets Error
    /// </summary>
    [DataMember(Name="Error", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "Error")]
    public PhysicalQuantity Error { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class MeasurementCompensatedMathematicalModelPart {\n");
      sb.Append("  Output: ").Append(Output).Append("\n");
      sb.Append("  Error: ").Append(Error).Append("\n");
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
