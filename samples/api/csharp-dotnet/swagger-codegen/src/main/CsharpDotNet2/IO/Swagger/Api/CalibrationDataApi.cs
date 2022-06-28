using System;
using System.Collections.Generic;
using RestSharp;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace IO.Swagger.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface ICalibrationDataApi
    {
        /// <summary>
        /// Gathers all filtered data in one JSON response 
        /// </summary>
        /// <param name="includedIds">If null: Either are &#x27;ALL SELECTED&#x27; or some are unselected (and listed in ExcludedIds)&lt;br /&gt;  If not null: None are selected except those that are listed here.&lt;br /&gt;  It is not allowed to have IncludedIds AND ExcludedIds have listed values. One most be null or both most be null.&lt;br /&gt;  The list of included ids is limited to 50. More than 50 will throw an exception.&lt;br /&gt;</param>
        /// <param name="excludedIds">If null: Either are &#x27;ALL SELECTED&#x27; or only some few are selected (and listed in IncludedIds)&lt;br /&gt;  If not null: All are selected and except those that are listed here.&lt;br /&gt;  It is not allowed to have IncludedIds AND ExcludedIds have listed values. One most be null or both most be null.&lt;br /&gt;  The list of excluded ids is limited to 50. More than 50 will throw an exception.&lt;br /&gt;</param>
        /// <param name="orderNumbers">List of Order Numbers</param>
        /// <param name="orderPositions">List of Order Positions</param>
        /// <param name="dateFilterType">One of &#x27;equals&#x27;, &#x27;greaterThan&#x27;, &#x27;lessThan&#x27;, &#x27;notEqual&#x27;, &#x27;inRange&#x27;.&lt;br /&gt;  When &#x27;inRange&#x27; then &#x27;DateTo&#x27; is needed.&lt;br /&gt;  Example 1:&lt;br /&gt;  \&quot;All data newer than August 1st\&quot; &#x3D; https://mycalibrationapi.azurewebsites.net/v1/CalibrationData?DateFilterType&#x3D;greaterThan&amp;Date&#x3D;2021-08-01&lt;br /&gt;  Example 2:&lt;br /&gt;  \&quot;All data from the year 2020\&quot; &#x3D; https://mycalibrationapi.azurewebsites.net/v1/CalibrationData?DateFilterType&#x3D;inRange&amp;Date&#x3D;2021-01-01&amp;DateTo&#x3D;2021-12-31 &lt;br /&gt;  Example 3:&lt;br /&gt;  \&quot;All data from the first day in January and February\&quot; &#x3D; https://mycalibrationapi.azurewebsites.net/v1/CalibrationData?DateFilterType&#x3D;equals&amp;Date&#x3D;2021-01-01&amp;Date&#x3D;2021-02-01 &lt;br /&gt;</param>
        /// <param name="date">Dispatch-date text in format &#x27;yyyy-MM-dd&#x27; eg. \&quot;2021-12-24\&quot;&lt;br /&gt;  Normally, this is a list with one element. Nevertheless, it is possible to GET calibration data from multiple dates. In this case DateFilterType must be &#x27;equals&#x27; and DateTo must be null.</param>
        /// <param name="dateTo">Used when DateFilterType is &#x27;inRange&#x27;.&lt;br /&gt;  Data is gathered from &#x27;Date&#x27; to &#x27;DateTo&#x27;&lt;br /&gt;  Date text in format &#x27;yyyy-MM-dd&#x27; eg. \&quot;2021-12-24\&quot;</param>
        /// <param name="customerProductTypes">To search for [Blanks] use \&quot;blank\&quot;</param>
        /// <param name="pressureTypes">Eg. [\&quot;pa\&quot;,\&quot;paa\&quot;,\&quot;pr\&quot;]  To see all possible enum strings, go to https://mycalibration.github.io/#filter-parameters</param>
        /// <param name="productSeries">Eg. [\&quot;10LHP\&quot;,\&quot;25Y\&quot;,\&quot;46X\&quot;,\&quot;K-102\&quot;]</param>
        /// <param name="productNumbers"></param>
        /// <param name="serialNumberSearchText">Use this to find all SerialNumbers that contains this text content.</param>
        /// <param name="pressureMinFilterType">One of &#x27;equals&#x27;, &#x27;greaterThan&#x27;, &#x27;lessThan&#x27;, &#x27;notEqual&#x27;, &#x27;inRange&#x27;, &#x27;lessThanOrEqual&#x27;, &#x27;greaterThanOrEqual&#x27;.&lt;br /&gt;  When &#x27;inRange&#x27; then &#x27;PressureMinTo&#x27; is needed.</param>
        /// <param name="pressureMin">The exclusive lower bound of the \&quot;Minimum Pressure\&quot;</param>
        /// <param name="pressureMinTo">The exclusive upper bound of the \&quot;Minimum Pressure\&quot;.&lt;br /&gt;  Used when PressureMinFilterType is &#x27;inRange&#x27;.&lt;br /&gt;  Data is gathered from &#x27;PressureMin&#x27; to &#x27;PressureMinTo&#x27;.&lt;br /&gt;  Date text in format &#x27;yyyy-MM-dd&#x27; eg. \&quot;2021-12-24\&quot;&lt;br /&gt;</param>
        /// <param name="pressureMaxFilterType">One of &#x27;equals&#x27;, &#x27;greaterThan&#x27;, &#x27;lessThan&#x27;, &#x27;notEqual&#x27;, &#x27;inRange&#x27;, &#x27;lessThanOrEqual&#x27;, &#x27;greaterThanOrEqual&#x27;.&lt;br /&gt;  When &#x27;inRange&#x27; then &#x27;PressureMaxTo&#x27; is needed.</param>
        /// <param name="pressureMax">The exclusive lower bound of the \&quot;Maximum Pressure\&quot;</param>
        /// <param name="pressureMaxTo">The exclusive upper bound of the \&quot;Maximum Pressure\&quot;&lt;br /&gt;  Used when PressureMaxFilterType is &#x27;inRange&#x27;.&lt;br /&gt;  Data is gathered from &#x27;PressureMax&#x27; to &#x27;PressureMaxTo&#x27;&lt;br /&gt;  Date text in format &#x27;yyyy-MM-dd&#x27; eg. \&quot;2021-12-24\&quot;</param>
        /// <param name="pressureUnit">&lt;list type&#x3D;\&quot;string\&quot;&gt;List of the Pressure Unit&lt;/list&gt;</param>
        /// <param name="temperatureMinFilterType">One of &#x27;equals&#x27;, &#x27;greaterThan&#x27;, &#x27;lessThan&#x27;, &#x27;notEqual&#x27;, &#x27;inRange&#x27;, &#x27;lessThanOrEqual&#x27;, &#x27;greaterThanOrEqual&#x27;.&lt;br /&gt;  When &#x27;inRange&#x27; then &#x27;TemperatureMinTo&#x27; is needed.</param>
        /// <param name="temperatureMin">The exclusive lower bound of the \&quot;Minimum Temperature\&quot;</param>
        /// <param name="temperatureMinTo">The exclusive upper bound of the \&quot;Minimum Temperature\&quot;&lt;br /&gt;  Used when TemperatureMinFilterType is &#x27;inRange&#x27;.&lt;br /&gt;  Data is gathered from &#x27;TemperatureMin&#x27; to &#x27;TemperatureMinTo&#x27;&lt;br /&gt;  Date text in format &#x27;yyyy-MM-dd&#x27; eg. \&quot;2021-12-24\&quot;</param>
        /// <param name="temperatureMaxFilterType">One of &#x27;equals&#x27;, &#x27;greaterThan&#x27;, &#x27;lessThan&#x27;, &#x27;notEqual&#x27;, &#x27;inRange&#x27;, &#x27;lessThanOrEqual&#x27;, &#x27;greaterThanOrEqual&#x27;.&lt;br /&gt;  When &#x27;inRange&#x27; then &#x27;TemperatureMaxTo&#x27; is needed.</param>
        /// <param name="temperatureMax">The exclusive lower bound of the \&quot;Maximum Temperature\&quot;</param>
        /// <param name="temperatureMaxTo">The exclusive upper bound of the \&quot;Maximum Temperature\&quot;&lt;br /&gt;  Used when TemperatureMaxFilterType is &#x27;inRange&#x27;.&lt;br /&gt;  Data is gathered from &#x27;TemperatureMax&#x27; to &#x27;TemperatureMaxTo&#x27;&lt;br /&gt;  Date text in format &#x27;yyyy-MM-dd&#x27; eg. \&quot;2021-12-24\&quot;</param>
        /// <param name="temperatureUnit">&lt;list type&#x3D;\&quot;string\&quot;&gt;List of the Temperature Unit&lt;/list&gt;</param>
        /// <param name="supplyMinFilterType">One of &#x27;equals&#x27;, &#x27;greaterThan&#x27;, &#x27;lessThan&#x27;, &#x27;notEqual&#x27;, &#x27;inRange&#x27;, &#x27;lessThanOrEqual&#x27;, &#x27;greaterThanOrEqual&#x27;.&lt;br /&gt;  When &#x27;inRange&#x27; then &#x27;SupplyMinTo&#x27; is needed.&lt;br /&gt;  Either Min/Max is used or Magnitude.&lt;br /&gt;</param>
        /// <param name="supplyMin">The exclusive lower bound of the \&quot;Minimum Supply\&quot;&lt;br /&gt;  Either Min/Max is used or Magnitude.</param>
        /// <param name="supplyMinTo">The exclusive upper bound of the \&quot;Minimum Supply\&quot;&lt;br /&gt;  Used when SupplyMinFilterType is &#x27;inRange&#x27;.&lt;br /&gt;  Data is gathered from &#x27;SupplyMin&#x27; to &#x27;SupplyMinTo&#x27;&lt;br /&gt;  Date text in format &#x27;yyyy-MM-dd&#x27; eg. \&quot;2021-12-24\&quot;&lt;br /&gt;  Either Min/Max is used or Magnitude.</param>
        /// <param name="supplyMaxFilterType">One of &#x27;equals&#x27;, &#x27;greaterThan&#x27;, &#x27;lessThan&#x27;, &#x27;notEqual&#x27;, &#x27;inRange&#x27;, &#x27;lessThanOrEqual&#x27;, &#x27;greaterThanOrEqual&#x27;.&lt;br /&gt;  When &#x27;inRange&#x27; then &#x27;SupplyMaxTo&#x27; is needed.&lt;br /&gt;  Either Min/Max is used or Magnitude.</param>
        /// <param name="supplyMax">The exclusive lower bound of the \&quot;Maximum Supply\&quot;&lt;br /&gt;  Either Min/Max is used or Magnitude.</param>
        /// <param name="supplyMaxTo">The exclusive upper bound of the \&quot;Maximum Supply\&quot;&lt;br /&gt;  Used when SupplyMaxFilterType is &#x27;inRange&#x27;.&lt;br /&gt;  Data is gathered from &#x27;SupplyMax&#x27; to &#x27;SupplyMaxTo&#x27;&lt;br /&gt;  Date text in format &#x27;yyyy-MM-dd&#x27; eg. \&quot;2021-12-24\&quot;&lt;br /&gt;  Either Min/Max is used or Magnitude.</param>
        /// <param name="supplyMagnitudeFilterType">One of &#x27;equals&#x27;, &#x27;greaterThan&#x27;, &#x27;lessThan&#x27;, &#x27;notEqual&#x27;, &#x27;inRange&#x27;, &#x27;lessThanOrEqual&#x27;, &#x27;greaterThanOrEqual&#x27;.&lt;br /&gt;  When &#x27;inRange&#x27; then &#x27;SupplyMagnitudeTo&#x27; is needed.&lt;br /&gt;  Either Min/Max is used or Magnitude.</param>
        /// <param name="supplyMagnitude">The exclusive lower bound of the \&quot;Supply Magnitude\&quot;&lt;br /&gt;  Either Min/Max is used or Magnitude.</param>
        /// <param name="supplyMagnitudeTo">The exclusive upper bound of the \&quot;Supply Magnitude\&quot;&lt;br /&gt;  Used when SupplyMagnitudeFilterType is &#x27;inRange&#x27;.&lt;br /&gt;  Data is gathered from &#x27;SupplyMagnitude&#x27; to &#x27;SupplyMagnitudeTo&#x27;&lt;br /&gt;  Either Min/Max is used or Magnitude.</param>
        /// <param name="supplyUnit">&lt;list type&#x3D;\&quot;string\&quot;&gt;List of the Supply Unit&lt;/list&gt;</param>
        /// <param name="customerReferenceNumberSearchText">Find all data with contains this search text</param>
        /// <param name="customerOrderNumberSearchText">Find all data with contains this search text</param>
        /// <param name="remarksSearchText">Find all data with contains this search text</param>
        /// <returns>List&lt;KellerSensorData&gt;</returns>
        List<KellerSensorData> CalibrationDataGetCalibrationData (List<string> includedIds, List<string> excludedIds, List<string> orderNumbers, List<string> orderPositions, string dateFilterType, List<string> date, string dateTo, List<string> customerProductTypes, List<string> pressureTypes, List<string> productSeries, List<string> productNumbers, string serialNumberSearchText, string pressureMinFilterType, double? pressureMin, double? pressureMinTo, string pressureMaxFilterType, double? pressureMax, double? pressureMaxTo, List<string> pressureUnit, string temperatureMinFilterType, double? temperatureMin, double? temperatureMinTo, string temperatureMaxFilterType, double? temperatureMax, double? temperatureMaxTo, List<string> temperatureUnit, string supplyMinFilterType, double? supplyMin, double? supplyMinTo, string supplyMaxFilterType, double? supplyMax, double? supplyMaxTo, string supplyMagnitudeFilterType, double? supplyMagnitude, double? supplyMagnitudeTo, List<string> supplyUnit, string customerReferenceNumberSearchText, string customerOrderNumberSearchText, string remarksSearchText);
        /// <summary>
        /// Locates the filtered (optionalSearchParameter) data, bundles them and creates a download link 
        /// </summary>
        /// <param name="fileType">1 &#x3D; All calibration data items will be merged in one JSON list  2 &#x3D; All calibration data items will be merged in one JSON list. This JSON file will be compressed to zip file  3 &#x3D; Every calibration data items will stored as JSON file. All these files will be compressed to one single zip file  4 &#x3D; Every calibration data items will stored as JSON file. All these files will be compressed to one single brotli file</param>
        /// <param name="includedIds">If null: Either are &#x27;ALL SELECTED&#x27; or some are unselected (and listed in ExcludedIds)&lt;br /&gt;  If not null: None are selected except those that are listed here.&lt;br /&gt;  It is not allowed to have IncludedIds AND ExcludedIds have listed values. One most be null or both most be null.&lt;br /&gt;  The list of included ids is limited to 50. More than 50 will throw an exception.&lt;br /&gt;</param>
        /// <param name="excludedIds">If null: Either are &#x27;ALL SELECTED&#x27; or only some few are selected (and listed in IncludedIds)&lt;br /&gt;  If not null: All are selected and except those that are listed here.&lt;br /&gt;  It is not allowed to have IncludedIds AND ExcludedIds have listed values. One most be null or both most be null.&lt;br /&gt;  The list of excluded ids is limited to 50. More than 50 will throw an exception.&lt;br /&gt;</param>
        /// <param name="orderNumbers">List of Order Numbers</param>
        /// <param name="orderPositions">List of Order Positions</param>
        /// <param name="dateFilterType">One of &#x27;equals&#x27;, &#x27;greaterThan&#x27;, &#x27;lessThan&#x27;, &#x27;notEqual&#x27;, &#x27;inRange&#x27;.&lt;br /&gt;  When &#x27;inRange&#x27; then &#x27;DateTo&#x27; is needed.&lt;br /&gt;  Example 1:&lt;br /&gt;  \&quot;All data newer than August 1st\&quot; &#x3D; https://mycalibrationapi.azurewebsites.net/v1/CalibrationData?DateFilterType&#x3D;greaterThan&amp;Date&#x3D;2021-08-01&lt;br /&gt;  Example 2:&lt;br /&gt;  \&quot;All data from the year 2020\&quot; &#x3D; https://mycalibrationapi.azurewebsites.net/v1/CalibrationData?DateFilterType&#x3D;inRange&amp;Date&#x3D;2021-01-01&amp;DateTo&#x3D;2021-12-31 &lt;br /&gt;  Example 3:&lt;br /&gt;  \&quot;All data from the first day in January and February\&quot; &#x3D; https://mycalibrationapi.azurewebsites.net/v1/CalibrationData?DateFilterType&#x3D;equals&amp;Date&#x3D;2021-01-01&amp;Date&#x3D;2021-02-01 &lt;br /&gt;</param>
        /// <param name="date">Dispatch-date text in format &#x27;yyyy-MM-dd&#x27; eg. \&quot;2021-12-24\&quot;&lt;br /&gt;  Normally, this is a list with one element. Nevertheless, it is possible to GET calibration data from multiple dates. In this case DateFilterType must be &#x27;equals&#x27; and DateTo must be null.</param>
        /// <param name="dateTo">Used when DateFilterType is &#x27;inRange&#x27;.&lt;br /&gt;  Data is gathered from &#x27;Date&#x27; to &#x27;DateTo&#x27;&lt;br /&gt;  Date text in format &#x27;yyyy-MM-dd&#x27; eg. \&quot;2021-12-24\&quot;</param>
        /// <param name="customerProductTypes">To search for [Blanks] use \&quot;blank\&quot;</param>
        /// <param name="pressureTypes">Eg. [\&quot;pa\&quot;,\&quot;paa\&quot;,\&quot;pr\&quot;]  To see all possible enum strings, go to https://mycalibration.github.io/#filter-parameters</param>
        /// <param name="productSeries">Eg. [\&quot;10LHP\&quot;,\&quot;25Y\&quot;,\&quot;46X\&quot;,\&quot;K-102\&quot;]</param>
        /// <param name="productNumbers"></param>
        /// <param name="serialNumberSearchText">Use this to find all SerialNumbers that contains this text content.</param>
        /// <param name="pressureMinFilterType">One of &#x27;equals&#x27;, &#x27;greaterThan&#x27;, &#x27;lessThan&#x27;, &#x27;notEqual&#x27;, &#x27;inRange&#x27;, &#x27;lessThanOrEqual&#x27;, &#x27;greaterThanOrEqual&#x27;.&lt;br /&gt;  When &#x27;inRange&#x27; then &#x27;PressureMinTo&#x27; is needed.</param>
        /// <param name="pressureMin">The exclusive lower bound of the \&quot;Minimum Pressure\&quot;</param>
        /// <param name="pressureMinTo">The exclusive upper bound of the \&quot;Minimum Pressure\&quot;.&lt;br /&gt;  Used when PressureMinFilterType is &#x27;inRange&#x27;.&lt;br /&gt;  Data is gathered from &#x27;PressureMin&#x27; to &#x27;PressureMinTo&#x27;.&lt;br /&gt;  Date text in format &#x27;yyyy-MM-dd&#x27; eg. \&quot;2021-12-24\&quot;&lt;br /&gt;</param>
        /// <param name="pressureMaxFilterType">One of &#x27;equals&#x27;, &#x27;greaterThan&#x27;, &#x27;lessThan&#x27;, &#x27;notEqual&#x27;, &#x27;inRange&#x27;, &#x27;lessThanOrEqual&#x27;, &#x27;greaterThanOrEqual&#x27;.&lt;br /&gt;  When &#x27;inRange&#x27; then &#x27;PressureMaxTo&#x27; is needed.</param>
        /// <param name="pressureMax">The exclusive lower bound of the \&quot;Maximum Pressure\&quot;</param>
        /// <param name="pressureMaxTo">The exclusive upper bound of the \&quot;Maximum Pressure\&quot;&lt;br /&gt;  Used when PressureMaxFilterType is &#x27;inRange&#x27;.&lt;br /&gt;  Data is gathered from &#x27;PressureMax&#x27; to &#x27;PressureMaxTo&#x27;&lt;br /&gt;  Date text in format &#x27;yyyy-MM-dd&#x27; eg. \&quot;2021-12-24\&quot;</param>
        /// <param name="pressureUnit">&lt;list type&#x3D;\&quot;string\&quot;&gt;List of the Pressure Unit&lt;/list&gt;</param>
        /// <param name="temperatureMinFilterType">One of &#x27;equals&#x27;, &#x27;greaterThan&#x27;, &#x27;lessThan&#x27;, &#x27;notEqual&#x27;, &#x27;inRange&#x27;, &#x27;lessThanOrEqual&#x27;, &#x27;greaterThanOrEqual&#x27;.&lt;br /&gt;  When &#x27;inRange&#x27; then &#x27;TemperatureMinTo&#x27; is needed.</param>
        /// <param name="temperatureMin">The exclusive lower bound of the \&quot;Minimum Temperature\&quot;</param>
        /// <param name="temperatureMinTo">The exclusive upper bound of the \&quot;Minimum Temperature\&quot;&lt;br /&gt;  Used when TemperatureMinFilterType is &#x27;inRange&#x27;.&lt;br /&gt;  Data is gathered from &#x27;TemperatureMin&#x27; to &#x27;TemperatureMinTo&#x27;&lt;br /&gt;  Date text in format &#x27;yyyy-MM-dd&#x27; eg. \&quot;2021-12-24\&quot;</param>
        /// <param name="temperatureMaxFilterType">One of &#x27;equals&#x27;, &#x27;greaterThan&#x27;, &#x27;lessThan&#x27;, &#x27;notEqual&#x27;, &#x27;inRange&#x27;, &#x27;lessThanOrEqual&#x27;, &#x27;greaterThanOrEqual&#x27;.&lt;br /&gt;  When &#x27;inRange&#x27; then &#x27;TemperatureMaxTo&#x27; is needed.</param>
        /// <param name="temperatureMax">The exclusive lower bound of the \&quot;Maximum Temperature\&quot;</param>
        /// <param name="temperatureMaxTo">The exclusive upper bound of the \&quot;Maximum Temperature\&quot;&lt;br /&gt;  Used when TemperatureMaxFilterType is &#x27;inRange&#x27;.&lt;br /&gt;  Data is gathered from &#x27;TemperatureMax&#x27; to &#x27;TemperatureMaxTo&#x27;&lt;br /&gt;  Date text in format &#x27;yyyy-MM-dd&#x27; eg. \&quot;2021-12-24\&quot;</param>
        /// <param name="temperatureUnit">&lt;list type&#x3D;\&quot;string\&quot;&gt;List of the Temperature Unit&lt;/list&gt;</param>
        /// <param name="supplyMinFilterType">One of &#x27;equals&#x27;, &#x27;greaterThan&#x27;, &#x27;lessThan&#x27;, &#x27;notEqual&#x27;, &#x27;inRange&#x27;, &#x27;lessThanOrEqual&#x27;, &#x27;greaterThanOrEqual&#x27;.&lt;br /&gt;  When &#x27;inRange&#x27; then &#x27;SupplyMinTo&#x27; is needed.&lt;br /&gt;  Either Min/Max is used or Magnitude.&lt;br /&gt;</param>
        /// <param name="supplyMin">The exclusive lower bound of the \&quot;Minimum Supply\&quot;&lt;br /&gt;  Either Min/Max is used or Magnitude.</param>
        /// <param name="supplyMinTo">The exclusive upper bound of the \&quot;Minimum Supply\&quot;&lt;br /&gt;  Used when SupplyMinFilterType is &#x27;inRange&#x27;.&lt;br /&gt;  Data is gathered from &#x27;SupplyMin&#x27; to &#x27;SupplyMinTo&#x27;&lt;br /&gt;  Date text in format &#x27;yyyy-MM-dd&#x27; eg. \&quot;2021-12-24\&quot;&lt;br /&gt;  Either Min/Max is used or Magnitude.</param>
        /// <param name="supplyMaxFilterType">One of &#x27;equals&#x27;, &#x27;greaterThan&#x27;, &#x27;lessThan&#x27;, &#x27;notEqual&#x27;, &#x27;inRange&#x27;, &#x27;lessThanOrEqual&#x27;, &#x27;greaterThanOrEqual&#x27;.&lt;br /&gt;  When &#x27;inRange&#x27; then &#x27;SupplyMaxTo&#x27; is needed.&lt;br /&gt;  Either Min/Max is used or Magnitude.</param>
        /// <param name="supplyMax">The exclusive lower bound of the \&quot;Maximum Supply\&quot;&lt;br /&gt;  Either Min/Max is used or Magnitude.</param>
        /// <param name="supplyMaxTo">The exclusive upper bound of the \&quot;Maximum Supply\&quot;&lt;br /&gt;  Used when SupplyMaxFilterType is &#x27;inRange&#x27;.&lt;br /&gt;  Data is gathered from &#x27;SupplyMax&#x27; to &#x27;SupplyMaxTo&#x27;&lt;br /&gt;  Date text in format &#x27;yyyy-MM-dd&#x27; eg. \&quot;2021-12-24\&quot;&lt;br /&gt;  Either Min/Max is used or Magnitude.</param>
        /// <param name="supplyMagnitudeFilterType">One of &#x27;equals&#x27;, &#x27;greaterThan&#x27;, &#x27;lessThan&#x27;, &#x27;notEqual&#x27;, &#x27;inRange&#x27;, &#x27;lessThanOrEqual&#x27;, &#x27;greaterThanOrEqual&#x27;.&lt;br /&gt;  When &#x27;inRange&#x27; then &#x27;SupplyMagnitudeTo&#x27; is needed.&lt;br /&gt;  Either Min/Max is used or Magnitude.</param>
        /// <param name="supplyMagnitude">The exclusive lower bound of the \&quot;Supply Magnitude\&quot;&lt;br /&gt;  Either Min/Max is used or Magnitude.</param>
        /// <param name="supplyMagnitudeTo">The exclusive upper bound of the \&quot;Supply Magnitude\&quot;&lt;br /&gt;  Used when SupplyMagnitudeFilterType is &#x27;inRange&#x27;.&lt;br /&gt;  Data is gathered from &#x27;SupplyMagnitude&#x27; to &#x27;SupplyMagnitudeTo&#x27;&lt;br /&gt;  Either Min/Max is used or Magnitude.</param>
        /// <param name="supplyUnit">&lt;list type&#x3D;\&quot;string\&quot;&gt;List of the Supply Unit&lt;/list&gt;</param>
        /// <param name="customerReferenceNumberSearchText">Find all data with contains this search text</param>
        /// <param name="customerOrderNumberSearchText">Find all data with contains this search text</param>
        /// <param name="remarksSearchText">Find all data with contains this search text</param>
        /// <returns></returns>
        void CalibrationDataGetCalibrationDataAsFile (ExportFileType fileType, List<string> includedIds, List<string> excludedIds, List<string> orderNumbers, List<string> orderPositions, string dateFilterType, List<string> date, string dateTo, List<string> customerProductTypes, List<string> pressureTypes, List<string> productSeries, List<string> productNumbers, string serialNumberSearchText, string pressureMinFilterType, double? pressureMin, double? pressureMinTo, string pressureMaxFilterType, double? pressureMax, double? pressureMaxTo, List<string> pressureUnit, string temperatureMinFilterType, double? temperatureMin, double? temperatureMinTo, string temperatureMaxFilterType, double? temperatureMax, double? temperatureMaxTo, List<string> temperatureUnit, string supplyMinFilterType, double? supplyMin, double? supplyMinTo, string supplyMaxFilterType, double? supplyMax, double? supplyMaxTo, string supplyMagnitudeFilterType, double? supplyMagnitude, double? supplyMagnitudeTo, List<string> supplyUnit, string customerReferenceNumberSearchText, string customerOrderNumberSearchText, string remarksSearchText);
        /// <summary>
        /// Get a list with all meta-information. 
        /// </summary>
        /// <param name="skip">OPTIONAL. Skips the given number of rows. The opposite of Take.</param>
        /// <param name="take">OPTIONAL. Takes only the first .. rows of meta information. The opposite of Skip. When not specified the API tries to get all rows.</param>
        /// <returns>List&lt;MefistoViewModel&gt;</returns>
        List<MefistoViewModel> CalibrationDataGetCalibrationDataHeaders (int? skip, int? take);
        /// <summary>
        /// Only used for maintenance reasons. Do not use! 
        /// </summary>
        /// <returns>string</returns>
        string CalibrationDataSyncCalibrationData ();
        /// <summary>
        ///  
        /// </summary>
        /// <returns>int?</returns>
        int? MeGetMeDetails ();
        /// <summary>
        ///  
        /// </summary>
        /// <returns>Profile</returns>
        Profile ProfileGetProfile ();
        /// <summary>
        ///  
        /// </summary>
        /// <param name="downloadFormat">Either \&quot;zip\&quot; or \&quot;br\&quot; (brotli). \&quot;zip\&quot; is default.</param>
        /// <param name="showSubCustomer">Default &#x3D; false</param>
        /// <returns>bool?</returns>
        bool? ProfileUpdateProfile (string downloadFormat, bool? showSubCustomer);
        /// <summary>
        ///  
        /// </summary>
        /// <param name="subCustomerNumber"></param>
        /// <param name="includedIds">If null: Either are &#x27;ALL SELECTED&#x27; or some are unselected (and listed in ExcludedIds)&lt;br /&gt;  If not null: None are selected except those that are listed here.&lt;br /&gt;  It is not allowed to have IncludedIds AND ExcludedIds have listed values. One most be null or both most be null.&lt;br /&gt;  The list of included ids is limited to 50. More than 50 will throw an exception.&lt;br /&gt;</param>
        /// <param name="excludedIds">If null: Either are &#x27;ALL SELECTED&#x27; or only some few are selected (and listed in IncludedIds)&lt;br /&gt;  If not null: All are selected and except those that are listed here.&lt;br /&gt;  It is not allowed to have IncludedIds AND ExcludedIds have listed values. One most be null or both most be null.&lt;br /&gt;  The list of excluded ids is limited to 50. More than 50 will throw an exception.&lt;br /&gt;</param>
        /// <param name="orderNumbers">List of Order Numbers</param>
        /// <param name="orderPositions">List of Order Positions</param>
        /// <param name="dateFilterType">One of &#x27;equals&#x27;, &#x27;greaterThan&#x27;, &#x27;lessThan&#x27;, &#x27;notEqual&#x27;, &#x27;inRange&#x27;.&lt;br /&gt;  When &#x27;inRange&#x27; then &#x27;DateTo&#x27; is needed.&lt;br /&gt;  Example 1:&lt;br /&gt;  \&quot;All data newer than August 1st\&quot; &#x3D; https://mycalibrationapi.azurewebsites.net/v1/CalibrationData?DateFilterType&#x3D;greaterThan&amp;Date&#x3D;2021-08-01&lt;br /&gt;  Example 2:&lt;br /&gt;  \&quot;All data from the year 2020\&quot; &#x3D; https://mycalibrationapi.azurewebsites.net/v1/CalibrationData?DateFilterType&#x3D;inRange&amp;Date&#x3D;2021-01-01&amp;DateTo&#x3D;2021-12-31 &lt;br /&gt;  Example 3:&lt;br /&gt;  \&quot;All data from the first day in January and February\&quot; &#x3D; https://mycalibrationapi.azurewebsites.net/v1/CalibrationData?DateFilterType&#x3D;equals&amp;Date&#x3D;2021-01-01&amp;Date&#x3D;2021-02-01 &lt;br /&gt;</param>
        /// <param name="date">Dispatch-date text in format &#x27;yyyy-MM-dd&#x27; eg. \&quot;2021-12-24\&quot;&lt;br /&gt;  Normally, this is a list with one element. Nevertheless, it is possible to GET calibration data from multiple dates. In this case DateFilterType must be &#x27;equals&#x27; and DateTo must be null.</param>
        /// <param name="dateTo">Used when DateFilterType is &#x27;inRange&#x27;.&lt;br /&gt;  Data is gathered from &#x27;Date&#x27; to &#x27;DateTo&#x27;&lt;br /&gt;  Date text in format &#x27;yyyy-MM-dd&#x27; eg. \&quot;2021-12-24\&quot;</param>
        /// <param name="customerProductTypes">To search for [Blanks] use \&quot;blank\&quot;</param>
        /// <param name="pressureTypes">Eg. [\&quot;pa\&quot;,\&quot;paa\&quot;,\&quot;pr\&quot;]  To see all possible enum strings, go to https://mycalibration.github.io/#filter-parameters</param>
        /// <param name="productSeries">Eg. [\&quot;10LHP\&quot;,\&quot;25Y\&quot;,\&quot;46X\&quot;,\&quot;K-102\&quot;]</param>
        /// <param name="productNumbers"></param>
        /// <param name="serialNumberSearchText">Use this to find all SerialNumbers that contains this text content.</param>
        /// <param name="pressureMinFilterType">One of &#x27;equals&#x27;, &#x27;greaterThan&#x27;, &#x27;lessThan&#x27;, &#x27;notEqual&#x27;, &#x27;inRange&#x27;, &#x27;lessThanOrEqual&#x27;, &#x27;greaterThanOrEqual&#x27;.&lt;br /&gt;  When &#x27;inRange&#x27; then &#x27;PressureMinTo&#x27; is needed.</param>
        /// <param name="pressureMin">The exclusive lower bound of the \&quot;Minimum Pressure\&quot;</param>
        /// <param name="pressureMinTo">The exclusive upper bound of the \&quot;Minimum Pressure\&quot;.&lt;br /&gt;  Used when PressureMinFilterType is &#x27;inRange&#x27;.&lt;br /&gt;  Data is gathered from &#x27;PressureMin&#x27; to &#x27;PressureMinTo&#x27;.&lt;br /&gt;  Date text in format &#x27;yyyy-MM-dd&#x27; eg. \&quot;2021-12-24\&quot;&lt;br /&gt;</param>
        /// <param name="pressureMaxFilterType">One of &#x27;equals&#x27;, &#x27;greaterThan&#x27;, &#x27;lessThan&#x27;, &#x27;notEqual&#x27;, &#x27;inRange&#x27;, &#x27;lessThanOrEqual&#x27;, &#x27;greaterThanOrEqual&#x27;.&lt;br /&gt;  When &#x27;inRange&#x27; then &#x27;PressureMaxTo&#x27; is needed.</param>
        /// <param name="pressureMax">The exclusive lower bound of the \&quot;Maximum Pressure\&quot;</param>
        /// <param name="pressureMaxTo">The exclusive upper bound of the \&quot;Maximum Pressure\&quot;&lt;br /&gt;  Used when PressureMaxFilterType is &#x27;inRange&#x27;.&lt;br /&gt;  Data is gathered from &#x27;PressureMax&#x27; to &#x27;PressureMaxTo&#x27;&lt;br /&gt;  Date text in format &#x27;yyyy-MM-dd&#x27; eg. \&quot;2021-12-24\&quot;</param>
        /// <param name="pressureUnit">&lt;list type&#x3D;\&quot;string\&quot;&gt;List of the Pressure Unit&lt;/list&gt;</param>
        /// <param name="temperatureMinFilterType">One of &#x27;equals&#x27;, &#x27;greaterThan&#x27;, &#x27;lessThan&#x27;, &#x27;notEqual&#x27;, &#x27;inRange&#x27;, &#x27;lessThanOrEqual&#x27;, &#x27;greaterThanOrEqual&#x27;.&lt;br /&gt;  When &#x27;inRange&#x27; then &#x27;TemperatureMinTo&#x27; is needed.</param>
        /// <param name="temperatureMin">The exclusive lower bound of the \&quot;Minimum Temperature\&quot;</param>
        /// <param name="temperatureMinTo">The exclusive upper bound of the \&quot;Minimum Temperature\&quot;&lt;br /&gt;  Used when TemperatureMinFilterType is &#x27;inRange&#x27;.&lt;br /&gt;  Data is gathered from &#x27;TemperatureMin&#x27; to &#x27;TemperatureMinTo&#x27;&lt;br /&gt;  Date text in format &#x27;yyyy-MM-dd&#x27; eg. \&quot;2021-12-24\&quot;</param>
        /// <param name="temperatureMaxFilterType">One of &#x27;equals&#x27;, &#x27;greaterThan&#x27;, &#x27;lessThan&#x27;, &#x27;notEqual&#x27;, &#x27;inRange&#x27;, &#x27;lessThanOrEqual&#x27;, &#x27;greaterThanOrEqual&#x27;.&lt;br /&gt;  When &#x27;inRange&#x27; then &#x27;TemperatureMaxTo&#x27; is needed.</param>
        /// <param name="temperatureMax">The exclusive lower bound of the \&quot;Maximum Temperature\&quot;</param>
        /// <param name="temperatureMaxTo">The exclusive upper bound of the \&quot;Maximum Temperature\&quot;&lt;br /&gt;  Used when TemperatureMaxFilterType is &#x27;inRange&#x27;.&lt;br /&gt;  Data is gathered from &#x27;TemperatureMax&#x27; to &#x27;TemperatureMaxTo&#x27;&lt;br /&gt;  Date text in format &#x27;yyyy-MM-dd&#x27; eg. \&quot;2021-12-24\&quot;</param>
        /// <param name="temperatureUnit">&lt;list type&#x3D;\&quot;string\&quot;&gt;List of the Temperature Unit&lt;/list&gt;</param>
        /// <param name="supplyMinFilterType">One of &#x27;equals&#x27;, &#x27;greaterThan&#x27;, &#x27;lessThan&#x27;, &#x27;notEqual&#x27;, &#x27;inRange&#x27;, &#x27;lessThanOrEqual&#x27;, &#x27;greaterThanOrEqual&#x27;.&lt;br /&gt;  When &#x27;inRange&#x27; then &#x27;SupplyMinTo&#x27; is needed.&lt;br /&gt;  Either Min/Max is used or Magnitude.&lt;br /&gt;</param>
        /// <param name="supplyMin">The exclusive lower bound of the \&quot;Minimum Supply\&quot;&lt;br /&gt;  Either Min/Max is used or Magnitude.</param>
        /// <param name="supplyMinTo">The exclusive upper bound of the \&quot;Minimum Supply\&quot;&lt;br /&gt;  Used when SupplyMinFilterType is &#x27;inRange&#x27;.&lt;br /&gt;  Data is gathered from &#x27;SupplyMin&#x27; to &#x27;SupplyMinTo&#x27;&lt;br /&gt;  Date text in format &#x27;yyyy-MM-dd&#x27; eg. \&quot;2021-12-24\&quot;&lt;br /&gt;  Either Min/Max is used or Magnitude.</param>
        /// <param name="supplyMaxFilterType">One of &#x27;equals&#x27;, &#x27;greaterThan&#x27;, &#x27;lessThan&#x27;, &#x27;notEqual&#x27;, &#x27;inRange&#x27;, &#x27;lessThanOrEqual&#x27;, &#x27;greaterThanOrEqual&#x27;.&lt;br /&gt;  When &#x27;inRange&#x27; then &#x27;SupplyMaxTo&#x27; is needed.&lt;br /&gt;  Either Min/Max is used or Magnitude.</param>
        /// <param name="supplyMax">The exclusive lower bound of the \&quot;Maximum Supply\&quot;&lt;br /&gt;  Either Min/Max is used or Magnitude.</param>
        /// <param name="supplyMaxTo">The exclusive upper bound of the \&quot;Maximum Supply\&quot;&lt;br /&gt;  Used when SupplyMaxFilterType is &#x27;inRange&#x27;.&lt;br /&gt;  Data is gathered from &#x27;SupplyMax&#x27; to &#x27;SupplyMaxTo&#x27;&lt;br /&gt;  Date text in format &#x27;yyyy-MM-dd&#x27; eg. \&quot;2021-12-24\&quot;&lt;br /&gt;  Either Min/Max is used or Magnitude.</param>
        /// <param name="supplyMagnitudeFilterType">One of &#x27;equals&#x27;, &#x27;greaterThan&#x27;, &#x27;lessThan&#x27;, &#x27;notEqual&#x27;, &#x27;inRange&#x27;, &#x27;lessThanOrEqual&#x27;, &#x27;greaterThanOrEqual&#x27;.&lt;br /&gt;  When &#x27;inRange&#x27; then &#x27;SupplyMagnitudeTo&#x27; is needed.&lt;br /&gt;  Either Min/Max is used or Magnitude.</param>
        /// <param name="supplyMagnitude">The exclusive lower bound of the \&quot;Supply Magnitude\&quot;&lt;br /&gt;  Either Min/Max is used or Magnitude.</param>
        /// <param name="supplyMagnitudeTo">The exclusive upper bound of the \&quot;Supply Magnitude\&quot;&lt;br /&gt;  Used when SupplyMagnitudeFilterType is &#x27;inRange&#x27;.&lt;br /&gt;  Data is gathered from &#x27;SupplyMagnitude&#x27; to &#x27;SupplyMagnitudeTo&#x27;&lt;br /&gt;  Either Min/Max is used or Magnitude.</param>
        /// <param name="supplyUnit">&lt;list type&#x3D;\&quot;string\&quot;&gt;List of the Supply Unit&lt;/list&gt;</param>
        /// <param name="customerReferenceNumberSearchText">Find all data with contains this search text</param>
        /// <param name="customerOrderNumberSearchText">Find all data with contains this search text</param>
        /// <param name="remarksSearchText">Find all data with contains this search text</param>
        /// <returns>bool?</returns>
        bool? SubCustomerUpdateSubCustomers (int? subCustomerNumber, List<string> includedIds, List<string> excludedIds, List<string> orderNumbers, List<string> orderPositions, string dateFilterType, List<string> date, string dateTo, List<string> customerProductTypes, List<string> pressureTypes, List<string> productSeries, List<string> productNumbers, string serialNumberSearchText, string pressureMinFilterType, double? pressureMin, double? pressureMinTo, string pressureMaxFilterType, double? pressureMax, double? pressureMaxTo, List<string> pressureUnit, string temperatureMinFilterType, double? temperatureMin, double? temperatureMinTo, string temperatureMaxFilterType, double? temperatureMax, double? temperatureMaxTo, List<string> temperatureUnit, string supplyMinFilterType, double? supplyMin, double? supplyMinTo, string supplyMaxFilterType, double? supplyMax, double? supplyMaxTo, string supplyMagnitudeFilterType, double? supplyMagnitude, double? supplyMagnitudeTo, List<string> supplyUnit, string customerReferenceNumberSearchText, string customerOrderNumberSearchText, string remarksSearchText);
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class CalibrationDataApi : ICalibrationDataApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CalibrationDataApi"/> class.
        /// </summary>
        /// <param name="apiClient"> an instance of ApiClient (optional)</param>
        /// <returns></returns>
        public CalibrationDataApi(ApiClient apiClient = null)
        {
            if (apiClient == null) // use the default one in Configuration
                this.ApiClient = Configuration.DefaultApiClient; 
            else
                this.ApiClient = apiClient;
        }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="CalibrationDataApi"/> class.
        /// </summary>
        /// <returns></returns>
        public CalibrationDataApi(String basePath)
        {
            this.ApiClient = new ApiClient(basePath);
        }
    
        /// <summary>
        /// Sets the base path of the API client.
        /// </summary>
        /// <param name="basePath">The base path</param>
        /// <value>The base path</value>
        public void SetBasePath(String basePath)
        {
            this.ApiClient.BasePath = basePath;
        }
    
        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <param name="basePath">The base path</param>
        /// <value>The base path</value>
        public String GetBasePath(String basePath)
        {
            return this.ApiClient.BasePath;
        }
    
        /// <summary>
        /// Gets or sets the API client.
        /// </summary>
        /// <value>An instance of the ApiClient</value>
        public ApiClient ApiClient {get; set;}
    
        /// <summary>
        /// Gathers all filtered data in one JSON response 
        /// </summary>
        /// <param name="includedIds">If null: Either are &#x27;ALL SELECTED&#x27; or some are unselected (and listed in ExcludedIds)&lt;br /&gt;  If not null: None are selected except those that are listed here.&lt;br /&gt;  It is not allowed to have IncludedIds AND ExcludedIds have listed values. One most be null or both most be null.&lt;br /&gt;  The list of included ids is limited to 50. More than 50 will throw an exception.&lt;br /&gt;</param>
        /// <param name="excludedIds">If null: Either are &#x27;ALL SELECTED&#x27; or only some few are selected (and listed in IncludedIds)&lt;br /&gt;  If not null: All are selected and except those that are listed here.&lt;br /&gt;  It is not allowed to have IncludedIds AND ExcludedIds have listed values. One most be null or both most be null.&lt;br /&gt;  The list of excluded ids is limited to 50. More than 50 will throw an exception.&lt;br /&gt;</param>
        /// <param name="orderNumbers">List of Order Numbers</param>
        /// <param name="orderPositions">List of Order Positions</param>
        /// <param name="dateFilterType">One of &#x27;equals&#x27;, &#x27;greaterThan&#x27;, &#x27;lessThan&#x27;, &#x27;notEqual&#x27;, &#x27;inRange&#x27;.&lt;br /&gt;  When &#x27;inRange&#x27; then &#x27;DateTo&#x27; is needed.&lt;br /&gt;  Example 1:&lt;br /&gt;  \&quot;All data newer than August 1st\&quot; &#x3D; https://mycalibrationapi.azurewebsites.net/v1/CalibrationData?DateFilterType&#x3D;greaterThan&amp;Date&#x3D;2021-08-01&lt;br /&gt;  Example 2:&lt;br /&gt;  \&quot;All data from the year 2020\&quot; &#x3D; https://mycalibrationapi.azurewebsites.net/v1/CalibrationData?DateFilterType&#x3D;inRange&amp;Date&#x3D;2021-01-01&amp;DateTo&#x3D;2021-12-31 &lt;br /&gt;  Example 3:&lt;br /&gt;  \&quot;All data from the first day in January and February\&quot; &#x3D; https://mycalibrationapi.azurewebsites.net/v1/CalibrationData?DateFilterType&#x3D;equals&amp;Date&#x3D;2021-01-01&amp;Date&#x3D;2021-02-01 &lt;br /&gt;</param>
        /// <param name="date">Dispatch-date text in format &#x27;yyyy-MM-dd&#x27; eg. \&quot;2021-12-24\&quot;&lt;br /&gt;  Normally, this is a list with one element. Nevertheless, it is possible to GET calibration data from multiple dates. In this case DateFilterType must be &#x27;equals&#x27; and DateTo must be null.</param>
        /// <param name="dateTo">Used when DateFilterType is &#x27;inRange&#x27;.&lt;br /&gt;  Data is gathered from &#x27;Date&#x27; to &#x27;DateTo&#x27;&lt;br /&gt;  Date text in format &#x27;yyyy-MM-dd&#x27; eg. \&quot;2021-12-24\&quot;</param>
        /// <param name="customerProductTypes">To search for [Blanks] use \&quot;blank\&quot;</param>
        /// <param name="pressureTypes">Eg. [\&quot;pa\&quot;,\&quot;paa\&quot;,\&quot;pr\&quot;]  To see all possible enum strings, go to https://mycalibration.github.io/#filter-parameters</param>
        /// <param name="productSeries">Eg. [\&quot;10LHP\&quot;,\&quot;25Y\&quot;,\&quot;46X\&quot;,\&quot;K-102\&quot;]</param>
        /// <param name="productNumbers"></param>
        /// <param name="serialNumberSearchText">Use this to find all SerialNumbers that contains this text content.</param>
        /// <param name="pressureMinFilterType">One of &#x27;equals&#x27;, &#x27;greaterThan&#x27;, &#x27;lessThan&#x27;, &#x27;notEqual&#x27;, &#x27;inRange&#x27;, &#x27;lessThanOrEqual&#x27;, &#x27;greaterThanOrEqual&#x27;.&lt;br /&gt;  When &#x27;inRange&#x27; then &#x27;PressureMinTo&#x27; is needed.</param>
        /// <param name="pressureMin">The exclusive lower bound of the \&quot;Minimum Pressure\&quot;</param>
        /// <param name="pressureMinTo">The exclusive upper bound of the \&quot;Minimum Pressure\&quot;.&lt;br /&gt;  Used when PressureMinFilterType is &#x27;inRange&#x27;.&lt;br /&gt;  Data is gathered from &#x27;PressureMin&#x27; to &#x27;PressureMinTo&#x27;.&lt;br /&gt;  Date text in format &#x27;yyyy-MM-dd&#x27; eg. \&quot;2021-12-24\&quot;&lt;br /&gt;</param>
        /// <param name="pressureMaxFilterType">One of &#x27;equals&#x27;, &#x27;greaterThan&#x27;, &#x27;lessThan&#x27;, &#x27;notEqual&#x27;, &#x27;inRange&#x27;, &#x27;lessThanOrEqual&#x27;, &#x27;greaterThanOrEqual&#x27;.&lt;br /&gt;  When &#x27;inRange&#x27; then &#x27;PressureMaxTo&#x27; is needed.</param>
        /// <param name="pressureMax">The exclusive lower bound of the \&quot;Maximum Pressure\&quot;</param>
        /// <param name="pressureMaxTo">The exclusive upper bound of the \&quot;Maximum Pressure\&quot;&lt;br /&gt;  Used when PressureMaxFilterType is &#x27;inRange&#x27;.&lt;br /&gt;  Data is gathered from &#x27;PressureMax&#x27; to &#x27;PressureMaxTo&#x27;&lt;br /&gt;  Date text in format &#x27;yyyy-MM-dd&#x27; eg. \&quot;2021-12-24\&quot;</param>
        /// <param name="pressureUnit">&lt;list type&#x3D;\&quot;string\&quot;&gt;List of the Pressure Unit&lt;/list&gt;</param>
        /// <param name="temperatureMinFilterType">One of &#x27;equals&#x27;, &#x27;greaterThan&#x27;, &#x27;lessThan&#x27;, &#x27;notEqual&#x27;, &#x27;inRange&#x27;, &#x27;lessThanOrEqual&#x27;, &#x27;greaterThanOrEqual&#x27;.&lt;br /&gt;  When &#x27;inRange&#x27; then &#x27;TemperatureMinTo&#x27; is needed.</param>
        /// <param name="temperatureMin">The exclusive lower bound of the \&quot;Minimum Temperature\&quot;</param>
        /// <param name="temperatureMinTo">The exclusive upper bound of the \&quot;Minimum Temperature\&quot;&lt;br /&gt;  Used when TemperatureMinFilterType is &#x27;inRange&#x27;.&lt;br /&gt;  Data is gathered from &#x27;TemperatureMin&#x27; to &#x27;TemperatureMinTo&#x27;&lt;br /&gt;  Date text in format &#x27;yyyy-MM-dd&#x27; eg. \&quot;2021-12-24\&quot;</param>
        /// <param name="temperatureMaxFilterType">One of &#x27;equals&#x27;, &#x27;greaterThan&#x27;, &#x27;lessThan&#x27;, &#x27;notEqual&#x27;, &#x27;inRange&#x27;, &#x27;lessThanOrEqual&#x27;, &#x27;greaterThanOrEqual&#x27;.&lt;br /&gt;  When &#x27;inRange&#x27; then &#x27;TemperatureMaxTo&#x27; is needed.</param>
        /// <param name="temperatureMax">The exclusive lower bound of the \&quot;Maximum Temperature\&quot;</param>
        /// <param name="temperatureMaxTo">The exclusive upper bound of the \&quot;Maximum Temperature\&quot;&lt;br /&gt;  Used when TemperatureMaxFilterType is &#x27;inRange&#x27;.&lt;br /&gt;  Data is gathered from &#x27;TemperatureMax&#x27; to &#x27;TemperatureMaxTo&#x27;&lt;br /&gt;  Date text in format &#x27;yyyy-MM-dd&#x27; eg. \&quot;2021-12-24\&quot;</param>
        /// <param name="temperatureUnit">&lt;list type&#x3D;\&quot;string\&quot;&gt;List of the Temperature Unit&lt;/list&gt;</param>
        /// <param name="supplyMinFilterType">One of &#x27;equals&#x27;, &#x27;greaterThan&#x27;, &#x27;lessThan&#x27;, &#x27;notEqual&#x27;, &#x27;inRange&#x27;, &#x27;lessThanOrEqual&#x27;, &#x27;greaterThanOrEqual&#x27;.&lt;br /&gt;  When &#x27;inRange&#x27; then &#x27;SupplyMinTo&#x27; is needed.&lt;br /&gt;  Either Min/Max is used or Magnitude.&lt;br /&gt;</param>
        /// <param name="supplyMin">The exclusive lower bound of the \&quot;Minimum Supply\&quot;&lt;br /&gt;  Either Min/Max is used or Magnitude.</param>
        /// <param name="supplyMinTo">The exclusive upper bound of the \&quot;Minimum Supply\&quot;&lt;br /&gt;  Used when SupplyMinFilterType is &#x27;inRange&#x27;.&lt;br /&gt;  Data is gathered from &#x27;SupplyMin&#x27; to &#x27;SupplyMinTo&#x27;&lt;br /&gt;  Date text in format &#x27;yyyy-MM-dd&#x27; eg. \&quot;2021-12-24\&quot;&lt;br /&gt;  Either Min/Max is used or Magnitude.</param>
        /// <param name="supplyMaxFilterType">One of &#x27;equals&#x27;, &#x27;greaterThan&#x27;, &#x27;lessThan&#x27;, &#x27;notEqual&#x27;, &#x27;inRange&#x27;, &#x27;lessThanOrEqual&#x27;, &#x27;greaterThanOrEqual&#x27;.&lt;br /&gt;  When &#x27;inRange&#x27; then &#x27;SupplyMaxTo&#x27; is needed.&lt;br /&gt;  Either Min/Max is used or Magnitude.</param>
        /// <param name="supplyMax">The exclusive lower bound of the \&quot;Maximum Supply\&quot;&lt;br /&gt;  Either Min/Max is used or Magnitude.</param>
        /// <param name="supplyMaxTo">The exclusive upper bound of the \&quot;Maximum Supply\&quot;&lt;br /&gt;  Used when SupplyMaxFilterType is &#x27;inRange&#x27;.&lt;br /&gt;  Data is gathered from &#x27;SupplyMax&#x27; to &#x27;SupplyMaxTo&#x27;&lt;br /&gt;  Date text in format &#x27;yyyy-MM-dd&#x27; eg. \&quot;2021-12-24\&quot;&lt;br /&gt;  Either Min/Max is used or Magnitude.</param>
        /// <param name="supplyMagnitudeFilterType">One of &#x27;equals&#x27;, &#x27;greaterThan&#x27;, &#x27;lessThan&#x27;, &#x27;notEqual&#x27;, &#x27;inRange&#x27;, &#x27;lessThanOrEqual&#x27;, &#x27;greaterThanOrEqual&#x27;.&lt;br /&gt;  When &#x27;inRange&#x27; then &#x27;SupplyMagnitudeTo&#x27; is needed.&lt;br /&gt;  Either Min/Max is used or Magnitude.</param>
        /// <param name="supplyMagnitude">The exclusive lower bound of the \&quot;Supply Magnitude\&quot;&lt;br /&gt;  Either Min/Max is used or Magnitude.</param>
        /// <param name="supplyMagnitudeTo">The exclusive upper bound of the \&quot;Supply Magnitude\&quot;&lt;br /&gt;  Used when SupplyMagnitudeFilterType is &#x27;inRange&#x27;.&lt;br /&gt;  Data is gathered from &#x27;SupplyMagnitude&#x27; to &#x27;SupplyMagnitudeTo&#x27;&lt;br /&gt;  Either Min/Max is used or Magnitude.</param>
        /// <param name="supplyUnit">&lt;list type&#x3D;\&quot;string\&quot;&gt;List of the Supply Unit&lt;/list&gt;</param>
        /// <param name="customerReferenceNumberSearchText">Find all data with contains this search text</param>
        /// <param name="customerOrderNumberSearchText">Find all data with contains this search text</param>
        /// <param name="remarksSearchText">Find all data with contains this search text</param>
        /// <returns>List&lt;KellerSensorData&gt;</returns>
        public List<KellerSensorData> CalibrationDataGetCalibrationData (List<string> includedIds, List<string> excludedIds, List<string> orderNumbers, List<string> orderPositions, string dateFilterType, List<string> date, string dateTo, List<string> customerProductTypes, List<string> pressureTypes, List<string> productSeries, List<string> productNumbers, string serialNumberSearchText, string pressureMinFilterType, double? pressureMin, double? pressureMinTo, string pressureMaxFilterType, double? pressureMax, double? pressureMaxTo, List<string> pressureUnit, string temperatureMinFilterType, double? temperatureMin, double? temperatureMinTo, string temperatureMaxFilterType, double? temperatureMax, double? temperatureMaxTo, List<string> temperatureUnit, string supplyMinFilterType, double? supplyMin, double? supplyMinTo, string supplyMaxFilterType, double? supplyMax, double? supplyMaxTo, string supplyMagnitudeFilterType, double? supplyMagnitude, double? supplyMagnitudeTo, List<string> supplyUnit, string customerReferenceNumberSearchText, string customerOrderNumberSearchText, string remarksSearchText)
        {
    
            var path = "/v1/CalibrationData";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (includedIds != null) queryParams.Add("IncludedIds", ApiClient.ParameterToString(includedIds)); // query parameter
 if (excludedIds != null) queryParams.Add("ExcludedIds", ApiClient.ParameterToString(excludedIds)); // query parameter
 if (orderNumbers != null) queryParams.Add("OrderNumbers", ApiClient.ParameterToString(orderNumbers)); // query parameter
 if (orderPositions != null) queryParams.Add("OrderPositions", ApiClient.ParameterToString(orderPositions)); // query parameter
 if (dateFilterType != null) queryParams.Add("DateFilterType", ApiClient.ParameterToString(dateFilterType)); // query parameter
 if (date != null) queryParams.Add("Date", ApiClient.ParameterToString(date)); // query parameter
 if (dateTo != null) queryParams.Add("DateTo", ApiClient.ParameterToString(dateTo)); // query parameter
 if (customerProductTypes != null) queryParams.Add("CustomerProductTypes", ApiClient.ParameterToString(customerProductTypes)); // query parameter
 if (pressureTypes != null) queryParams.Add("PressureTypes", ApiClient.ParameterToString(pressureTypes)); // query parameter
 if (productSeries != null) queryParams.Add("ProductSeries", ApiClient.ParameterToString(productSeries)); // query parameter
 if (productNumbers != null) queryParams.Add("ProductNumbers", ApiClient.ParameterToString(productNumbers)); // query parameter
 if (serialNumberSearchText != null) queryParams.Add("SerialNumberSearchText", ApiClient.ParameterToString(serialNumberSearchText)); // query parameter
 if (pressureMinFilterType != null) queryParams.Add("PressureMinFilterType", ApiClient.ParameterToString(pressureMinFilterType)); // query parameter
 if (pressureMin != null) queryParams.Add("PressureMin", ApiClient.ParameterToString(pressureMin)); // query parameter
 if (pressureMinTo != null) queryParams.Add("PressureMinTo", ApiClient.ParameterToString(pressureMinTo)); // query parameter
 if (pressureMaxFilterType != null) queryParams.Add("PressureMaxFilterType", ApiClient.ParameterToString(pressureMaxFilterType)); // query parameter
 if (pressureMax != null) queryParams.Add("PressureMax", ApiClient.ParameterToString(pressureMax)); // query parameter
 if (pressureMaxTo != null) queryParams.Add("PressureMaxTo", ApiClient.ParameterToString(pressureMaxTo)); // query parameter
 if (pressureUnit != null) queryParams.Add("PressureUnit", ApiClient.ParameterToString(pressureUnit)); // query parameter
 if (temperatureMinFilterType != null) queryParams.Add("TemperatureMinFilterType", ApiClient.ParameterToString(temperatureMinFilterType)); // query parameter
 if (temperatureMin != null) queryParams.Add("TemperatureMin", ApiClient.ParameterToString(temperatureMin)); // query parameter
 if (temperatureMinTo != null) queryParams.Add("TemperatureMinTo", ApiClient.ParameterToString(temperatureMinTo)); // query parameter
 if (temperatureMaxFilterType != null) queryParams.Add("TemperatureMaxFilterType", ApiClient.ParameterToString(temperatureMaxFilterType)); // query parameter
 if (temperatureMax != null) queryParams.Add("TemperatureMax", ApiClient.ParameterToString(temperatureMax)); // query parameter
 if (temperatureMaxTo != null) queryParams.Add("TemperatureMaxTo", ApiClient.ParameterToString(temperatureMaxTo)); // query parameter
 if (temperatureUnit != null) queryParams.Add("TemperatureUnit", ApiClient.ParameterToString(temperatureUnit)); // query parameter
 if (supplyMinFilterType != null) queryParams.Add("SupplyMinFilterType", ApiClient.ParameterToString(supplyMinFilterType)); // query parameter
 if (supplyMin != null) queryParams.Add("SupplyMin", ApiClient.ParameterToString(supplyMin)); // query parameter
 if (supplyMinTo != null) queryParams.Add("SupplyMinTo", ApiClient.ParameterToString(supplyMinTo)); // query parameter
 if (supplyMaxFilterType != null) queryParams.Add("SupplyMaxFilterType", ApiClient.ParameterToString(supplyMaxFilterType)); // query parameter
 if (supplyMax != null) queryParams.Add("SupplyMax", ApiClient.ParameterToString(supplyMax)); // query parameter
 if (supplyMaxTo != null) queryParams.Add("SupplyMaxTo", ApiClient.ParameterToString(supplyMaxTo)); // query parameter
 if (supplyMagnitudeFilterType != null) queryParams.Add("SupplyMagnitudeFilterType", ApiClient.ParameterToString(supplyMagnitudeFilterType)); // query parameter
 if (supplyMagnitude != null) queryParams.Add("SupplyMagnitude", ApiClient.ParameterToString(supplyMagnitude)); // query parameter
 if (supplyMagnitudeTo != null) queryParams.Add("SupplyMagnitudeTo", ApiClient.ParameterToString(supplyMagnitudeTo)); // query parameter
 if (supplyUnit != null) queryParams.Add("SupplyUnit", ApiClient.ParameterToString(supplyUnit)); // query parameter
 if (customerReferenceNumberSearchText != null) queryParams.Add("CustomerReferenceNumberSearchText", ApiClient.ParameterToString(customerReferenceNumberSearchText)); // query parameter
 if (customerOrderNumberSearchText != null) queryParams.Add("CustomerOrderNumberSearchText", ApiClient.ParameterToString(customerOrderNumberSearchText)); // query parameter
 if (remarksSearchText != null) queryParams.Add("RemarksSearchText", ApiClient.ParameterToString(remarksSearchText)); // query parameter
                        
            // authentication setting, if any
            String[] authSettings = new String[] { "Bearer" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling CalibrationDataGetCalibrationData: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling CalibrationDataGetCalibrationData: " + response.ErrorMessage, response.ErrorMessage);
    
            return (List<KellerSensorData>) ApiClient.Deserialize(response.Content, typeof(List<KellerSensorData>), response.Headers);
        }
    
        /// <summary>
        /// Locates the filtered (optionalSearchParameter) data, bundles them and creates a download link 
        /// </summary>
        /// <param name="fileType">1 &#x3D; All calibration data items will be merged in one JSON list  2 &#x3D; All calibration data items will be merged in one JSON list. This JSON file will be compressed to zip file  3 &#x3D; Every calibration data items will stored as JSON file. All these files will be compressed to one single zip file  4 &#x3D; Every calibration data items will stored as JSON file. All these files will be compressed to one single brotli file</param>
        /// <param name="includedIds">If null: Either are &#x27;ALL SELECTED&#x27; or some are unselected (and listed in ExcludedIds)&lt;br /&gt;  If not null: None are selected except those that are listed here.&lt;br /&gt;  It is not allowed to have IncludedIds AND ExcludedIds have listed values. One most be null or both most be null.&lt;br /&gt;  The list of included ids is limited to 50. More than 50 will throw an exception.&lt;br /&gt;</param>
        /// <param name="excludedIds">If null: Either are &#x27;ALL SELECTED&#x27; or only some few are selected (and listed in IncludedIds)&lt;br /&gt;  If not null: All are selected and except those that are listed here.&lt;br /&gt;  It is not allowed to have IncludedIds AND ExcludedIds have listed values. One most be null or both most be null.&lt;br /&gt;  The list of excluded ids is limited to 50. More than 50 will throw an exception.&lt;br /&gt;</param>
        /// <param name="orderNumbers">List of Order Numbers</param>
        /// <param name="orderPositions">List of Order Positions</param>
        /// <param name="dateFilterType">One of &#x27;equals&#x27;, &#x27;greaterThan&#x27;, &#x27;lessThan&#x27;, &#x27;notEqual&#x27;, &#x27;inRange&#x27;.&lt;br /&gt;  When &#x27;inRange&#x27; then &#x27;DateTo&#x27; is needed.&lt;br /&gt;  Example 1:&lt;br /&gt;  \&quot;All data newer than August 1st\&quot; &#x3D; https://mycalibrationapi.azurewebsites.net/v1/CalibrationData?DateFilterType&#x3D;greaterThan&amp;Date&#x3D;2021-08-01&lt;br /&gt;  Example 2:&lt;br /&gt;  \&quot;All data from the year 2020\&quot; &#x3D; https://mycalibrationapi.azurewebsites.net/v1/CalibrationData?DateFilterType&#x3D;inRange&amp;Date&#x3D;2021-01-01&amp;DateTo&#x3D;2021-12-31 &lt;br /&gt;  Example 3:&lt;br /&gt;  \&quot;All data from the first day in January and February\&quot; &#x3D; https://mycalibrationapi.azurewebsites.net/v1/CalibrationData?DateFilterType&#x3D;equals&amp;Date&#x3D;2021-01-01&amp;Date&#x3D;2021-02-01 &lt;br /&gt;</param>
        /// <param name="date">Dispatch-date text in format &#x27;yyyy-MM-dd&#x27; eg. \&quot;2021-12-24\&quot;&lt;br /&gt;  Normally, this is a list with one element. Nevertheless, it is possible to GET calibration data from multiple dates. In this case DateFilterType must be &#x27;equals&#x27; and DateTo must be null.</param>
        /// <param name="dateTo">Used when DateFilterType is &#x27;inRange&#x27;.&lt;br /&gt;  Data is gathered from &#x27;Date&#x27; to &#x27;DateTo&#x27;&lt;br /&gt;  Date text in format &#x27;yyyy-MM-dd&#x27; eg. \&quot;2021-12-24\&quot;</param>
        /// <param name="customerProductTypes">To search for [Blanks] use \&quot;blank\&quot;</param>
        /// <param name="pressureTypes">Eg. [\&quot;pa\&quot;,\&quot;paa\&quot;,\&quot;pr\&quot;]  To see all possible enum strings, go to https://mycalibration.github.io/#filter-parameters</param>
        /// <param name="productSeries">Eg. [\&quot;10LHP\&quot;,\&quot;25Y\&quot;,\&quot;46X\&quot;,\&quot;K-102\&quot;]</param>
        /// <param name="productNumbers"></param>
        /// <param name="serialNumberSearchText">Use this to find all SerialNumbers that contains this text content.</param>
        /// <param name="pressureMinFilterType">One of &#x27;equals&#x27;, &#x27;greaterThan&#x27;, &#x27;lessThan&#x27;, &#x27;notEqual&#x27;, &#x27;inRange&#x27;, &#x27;lessThanOrEqual&#x27;, &#x27;greaterThanOrEqual&#x27;.&lt;br /&gt;  When &#x27;inRange&#x27; then &#x27;PressureMinTo&#x27; is needed.</param>
        /// <param name="pressureMin">The exclusive lower bound of the \&quot;Minimum Pressure\&quot;</param>
        /// <param name="pressureMinTo">The exclusive upper bound of the \&quot;Minimum Pressure\&quot;.&lt;br /&gt;  Used when PressureMinFilterType is &#x27;inRange&#x27;.&lt;br /&gt;  Data is gathered from &#x27;PressureMin&#x27; to &#x27;PressureMinTo&#x27;.&lt;br /&gt;  Date text in format &#x27;yyyy-MM-dd&#x27; eg. \&quot;2021-12-24\&quot;&lt;br /&gt;</param>
        /// <param name="pressureMaxFilterType">One of &#x27;equals&#x27;, &#x27;greaterThan&#x27;, &#x27;lessThan&#x27;, &#x27;notEqual&#x27;, &#x27;inRange&#x27;, &#x27;lessThanOrEqual&#x27;, &#x27;greaterThanOrEqual&#x27;.&lt;br /&gt;  When &#x27;inRange&#x27; then &#x27;PressureMaxTo&#x27; is needed.</param>
        /// <param name="pressureMax">The exclusive lower bound of the \&quot;Maximum Pressure\&quot;</param>
        /// <param name="pressureMaxTo">The exclusive upper bound of the \&quot;Maximum Pressure\&quot;&lt;br /&gt;  Used when PressureMaxFilterType is &#x27;inRange&#x27;.&lt;br /&gt;  Data is gathered from &#x27;PressureMax&#x27; to &#x27;PressureMaxTo&#x27;&lt;br /&gt;  Date text in format &#x27;yyyy-MM-dd&#x27; eg. \&quot;2021-12-24\&quot;</param>
        /// <param name="pressureUnit">&lt;list type&#x3D;\&quot;string\&quot;&gt;List of the Pressure Unit&lt;/list&gt;</param>
        /// <param name="temperatureMinFilterType">One of &#x27;equals&#x27;, &#x27;greaterThan&#x27;, &#x27;lessThan&#x27;, &#x27;notEqual&#x27;, &#x27;inRange&#x27;, &#x27;lessThanOrEqual&#x27;, &#x27;greaterThanOrEqual&#x27;.&lt;br /&gt;  When &#x27;inRange&#x27; then &#x27;TemperatureMinTo&#x27; is needed.</param>
        /// <param name="temperatureMin">The exclusive lower bound of the \&quot;Minimum Temperature\&quot;</param>
        /// <param name="temperatureMinTo">The exclusive upper bound of the \&quot;Minimum Temperature\&quot;&lt;br /&gt;  Used when TemperatureMinFilterType is &#x27;inRange&#x27;.&lt;br /&gt;  Data is gathered from &#x27;TemperatureMin&#x27; to &#x27;TemperatureMinTo&#x27;&lt;br /&gt;  Date text in format &#x27;yyyy-MM-dd&#x27; eg. \&quot;2021-12-24\&quot;</param>
        /// <param name="temperatureMaxFilterType">One of &#x27;equals&#x27;, &#x27;greaterThan&#x27;, &#x27;lessThan&#x27;, &#x27;notEqual&#x27;, &#x27;inRange&#x27;, &#x27;lessThanOrEqual&#x27;, &#x27;greaterThanOrEqual&#x27;.&lt;br /&gt;  When &#x27;inRange&#x27; then &#x27;TemperatureMaxTo&#x27; is needed.</param>
        /// <param name="temperatureMax">The exclusive lower bound of the \&quot;Maximum Temperature\&quot;</param>
        /// <param name="temperatureMaxTo">The exclusive upper bound of the \&quot;Maximum Temperature\&quot;&lt;br /&gt;  Used when TemperatureMaxFilterType is &#x27;inRange&#x27;.&lt;br /&gt;  Data is gathered from &#x27;TemperatureMax&#x27; to &#x27;TemperatureMaxTo&#x27;&lt;br /&gt;  Date text in format &#x27;yyyy-MM-dd&#x27; eg. \&quot;2021-12-24\&quot;</param>
        /// <param name="temperatureUnit">&lt;list type&#x3D;\&quot;string\&quot;&gt;List of the Temperature Unit&lt;/list&gt;</param>
        /// <param name="supplyMinFilterType">One of &#x27;equals&#x27;, &#x27;greaterThan&#x27;, &#x27;lessThan&#x27;, &#x27;notEqual&#x27;, &#x27;inRange&#x27;, &#x27;lessThanOrEqual&#x27;, &#x27;greaterThanOrEqual&#x27;.&lt;br /&gt;  When &#x27;inRange&#x27; then &#x27;SupplyMinTo&#x27; is needed.&lt;br /&gt;  Either Min/Max is used or Magnitude.&lt;br /&gt;</param>
        /// <param name="supplyMin">The exclusive lower bound of the \&quot;Minimum Supply\&quot;&lt;br /&gt;  Either Min/Max is used or Magnitude.</param>
        /// <param name="supplyMinTo">The exclusive upper bound of the \&quot;Minimum Supply\&quot;&lt;br /&gt;  Used when SupplyMinFilterType is &#x27;inRange&#x27;.&lt;br /&gt;  Data is gathered from &#x27;SupplyMin&#x27; to &#x27;SupplyMinTo&#x27;&lt;br /&gt;  Date text in format &#x27;yyyy-MM-dd&#x27; eg. \&quot;2021-12-24\&quot;&lt;br /&gt;  Either Min/Max is used or Magnitude.</param>
        /// <param name="supplyMaxFilterType">One of &#x27;equals&#x27;, &#x27;greaterThan&#x27;, &#x27;lessThan&#x27;, &#x27;notEqual&#x27;, &#x27;inRange&#x27;, &#x27;lessThanOrEqual&#x27;, &#x27;greaterThanOrEqual&#x27;.&lt;br /&gt;  When &#x27;inRange&#x27; then &#x27;SupplyMaxTo&#x27; is needed.&lt;br /&gt;  Either Min/Max is used or Magnitude.</param>
        /// <param name="supplyMax">The exclusive lower bound of the \&quot;Maximum Supply\&quot;&lt;br /&gt;  Either Min/Max is used or Magnitude.</param>
        /// <param name="supplyMaxTo">The exclusive upper bound of the \&quot;Maximum Supply\&quot;&lt;br /&gt;  Used when SupplyMaxFilterType is &#x27;inRange&#x27;.&lt;br /&gt;  Data is gathered from &#x27;SupplyMax&#x27; to &#x27;SupplyMaxTo&#x27;&lt;br /&gt;  Date text in format &#x27;yyyy-MM-dd&#x27; eg. \&quot;2021-12-24\&quot;&lt;br /&gt;  Either Min/Max is used or Magnitude.</param>
        /// <param name="supplyMagnitudeFilterType">One of &#x27;equals&#x27;, &#x27;greaterThan&#x27;, &#x27;lessThan&#x27;, &#x27;notEqual&#x27;, &#x27;inRange&#x27;, &#x27;lessThanOrEqual&#x27;, &#x27;greaterThanOrEqual&#x27;.&lt;br /&gt;  When &#x27;inRange&#x27; then &#x27;SupplyMagnitudeTo&#x27; is needed.&lt;br /&gt;  Either Min/Max is used or Magnitude.</param>
        /// <param name="supplyMagnitude">The exclusive lower bound of the \&quot;Supply Magnitude\&quot;&lt;br /&gt;  Either Min/Max is used or Magnitude.</param>
        /// <param name="supplyMagnitudeTo">The exclusive upper bound of the \&quot;Supply Magnitude\&quot;&lt;br /&gt;  Used when SupplyMagnitudeFilterType is &#x27;inRange&#x27;.&lt;br /&gt;  Data is gathered from &#x27;SupplyMagnitude&#x27; to &#x27;SupplyMagnitudeTo&#x27;&lt;br /&gt;  Either Min/Max is used or Magnitude.</param>
        /// <param name="supplyUnit">&lt;list type&#x3D;\&quot;string\&quot;&gt;List of the Supply Unit&lt;/list&gt;</param>
        /// <param name="customerReferenceNumberSearchText">Find all data with contains this search text</param>
        /// <param name="customerOrderNumberSearchText">Find all data with contains this search text</param>
        /// <param name="remarksSearchText">Find all data with contains this search text</param>
        /// <returns></returns>
        public void CalibrationDataGetCalibrationDataAsFile (ExportFileType fileType, List<string> includedIds, List<string> excludedIds, List<string> orderNumbers, List<string> orderPositions, string dateFilterType, List<string> date, string dateTo, List<string> customerProductTypes, List<string> pressureTypes, List<string> productSeries, List<string> productNumbers, string serialNumberSearchText, string pressureMinFilterType, double? pressureMin, double? pressureMinTo, string pressureMaxFilterType, double? pressureMax, double? pressureMaxTo, List<string> pressureUnit, string temperatureMinFilterType, double? temperatureMin, double? temperatureMinTo, string temperatureMaxFilterType, double? temperatureMax, double? temperatureMaxTo, List<string> temperatureUnit, string supplyMinFilterType, double? supplyMin, double? supplyMinTo, string supplyMaxFilterType, double? supplyMax, double? supplyMaxTo, string supplyMagnitudeFilterType, double? supplyMagnitude, double? supplyMagnitudeTo, List<string> supplyUnit, string customerReferenceNumberSearchText, string customerOrderNumberSearchText, string remarksSearchText)
        {
    
            var path = "/v1/CalibrationData/Export";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (fileType != null) queryParams.Add("fileType", ApiClient.ParameterToString(fileType)); // query parameter
 if (includedIds != null) queryParams.Add("IncludedIds", ApiClient.ParameterToString(includedIds)); // query parameter
 if (excludedIds != null) queryParams.Add("ExcludedIds", ApiClient.ParameterToString(excludedIds)); // query parameter
 if (orderNumbers != null) queryParams.Add("OrderNumbers", ApiClient.ParameterToString(orderNumbers)); // query parameter
 if (orderPositions != null) queryParams.Add("OrderPositions", ApiClient.ParameterToString(orderPositions)); // query parameter
 if (dateFilterType != null) queryParams.Add("DateFilterType", ApiClient.ParameterToString(dateFilterType)); // query parameter
 if (date != null) queryParams.Add("Date", ApiClient.ParameterToString(date)); // query parameter
 if (dateTo != null) queryParams.Add("DateTo", ApiClient.ParameterToString(dateTo)); // query parameter
 if (customerProductTypes != null) queryParams.Add("CustomerProductTypes", ApiClient.ParameterToString(customerProductTypes)); // query parameter
 if (pressureTypes != null) queryParams.Add("PressureTypes", ApiClient.ParameterToString(pressureTypes)); // query parameter
 if (productSeries != null) queryParams.Add("ProductSeries", ApiClient.ParameterToString(productSeries)); // query parameter
 if (productNumbers != null) queryParams.Add("ProductNumbers", ApiClient.ParameterToString(productNumbers)); // query parameter
 if (serialNumberSearchText != null) queryParams.Add("SerialNumberSearchText", ApiClient.ParameterToString(serialNumberSearchText)); // query parameter
 if (pressureMinFilterType != null) queryParams.Add("PressureMinFilterType", ApiClient.ParameterToString(pressureMinFilterType)); // query parameter
 if (pressureMin != null) queryParams.Add("PressureMin", ApiClient.ParameterToString(pressureMin)); // query parameter
 if (pressureMinTo != null) queryParams.Add("PressureMinTo", ApiClient.ParameterToString(pressureMinTo)); // query parameter
 if (pressureMaxFilterType != null) queryParams.Add("PressureMaxFilterType", ApiClient.ParameterToString(pressureMaxFilterType)); // query parameter
 if (pressureMax != null) queryParams.Add("PressureMax", ApiClient.ParameterToString(pressureMax)); // query parameter
 if (pressureMaxTo != null) queryParams.Add("PressureMaxTo", ApiClient.ParameterToString(pressureMaxTo)); // query parameter
 if (pressureUnit != null) queryParams.Add("PressureUnit", ApiClient.ParameterToString(pressureUnit)); // query parameter
 if (temperatureMinFilterType != null) queryParams.Add("TemperatureMinFilterType", ApiClient.ParameterToString(temperatureMinFilterType)); // query parameter
 if (temperatureMin != null) queryParams.Add("TemperatureMin", ApiClient.ParameterToString(temperatureMin)); // query parameter
 if (temperatureMinTo != null) queryParams.Add("TemperatureMinTo", ApiClient.ParameterToString(temperatureMinTo)); // query parameter
 if (temperatureMaxFilterType != null) queryParams.Add("TemperatureMaxFilterType", ApiClient.ParameterToString(temperatureMaxFilterType)); // query parameter
 if (temperatureMax != null) queryParams.Add("TemperatureMax", ApiClient.ParameterToString(temperatureMax)); // query parameter
 if (temperatureMaxTo != null) queryParams.Add("TemperatureMaxTo", ApiClient.ParameterToString(temperatureMaxTo)); // query parameter
 if (temperatureUnit != null) queryParams.Add("TemperatureUnit", ApiClient.ParameterToString(temperatureUnit)); // query parameter
 if (supplyMinFilterType != null) queryParams.Add("SupplyMinFilterType", ApiClient.ParameterToString(supplyMinFilterType)); // query parameter
 if (supplyMin != null) queryParams.Add("SupplyMin", ApiClient.ParameterToString(supplyMin)); // query parameter
 if (supplyMinTo != null) queryParams.Add("SupplyMinTo", ApiClient.ParameterToString(supplyMinTo)); // query parameter
 if (supplyMaxFilterType != null) queryParams.Add("SupplyMaxFilterType", ApiClient.ParameterToString(supplyMaxFilterType)); // query parameter
 if (supplyMax != null) queryParams.Add("SupplyMax", ApiClient.ParameterToString(supplyMax)); // query parameter
 if (supplyMaxTo != null) queryParams.Add("SupplyMaxTo", ApiClient.ParameterToString(supplyMaxTo)); // query parameter
 if (supplyMagnitudeFilterType != null) queryParams.Add("SupplyMagnitudeFilterType", ApiClient.ParameterToString(supplyMagnitudeFilterType)); // query parameter
 if (supplyMagnitude != null) queryParams.Add("SupplyMagnitude", ApiClient.ParameterToString(supplyMagnitude)); // query parameter
 if (supplyMagnitudeTo != null) queryParams.Add("SupplyMagnitudeTo", ApiClient.ParameterToString(supplyMagnitudeTo)); // query parameter
 if (supplyUnit != null) queryParams.Add("SupplyUnit", ApiClient.ParameterToString(supplyUnit)); // query parameter
 if (customerReferenceNumberSearchText != null) queryParams.Add("CustomerReferenceNumberSearchText", ApiClient.ParameterToString(customerReferenceNumberSearchText)); // query parameter
 if (customerOrderNumberSearchText != null) queryParams.Add("CustomerOrderNumberSearchText", ApiClient.ParameterToString(customerOrderNumberSearchText)); // query parameter
 if (remarksSearchText != null) queryParams.Add("RemarksSearchText", ApiClient.ParameterToString(remarksSearchText)); // query parameter
                        
            // authentication setting, if any
            String[] authSettings = new String[] { "Bearer" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling CalibrationDataGetCalibrationDataAsFile: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling CalibrationDataGetCalibrationDataAsFile: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        /// Get a list with all meta-information. 
        /// </summary>
        /// <param name="skip">OPTIONAL. Skips the given number of rows. The opposite of Take.</param>
        /// <param name="take">OPTIONAL. Takes only the first .. rows of meta information. The opposite of Skip. When not specified the API tries to get all rows.</param>
        /// <returns>List&lt;MefistoViewModel&gt;</returns>
        public List<MefistoViewModel> CalibrationDataGetCalibrationDataHeaders (int? skip, int? take)
        {
    
            var path = "/v1/CalibrationData/Headers";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (skip != null) queryParams.Add("skip", ApiClient.ParameterToString(skip)); // query parameter
 if (take != null) queryParams.Add("take", ApiClient.ParameterToString(take)); // query parameter
                        
            // authentication setting, if any
            String[] authSettings = new String[] { "Bearer" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling CalibrationDataGetCalibrationDataHeaders: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling CalibrationDataGetCalibrationDataHeaders: " + response.ErrorMessage, response.ErrorMessage);
    
            return (List<MefistoViewModel>) ApiClient.Deserialize(response.Content, typeof(List<MefistoViewModel>), response.Headers);
        }
    
        /// <summary>
        /// Only used for maintenance reasons. Do not use! 
        /// </summary>
        /// <returns>string</returns>
        public string CalibrationDataSyncCalibrationData ()
        {
    
            var path = "/v1/CalibrationData/Sync";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                    
            // authentication setting, if any
            String[] authSettings = new String[] { "Bearer" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling CalibrationDataSyncCalibrationData: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling CalibrationDataSyncCalibrationData: " + response.ErrorMessage, response.ErrorMessage);
    
            return (string) ApiClient.Deserialize(response.Content, typeof(string), response.Headers);
        }
    
        /// <summary>
        ///  
        /// </summary>
        /// <returns>int?</returns>
        public int? MeGetMeDetails ()
        {
    
            var path = "/v1/Me";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                    
            // authentication setting, if any
            String[] authSettings = new String[] { "Bearer" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling MeGetMeDetails: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling MeGetMeDetails: " + response.ErrorMessage, response.ErrorMessage);
    
            return (int?) ApiClient.Deserialize(response.Content, typeof(int?), response.Headers);
        }
    
        /// <summary>
        ///  
        /// </summary>
        /// <returns>Profile</returns>
        public Profile ProfileGetProfile ()
        {
    
            var path = "/v1/Profile";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                    
            // authentication setting, if any
            String[] authSettings = new String[] { "Bearer" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling ProfileGetProfile: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling ProfileGetProfile: " + response.ErrorMessage, response.ErrorMessage);
    
            return (Profile) ApiClient.Deserialize(response.Content, typeof(Profile), response.Headers);
        }
    
        /// <summary>
        ///  
        /// </summary>
        /// <param name="downloadFormat">Either \&quot;zip\&quot; or \&quot;br\&quot; (brotli). \&quot;zip\&quot; is default.</param>
        /// <param name="showSubCustomer">Default &#x3D; false</param>
        /// <returns>bool?</returns>
        public bool? ProfileUpdateProfile (string downloadFormat, bool? showSubCustomer)
        {
    
            var path = "/v1/Profile";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (downloadFormat != null) queryParams.Add("downloadFormat", ApiClient.ParameterToString(downloadFormat)); // query parameter
 if (showSubCustomer != null) queryParams.Add("showSubCustomer", ApiClient.ParameterToString(showSubCustomer)); // query parameter
                        
            // authentication setting, if any
            String[] authSettings = new String[] { "Bearer" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling ProfileUpdateProfile: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling ProfileUpdateProfile: " + response.ErrorMessage, response.ErrorMessage);
    
            return (bool?) ApiClient.Deserialize(response.Content, typeof(bool?), response.Headers);
        }
    
        /// <summary>
        ///  
        /// </summary>
        /// <param name="subCustomerNumber"></param>
        /// <param name="includedIds">If null: Either are &#x27;ALL SELECTED&#x27; or some are unselected (and listed in ExcludedIds)&lt;br /&gt;  If not null: None are selected except those that are listed here.&lt;br /&gt;  It is not allowed to have IncludedIds AND ExcludedIds have listed values. One most be null or both most be null.&lt;br /&gt;  The list of included ids is limited to 50. More than 50 will throw an exception.&lt;br /&gt;</param>
        /// <param name="excludedIds">If null: Either are &#x27;ALL SELECTED&#x27; or only some few are selected (and listed in IncludedIds)&lt;br /&gt;  If not null: All are selected and except those that are listed here.&lt;br /&gt;  It is not allowed to have IncludedIds AND ExcludedIds have listed values. One most be null or both most be null.&lt;br /&gt;  The list of excluded ids is limited to 50. More than 50 will throw an exception.&lt;br /&gt;</param>
        /// <param name="orderNumbers">List of Order Numbers</param>
        /// <param name="orderPositions">List of Order Positions</param>
        /// <param name="dateFilterType">One of &#x27;equals&#x27;, &#x27;greaterThan&#x27;, &#x27;lessThan&#x27;, &#x27;notEqual&#x27;, &#x27;inRange&#x27;.&lt;br /&gt;  When &#x27;inRange&#x27; then &#x27;DateTo&#x27; is needed.&lt;br /&gt;  Example 1:&lt;br /&gt;  \&quot;All data newer than August 1st\&quot; &#x3D; https://mycalibrationapi.azurewebsites.net/v1/CalibrationData?DateFilterType&#x3D;greaterThan&amp;Date&#x3D;2021-08-01&lt;br /&gt;  Example 2:&lt;br /&gt;  \&quot;All data from the year 2020\&quot; &#x3D; https://mycalibrationapi.azurewebsites.net/v1/CalibrationData?DateFilterType&#x3D;inRange&amp;Date&#x3D;2021-01-01&amp;DateTo&#x3D;2021-12-31 &lt;br /&gt;  Example 3:&lt;br /&gt;  \&quot;All data from the first day in January and February\&quot; &#x3D; https://mycalibrationapi.azurewebsites.net/v1/CalibrationData?DateFilterType&#x3D;equals&amp;Date&#x3D;2021-01-01&amp;Date&#x3D;2021-02-01 &lt;br /&gt;</param>
        /// <param name="date">Dispatch-date text in format &#x27;yyyy-MM-dd&#x27; eg. \&quot;2021-12-24\&quot;&lt;br /&gt;  Normally, this is a list with one element. Nevertheless, it is possible to GET calibration data from multiple dates. In this case DateFilterType must be &#x27;equals&#x27; and DateTo must be null.</param>
        /// <param name="dateTo">Used when DateFilterType is &#x27;inRange&#x27;.&lt;br /&gt;  Data is gathered from &#x27;Date&#x27; to &#x27;DateTo&#x27;&lt;br /&gt;  Date text in format &#x27;yyyy-MM-dd&#x27; eg. \&quot;2021-12-24\&quot;</param>
        /// <param name="customerProductTypes">To search for [Blanks] use \&quot;blank\&quot;</param>
        /// <param name="pressureTypes">Eg. [\&quot;pa\&quot;,\&quot;paa\&quot;,\&quot;pr\&quot;]  To see all possible enum strings, go to https://mycalibration.github.io/#filter-parameters</param>
        /// <param name="productSeries">Eg. [\&quot;10LHP\&quot;,\&quot;25Y\&quot;,\&quot;46X\&quot;,\&quot;K-102\&quot;]</param>
        /// <param name="productNumbers"></param>
        /// <param name="serialNumberSearchText">Use this to find all SerialNumbers that contains this text content.</param>
        /// <param name="pressureMinFilterType">One of &#x27;equals&#x27;, &#x27;greaterThan&#x27;, &#x27;lessThan&#x27;, &#x27;notEqual&#x27;, &#x27;inRange&#x27;, &#x27;lessThanOrEqual&#x27;, &#x27;greaterThanOrEqual&#x27;.&lt;br /&gt;  When &#x27;inRange&#x27; then &#x27;PressureMinTo&#x27; is needed.</param>
        /// <param name="pressureMin">The exclusive lower bound of the \&quot;Minimum Pressure\&quot;</param>
        /// <param name="pressureMinTo">The exclusive upper bound of the \&quot;Minimum Pressure\&quot;.&lt;br /&gt;  Used when PressureMinFilterType is &#x27;inRange&#x27;.&lt;br /&gt;  Data is gathered from &#x27;PressureMin&#x27; to &#x27;PressureMinTo&#x27;.&lt;br /&gt;  Date text in format &#x27;yyyy-MM-dd&#x27; eg. \&quot;2021-12-24\&quot;&lt;br /&gt;</param>
        /// <param name="pressureMaxFilterType">One of &#x27;equals&#x27;, &#x27;greaterThan&#x27;, &#x27;lessThan&#x27;, &#x27;notEqual&#x27;, &#x27;inRange&#x27;, &#x27;lessThanOrEqual&#x27;, &#x27;greaterThanOrEqual&#x27;.&lt;br /&gt;  When &#x27;inRange&#x27; then &#x27;PressureMaxTo&#x27; is needed.</param>
        /// <param name="pressureMax">The exclusive lower bound of the \&quot;Maximum Pressure\&quot;</param>
        /// <param name="pressureMaxTo">The exclusive upper bound of the \&quot;Maximum Pressure\&quot;&lt;br /&gt;  Used when PressureMaxFilterType is &#x27;inRange&#x27;.&lt;br /&gt;  Data is gathered from &#x27;PressureMax&#x27; to &#x27;PressureMaxTo&#x27;&lt;br /&gt;  Date text in format &#x27;yyyy-MM-dd&#x27; eg. \&quot;2021-12-24\&quot;</param>
        /// <param name="pressureUnit">&lt;list type&#x3D;\&quot;string\&quot;&gt;List of the Pressure Unit&lt;/list&gt;</param>
        /// <param name="temperatureMinFilterType">One of &#x27;equals&#x27;, &#x27;greaterThan&#x27;, &#x27;lessThan&#x27;, &#x27;notEqual&#x27;, &#x27;inRange&#x27;, &#x27;lessThanOrEqual&#x27;, &#x27;greaterThanOrEqual&#x27;.&lt;br /&gt;  When &#x27;inRange&#x27; then &#x27;TemperatureMinTo&#x27; is needed.</param>
        /// <param name="temperatureMin">The exclusive lower bound of the \&quot;Minimum Temperature\&quot;</param>
        /// <param name="temperatureMinTo">The exclusive upper bound of the \&quot;Minimum Temperature\&quot;&lt;br /&gt;  Used when TemperatureMinFilterType is &#x27;inRange&#x27;.&lt;br /&gt;  Data is gathered from &#x27;TemperatureMin&#x27; to &#x27;TemperatureMinTo&#x27;&lt;br /&gt;  Date text in format &#x27;yyyy-MM-dd&#x27; eg. \&quot;2021-12-24\&quot;</param>
        /// <param name="temperatureMaxFilterType">One of &#x27;equals&#x27;, &#x27;greaterThan&#x27;, &#x27;lessThan&#x27;, &#x27;notEqual&#x27;, &#x27;inRange&#x27;, &#x27;lessThanOrEqual&#x27;, &#x27;greaterThanOrEqual&#x27;.&lt;br /&gt;  When &#x27;inRange&#x27; then &#x27;TemperatureMaxTo&#x27; is needed.</param>
        /// <param name="temperatureMax">The exclusive lower bound of the \&quot;Maximum Temperature\&quot;</param>
        /// <param name="temperatureMaxTo">The exclusive upper bound of the \&quot;Maximum Temperature\&quot;&lt;br /&gt;  Used when TemperatureMaxFilterType is &#x27;inRange&#x27;.&lt;br /&gt;  Data is gathered from &#x27;TemperatureMax&#x27; to &#x27;TemperatureMaxTo&#x27;&lt;br /&gt;  Date text in format &#x27;yyyy-MM-dd&#x27; eg. \&quot;2021-12-24\&quot;</param>
        /// <param name="temperatureUnit">&lt;list type&#x3D;\&quot;string\&quot;&gt;List of the Temperature Unit&lt;/list&gt;</param>
        /// <param name="supplyMinFilterType">One of &#x27;equals&#x27;, &#x27;greaterThan&#x27;, &#x27;lessThan&#x27;, &#x27;notEqual&#x27;, &#x27;inRange&#x27;, &#x27;lessThanOrEqual&#x27;, &#x27;greaterThanOrEqual&#x27;.&lt;br /&gt;  When &#x27;inRange&#x27; then &#x27;SupplyMinTo&#x27; is needed.&lt;br /&gt;  Either Min/Max is used or Magnitude.&lt;br /&gt;</param>
        /// <param name="supplyMin">The exclusive lower bound of the \&quot;Minimum Supply\&quot;&lt;br /&gt;  Either Min/Max is used or Magnitude.</param>
        /// <param name="supplyMinTo">The exclusive upper bound of the \&quot;Minimum Supply\&quot;&lt;br /&gt;  Used when SupplyMinFilterType is &#x27;inRange&#x27;.&lt;br /&gt;  Data is gathered from &#x27;SupplyMin&#x27; to &#x27;SupplyMinTo&#x27;&lt;br /&gt;  Date text in format &#x27;yyyy-MM-dd&#x27; eg. \&quot;2021-12-24\&quot;&lt;br /&gt;  Either Min/Max is used or Magnitude.</param>
        /// <param name="supplyMaxFilterType">One of &#x27;equals&#x27;, &#x27;greaterThan&#x27;, &#x27;lessThan&#x27;, &#x27;notEqual&#x27;, &#x27;inRange&#x27;, &#x27;lessThanOrEqual&#x27;, &#x27;greaterThanOrEqual&#x27;.&lt;br /&gt;  When &#x27;inRange&#x27; then &#x27;SupplyMaxTo&#x27; is needed.&lt;br /&gt;  Either Min/Max is used or Magnitude.</param>
        /// <param name="supplyMax">The exclusive lower bound of the \&quot;Maximum Supply\&quot;&lt;br /&gt;  Either Min/Max is used or Magnitude.</param>
        /// <param name="supplyMaxTo">The exclusive upper bound of the \&quot;Maximum Supply\&quot;&lt;br /&gt;  Used when SupplyMaxFilterType is &#x27;inRange&#x27;.&lt;br /&gt;  Data is gathered from &#x27;SupplyMax&#x27; to &#x27;SupplyMaxTo&#x27;&lt;br /&gt;  Date text in format &#x27;yyyy-MM-dd&#x27; eg. \&quot;2021-12-24\&quot;&lt;br /&gt;  Either Min/Max is used or Magnitude.</param>
        /// <param name="supplyMagnitudeFilterType">One of &#x27;equals&#x27;, &#x27;greaterThan&#x27;, &#x27;lessThan&#x27;, &#x27;notEqual&#x27;, &#x27;inRange&#x27;, &#x27;lessThanOrEqual&#x27;, &#x27;greaterThanOrEqual&#x27;.&lt;br /&gt;  When &#x27;inRange&#x27; then &#x27;SupplyMagnitudeTo&#x27; is needed.&lt;br /&gt;  Either Min/Max is used or Magnitude.</param>
        /// <param name="supplyMagnitude">The exclusive lower bound of the \&quot;Supply Magnitude\&quot;&lt;br /&gt;  Either Min/Max is used or Magnitude.</param>
        /// <param name="supplyMagnitudeTo">The exclusive upper bound of the \&quot;Supply Magnitude\&quot;&lt;br /&gt;  Used when SupplyMagnitudeFilterType is &#x27;inRange&#x27;.&lt;br /&gt;  Data is gathered from &#x27;SupplyMagnitude&#x27; to &#x27;SupplyMagnitudeTo&#x27;&lt;br /&gt;  Either Min/Max is used or Magnitude.</param>
        /// <param name="supplyUnit">&lt;list type&#x3D;\&quot;string\&quot;&gt;List of the Supply Unit&lt;/list&gt;</param>
        /// <param name="customerReferenceNumberSearchText">Find all data with contains this search text</param>
        /// <param name="customerOrderNumberSearchText">Find all data with contains this search text</param>
        /// <param name="remarksSearchText">Find all data with contains this search text</param>
        /// <returns>bool?</returns>
        public bool? SubCustomerUpdateSubCustomers (int? subCustomerNumber, List<string> includedIds, List<string> excludedIds, List<string> orderNumbers, List<string> orderPositions, string dateFilterType, List<string> date, string dateTo, List<string> customerProductTypes, List<string> pressureTypes, List<string> productSeries, List<string> productNumbers, string serialNumberSearchText, string pressureMinFilterType, double? pressureMin, double? pressureMinTo, string pressureMaxFilterType, double? pressureMax, double? pressureMaxTo, List<string> pressureUnit, string temperatureMinFilterType, double? temperatureMin, double? temperatureMinTo, string temperatureMaxFilterType, double? temperatureMax, double? temperatureMaxTo, List<string> temperatureUnit, string supplyMinFilterType, double? supplyMin, double? supplyMinTo, string supplyMaxFilterType, double? supplyMax, double? supplyMaxTo, string supplyMagnitudeFilterType, double? supplyMagnitude, double? supplyMagnitudeTo, List<string> supplyUnit, string customerReferenceNumberSearchText, string customerOrderNumberSearchText, string remarksSearchText)
        {
    
            var path = "/v1/SubCustomer";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (subCustomerNumber != null) queryParams.Add("subCustomerNumber", ApiClient.ParameterToString(subCustomerNumber)); // query parameter
 if (includedIds != null) queryParams.Add("IncludedIds", ApiClient.ParameterToString(includedIds)); // query parameter
 if (excludedIds != null) queryParams.Add("ExcludedIds", ApiClient.ParameterToString(excludedIds)); // query parameter
 if (orderNumbers != null) queryParams.Add("OrderNumbers", ApiClient.ParameterToString(orderNumbers)); // query parameter
 if (orderPositions != null) queryParams.Add("OrderPositions", ApiClient.ParameterToString(orderPositions)); // query parameter
 if (dateFilterType != null) queryParams.Add("DateFilterType", ApiClient.ParameterToString(dateFilterType)); // query parameter
 if (date != null) queryParams.Add("Date", ApiClient.ParameterToString(date)); // query parameter
 if (dateTo != null) queryParams.Add("DateTo", ApiClient.ParameterToString(dateTo)); // query parameter
 if (customerProductTypes != null) queryParams.Add("CustomerProductTypes", ApiClient.ParameterToString(customerProductTypes)); // query parameter
 if (pressureTypes != null) queryParams.Add("PressureTypes", ApiClient.ParameterToString(pressureTypes)); // query parameter
 if (productSeries != null) queryParams.Add("ProductSeries", ApiClient.ParameterToString(productSeries)); // query parameter
 if (productNumbers != null) queryParams.Add("ProductNumbers", ApiClient.ParameterToString(productNumbers)); // query parameter
 if (serialNumberSearchText != null) queryParams.Add("SerialNumberSearchText", ApiClient.ParameterToString(serialNumberSearchText)); // query parameter
 if (pressureMinFilterType != null) queryParams.Add("PressureMinFilterType", ApiClient.ParameterToString(pressureMinFilterType)); // query parameter
 if (pressureMin != null) queryParams.Add("PressureMin", ApiClient.ParameterToString(pressureMin)); // query parameter
 if (pressureMinTo != null) queryParams.Add("PressureMinTo", ApiClient.ParameterToString(pressureMinTo)); // query parameter
 if (pressureMaxFilterType != null) queryParams.Add("PressureMaxFilterType", ApiClient.ParameterToString(pressureMaxFilterType)); // query parameter
 if (pressureMax != null) queryParams.Add("PressureMax", ApiClient.ParameterToString(pressureMax)); // query parameter
 if (pressureMaxTo != null) queryParams.Add("PressureMaxTo", ApiClient.ParameterToString(pressureMaxTo)); // query parameter
 if (pressureUnit != null) queryParams.Add("PressureUnit", ApiClient.ParameterToString(pressureUnit)); // query parameter
 if (temperatureMinFilterType != null) queryParams.Add("TemperatureMinFilterType", ApiClient.ParameterToString(temperatureMinFilterType)); // query parameter
 if (temperatureMin != null) queryParams.Add("TemperatureMin", ApiClient.ParameterToString(temperatureMin)); // query parameter
 if (temperatureMinTo != null) queryParams.Add("TemperatureMinTo", ApiClient.ParameterToString(temperatureMinTo)); // query parameter
 if (temperatureMaxFilterType != null) queryParams.Add("TemperatureMaxFilterType", ApiClient.ParameterToString(temperatureMaxFilterType)); // query parameter
 if (temperatureMax != null) queryParams.Add("TemperatureMax", ApiClient.ParameterToString(temperatureMax)); // query parameter
 if (temperatureMaxTo != null) queryParams.Add("TemperatureMaxTo", ApiClient.ParameterToString(temperatureMaxTo)); // query parameter
 if (temperatureUnit != null) queryParams.Add("TemperatureUnit", ApiClient.ParameterToString(temperatureUnit)); // query parameter
 if (supplyMinFilterType != null) queryParams.Add("SupplyMinFilterType", ApiClient.ParameterToString(supplyMinFilterType)); // query parameter
 if (supplyMin != null) queryParams.Add("SupplyMin", ApiClient.ParameterToString(supplyMin)); // query parameter
 if (supplyMinTo != null) queryParams.Add("SupplyMinTo", ApiClient.ParameterToString(supplyMinTo)); // query parameter
 if (supplyMaxFilterType != null) queryParams.Add("SupplyMaxFilterType", ApiClient.ParameterToString(supplyMaxFilterType)); // query parameter
 if (supplyMax != null) queryParams.Add("SupplyMax", ApiClient.ParameterToString(supplyMax)); // query parameter
 if (supplyMaxTo != null) queryParams.Add("SupplyMaxTo", ApiClient.ParameterToString(supplyMaxTo)); // query parameter
 if (supplyMagnitudeFilterType != null) queryParams.Add("SupplyMagnitudeFilterType", ApiClient.ParameterToString(supplyMagnitudeFilterType)); // query parameter
 if (supplyMagnitude != null) queryParams.Add("SupplyMagnitude", ApiClient.ParameterToString(supplyMagnitude)); // query parameter
 if (supplyMagnitudeTo != null) queryParams.Add("SupplyMagnitudeTo", ApiClient.ParameterToString(supplyMagnitudeTo)); // query parameter
 if (supplyUnit != null) queryParams.Add("SupplyUnit", ApiClient.ParameterToString(supplyUnit)); // query parameter
 if (customerReferenceNumberSearchText != null) queryParams.Add("CustomerReferenceNumberSearchText", ApiClient.ParameterToString(customerReferenceNumberSearchText)); // query parameter
 if (customerOrderNumberSearchText != null) queryParams.Add("CustomerOrderNumberSearchText", ApiClient.ParameterToString(customerOrderNumberSearchText)); // query parameter
 if (remarksSearchText != null) queryParams.Add("RemarksSearchText", ApiClient.ParameterToString(remarksSearchText)); // query parameter
                        
            // authentication setting, if any
            String[] authSettings = new String[] { "Bearer" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling SubCustomerUpdateSubCustomers: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling SubCustomerUpdateSubCustomers: " + response.ErrorMessage, response.ErrorMessage);
    
            return (bool?) ApiClient.Deserialize(response.Content, typeof(bool?), response.Headers);
        }
    
    }
}
