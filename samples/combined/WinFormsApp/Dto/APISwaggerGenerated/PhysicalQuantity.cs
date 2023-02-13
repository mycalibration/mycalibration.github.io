using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Model {

  /// <summary>
  /// Nominal electric supply of the mathematical compensation model                Physical quantity consisting of a magnitude and a unit of measurement
  /// </summary>
  [DataContract]
  public class PhysicalQuantity {
    /// <summary>
    /// Gets or Sets Magnitude
    /// </summary>
    [DataMember(Name="Magnitude", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "Magnitude")]
    public double? Magnitude { get; set; }

    /// <summary>
    /// Gets or Sets Unit
    /// </summary>
    [DataMember(Name="Unit", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "Unit")]
    public PhysicalUnit Unit { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class PhysicalQuantity {\n");
      sb.Append("  Magnitude: ").Append(Magnitude).Append("\n");
      sb.Append("  Unit: ").Append(Unit).Append("\n");
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
