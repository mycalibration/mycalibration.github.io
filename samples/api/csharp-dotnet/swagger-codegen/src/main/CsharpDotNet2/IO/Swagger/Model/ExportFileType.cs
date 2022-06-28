using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Model {

  /// <summary>
  /// 1 &#x3D; All calibration data items will be merged in one JSON list  2 &#x3D; All calibration data items will be merged in one JSON list. This JSON file will be compressed to zip file  3 &#x3D; Every calibration data items will stored as JSON file. All these files will be compressed to one single zip file  4 &#x3D; Every calibration data items will stored as JSON file. All these files will be compressed to one single brotli file
  /// </summary>
  [DataContract]
  public class ExportFileType {

    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class ExportFileType {\n");
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
