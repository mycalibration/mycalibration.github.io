using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Model {

  /// <summary>
  /// One measurement point
  /// </summary>
  [DataContract]
  public class Measurement {
    /// <summary>
    /// Gets or Sets Reference
    /// </summary>
    [DataMember(Name="Reference", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "Reference")]
    public string Reference { get; set; }

    /// <summary>
    /// Gets or Sets EnvironmentTarget
    /// </summary>
    [DataMember(Name="EnvironmentTarget", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "EnvironmentTarget")]
    public Dictionary<string, PhysicalQuantity> EnvironmentTarget { get; set; }

    /// <summary>
    /// Gets or Sets Environment
    /// </summary>
    [DataMember(Name="Environment", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "Environment")]
    public Dictionary<string, PhysicalQuantity> Environment { get; set; }

    /// <summary>
    /// Gets or Sets Raw
    /// </summary>
    [DataMember(Name="Raw", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "Raw")]
    public Dictionary<string, PhysicalQuantity> Raw { get; set; }

    /// <summary>
    /// Gets or Sets Compensated
    /// </summary>
    [DataMember(Name="Compensated", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "Compensated")]
    public MeasurementCompensated Compensated { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class Measurement {\n");
      sb.Append("  Reference: ").Append(Reference).Append("\n");
      sb.Append("  EnvironmentTarget: ").Append(EnvironmentTarget).Append("\n");
      sb.Append("  Environment: ").Append(Environment).Append("\n");
      sb.Append("  Raw: ").Append(Raw).Append("\n");
      sb.Append("  Compensated: ").Append(Compensated).Append("\n");
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
