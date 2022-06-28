using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Model {

  /// <summary>
  /// Information on different compensation methods
  /// </summary>
  [DataContract]
  public class CompensationMethods {
    /// <summary>
    /// Gets or Sets MathematicalModels
    /// </summary>
    [DataMember(Name="MathematicalModels", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "MathematicalModels")]
    public Dictionary<string, MathematicalModel> MathematicalModels { get; set; }

    /// <summary>
    /// Gets or Sets CompensationCircuit
    /// </summary>
    [DataMember(Name="CompensationCircuit", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "CompensationCircuit")]
    public CompensationCircuit CompensationCircuit { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class CompensationMethods {\n");
      sb.Append("  MathematicalModels: ").Append(MathematicalModels).Append("\n");
      sb.Append("  CompensationCircuit: ").Append(CompensationCircuit).Append("\n");
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
