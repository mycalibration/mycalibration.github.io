# IO.Swagger.Api.CalibrationDataApi

All URIs are relative to *https://mycalibrationapi.azurewebsites.net/*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CalibrationDataGetCalibrationData**](CalibrationDataApi.md#calibrationdatagetcalibrationdata) | **GET** /v1/CalibrationData | Gathers all filtered data in one JSON response
[**CalibrationDataGetCalibrationDataAsFile**](CalibrationDataApi.md#calibrationdatagetcalibrationdataasfile) | **GET** /v1/CalibrationData/Export | Locates the filtered (optionalSearchParameter) data, bundles them and creates a download link
[**CalibrationDataGetCalibrationDataHeaders**](CalibrationDataApi.md#calibrationdatagetcalibrationdataheaders) | **GET** /v1/CalibrationData/Headers | Get a list with all meta-information.
[**CalibrationDataSyncCalibrationData**](CalibrationDataApi.md#calibrationdatasynccalibrationdata) | **GET** /v1/CalibrationData/Sync | Only used for maintenance reasons. Do not use!
[**MeGetMeDetails**](CalibrationDataApi.md#megetmedetails) | **GET** /v1/Me | 
[**ProfileGetProfile**](CalibrationDataApi.md#profilegetprofile) | **GET** /v1/Profile | 
[**ProfileUpdateProfile**](CalibrationDataApi.md#profileupdateprofile) | **PUT** /v1/Profile | 
[**SubCustomerUpdateSubCustomers**](CalibrationDataApi.md#subcustomerupdatesubcustomers) | **PUT** /v1/SubCustomer | 

<a name="calibrationdatagetcalibrationdata"></a>
# **CalibrationDataGetCalibrationData**
> List<KellerSensorData> CalibrationDataGetCalibrationData (List<string> includedIds, List<string> excludedIds, List<string> orderNumbers, List<string> orderPositions, string dateFilterType, List<string> date, string dateTo, List<string> customerProductTypes, List<string> pressureTypes, List<string> productSeries, List<string> productNumbers, string serialNumberSearchText, string pressureMinFilterType, double? pressureMin, double? pressureMinTo, string pressureMaxFilterType, double? pressureMax, double? pressureMaxTo, List<string> pressureUnit, string temperatureMinFilterType, double? temperatureMin, double? temperatureMinTo, string temperatureMaxFilterType, double? temperatureMax, double? temperatureMaxTo, List<string> temperatureUnit, string supplyMinFilterType, double? supplyMin, double? supplyMinTo, string supplyMaxFilterType, double? supplyMax, double? supplyMaxTo, string supplyMagnitudeFilterType, double? supplyMagnitude, double? supplyMagnitudeTo, List<string> supplyUnit, string customerReferenceNumberSearchText, string customerOrderNumberSearchText, string remarksSearchText)

Gathers all filtered data in one JSON response

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class CalibrationDataGetCalibrationDataExample
    {
        public void main()
        {

            // Configure API key authorization: Bearer
            Configuration.Default.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new CalibrationDataApi();
            var includedIds = new List<string>(); // List<string> | If null: Either are 'ALL SELECTED' or some are unselected (and listed in ExcludedIds)<br />  If not null: None are selected except those that are listed here.<br />  It is not allowed to have IncludedIds AND ExcludedIds have listed values. One most be null or both most be null.<br />  The list of included ids is limited to 50. More than 50 will throw an exception.<br /> (optional) 
            var excludedIds = new List<string>(); // List<string> | If null: Either are 'ALL SELECTED' or only some few are selected (and listed in IncludedIds)<br />  If not null: All are selected and except those that are listed here.<br />  It is not allowed to have IncludedIds AND ExcludedIds have listed values. One most be null or both most be null.<br />  The list of excluded ids is limited to 50. More than 50 will throw an exception.<br /> (optional) 
            var orderNumbers = new List<string>(); // List<string> | List of Order Numbers (optional) 
            var orderPositions = new List<string>(); // List<string> | List of Order Positions (optional) 
            var dateFilterType = dateFilterType_example;  // string | One of 'equals', 'greaterThan', 'lessThan', 'notEqual', 'inRange'.<br />  When 'inRange' then 'DateTo' is needed.<br />  Example 1:<br />  \"All data newer than August 1st\" = https://mycalibrationapi.azurewebsites.net/v1/CalibrationData?DateFilterType=greaterThan&Date=2021-08-01<br />  Example 2:<br />  \"All data from the year 2020\" = https://mycalibrationapi.azurewebsites.net/v1/CalibrationData?DateFilterType=inRange&Date=2021-01-01&DateTo=2021-12-31 <br />  Example 3:<br />  \"All data from the first day in January and February\" = https://mycalibrationapi.azurewebsites.net/v1/CalibrationData?DateFilterType=equals&Date=2021-01-01&Date=2021-02-01 <br /> (optional) 
            var date = new List<string>(); // List<string> | Dispatch-date text in format 'yyyy-MM-dd' eg. \"2021-12-24\"<br />  Normally, this is a list with one element. Nevertheless, it is possible to GET calibration data from multiple dates. In this case DateFilterType must be 'equals' and DateTo must be null. (optional) 
            var dateTo = dateTo_example;  // string | Used when DateFilterType is 'inRange'.<br />  Data is gathered from 'Date' to 'DateTo'<br />  Date text in format 'yyyy-MM-dd' eg. \"2021-12-24\" (optional) 
            var customerProductTypes = new List<string>(); // List<string> | To search for [Blanks] use \"blank\" (optional) 
            var pressureTypes = new List<string>(); // List<string> | Eg. [\"pa\",\"paa\",\"pr\"]  To see all possible enum strings, go to https://mycalibration.github.io/#filter-parameters (optional) 
            var productSeries = new List<string>(); // List<string> | Eg. [\"10LHP\",\"25Y\",\"46X\",\"K-102\"] (optional) 
            var productNumbers = new List<string>(); // List<string> |  (optional) 
            var serialNumberSearchText = serialNumberSearchText_example;  // string | Use this to find all SerialNumbers that contains this text content. (optional) 
            var pressureMinFilterType = pressureMinFilterType_example;  // string | One of 'equals', 'greaterThan', 'lessThan', 'notEqual', 'inRange', 'lessThanOrEqual', 'greaterThanOrEqual'.<br />  When 'inRange' then 'PressureMinTo' is needed. (optional) 
            var pressureMin = 1.2;  // double? | The exclusive lower bound of the \"Minimum Pressure\" (optional) 
            var pressureMinTo = 1.2;  // double? | The exclusive upper bound of the \"Minimum Pressure\".<br />  Used when PressureMinFilterType is 'inRange'.<br />  Data is gathered from 'PressureMin' to 'PressureMinTo'.<br />  Date text in format 'yyyy-MM-dd' eg. \"2021-12-24\"<br /> (optional) 
            var pressureMaxFilterType = pressureMaxFilterType_example;  // string | One of 'equals', 'greaterThan', 'lessThan', 'notEqual', 'inRange', 'lessThanOrEqual', 'greaterThanOrEqual'.<br />  When 'inRange' then 'PressureMaxTo' is needed. (optional) 
            var pressureMax = 1.2;  // double? | The exclusive lower bound of the \"Maximum Pressure\" (optional) 
            var pressureMaxTo = 1.2;  // double? | The exclusive upper bound of the \"Maximum Pressure\"<br />  Used when PressureMaxFilterType is 'inRange'.<br />  Data is gathered from 'PressureMax' to 'PressureMaxTo'<br />  Date text in format 'yyyy-MM-dd' eg. \"2021-12-24\" (optional) 
            var pressureUnit = new List<string>(); // List<string> | <list type=\"string\">List of the Pressure Unit</list> (optional) 
            var temperatureMinFilterType = temperatureMinFilterType_example;  // string | One of 'equals', 'greaterThan', 'lessThan', 'notEqual', 'inRange', 'lessThanOrEqual', 'greaterThanOrEqual'.<br />  When 'inRange' then 'TemperatureMinTo' is needed. (optional) 
            var temperatureMin = 1.2;  // double? | The exclusive lower bound of the \"Minimum Temperature\" (optional) 
            var temperatureMinTo = 1.2;  // double? | The exclusive upper bound of the \"Minimum Temperature\"<br />  Used when TemperatureMinFilterType is 'inRange'.<br />  Data is gathered from 'TemperatureMin' to 'TemperatureMinTo'<br />  Date text in format 'yyyy-MM-dd' eg. \"2021-12-24\" (optional) 
            var temperatureMaxFilterType = temperatureMaxFilterType_example;  // string | One of 'equals', 'greaterThan', 'lessThan', 'notEqual', 'inRange', 'lessThanOrEqual', 'greaterThanOrEqual'.<br />  When 'inRange' then 'TemperatureMaxTo' is needed. (optional) 
            var temperatureMax = 1.2;  // double? | The exclusive lower bound of the \"Maximum Temperature\" (optional) 
            var temperatureMaxTo = 1.2;  // double? | The exclusive upper bound of the \"Maximum Temperature\"<br />  Used when TemperatureMaxFilterType is 'inRange'.<br />  Data is gathered from 'TemperatureMax' to 'TemperatureMaxTo'<br />  Date text in format 'yyyy-MM-dd' eg. \"2021-12-24\" (optional) 
            var temperatureUnit = new List<string>(); // List<string> | <list type=\"string\">List of the Temperature Unit</list> (optional) 
            var supplyMinFilterType = supplyMinFilterType_example;  // string | One of 'equals', 'greaterThan', 'lessThan', 'notEqual', 'inRange', 'lessThanOrEqual', 'greaterThanOrEqual'.<br />  When 'inRange' then 'SupplyMinTo' is needed.<br />  Either Min/Max is used or Magnitude.<br /> (optional) 
            var supplyMin = 1.2;  // double? | The exclusive lower bound of the \"Minimum Supply\"<br />  Either Min/Max is used or Magnitude. (optional) 
            var supplyMinTo = 1.2;  // double? | The exclusive upper bound of the \"Minimum Supply\"<br />  Used when SupplyMinFilterType is 'inRange'.<br />  Data is gathered from 'SupplyMin' to 'SupplyMinTo'<br />  Date text in format 'yyyy-MM-dd' eg. \"2021-12-24\"<br />  Either Min/Max is used or Magnitude. (optional) 
            var supplyMaxFilterType = supplyMaxFilterType_example;  // string | One of 'equals', 'greaterThan', 'lessThan', 'notEqual', 'inRange', 'lessThanOrEqual', 'greaterThanOrEqual'.<br />  When 'inRange' then 'SupplyMaxTo' is needed.<br />  Either Min/Max is used or Magnitude. (optional) 
            var supplyMax = 1.2;  // double? | The exclusive lower bound of the \"Maximum Supply\"<br />  Either Min/Max is used or Magnitude. (optional) 
            var supplyMaxTo = 1.2;  // double? | The exclusive upper bound of the \"Maximum Supply\"<br />  Used when SupplyMaxFilterType is 'inRange'.<br />  Data is gathered from 'SupplyMax' to 'SupplyMaxTo'<br />  Date text in format 'yyyy-MM-dd' eg. \"2021-12-24\"<br />  Either Min/Max is used or Magnitude. (optional) 
            var supplyMagnitudeFilterType = supplyMagnitudeFilterType_example;  // string | One of 'equals', 'greaterThan', 'lessThan', 'notEqual', 'inRange', 'lessThanOrEqual', 'greaterThanOrEqual'.<br />  When 'inRange' then 'SupplyMagnitudeTo' is needed.<br />  Either Min/Max is used or Magnitude. (optional) 
            var supplyMagnitude = 1.2;  // double? | The exclusive lower bound of the \"Supply Magnitude\"<br />  Either Min/Max is used or Magnitude. (optional) 
            var supplyMagnitudeTo = 1.2;  // double? | The exclusive upper bound of the \"Supply Magnitude\"<br />  Used when SupplyMagnitudeFilterType is 'inRange'.<br />  Data is gathered from 'SupplyMagnitude' to 'SupplyMagnitudeTo'<br />  Either Min/Max is used or Magnitude. (optional) 
            var supplyUnit = new List<string>(); // List<string> | <list type=\"string\">List of the Supply Unit</list> (optional) 
            var customerReferenceNumberSearchText = customerReferenceNumberSearchText_example;  // string | Find all data with contains this search text (optional) 
            var customerOrderNumberSearchText = customerOrderNumberSearchText_example;  // string | Find all data with contains this search text (optional) 
            var remarksSearchText = remarksSearchText_example;  // string | Find all data with contains this search text (optional) 

            try
            {
                // Gathers all filtered data in one JSON response
                List&lt;KellerSensorData&gt; result = apiInstance.CalibrationDataGetCalibrationData(includedIds, excludedIds, orderNumbers, orderPositions, dateFilterType, date, dateTo, customerProductTypes, pressureTypes, productSeries, productNumbers, serialNumberSearchText, pressureMinFilterType, pressureMin, pressureMinTo, pressureMaxFilterType, pressureMax, pressureMaxTo, pressureUnit, temperatureMinFilterType, temperatureMin, temperatureMinTo, temperatureMaxFilterType, temperatureMax, temperatureMaxTo, temperatureUnit, supplyMinFilterType, supplyMin, supplyMinTo, supplyMaxFilterType, supplyMax, supplyMaxTo, supplyMagnitudeFilterType, supplyMagnitude, supplyMagnitudeTo, supplyUnit, customerReferenceNumberSearchText, customerOrderNumberSearchText, remarksSearchText);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling CalibrationDataApi.CalibrationDataGetCalibrationData: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **includedIds** | [**List<string>**](string.md)| If null: Either are &#x27;ALL SELECTED&#x27; or some are unselected (and listed in ExcludedIds)&lt;br /&gt;  If not null: None are selected except those that are listed here.&lt;br /&gt;  It is not allowed to have IncludedIds AND ExcludedIds have listed values. One most be null or both most be null.&lt;br /&gt;  The list of included ids is limited to 50. More than 50 will throw an exception.&lt;br /&gt; | [optional] 
 **excludedIds** | [**List<string>**](string.md)| If null: Either are &#x27;ALL SELECTED&#x27; or only some few are selected (and listed in IncludedIds)&lt;br /&gt;  If not null: All are selected and except those that are listed here.&lt;br /&gt;  It is not allowed to have IncludedIds AND ExcludedIds have listed values. One most be null or both most be null.&lt;br /&gt;  The list of excluded ids is limited to 50. More than 50 will throw an exception.&lt;br /&gt; | [optional] 
 **orderNumbers** | [**List<string>**](string.md)| List of Order Numbers | [optional] 
 **orderPositions** | [**List<string>**](string.md)| List of Order Positions | [optional] 
 **dateFilterType** | **string**| One of &#x27;equals&#x27;, &#x27;greaterThan&#x27;, &#x27;lessThan&#x27;, &#x27;notEqual&#x27;, &#x27;inRange&#x27;.&lt;br /&gt;  When &#x27;inRange&#x27; then &#x27;DateTo&#x27; is needed.&lt;br /&gt;  Example 1:&lt;br /&gt;  \&quot;All data newer than August 1st\&quot; &#x3D; https://mycalibrationapi.azurewebsites.net/v1/CalibrationData?DateFilterType&#x3D;greaterThan&amp;Date&#x3D;2021-08-01&lt;br /&gt;  Example 2:&lt;br /&gt;  \&quot;All data from the year 2020\&quot; &#x3D; https://mycalibrationapi.azurewebsites.net/v1/CalibrationData?DateFilterType&#x3D;inRange&amp;Date&#x3D;2021-01-01&amp;DateTo&#x3D;2021-12-31 &lt;br /&gt;  Example 3:&lt;br /&gt;  \&quot;All data from the first day in January and February\&quot; &#x3D; https://mycalibrationapi.azurewebsites.net/v1/CalibrationData?DateFilterType&#x3D;equals&amp;Date&#x3D;2021-01-01&amp;Date&#x3D;2021-02-01 &lt;br /&gt; | [optional] 
 **date** | [**List<string>**](string.md)| Dispatch-date text in format &#x27;yyyy-MM-dd&#x27; eg. \&quot;2021-12-24\&quot;&lt;br /&gt;  Normally, this is a list with one element. Nevertheless, it is possible to GET calibration data from multiple dates. In this case DateFilterType must be &#x27;equals&#x27; and DateTo must be null. | [optional] 
 **dateTo** | **string**| Used when DateFilterType is &#x27;inRange&#x27;.&lt;br /&gt;  Data is gathered from &#x27;Date&#x27; to &#x27;DateTo&#x27;&lt;br /&gt;  Date text in format &#x27;yyyy-MM-dd&#x27; eg. \&quot;2021-12-24\&quot; | [optional] 
 **customerProductTypes** | [**List<string>**](string.md)| To search for [Blanks] use \&quot;blank\&quot; | [optional] 
 **pressureTypes** | [**List<string>**](string.md)| Eg. [\&quot;pa\&quot;,\&quot;paa\&quot;,\&quot;pr\&quot;]  To see all possible enum strings, go to https://mycalibration.github.io/#filter-parameters | [optional] 
 **productSeries** | [**List<string>**](string.md)| Eg. [\&quot;10LHP\&quot;,\&quot;25Y\&quot;,\&quot;46X\&quot;,\&quot;K-102\&quot;] | [optional] 
 **productNumbers** | [**List<string>**](string.md)|  | [optional] 
 **serialNumberSearchText** | **string**| Use this to find all SerialNumbers that contains this text content. | [optional] 
 **pressureMinFilterType** | **string**| One of &#x27;equals&#x27;, &#x27;greaterThan&#x27;, &#x27;lessThan&#x27;, &#x27;notEqual&#x27;, &#x27;inRange&#x27;, &#x27;lessThanOrEqual&#x27;, &#x27;greaterThanOrEqual&#x27;.&lt;br /&gt;  When &#x27;inRange&#x27; then &#x27;PressureMinTo&#x27; is needed. | [optional] 
 **pressureMin** | **double?**| The exclusive lower bound of the \&quot;Minimum Pressure\&quot; | [optional] 
 **pressureMinTo** | **double?**| The exclusive upper bound of the \&quot;Minimum Pressure\&quot;.&lt;br /&gt;  Used when PressureMinFilterType is &#x27;inRange&#x27;.&lt;br /&gt;  Data is gathered from &#x27;PressureMin&#x27; to &#x27;PressureMinTo&#x27;.&lt;br /&gt;  Date text in format &#x27;yyyy-MM-dd&#x27; eg. \&quot;2021-12-24\&quot;&lt;br /&gt; | [optional] 
 **pressureMaxFilterType** | **string**| One of &#x27;equals&#x27;, &#x27;greaterThan&#x27;, &#x27;lessThan&#x27;, &#x27;notEqual&#x27;, &#x27;inRange&#x27;, &#x27;lessThanOrEqual&#x27;, &#x27;greaterThanOrEqual&#x27;.&lt;br /&gt;  When &#x27;inRange&#x27; then &#x27;PressureMaxTo&#x27; is needed. | [optional] 
 **pressureMax** | **double?**| The exclusive lower bound of the \&quot;Maximum Pressure\&quot; | [optional] 
 **pressureMaxTo** | **double?**| The exclusive upper bound of the \&quot;Maximum Pressure\&quot;&lt;br /&gt;  Used when PressureMaxFilterType is &#x27;inRange&#x27;.&lt;br /&gt;  Data is gathered from &#x27;PressureMax&#x27; to &#x27;PressureMaxTo&#x27;&lt;br /&gt;  Date text in format &#x27;yyyy-MM-dd&#x27; eg. \&quot;2021-12-24\&quot; | [optional] 
 **pressureUnit** | [**List<string>**](string.md)| &lt;list type&#x3D;\&quot;string\&quot;&gt;List of the Pressure Unit&lt;/list&gt; | [optional] 
 **temperatureMinFilterType** | **string**| One of &#x27;equals&#x27;, &#x27;greaterThan&#x27;, &#x27;lessThan&#x27;, &#x27;notEqual&#x27;, &#x27;inRange&#x27;, &#x27;lessThanOrEqual&#x27;, &#x27;greaterThanOrEqual&#x27;.&lt;br /&gt;  When &#x27;inRange&#x27; then &#x27;TemperatureMinTo&#x27; is needed. | [optional] 
 **temperatureMin** | **double?**| The exclusive lower bound of the \&quot;Minimum Temperature\&quot; | [optional] 
 **temperatureMinTo** | **double?**| The exclusive upper bound of the \&quot;Minimum Temperature\&quot;&lt;br /&gt;  Used when TemperatureMinFilterType is &#x27;inRange&#x27;.&lt;br /&gt;  Data is gathered from &#x27;TemperatureMin&#x27; to &#x27;TemperatureMinTo&#x27;&lt;br /&gt;  Date text in format &#x27;yyyy-MM-dd&#x27; eg. \&quot;2021-12-24\&quot; | [optional] 
 **temperatureMaxFilterType** | **string**| One of &#x27;equals&#x27;, &#x27;greaterThan&#x27;, &#x27;lessThan&#x27;, &#x27;notEqual&#x27;, &#x27;inRange&#x27;, &#x27;lessThanOrEqual&#x27;, &#x27;greaterThanOrEqual&#x27;.&lt;br /&gt;  When &#x27;inRange&#x27; then &#x27;TemperatureMaxTo&#x27; is needed. | [optional] 
 **temperatureMax** | **double?**| The exclusive lower bound of the \&quot;Maximum Temperature\&quot; | [optional] 
 **temperatureMaxTo** | **double?**| The exclusive upper bound of the \&quot;Maximum Temperature\&quot;&lt;br /&gt;  Used when TemperatureMaxFilterType is &#x27;inRange&#x27;.&lt;br /&gt;  Data is gathered from &#x27;TemperatureMax&#x27; to &#x27;TemperatureMaxTo&#x27;&lt;br /&gt;  Date text in format &#x27;yyyy-MM-dd&#x27; eg. \&quot;2021-12-24\&quot; | [optional] 
 **temperatureUnit** | [**List<string>**](string.md)| &lt;list type&#x3D;\&quot;string\&quot;&gt;List of the Temperature Unit&lt;/list&gt; | [optional] 
 **supplyMinFilterType** | **string**| One of &#x27;equals&#x27;, &#x27;greaterThan&#x27;, &#x27;lessThan&#x27;, &#x27;notEqual&#x27;, &#x27;inRange&#x27;, &#x27;lessThanOrEqual&#x27;, &#x27;greaterThanOrEqual&#x27;.&lt;br /&gt;  When &#x27;inRange&#x27; then &#x27;SupplyMinTo&#x27; is needed.&lt;br /&gt;  Either Min/Max is used or Magnitude.&lt;br /&gt; | [optional] 
 **supplyMin** | **double?**| The exclusive lower bound of the \&quot;Minimum Supply\&quot;&lt;br /&gt;  Either Min/Max is used or Magnitude. | [optional] 
 **supplyMinTo** | **double?**| The exclusive upper bound of the \&quot;Minimum Supply\&quot;&lt;br /&gt;  Used when SupplyMinFilterType is &#x27;inRange&#x27;.&lt;br /&gt;  Data is gathered from &#x27;SupplyMin&#x27; to &#x27;SupplyMinTo&#x27;&lt;br /&gt;  Date text in format &#x27;yyyy-MM-dd&#x27; eg. \&quot;2021-12-24\&quot;&lt;br /&gt;  Either Min/Max is used or Magnitude. | [optional] 
 **supplyMaxFilterType** | **string**| One of &#x27;equals&#x27;, &#x27;greaterThan&#x27;, &#x27;lessThan&#x27;, &#x27;notEqual&#x27;, &#x27;inRange&#x27;, &#x27;lessThanOrEqual&#x27;, &#x27;greaterThanOrEqual&#x27;.&lt;br /&gt;  When &#x27;inRange&#x27; then &#x27;SupplyMaxTo&#x27; is needed.&lt;br /&gt;  Either Min/Max is used or Magnitude. | [optional] 
 **supplyMax** | **double?**| The exclusive lower bound of the \&quot;Maximum Supply\&quot;&lt;br /&gt;  Either Min/Max is used or Magnitude. | [optional] 
 **supplyMaxTo** | **double?**| The exclusive upper bound of the \&quot;Maximum Supply\&quot;&lt;br /&gt;  Used when SupplyMaxFilterType is &#x27;inRange&#x27;.&lt;br /&gt;  Data is gathered from &#x27;SupplyMax&#x27; to &#x27;SupplyMaxTo&#x27;&lt;br /&gt;  Date text in format &#x27;yyyy-MM-dd&#x27; eg. \&quot;2021-12-24\&quot;&lt;br /&gt;  Either Min/Max is used or Magnitude. | [optional] 
 **supplyMagnitudeFilterType** | **string**| One of &#x27;equals&#x27;, &#x27;greaterThan&#x27;, &#x27;lessThan&#x27;, &#x27;notEqual&#x27;, &#x27;inRange&#x27;, &#x27;lessThanOrEqual&#x27;, &#x27;greaterThanOrEqual&#x27;.&lt;br /&gt;  When &#x27;inRange&#x27; then &#x27;SupplyMagnitudeTo&#x27; is needed.&lt;br /&gt;  Either Min/Max is used or Magnitude. | [optional] 
 **supplyMagnitude** | **double?**| The exclusive lower bound of the \&quot;Supply Magnitude\&quot;&lt;br /&gt;  Either Min/Max is used or Magnitude. | [optional] 
 **supplyMagnitudeTo** | **double?**| The exclusive upper bound of the \&quot;Supply Magnitude\&quot;&lt;br /&gt;  Used when SupplyMagnitudeFilterType is &#x27;inRange&#x27;.&lt;br /&gt;  Data is gathered from &#x27;SupplyMagnitude&#x27; to &#x27;SupplyMagnitudeTo&#x27;&lt;br /&gt;  Either Min/Max is used or Magnitude. | [optional] 
 **supplyUnit** | [**List<string>**](string.md)| &lt;list type&#x3D;\&quot;string\&quot;&gt;List of the Supply Unit&lt;/list&gt; | [optional] 
 **customerReferenceNumberSearchText** | **string**| Find all data with contains this search text | [optional] 
 **customerOrderNumberSearchText** | **string**| Find all data with contains this search text | [optional] 
 **remarksSearchText** | **string**| Find all data with contains this search text | [optional] 

### Return type

[**List<KellerSensorData>**](KellerSensorData.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="calibrationdatagetcalibrationdataasfile"></a>
# **CalibrationDataGetCalibrationDataAsFile**
> void CalibrationDataGetCalibrationDataAsFile (ExportFileType fileType, List<string> includedIds, List<string> excludedIds, List<string> orderNumbers, List<string> orderPositions, string dateFilterType, List<string> date, string dateTo, List<string> customerProductTypes, List<string> pressureTypes, List<string> productSeries, List<string> productNumbers, string serialNumberSearchText, string pressureMinFilterType, double? pressureMin, double? pressureMinTo, string pressureMaxFilterType, double? pressureMax, double? pressureMaxTo, List<string> pressureUnit, string temperatureMinFilterType, double? temperatureMin, double? temperatureMinTo, string temperatureMaxFilterType, double? temperatureMax, double? temperatureMaxTo, List<string> temperatureUnit, string supplyMinFilterType, double? supplyMin, double? supplyMinTo, string supplyMaxFilterType, double? supplyMax, double? supplyMaxTo, string supplyMagnitudeFilterType, double? supplyMagnitude, double? supplyMagnitudeTo, List<string> supplyUnit, string customerReferenceNumberSearchText, string customerOrderNumberSearchText, string remarksSearchText)

Locates the filtered (optionalSearchParameter) data, bundles them and creates a download link

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class CalibrationDataGetCalibrationDataAsFileExample
    {
        public void main()
        {

            // Configure API key authorization: Bearer
            Configuration.Default.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new CalibrationDataApi();
            var fileType = new ExportFileType(); // ExportFileType | 1 = All calibration data items will be merged in one JSON list  2 = All calibration data items will be merged in one JSON list. This JSON file will be compressed to zip file  3 = Every calibration data items will stored as JSON file. All these files will be compressed to one single zip file  4 = Every calibration data items will stored as JSON file. All these files will be compressed to one single brotli file (optional) 
            var includedIds = new List<string>(); // List<string> | If null: Either are 'ALL SELECTED' or some are unselected (and listed in ExcludedIds)<br />  If not null: None are selected except those that are listed here.<br />  It is not allowed to have IncludedIds AND ExcludedIds have listed values. One most be null or both most be null.<br />  The list of included ids is limited to 50. More than 50 will throw an exception.<br /> (optional) 
            var excludedIds = new List<string>(); // List<string> | If null: Either are 'ALL SELECTED' or only some few are selected (and listed in IncludedIds)<br />  If not null: All are selected and except those that are listed here.<br />  It is not allowed to have IncludedIds AND ExcludedIds have listed values. One most be null or both most be null.<br />  The list of excluded ids is limited to 50. More than 50 will throw an exception.<br /> (optional) 
            var orderNumbers = new List<string>(); // List<string> | List of Order Numbers (optional) 
            var orderPositions = new List<string>(); // List<string> | List of Order Positions (optional) 
            var dateFilterType = dateFilterType_example;  // string | One of 'equals', 'greaterThan', 'lessThan', 'notEqual', 'inRange'.<br />  When 'inRange' then 'DateTo' is needed.<br />  Example 1:<br />  \"All data newer than August 1st\" = https://mycalibrationapi.azurewebsites.net/v1/CalibrationData?DateFilterType=greaterThan&Date=2021-08-01<br />  Example 2:<br />  \"All data from the year 2020\" = https://mycalibrationapi.azurewebsites.net/v1/CalibrationData?DateFilterType=inRange&Date=2021-01-01&DateTo=2021-12-31 <br />  Example 3:<br />  \"All data from the first day in January and February\" = https://mycalibrationapi.azurewebsites.net/v1/CalibrationData?DateFilterType=equals&Date=2021-01-01&Date=2021-02-01 <br /> (optional) 
            var date = new List<string>(); // List<string> | Dispatch-date text in format 'yyyy-MM-dd' eg. \"2021-12-24\"<br />  Normally, this is a list with one element. Nevertheless, it is possible to GET calibration data from multiple dates. In this case DateFilterType must be 'equals' and DateTo must be null. (optional) 
            var dateTo = dateTo_example;  // string | Used when DateFilterType is 'inRange'.<br />  Data is gathered from 'Date' to 'DateTo'<br />  Date text in format 'yyyy-MM-dd' eg. \"2021-12-24\" (optional) 
            var customerProductTypes = new List<string>(); // List<string> | To search for [Blanks] use \"blank\" (optional) 
            var pressureTypes = new List<string>(); // List<string> | Eg. [\"pa\",\"paa\",\"pr\"]  To see all possible enum strings, go to https://mycalibration.github.io/#filter-parameters (optional) 
            var productSeries = new List<string>(); // List<string> | Eg. [\"10LHP\",\"25Y\",\"46X\",\"K-102\"] (optional) 
            var productNumbers = new List<string>(); // List<string> |  (optional) 
            var serialNumberSearchText = serialNumberSearchText_example;  // string | Use this to find all SerialNumbers that contains this text content. (optional) 
            var pressureMinFilterType = pressureMinFilterType_example;  // string | One of 'equals', 'greaterThan', 'lessThan', 'notEqual', 'inRange', 'lessThanOrEqual', 'greaterThanOrEqual'.<br />  When 'inRange' then 'PressureMinTo' is needed. (optional) 
            var pressureMin = 1.2;  // double? | The exclusive lower bound of the \"Minimum Pressure\" (optional) 
            var pressureMinTo = 1.2;  // double? | The exclusive upper bound of the \"Minimum Pressure\".<br />  Used when PressureMinFilterType is 'inRange'.<br />  Data is gathered from 'PressureMin' to 'PressureMinTo'.<br />  Date text in format 'yyyy-MM-dd' eg. \"2021-12-24\"<br /> (optional) 
            var pressureMaxFilterType = pressureMaxFilterType_example;  // string | One of 'equals', 'greaterThan', 'lessThan', 'notEqual', 'inRange', 'lessThanOrEqual', 'greaterThanOrEqual'.<br />  When 'inRange' then 'PressureMaxTo' is needed. (optional) 
            var pressureMax = 1.2;  // double? | The exclusive lower bound of the \"Maximum Pressure\" (optional) 
            var pressureMaxTo = 1.2;  // double? | The exclusive upper bound of the \"Maximum Pressure\"<br />  Used when PressureMaxFilterType is 'inRange'.<br />  Data is gathered from 'PressureMax' to 'PressureMaxTo'<br />  Date text in format 'yyyy-MM-dd' eg. \"2021-12-24\" (optional) 
            var pressureUnit = new List<string>(); // List<string> | <list type=\"string\">List of the Pressure Unit</list> (optional) 
            var temperatureMinFilterType = temperatureMinFilterType_example;  // string | One of 'equals', 'greaterThan', 'lessThan', 'notEqual', 'inRange', 'lessThanOrEqual', 'greaterThanOrEqual'.<br />  When 'inRange' then 'TemperatureMinTo' is needed. (optional) 
            var temperatureMin = 1.2;  // double? | The exclusive lower bound of the \"Minimum Temperature\" (optional) 
            var temperatureMinTo = 1.2;  // double? | The exclusive upper bound of the \"Minimum Temperature\"<br />  Used when TemperatureMinFilterType is 'inRange'.<br />  Data is gathered from 'TemperatureMin' to 'TemperatureMinTo'<br />  Date text in format 'yyyy-MM-dd' eg. \"2021-12-24\" (optional) 
            var temperatureMaxFilterType = temperatureMaxFilterType_example;  // string | One of 'equals', 'greaterThan', 'lessThan', 'notEqual', 'inRange', 'lessThanOrEqual', 'greaterThanOrEqual'.<br />  When 'inRange' then 'TemperatureMaxTo' is needed. (optional) 
            var temperatureMax = 1.2;  // double? | The exclusive lower bound of the \"Maximum Temperature\" (optional) 
            var temperatureMaxTo = 1.2;  // double? | The exclusive upper bound of the \"Maximum Temperature\"<br />  Used when TemperatureMaxFilterType is 'inRange'.<br />  Data is gathered from 'TemperatureMax' to 'TemperatureMaxTo'<br />  Date text in format 'yyyy-MM-dd' eg. \"2021-12-24\" (optional) 
            var temperatureUnit = new List<string>(); // List<string> | <list type=\"string\">List of the Temperature Unit</list> (optional) 
            var supplyMinFilterType = supplyMinFilterType_example;  // string | One of 'equals', 'greaterThan', 'lessThan', 'notEqual', 'inRange', 'lessThanOrEqual', 'greaterThanOrEqual'.<br />  When 'inRange' then 'SupplyMinTo' is needed.<br />  Either Min/Max is used or Magnitude.<br /> (optional) 
            var supplyMin = 1.2;  // double? | The exclusive lower bound of the \"Minimum Supply\"<br />  Either Min/Max is used or Magnitude. (optional) 
            var supplyMinTo = 1.2;  // double? | The exclusive upper bound of the \"Minimum Supply\"<br />  Used when SupplyMinFilterType is 'inRange'.<br />  Data is gathered from 'SupplyMin' to 'SupplyMinTo'<br />  Date text in format 'yyyy-MM-dd' eg. \"2021-12-24\"<br />  Either Min/Max is used or Magnitude. (optional) 
            var supplyMaxFilterType = supplyMaxFilterType_example;  // string | One of 'equals', 'greaterThan', 'lessThan', 'notEqual', 'inRange', 'lessThanOrEqual', 'greaterThanOrEqual'.<br />  When 'inRange' then 'SupplyMaxTo' is needed.<br />  Either Min/Max is used or Magnitude. (optional) 
            var supplyMax = 1.2;  // double? | The exclusive lower bound of the \"Maximum Supply\"<br />  Either Min/Max is used or Magnitude. (optional) 
            var supplyMaxTo = 1.2;  // double? | The exclusive upper bound of the \"Maximum Supply\"<br />  Used when SupplyMaxFilterType is 'inRange'.<br />  Data is gathered from 'SupplyMax' to 'SupplyMaxTo'<br />  Date text in format 'yyyy-MM-dd' eg. \"2021-12-24\"<br />  Either Min/Max is used or Magnitude. (optional) 
            var supplyMagnitudeFilterType = supplyMagnitudeFilterType_example;  // string | One of 'equals', 'greaterThan', 'lessThan', 'notEqual', 'inRange', 'lessThanOrEqual', 'greaterThanOrEqual'.<br />  When 'inRange' then 'SupplyMagnitudeTo' is needed.<br />  Either Min/Max is used or Magnitude. (optional) 
            var supplyMagnitude = 1.2;  // double? | The exclusive lower bound of the \"Supply Magnitude\"<br />  Either Min/Max is used or Magnitude. (optional) 
            var supplyMagnitudeTo = 1.2;  // double? | The exclusive upper bound of the \"Supply Magnitude\"<br />  Used when SupplyMagnitudeFilterType is 'inRange'.<br />  Data is gathered from 'SupplyMagnitude' to 'SupplyMagnitudeTo'<br />  Either Min/Max is used or Magnitude. (optional) 
            var supplyUnit = new List<string>(); // List<string> | <list type=\"string\">List of the Supply Unit</list> (optional) 
            var customerReferenceNumberSearchText = customerReferenceNumberSearchText_example;  // string | Find all data with contains this search text (optional) 
            var customerOrderNumberSearchText = customerOrderNumberSearchText_example;  // string | Find all data with contains this search text (optional) 
            var remarksSearchText = remarksSearchText_example;  // string | Find all data with contains this search text (optional) 

            try
            {
                // Locates the filtered (optionalSearchParameter) data, bundles them and creates a download link
                apiInstance.CalibrationDataGetCalibrationDataAsFile(fileType, includedIds, excludedIds, orderNumbers, orderPositions, dateFilterType, date, dateTo, customerProductTypes, pressureTypes, productSeries, productNumbers, serialNumberSearchText, pressureMinFilterType, pressureMin, pressureMinTo, pressureMaxFilterType, pressureMax, pressureMaxTo, pressureUnit, temperatureMinFilterType, temperatureMin, temperatureMinTo, temperatureMaxFilterType, temperatureMax, temperatureMaxTo, temperatureUnit, supplyMinFilterType, supplyMin, supplyMinTo, supplyMaxFilterType, supplyMax, supplyMaxTo, supplyMagnitudeFilterType, supplyMagnitude, supplyMagnitudeTo, supplyUnit, customerReferenceNumberSearchText, customerOrderNumberSearchText, remarksSearchText);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling CalibrationDataApi.CalibrationDataGetCalibrationDataAsFile: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **fileType** | [**ExportFileType**](.md)| 1 &#x3D; All calibration data items will be merged in one JSON list  2 &#x3D; All calibration data items will be merged in one JSON list. This JSON file will be compressed to zip file  3 &#x3D; Every calibration data items will stored as JSON file. All these files will be compressed to one single zip file  4 &#x3D; Every calibration data items will stored as JSON file. All these files will be compressed to one single brotli file | [optional] 
 **includedIds** | [**List<string>**](string.md)| If null: Either are &#x27;ALL SELECTED&#x27; or some are unselected (and listed in ExcludedIds)&lt;br /&gt;  If not null: None are selected except those that are listed here.&lt;br /&gt;  It is not allowed to have IncludedIds AND ExcludedIds have listed values. One most be null or both most be null.&lt;br /&gt;  The list of included ids is limited to 50. More than 50 will throw an exception.&lt;br /&gt; | [optional] 
 **excludedIds** | [**List<string>**](string.md)| If null: Either are &#x27;ALL SELECTED&#x27; or only some few are selected (and listed in IncludedIds)&lt;br /&gt;  If not null: All are selected and except those that are listed here.&lt;br /&gt;  It is not allowed to have IncludedIds AND ExcludedIds have listed values. One most be null or both most be null.&lt;br /&gt;  The list of excluded ids is limited to 50. More than 50 will throw an exception.&lt;br /&gt; | [optional] 
 **orderNumbers** | [**List<string>**](string.md)| List of Order Numbers | [optional] 
 **orderPositions** | [**List<string>**](string.md)| List of Order Positions | [optional] 
 **dateFilterType** | **string**| One of &#x27;equals&#x27;, &#x27;greaterThan&#x27;, &#x27;lessThan&#x27;, &#x27;notEqual&#x27;, &#x27;inRange&#x27;.&lt;br /&gt;  When &#x27;inRange&#x27; then &#x27;DateTo&#x27; is needed.&lt;br /&gt;  Example 1:&lt;br /&gt;  \&quot;All data newer than August 1st\&quot; &#x3D; https://mycalibrationapi.azurewebsites.net/v1/CalibrationData?DateFilterType&#x3D;greaterThan&amp;Date&#x3D;2021-08-01&lt;br /&gt;  Example 2:&lt;br /&gt;  \&quot;All data from the year 2020\&quot; &#x3D; https://mycalibrationapi.azurewebsites.net/v1/CalibrationData?DateFilterType&#x3D;inRange&amp;Date&#x3D;2021-01-01&amp;DateTo&#x3D;2021-12-31 &lt;br /&gt;  Example 3:&lt;br /&gt;  \&quot;All data from the first day in January and February\&quot; &#x3D; https://mycalibrationapi.azurewebsites.net/v1/CalibrationData?DateFilterType&#x3D;equals&amp;Date&#x3D;2021-01-01&amp;Date&#x3D;2021-02-01 &lt;br /&gt; | [optional] 
 **date** | [**List<string>**](string.md)| Dispatch-date text in format &#x27;yyyy-MM-dd&#x27; eg. \&quot;2021-12-24\&quot;&lt;br /&gt;  Normally, this is a list with one element. Nevertheless, it is possible to GET calibration data from multiple dates. In this case DateFilterType must be &#x27;equals&#x27; and DateTo must be null. | [optional] 
 **dateTo** | **string**| Used when DateFilterType is &#x27;inRange&#x27;.&lt;br /&gt;  Data is gathered from &#x27;Date&#x27; to &#x27;DateTo&#x27;&lt;br /&gt;  Date text in format &#x27;yyyy-MM-dd&#x27; eg. \&quot;2021-12-24\&quot; | [optional] 
 **customerProductTypes** | [**List<string>**](string.md)| To search for [Blanks] use \&quot;blank\&quot; | [optional] 
 **pressureTypes** | [**List<string>**](string.md)| Eg. [\&quot;pa\&quot;,\&quot;paa\&quot;,\&quot;pr\&quot;]  To see all possible enum strings, go to https://mycalibration.github.io/#filter-parameters | [optional] 
 **productSeries** | [**List<string>**](string.md)| Eg. [\&quot;10LHP\&quot;,\&quot;25Y\&quot;,\&quot;46X\&quot;,\&quot;K-102\&quot;] | [optional] 
 **productNumbers** | [**List<string>**](string.md)|  | [optional] 
 **serialNumberSearchText** | **string**| Use this to find all SerialNumbers that contains this text content. | [optional] 
 **pressureMinFilterType** | **string**| One of &#x27;equals&#x27;, &#x27;greaterThan&#x27;, &#x27;lessThan&#x27;, &#x27;notEqual&#x27;, &#x27;inRange&#x27;, &#x27;lessThanOrEqual&#x27;, &#x27;greaterThanOrEqual&#x27;.&lt;br /&gt;  When &#x27;inRange&#x27; then &#x27;PressureMinTo&#x27; is needed. | [optional] 
 **pressureMin** | **double?**| The exclusive lower bound of the \&quot;Minimum Pressure\&quot; | [optional] 
 **pressureMinTo** | **double?**| The exclusive upper bound of the \&quot;Minimum Pressure\&quot;.&lt;br /&gt;  Used when PressureMinFilterType is &#x27;inRange&#x27;.&lt;br /&gt;  Data is gathered from &#x27;PressureMin&#x27; to &#x27;PressureMinTo&#x27;.&lt;br /&gt;  Date text in format &#x27;yyyy-MM-dd&#x27; eg. \&quot;2021-12-24\&quot;&lt;br /&gt; | [optional] 
 **pressureMaxFilterType** | **string**| One of &#x27;equals&#x27;, &#x27;greaterThan&#x27;, &#x27;lessThan&#x27;, &#x27;notEqual&#x27;, &#x27;inRange&#x27;, &#x27;lessThanOrEqual&#x27;, &#x27;greaterThanOrEqual&#x27;.&lt;br /&gt;  When &#x27;inRange&#x27; then &#x27;PressureMaxTo&#x27; is needed. | [optional] 
 **pressureMax** | **double?**| The exclusive lower bound of the \&quot;Maximum Pressure\&quot; | [optional] 
 **pressureMaxTo** | **double?**| The exclusive upper bound of the \&quot;Maximum Pressure\&quot;&lt;br /&gt;  Used when PressureMaxFilterType is &#x27;inRange&#x27;.&lt;br /&gt;  Data is gathered from &#x27;PressureMax&#x27; to &#x27;PressureMaxTo&#x27;&lt;br /&gt;  Date text in format &#x27;yyyy-MM-dd&#x27; eg. \&quot;2021-12-24\&quot; | [optional] 
 **pressureUnit** | [**List<string>**](string.md)| &lt;list type&#x3D;\&quot;string\&quot;&gt;List of the Pressure Unit&lt;/list&gt; | [optional] 
 **temperatureMinFilterType** | **string**| One of &#x27;equals&#x27;, &#x27;greaterThan&#x27;, &#x27;lessThan&#x27;, &#x27;notEqual&#x27;, &#x27;inRange&#x27;, &#x27;lessThanOrEqual&#x27;, &#x27;greaterThanOrEqual&#x27;.&lt;br /&gt;  When &#x27;inRange&#x27; then &#x27;TemperatureMinTo&#x27; is needed. | [optional] 
 **temperatureMin** | **double?**| The exclusive lower bound of the \&quot;Minimum Temperature\&quot; | [optional] 
 **temperatureMinTo** | **double?**| The exclusive upper bound of the \&quot;Minimum Temperature\&quot;&lt;br /&gt;  Used when TemperatureMinFilterType is &#x27;inRange&#x27;.&lt;br /&gt;  Data is gathered from &#x27;TemperatureMin&#x27; to &#x27;TemperatureMinTo&#x27;&lt;br /&gt;  Date text in format &#x27;yyyy-MM-dd&#x27; eg. \&quot;2021-12-24\&quot; | [optional] 
 **temperatureMaxFilterType** | **string**| One of &#x27;equals&#x27;, &#x27;greaterThan&#x27;, &#x27;lessThan&#x27;, &#x27;notEqual&#x27;, &#x27;inRange&#x27;, &#x27;lessThanOrEqual&#x27;, &#x27;greaterThanOrEqual&#x27;.&lt;br /&gt;  When &#x27;inRange&#x27; then &#x27;TemperatureMaxTo&#x27; is needed. | [optional] 
 **temperatureMax** | **double?**| The exclusive lower bound of the \&quot;Maximum Temperature\&quot; | [optional] 
 **temperatureMaxTo** | **double?**| The exclusive upper bound of the \&quot;Maximum Temperature\&quot;&lt;br /&gt;  Used when TemperatureMaxFilterType is &#x27;inRange&#x27;.&lt;br /&gt;  Data is gathered from &#x27;TemperatureMax&#x27; to &#x27;TemperatureMaxTo&#x27;&lt;br /&gt;  Date text in format &#x27;yyyy-MM-dd&#x27; eg. \&quot;2021-12-24\&quot; | [optional] 
 **temperatureUnit** | [**List<string>**](string.md)| &lt;list type&#x3D;\&quot;string\&quot;&gt;List of the Temperature Unit&lt;/list&gt; | [optional] 
 **supplyMinFilterType** | **string**| One of &#x27;equals&#x27;, &#x27;greaterThan&#x27;, &#x27;lessThan&#x27;, &#x27;notEqual&#x27;, &#x27;inRange&#x27;, &#x27;lessThanOrEqual&#x27;, &#x27;greaterThanOrEqual&#x27;.&lt;br /&gt;  When &#x27;inRange&#x27; then &#x27;SupplyMinTo&#x27; is needed.&lt;br /&gt;  Either Min/Max is used or Magnitude.&lt;br /&gt; | [optional] 
 **supplyMin** | **double?**| The exclusive lower bound of the \&quot;Minimum Supply\&quot;&lt;br /&gt;  Either Min/Max is used or Magnitude. | [optional] 
 **supplyMinTo** | **double?**| The exclusive upper bound of the \&quot;Minimum Supply\&quot;&lt;br /&gt;  Used when SupplyMinFilterType is &#x27;inRange&#x27;.&lt;br /&gt;  Data is gathered from &#x27;SupplyMin&#x27; to &#x27;SupplyMinTo&#x27;&lt;br /&gt;  Date text in format &#x27;yyyy-MM-dd&#x27; eg. \&quot;2021-12-24\&quot;&lt;br /&gt;  Either Min/Max is used or Magnitude. | [optional] 
 **supplyMaxFilterType** | **string**| One of &#x27;equals&#x27;, &#x27;greaterThan&#x27;, &#x27;lessThan&#x27;, &#x27;notEqual&#x27;, &#x27;inRange&#x27;, &#x27;lessThanOrEqual&#x27;, &#x27;greaterThanOrEqual&#x27;.&lt;br /&gt;  When &#x27;inRange&#x27; then &#x27;SupplyMaxTo&#x27; is needed.&lt;br /&gt;  Either Min/Max is used or Magnitude. | [optional] 
 **supplyMax** | **double?**| The exclusive lower bound of the \&quot;Maximum Supply\&quot;&lt;br /&gt;  Either Min/Max is used or Magnitude. | [optional] 
 **supplyMaxTo** | **double?**| The exclusive upper bound of the \&quot;Maximum Supply\&quot;&lt;br /&gt;  Used when SupplyMaxFilterType is &#x27;inRange&#x27;.&lt;br /&gt;  Data is gathered from &#x27;SupplyMax&#x27; to &#x27;SupplyMaxTo&#x27;&lt;br /&gt;  Date text in format &#x27;yyyy-MM-dd&#x27; eg. \&quot;2021-12-24\&quot;&lt;br /&gt;  Either Min/Max is used or Magnitude. | [optional] 
 **supplyMagnitudeFilterType** | **string**| One of &#x27;equals&#x27;, &#x27;greaterThan&#x27;, &#x27;lessThan&#x27;, &#x27;notEqual&#x27;, &#x27;inRange&#x27;, &#x27;lessThanOrEqual&#x27;, &#x27;greaterThanOrEqual&#x27;.&lt;br /&gt;  When &#x27;inRange&#x27; then &#x27;SupplyMagnitudeTo&#x27; is needed.&lt;br /&gt;  Either Min/Max is used or Magnitude. | [optional] 
 **supplyMagnitude** | **double?**| The exclusive lower bound of the \&quot;Supply Magnitude\&quot;&lt;br /&gt;  Either Min/Max is used or Magnitude. | [optional] 
 **supplyMagnitudeTo** | **double?**| The exclusive upper bound of the \&quot;Supply Magnitude\&quot;&lt;br /&gt;  Used when SupplyMagnitudeFilterType is &#x27;inRange&#x27;.&lt;br /&gt;  Data is gathered from &#x27;SupplyMagnitude&#x27; to &#x27;SupplyMagnitudeTo&#x27;&lt;br /&gt;  Either Min/Max is used or Magnitude. | [optional] 
 **supplyUnit** | [**List<string>**](string.md)| &lt;list type&#x3D;\&quot;string\&quot;&gt;List of the Supply Unit&lt;/list&gt; | [optional] 
 **customerReferenceNumberSearchText** | **string**| Find all data with contains this search text | [optional] 
 **customerOrderNumberSearchText** | **string**| Find all data with contains this search text | [optional] 
 **remarksSearchText** | **string**| Find all data with contains this search text | [optional] 

### Return type

void (empty response body)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="calibrationdatagetcalibrationdataheaders"></a>
# **CalibrationDataGetCalibrationDataHeaders**
> List<MefistoViewModel> CalibrationDataGetCalibrationDataHeaders (int? skip, int? take)

Get a list with all meta-information.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class CalibrationDataGetCalibrationDataHeadersExample
    {
        public void main()
        {

            // Configure API key authorization: Bearer
            Configuration.Default.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new CalibrationDataApi();
            var skip = 56;  // int? | OPTIONAL. Skips the given number of rows. The opposite of Take. (optional)  (default to 0)
            var take = 56;  // int? | OPTIONAL. Takes only the first .. rows of meta information. The opposite of Skip. When not specified the API tries to get all rows. (optional)  (default to 2147483647)

            try
            {
                // Get a list with all meta-information.
                List&lt;MefistoViewModel&gt; result = apiInstance.CalibrationDataGetCalibrationDataHeaders(skip, take);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling CalibrationDataApi.CalibrationDataGetCalibrationDataHeaders: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **skip** | **int?**| OPTIONAL. Skips the given number of rows. The opposite of Take. | [optional] [default to 0]
 **take** | **int?**| OPTIONAL. Takes only the first .. rows of meta information. The opposite of Skip. When not specified the API tries to get all rows. | [optional] [default to 2147483647]

### Return type

[**List<MefistoViewModel>**](MefistoViewModel.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="calibrationdatasynccalibrationdata"></a>
# **CalibrationDataSyncCalibrationData**
> string CalibrationDataSyncCalibrationData ()

Only used for maintenance reasons. Do not use!

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class CalibrationDataSyncCalibrationDataExample
    {
        public void main()
        {

            // Configure API key authorization: Bearer
            Configuration.Default.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new CalibrationDataApi();

            try
            {
                // Only used for maintenance reasons. Do not use!
                string result = apiInstance.CalibrationDataSyncCalibrationData();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling CalibrationDataApi.CalibrationDataSyncCalibrationData: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

**string**

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="megetmedetails"></a>
# **MeGetMeDetails**
> int? MeGetMeDetails ()



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class MeGetMeDetailsExample
    {
        public void main()
        {

            // Configure API key authorization: Bearer
            Configuration.Default.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new CalibrationDataApi();

            try
            {
                int? result = apiInstance.MeGetMeDetails();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling CalibrationDataApi.MeGetMeDetails: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

**int?**

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="profilegetprofile"></a>
# **ProfileGetProfile**
> Profile ProfileGetProfile ()



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ProfileGetProfileExample
    {
        public void main()
        {

            // Configure API key authorization: Bearer
            Configuration.Default.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new CalibrationDataApi();

            try
            {
                Profile result = apiInstance.ProfileGetProfile();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling CalibrationDataApi.ProfileGetProfile: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**Profile**](Profile.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="profileupdateprofile"></a>
# **ProfileUpdateProfile**
> bool? ProfileUpdateProfile (string downloadFormat, bool? showSubCustomer)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ProfileUpdateProfileExample
    {
        public void main()
        {

            // Configure API key authorization: Bearer
            Configuration.Default.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new CalibrationDataApi();
            var downloadFormat = downloadFormat_example;  // string | Either \"zip\" or \"br\" (brotli). \"zip\" is default. (optional) 
            var showSubCustomer = true;  // bool? | Default = false (optional) 

            try
            {
                bool? result = apiInstance.ProfileUpdateProfile(downloadFormat, showSubCustomer);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling CalibrationDataApi.ProfileUpdateProfile: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **downloadFormat** | **string**| Either \&quot;zip\&quot; or \&quot;br\&quot; (brotli). \&quot;zip\&quot; is default. | [optional] 
 **showSubCustomer** | **bool?**| Default &#x3D; false | [optional] 

### Return type

**bool?**

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="subcustomerupdatesubcustomers"></a>
# **SubCustomerUpdateSubCustomers**
> bool? SubCustomerUpdateSubCustomers (int? subCustomerNumber, List<string> includedIds, List<string> excludedIds, List<string> orderNumbers, List<string> orderPositions, string dateFilterType, List<string> date, string dateTo, List<string> customerProductTypes, List<string> pressureTypes, List<string> productSeries, List<string> productNumbers, string serialNumberSearchText, string pressureMinFilterType, double? pressureMin, double? pressureMinTo, string pressureMaxFilterType, double? pressureMax, double? pressureMaxTo, List<string> pressureUnit, string temperatureMinFilterType, double? temperatureMin, double? temperatureMinTo, string temperatureMaxFilterType, double? temperatureMax, double? temperatureMaxTo, List<string> temperatureUnit, string supplyMinFilterType, double? supplyMin, double? supplyMinTo, string supplyMaxFilterType, double? supplyMax, double? supplyMaxTo, string supplyMagnitudeFilterType, double? supplyMagnitude, double? supplyMagnitudeTo, List<string> supplyUnit, string customerReferenceNumberSearchText, string customerOrderNumberSearchText, string remarksSearchText)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class SubCustomerUpdateSubCustomersExample
    {
        public void main()
        {

            // Configure API key authorization: Bearer
            Configuration.Default.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new CalibrationDataApi();
            var subCustomerNumber = 56;  // int? |  (optional) 
            var includedIds = new List<string>(); // List<string> | If null: Either are 'ALL SELECTED' or some are unselected (and listed in ExcludedIds)<br />  If not null: None are selected except those that are listed here.<br />  It is not allowed to have IncludedIds AND ExcludedIds have listed values. One most be null or both most be null.<br />  The list of included ids is limited to 50. More than 50 will throw an exception.<br /> (optional) 
            var excludedIds = new List<string>(); // List<string> | If null: Either are 'ALL SELECTED' or only some few are selected (and listed in IncludedIds)<br />  If not null: All are selected and except those that are listed here.<br />  It is not allowed to have IncludedIds AND ExcludedIds have listed values. One most be null or both most be null.<br />  The list of excluded ids is limited to 50. More than 50 will throw an exception.<br /> (optional) 
            var orderNumbers = new List<string>(); // List<string> | List of Order Numbers (optional) 
            var orderPositions = new List<string>(); // List<string> | List of Order Positions (optional) 
            var dateFilterType = dateFilterType_example;  // string | One of 'equals', 'greaterThan', 'lessThan', 'notEqual', 'inRange'.<br />  When 'inRange' then 'DateTo' is needed.<br />  Example 1:<br />  \"All data newer than August 1st\" = https://mycalibrationapi.azurewebsites.net/v1/CalibrationData?DateFilterType=greaterThan&Date=2021-08-01<br />  Example 2:<br />  \"All data from the year 2020\" = https://mycalibrationapi.azurewebsites.net/v1/CalibrationData?DateFilterType=inRange&Date=2021-01-01&DateTo=2021-12-31 <br />  Example 3:<br />  \"All data from the first day in January and February\" = https://mycalibrationapi.azurewebsites.net/v1/CalibrationData?DateFilterType=equals&Date=2021-01-01&Date=2021-02-01 <br /> (optional) 
            var date = new List<string>(); // List<string> | Dispatch-date text in format 'yyyy-MM-dd' eg. \"2021-12-24\"<br />  Normally, this is a list with one element. Nevertheless, it is possible to GET calibration data from multiple dates. In this case DateFilterType must be 'equals' and DateTo must be null. (optional) 
            var dateTo = dateTo_example;  // string | Used when DateFilterType is 'inRange'.<br />  Data is gathered from 'Date' to 'DateTo'<br />  Date text in format 'yyyy-MM-dd' eg. \"2021-12-24\" (optional) 
            var customerProductTypes = new List<string>(); // List<string> | To search for [Blanks] use \"blank\" (optional) 
            var pressureTypes = new List<string>(); // List<string> | Eg. [\"pa\",\"paa\",\"pr\"]  To see all possible enum strings, go to https://mycalibration.github.io/#filter-parameters (optional) 
            var productSeries = new List<string>(); // List<string> | Eg. [\"10LHP\",\"25Y\",\"46X\",\"K-102\"] (optional) 
            var productNumbers = new List<string>(); // List<string> |  (optional) 
            var serialNumberSearchText = serialNumberSearchText_example;  // string | Use this to find all SerialNumbers that contains this text content. (optional) 
            var pressureMinFilterType = pressureMinFilterType_example;  // string | One of 'equals', 'greaterThan', 'lessThan', 'notEqual', 'inRange', 'lessThanOrEqual', 'greaterThanOrEqual'.<br />  When 'inRange' then 'PressureMinTo' is needed. (optional) 
            var pressureMin = 1.2;  // double? | The exclusive lower bound of the \"Minimum Pressure\" (optional) 
            var pressureMinTo = 1.2;  // double? | The exclusive upper bound of the \"Minimum Pressure\".<br />  Used when PressureMinFilterType is 'inRange'.<br />  Data is gathered from 'PressureMin' to 'PressureMinTo'.<br />  Date text in format 'yyyy-MM-dd' eg. \"2021-12-24\"<br /> (optional) 
            var pressureMaxFilterType = pressureMaxFilterType_example;  // string | One of 'equals', 'greaterThan', 'lessThan', 'notEqual', 'inRange', 'lessThanOrEqual', 'greaterThanOrEqual'.<br />  When 'inRange' then 'PressureMaxTo' is needed. (optional) 
            var pressureMax = 1.2;  // double? | The exclusive lower bound of the \"Maximum Pressure\" (optional) 
            var pressureMaxTo = 1.2;  // double? | The exclusive upper bound of the \"Maximum Pressure\"<br />  Used when PressureMaxFilterType is 'inRange'.<br />  Data is gathered from 'PressureMax' to 'PressureMaxTo'<br />  Date text in format 'yyyy-MM-dd' eg. \"2021-12-24\" (optional) 
            var pressureUnit = new List<string>(); // List<string> | <list type=\"string\">List of the Pressure Unit</list> (optional) 
            var temperatureMinFilterType = temperatureMinFilterType_example;  // string | One of 'equals', 'greaterThan', 'lessThan', 'notEqual', 'inRange', 'lessThanOrEqual', 'greaterThanOrEqual'.<br />  When 'inRange' then 'TemperatureMinTo' is needed. (optional) 
            var temperatureMin = 1.2;  // double? | The exclusive lower bound of the \"Minimum Temperature\" (optional) 
            var temperatureMinTo = 1.2;  // double? | The exclusive upper bound of the \"Minimum Temperature\"<br />  Used when TemperatureMinFilterType is 'inRange'.<br />  Data is gathered from 'TemperatureMin' to 'TemperatureMinTo'<br />  Date text in format 'yyyy-MM-dd' eg. \"2021-12-24\" (optional) 
            var temperatureMaxFilterType = temperatureMaxFilterType_example;  // string | One of 'equals', 'greaterThan', 'lessThan', 'notEqual', 'inRange', 'lessThanOrEqual', 'greaterThanOrEqual'.<br />  When 'inRange' then 'TemperatureMaxTo' is needed. (optional) 
            var temperatureMax = 1.2;  // double? | The exclusive lower bound of the \"Maximum Temperature\" (optional) 
            var temperatureMaxTo = 1.2;  // double? | The exclusive upper bound of the \"Maximum Temperature\"<br />  Used when TemperatureMaxFilterType is 'inRange'.<br />  Data is gathered from 'TemperatureMax' to 'TemperatureMaxTo'<br />  Date text in format 'yyyy-MM-dd' eg. \"2021-12-24\" (optional) 
            var temperatureUnit = new List<string>(); // List<string> | <list type=\"string\">List of the Temperature Unit</list> (optional) 
            var supplyMinFilterType = supplyMinFilterType_example;  // string | One of 'equals', 'greaterThan', 'lessThan', 'notEqual', 'inRange', 'lessThanOrEqual', 'greaterThanOrEqual'.<br />  When 'inRange' then 'SupplyMinTo' is needed.<br />  Either Min/Max is used or Magnitude.<br /> (optional) 
            var supplyMin = 1.2;  // double? | The exclusive lower bound of the \"Minimum Supply\"<br />  Either Min/Max is used or Magnitude. (optional) 
            var supplyMinTo = 1.2;  // double? | The exclusive upper bound of the \"Minimum Supply\"<br />  Used when SupplyMinFilterType is 'inRange'.<br />  Data is gathered from 'SupplyMin' to 'SupplyMinTo'<br />  Date text in format 'yyyy-MM-dd' eg. \"2021-12-24\"<br />  Either Min/Max is used or Magnitude. (optional) 
            var supplyMaxFilterType = supplyMaxFilterType_example;  // string | One of 'equals', 'greaterThan', 'lessThan', 'notEqual', 'inRange', 'lessThanOrEqual', 'greaterThanOrEqual'.<br />  When 'inRange' then 'SupplyMaxTo' is needed.<br />  Either Min/Max is used or Magnitude. (optional) 
            var supplyMax = 1.2;  // double? | The exclusive lower bound of the \"Maximum Supply\"<br />  Either Min/Max is used or Magnitude. (optional) 
            var supplyMaxTo = 1.2;  // double? | The exclusive upper bound of the \"Maximum Supply\"<br />  Used when SupplyMaxFilterType is 'inRange'.<br />  Data is gathered from 'SupplyMax' to 'SupplyMaxTo'<br />  Date text in format 'yyyy-MM-dd' eg. \"2021-12-24\"<br />  Either Min/Max is used or Magnitude. (optional) 
            var supplyMagnitudeFilterType = supplyMagnitudeFilterType_example;  // string | One of 'equals', 'greaterThan', 'lessThan', 'notEqual', 'inRange', 'lessThanOrEqual', 'greaterThanOrEqual'.<br />  When 'inRange' then 'SupplyMagnitudeTo' is needed.<br />  Either Min/Max is used or Magnitude. (optional) 
            var supplyMagnitude = 1.2;  // double? | The exclusive lower bound of the \"Supply Magnitude\"<br />  Either Min/Max is used or Magnitude. (optional) 
            var supplyMagnitudeTo = 1.2;  // double? | The exclusive upper bound of the \"Supply Magnitude\"<br />  Used when SupplyMagnitudeFilterType is 'inRange'.<br />  Data is gathered from 'SupplyMagnitude' to 'SupplyMagnitudeTo'<br />  Either Min/Max is used or Magnitude. (optional) 
            var supplyUnit = new List<string>(); // List<string> | <list type=\"string\">List of the Supply Unit</list> (optional) 
            var customerReferenceNumberSearchText = customerReferenceNumberSearchText_example;  // string | Find all data with contains this search text (optional) 
            var customerOrderNumberSearchText = customerOrderNumberSearchText_example;  // string | Find all data with contains this search text (optional) 
            var remarksSearchText = remarksSearchText_example;  // string | Find all data with contains this search text (optional) 

            try
            {
                bool? result = apiInstance.SubCustomerUpdateSubCustomers(subCustomerNumber, includedIds, excludedIds, orderNumbers, orderPositions, dateFilterType, date, dateTo, customerProductTypes, pressureTypes, productSeries, productNumbers, serialNumberSearchText, pressureMinFilterType, pressureMin, pressureMinTo, pressureMaxFilterType, pressureMax, pressureMaxTo, pressureUnit, temperatureMinFilterType, temperatureMin, temperatureMinTo, temperatureMaxFilterType, temperatureMax, temperatureMaxTo, temperatureUnit, supplyMinFilterType, supplyMin, supplyMinTo, supplyMaxFilterType, supplyMax, supplyMaxTo, supplyMagnitudeFilterType, supplyMagnitude, supplyMagnitudeTo, supplyUnit, customerReferenceNumberSearchText, customerOrderNumberSearchText, remarksSearchText);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling CalibrationDataApi.SubCustomerUpdateSubCustomers: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **subCustomerNumber** | **int?**|  | [optional] 
 **includedIds** | [**List<string>**](string.md)| If null: Either are &#x27;ALL SELECTED&#x27; or some are unselected (and listed in ExcludedIds)&lt;br /&gt;  If not null: None are selected except those that are listed here.&lt;br /&gt;  It is not allowed to have IncludedIds AND ExcludedIds have listed values. One most be null or both most be null.&lt;br /&gt;  The list of included ids is limited to 50. More than 50 will throw an exception.&lt;br /&gt; | [optional] 
 **excludedIds** | [**List<string>**](string.md)| If null: Either are &#x27;ALL SELECTED&#x27; or only some few are selected (and listed in IncludedIds)&lt;br /&gt;  If not null: All are selected and except those that are listed here.&lt;br /&gt;  It is not allowed to have IncludedIds AND ExcludedIds have listed values. One most be null or both most be null.&lt;br /&gt;  The list of excluded ids is limited to 50. More than 50 will throw an exception.&lt;br /&gt; | [optional] 
 **orderNumbers** | [**List<string>**](string.md)| List of Order Numbers | [optional] 
 **orderPositions** | [**List<string>**](string.md)| List of Order Positions | [optional] 
 **dateFilterType** | **string**| One of &#x27;equals&#x27;, &#x27;greaterThan&#x27;, &#x27;lessThan&#x27;, &#x27;notEqual&#x27;, &#x27;inRange&#x27;.&lt;br /&gt;  When &#x27;inRange&#x27; then &#x27;DateTo&#x27; is needed.&lt;br /&gt;  Example 1:&lt;br /&gt;  \&quot;All data newer than August 1st\&quot; &#x3D; https://mycalibrationapi.azurewebsites.net/v1/CalibrationData?DateFilterType&#x3D;greaterThan&amp;Date&#x3D;2021-08-01&lt;br /&gt;  Example 2:&lt;br /&gt;  \&quot;All data from the year 2020\&quot; &#x3D; https://mycalibrationapi.azurewebsites.net/v1/CalibrationData?DateFilterType&#x3D;inRange&amp;Date&#x3D;2021-01-01&amp;DateTo&#x3D;2021-12-31 &lt;br /&gt;  Example 3:&lt;br /&gt;  \&quot;All data from the first day in January and February\&quot; &#x3D; https://mycalibrationapi.azurewebsites.net/v1/CalibrationData?DateFilterType&#x3D;equals&amp;Date&#x3D;2021-01-01&amp;Date&#x3D;2021-02-01 &lt;br /&gt; | [optional] 
 **date** | [**List<string>**](string.md)| Dispatch-date text in format &#x27;yyyy-MM-dd&#x27; eg. \&quot;2021-12-24\&quot;&lt;br /&gt;  Normally, this is a list with one element. Nevertheless, it is possible to GET calibration data from multiple dates. In this case DateFilterType must be &#x27;equals&#x27; and DateTo must be null. | [optional] 
 **dateTo** | **string**| Used when DateFilterType is &#x27;inRange&#x27;.&lt;br /&gt;  Data is gathered from &#x27;Date&#x27; to &#x27;DateTo&#x27;&lt;br /&gt;  Date text in format &#x27;yyyy-MM-dd&#x27; eg. \&quot;2021-12-24\&quot; | [optional] 
 **customerProductTypes** | [**List<string>**](string.md)| To search for [Blanks] use \&quot;blank\&quot; | [optional] 
 **pressureTypes** | [**List<string>**](string.md)| Eg. [\&quot;pa\&quot;,\&quot;paa\&quot;,\&quot;pr\&quot;]  To see all possible enum strings, go to https://mycalibration.github.io/#filter-parameters | [optional] 
 **productSeries** | [**List<string>**](string.md)| Eg. [\&quot;10LHP\&quot;,\&quot;25Y\&quot;,\&quot;46X\&quot;,\&quot;K-102\&quot;] | [optional] 
 **productNumbers** | [**List<string>**](string.md)|  | [optional] 
 **serialNumberSearchText** | **string**| Use this to find all SerialNumbers that contains this text content. | [optional] 
 **pressureMinFilterType** | **string**| One of &#x27;equals&#x27;, &#x27;greaterThan&#x27;, &#x27;lessThan&#x27;, &#x27;notEqual&#x27;, &#x27;inRange&#x27;, &#x27;lessThanOrEqual&#x27;, &#x27;greaterThanOrEqual&#x27;.&lt;br /&gt;  When &#x27;inRange&#x27; then &#x27;PressureMinTo&#x27; is needed. | [optional] 
 **pressureMin** | **double?**| The exclusive lower bound of the \&quot;Minimum Pressure\&quot; | [optional] 
 **pressureMinTo** | **double?**| The exclusive upper bound of the \&quot;Minimum Pressure\&quot;.&lt;br /&gt;  Used when PressureMinFilterType is &#x27;inRange&#x27;.&lt;br /&gt;  Data is gathered from &#x27;PressureMin&#x27; to &#x27;PressureMinTo&#x27;.&lt;br /&gt;  Date text in format &#x27;yyyy-MM-dd&#x27; eg. \&quot;2021-12-24\&quot;&lt;br /&gt; | [optional] 
 **pressureMaxFilterType** | **string**| One of &#x27;equals&#x27;, &#x27;greaterThan&#x27;, &#x27;lessThan&#x27;, &#x27;notEqual&#x27;, &#x27;inRange&#x27;, &#x27;lessThanOrEqual&#x27;, &#x27;greaterThanOrEqual&#x27;.&lt;br /&gt;  When &#x27;inRange&#x27; then &#x27;PressureMaxTo&#x27; is needed. | [optional] 
 **pressureMax** | **double?**| The exclusive lower bound of the \&quot;Maximum Pressure\&quot; | [optional] 
 **pressureMaxTo** | **double?**| The exclusive upper bound of the \&quot;Maximum Pressure\&quot;&lt;br /&gt;  Used when PressureMaxFilterType is &#x27;inRange&#x27;.&lt;br /&gt;  Data is gathered from &#x27;PressureMax&#x27; to &#x27;PressureMaxTo&#x27;&lt;br /&gt;  Date text in format &#x27;yyyy-MM-dd&#x27; eg. \&quot;2021-12-24\&quot; | [optional] 
 **pressureUnit** | [**List<string>**](string.md)| &lt;list type&#x3D;\&quot;string\&quot;&gt;List of the Pressure Unit&lt;/list&gt; | [optional] 
 **temperatureMinFilterType** | **string**| One of &#x27;equals&#x27;, &#x27;greaterThan&#x27;, &#x27;lessThan&#x27;, &#x27;notEqual&#x27;, &#x27;inRange&#x27;, &#x27;lessThanOrEqual&#x27;, &#x27;greaterThanOrEqual&#x27;.&lt;br /&gt;  When &#x27;inRange&#x27; then &#x27;TemperatureMinTo&#x27; is needed. | [optional] 
 **temperatureMin** | **double?**| The exclusive lower bound of the \&quot;Minimum Temperature\&quot; | [optional] 
 **temperatureMinTo** | **double?**| The exclusive upper bound of the \&quot;Minimum Temperature\&quot;&lt;br /&gt;  Used when TemperatureMinFilterType is &#x27;inRange&#x27;.&lt;br /&gt;  Data is gathered from &#x27;TemperatureMin&#x27; to &#x27;TemperatureMinTo&#x27;&lt;br /&gt;  Date text in format &#x27;yyyy-MM-dd&#x27; eg. \&quot;2021-12-24\&quot; | [optional] 
 **temperatureMaxFilterType** | **string**| One of &#x27;equals&#x27;, &#x27;greaterThan&#x27;, &#x27;lessThan&#x27;, &#x27;notEqual&#x27;, &#x27;inRange&#x27;, &#x27;lessThanOrEqual&#x27;, &#x27;greaterThanOrEqual&#x27;.&lt;br /&gt;  When &#x27;inRange&#x27; then &#x27;TemperatureMaxTo&#x27; is needed. | [optional] 
 **temperatureMax** | **double?**| The exclusive lower bound of the \&quot;Maximum Temperature\&quot; | [optional] 
 **temperatureMaxTo** | **double?**| The exclusive upper bound of the \&quot;Maximum Temperature\&quot;&lt;br /&gt;  Used when TemperatureMaxFilterType is &#x27;inRange&#x27;.&lt;br /&gt;  Data is gathered from &#x27;TemperatureMax&#x27; to &#x27;TemperatureMaxTo&#x27;&lt;br /&gt;  Date text in format &#x27;yyyy-MM-dd&#x27; eg. \&quot;2021-12-24\&quot; | [optional] 
 **temperatureUnit** | [**List<string>**](string.md)| &lt;list type&#x3D;\&quot;string\&quot;&gt;List of the Temperature Unit&lt;/list&gt; | [optional] 
 **supplyMinFilterType** | **string**| One of &#x27;equals&#x27;, &#x27;greaterThan&#x27;, &#x27;lessThan&#x27;, &#x27;notEqual&#x27;, &#x27;inRange&#x27;, &#x27;lessThanOrEqual&#x27;, &#x27;greaterThanOrEqual&#x27;.&lt;br /&gt;  When &#x27;inRange&#x27; then &#x27;SupplyMinTo&#x27; is needed.&lt;br /&gt;  Either Min/Max is used or Magnitude.&lt;br /&gt; | [optional] 
 **supplyMin** | **double?**| The exclusive lower bound of the \&quot;Minimum Supply\&quot;&lt;br /&gt;  Either Min/Max is used or Magnitude. | [optional] 
 **supplyMinTo** | **double?**| The exclusive upper bound of the \&quot;Minimum Supply\&quot;&lt;br /&gt;  Used when SupplyMinFilterType is &#x27;inRange&#x27;.&lt;br /&gt;  Data is gathered from &#x27;SupplyMin&#x27; to &#x27;SupplyMinTo&#x27;&lt;br /&gt;  Date text in format &#x27;yyyy-MM-dd&#x27; eg. \&quot;2021-12-24\&quot;&lt;br /&gt;  Either Min/Max is used or Magnitude. | [optional] 
 **supplyMaxFilterType** | **string**| One of &#x27;equals&#x27;, &#x27;greaterThan&#x27;, &#x27;lessThan&#x27;, &#x27;notEqual&#x27;, &#x27;inRange&#x27;, &#x27;lessThanOrEqual&#x27;, &#x27;greaterThanOrEqual&#x27;.&lt;br /&gt;  When &#x27;inRange&#x27; then &#x27;SupplyMaxTo&#x27; is needed.&lt;br /&gt;  Either Min/Max is used or Magnitude. | [optional] 
 **supplyMax** | **double?**| The exclusive lower bound of the \&quot;Maximum Supply\&quot;&lt;br /&gt;  Either Min/Max is used or Magnitude. | [optional] 
 **supplyMaxTo** | **double?**| The exclusive upper bound of the \&quot;Maximum Supply\&quot;&lt;br /&gt;  Used when SupplyMaxFilterType is &#x27;inRange&#x27;.&lt;br /&gt;  Data is gathered from &#x27;SupplyMax&#x27; to &#x27;SupplyMaxTo&#x27;&lt;br /&gt;  Date text in format &#x27;yyyy-MM-dd&#x27; eg. \&quot;2021-12-24\&quot;&lt;br /&gt;  Either Min/Max is used or Magnitude. | [optional] 
 **supplyMagnitudeFilterType** | **string**| One of &#x27;equals&#x27;, &#x27;greaterThan&#x27;, &#x27;lessThan&#x27;, &#x27;notEqual&#x27;, &#x27;inRange&#x27;, &#x27;lessThanOrEqual&#x27;, &#x27;greaterThanOrEqual&#x27;.&lt;br /&gt;  When &#x27;inRange&#x27; then &#x27;SupplyMagnitudeTo&#x27; is needed.&lt;br /&gt;  Either Min/Max is used or Magnitude. | [optional] 
 **supplyMagnitude** | **double?**| The exclusive lower bound of the \&quot;Supply Magnitude\&quot;&lt;br /&gt;  Either Min/Max is used or Magnitude. | [optional] 
 **supplyMagnitudeTo** | **double?**| The exclusive upper bound of the \&quot;Supply Magnitude\&quot;&lt;br /&gt;  Used when SupplyMagnitudeFilterType is &#x27;inRange&#x27;.&lt;br /&gt;  Data is gathered from &#x27;SupplyMagnitude&#x27; to &#x27;SupplyMagnitudeTo&#x27;&lt;br /&gt;  Either Min/Max is used or Magnitude. | [optional] 
 **supplyUnit** | [**List<string>**](string.md)| &lt;list type&#x3D;\&quot;string\&quot;&gt;List of the Supply Unit&lt;/list&gt; | [optional] 
 **customerReferenceNumberSearchText** | **string**| Find all data with contains this search text | [optional] 
 **customerOrderNumberSearchText** | **string**| Find all data with contains this search text | [optional] 
 **remarksSearchText** | **string**| Find all data with contains this search text | [optional] 

### Return type

**bool?**

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

