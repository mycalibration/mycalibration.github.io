using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Model {

  /// <summary>
  /// Compensated measurement data by different compensation methods
  /// </summary>
  [DataContract]
  public class MeasurementCompensated {
    /// <summary>
    /// Gets or Sets MathematicalModels
    /// </summary>
    [DataMember(Name="MathematicalModels", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "MathematicalModels")]
    public Dictionary<string, Dictionary<string, MeasurementCompensatedMathematicalModelPart>> MathematicalModels { get; set; }

    /// <summary>
    /// Gets or Sets CompensationCircuitOutputs
    /// </summary>
    [DataMember(Name="CompensationCircuitOutputs", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "CompensationCircuitOutputs")]
    public Dictionary<string, CompensationCircuitOutputValue> CompensationCircuitOutputs { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class MeasurementCompensated {\n");
      sb.Append("  MathematicalModels: ").Append(MathematicalModels).Append("\n");
      sb.Append("  CompensationCircuitOutputs: ").Append(CompensationCircuitOutputs).Append("\n");
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
