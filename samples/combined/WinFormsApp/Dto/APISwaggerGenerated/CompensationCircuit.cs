using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Model {

  /// <summary>
  /// Compensation circuit
  /// </summary>
  [DataContract]
  public class CompensationCircuit {
    /// <summary>
    /// Outputs of the compensation circuit
    /// </summary>
    /// <value>Outputs of the compensation circuit</value>
    [DataMember(Name="Outputs", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "Outputs")]
    public Dictionary<string, CompensationCircuitOutput> Outputs { get; set; }

    /// <summary>
    /// Gets or Sets Description
    /// </summary>
    [DataMember(Name="Description", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "Description")]
    public string Description { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class CompensationCircuit {\n");
      sb.Append("  Outputs: ").Append(Outputs).Append("\n");
      sb.Append("  Description: ").Append(Description).Append("\n");
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
