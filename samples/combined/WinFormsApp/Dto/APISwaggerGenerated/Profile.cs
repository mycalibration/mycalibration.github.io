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
  public class Profile {
    /// <summary>
    /// Gets or Sets CompanyName
    /// </summary>
    [DataMember(Name="CompanyName", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "CompanyName")]
    public string CompanyName { get; set; }

    /// <summary>
    /// Gets or Sets Role
    /// </summary>
    [DataMember(Name="Role", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "Role")]
    public string Role { get; set; }

    /// <summary>
    /// Gets or Sets DownloadFormat
    /// </summary>
    [DataMember(Name="DownloadFormat", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "DownloadFormat")]
    public string DownloadFormat { get; set; }

    /// <summary>
    /// Gets or Sets PermanentToken
    /// </summary>
    [DataMember(Name="PermanentToken", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "PermanentToken")]
    public string PermanentToken { get; set; }

    /// <summary>
    /// Gets or Sets ShowSubCustomer
    /// </summary>
    [DataMember(Name="ShowSubCustomer", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "ShowSubCustomer")]
    public bool? ShowSubCustomer { get; set; }

    /// <summary>
    /// Gets or Sets SubCustomers
    /// </summary>
    [DataMember(Name="SubCustomers", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "SubCustomers")]
    public List<string> SubCustomers { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class Profile {\n");
      sb.Append("  CompanyName: ").Append(CompanyName).Append("\n");
      sb.Append("  Role: ").Append(Role).Append("\n");
      sb.Append("  DownloadFormat: ").Append(DownloadFormat).Append("\n");
      sb.Append("  PermanentToken: ").Append(PermanentToken).Append("\n");
      sb.Append("  ShowSubCustomer: ").Append(ShowSubCustomer).Append("\n");
      sb.Append("  SubCustomers: ").Append(SubCustomers).Append("\n");
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
