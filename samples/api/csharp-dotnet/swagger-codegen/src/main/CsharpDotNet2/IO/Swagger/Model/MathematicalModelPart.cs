using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Model {

  /// <summary>
  /// Part of mathematical compensation model that generates of compensated output
  /// </summary>
  [DataContract]
  public class MathematicalModelPart {
    /// <summary>
    /// Input variables of the model part
    /// </summary>
    /// <value>Input variables of the model part</value>
    [DataMember(Name="Inputs", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "Inputs")]
    public List<string> Inputs { get; set; }

    /// <summary>
    /// Output variable of the model part
    /// </summary>
    /// <value>Output variable of the model part</value>
    [DataMember(Name="Output", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "Output")]
    public string Output { get; set; }

    /// <summary>
    /// Gets or Sets Description
    /// </summary>
    [DataMember(Name="Description", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "Description")]
    public string Description { get; set; }

    /// <summary>
    /// Gets or Sets Coefficients
    /// </summary>
    [DataMember(Name="Coefficients", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "Coefficients")]
    public List<List<double?>> Coefficients { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class MathematicalModelPart {\n");
      sb.Append("  Inputs: ").Append(Inputs).Append("\n");
      sb.Append("  Output: ").Append(Output).Append("\n");
      sb.Append("  Description: ").Append(Description).Append("\n");
      sb.Append("  Coefficients: ").Append(Coefficients).Append("\n");
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
