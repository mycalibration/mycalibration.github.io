using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Model {

  /// <summary>
  /// Nominal electric supply                Nominal electric supply of the mathematical compensation model                Physical quantity consisting of a magnitude and a unit of measurement                Pressure range of the mathematical compensation model                Range of physical quantities consisting of a minimum and maximum magnitude and a unit of  measurement                Temperature range of the mathematical compensation model                Pressure range over which the sensors characteristics have been compensated                Temperature range over which the sensors characteristics have been compensated
  /// </summary>
  [DataContract]
  public class HeaderElectricSupply {
    /// <summary>
    /// Gets or Sets Min
    /// </summary>
    [DataMember(Name="Min", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "Min")]
    public double? Min { get; set; }

    /// <summary>
    /// Gets or Sets Max
    /// </summary>
    [DataMember(Name="Max", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "Max")]
    public double? Max { get; set; }

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
      sb.Append("class HeaderElectricSupply {\n");
      sb.Append("  Min: ").Append(Min).Append("\n");
      sb.Append("  Max: ").Append(Max).Append("\n");
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
