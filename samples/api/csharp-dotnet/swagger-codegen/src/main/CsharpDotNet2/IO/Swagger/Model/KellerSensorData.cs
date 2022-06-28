using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Model {

  /// <summary>
  /// JSON Schema for KELLER sensor calibration data
  /// </summary>
  [DataContract]
  public class KellerSensorData {
    /// <summary>
    /// Version of the corresponding JSON Schema
    /// </summary>
    /// <value>Version of the corresponding JSON Schema</value>
    [DataMember(Name="Version", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "Version")]
    public string Version { get; set; }

    /// <summary>
    /// Gets or Sets Header
    /// </summary>
    [DataMember(Name="Header", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "Header")]
    public Header Header { get; set; }

    /// <summary>
    /// Gets or Sets CompensationMethods
    /// </summary>
    [DataMember(Name="CompensationMethods", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "CompensationMethods")]
    public CompensationMethods CompensationMethods { get; set; }

    /// <summary>
    /// Array of individual measurements. Item order corresponds to order in measurement sequence.
    /// </summary>
    /// <value>Array of individual measurements. Item order corresponds to order in measurement sequence.</value>
    [DataMember(Name="Measurements", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "Measurements")]
    public List<Measurement> Measurements { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class KellerSensorData {\n");
      sb.Append("  Version: ").Append(Version).Append("\n");
      sb.Append("  Header: ").Append(Header).Append("\n");
      sb.Append("  CompensationMethods: ").Append(CompensationMethods).Append("\n");
      sb.Append("  Measurements: ").Append(Measurements).Append("\n");
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
