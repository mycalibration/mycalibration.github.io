# swagger_client.CalibrationDataApi

All URIs are relative to *https://mycalibrationapi.azurewebsites.net/*

Method | HTTP request | Description
------------- | ------------- | -------------
[**calibration_data_get_calibration_data**](CalibrationDataApi.md#calibration_data_get_calibration_data) | **GET** /v1/CalibrationData | Gathers all filtered data in one JSON response
[**calibration_data_get_calibration_data_as_file**](CalibrationDataApi.md#calibration_data_get_calibration_data_as_file) | **GET** /v1/CalibrationData/Export | Locates the filtered (optionalSearchParameter) data, bundles them and creates a download link
[**calibration_data_get_calibration_data_headers**](CalibrationDataApi.md#calibration_data_get_calibration_data_headers) | **GET** /v1/CalibrationData/Headers | Get a list with all meta-information.
[**calibration_data_sync_calibration_data**](CalibrationDataApi.md#calibration_data_sync_calibration_data) | **GET** /v1/CalibrationData/Sync | Only used for maintenance reasons. Do not use!
[**me_get_me_details**](CalibrationDataApi.md#me_get_me_details) | **GET** /v1/Me | 
[**profile_get_profile**](CalibrationDataApi.md#profile_get_profile) | **GET** /v1/Profile | 
[**profile_update_profile**](CalibrationDataApi.md#profile_update_profile) | **PUT** /v1/Profile | 
[**sub_customer_update_sub_customers**](CalibrationDataApi.md#sub_customer_update_sub_customers) | **PUT** /v1/SubCustomer | 

# **calibration_data_get_calibration_data**
> list[KellerSensorData] calibration_data_get_calibration_data(included_ids=included_ids, excluded_ids=excluded_ids, order_numbers=order_numbers, order_positions=order_positions, date_filter_type=date_filter_type, _date=_date, date_to=date_to, customer_product_types=customer_product_types, pressure_types=pressure_types, product_series=product_series, product_numbers=product_numbers, serial_number_search_text=serial_number_search_text, pressure_min_filter_type=pressure_min_filter_type, pressure_min=pressure_min, pressure_min_to=pressure_min_to, pressure_max_filter_type=pressure_max_filter_type, pressure_max=pressure_max, pressure_max_to=pressure_max_to, pressure_unit=pressure_unit, temperature_min_filter_type=temperature_min_filter_type, temperature_min=temperature_min, temperature_min_to=temperature_min_to, temperature_max_filter_type=temperature_max_filter_type, temperature_max=temperature_max, temperature_max_to=temperature_max_to, temperature_unit=temperature_unit, supply_min_filter_type=supply_min_filter_type, supply_min=supply_min, supply_min_to=supply_min_to, supply_max_filter_type=supply_max_filter_type, supply_max=supply_max, supply_max_to=supply_max_to, supply_magnitude_filter_type=supply_magnitude_filter_type, supply_magnitude=supply_magnitude, supply_magnitude_to=supply_magnitude_to, supply_unit=supply_unit, customer_reference_number_search_text=customer_reference_number_search_text, customer_order_number_search_text=customer_order_number_search_text, remarks_search_text=remarks_search_text)

Gathers all filtered data in one JSON response

### Example
```python
from __future__ import print_function
import time
import swagger_client
from swagger_client.rest import ApiException
from pprint import pprint

# Configure API key authorization: Bearer
configuration = swagger_client.Configuration()
configuration.api_key['Authorization'] = 'YOUR_API_KEY'
# Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
# configuration.api_key_prefix['Authorization'] = 'Bearer'

# create an instance of the API class
api_instance = swagger_client.CalibrationDataApi(swagger_client.ApiClient(configuration))
included_ids = ['included_ids_example'] # list[str] | If null: Either are 'ALL SELECTED' or some are unselected (and listed in ExcludedIds)<br />  If not null: None are selected except those that are listed here.<br />  It is not allowed to have IncludedIds AND ExcludedIds have listed values. One most be null or both most be null.<br />  The list of included ids is limited to 50. More than 50 will throw an exception.<br /> (optional)
excluded_ids = ['excluded_ids_example'] # list[str] | If null: Either are 'ALL SELECTED' or only some few are selected (and listed in IncludedIds)<br />  If not null: All are selected and except those that are listed here.<br />  It is not allowed to have IncludedIds AND ExcludedIds have listed values. One most be null or both most be null.<br />  The list of excluded ids is limited to 50. More than 50 will throw an exception.<br /> (optional)
order_numbers = ['order_numbers_example'] # list[str] | List of Order Numbers (optional)
order_positions = ['order_positions_example'] # list[str] | List of Order Positions (optional)
date_filter_type = 'date_filter_type_example' # str | One of 'equals', 'greaterThan', 'lessThan', 'notEqual', 'inRange'.<br />  When 'inRange' then 'DateTo' is needed.<br />  Example 1:<br />  \"All data newer than August 1st\" = https://mycalibrationapi.azurewebsites.net/v1/CalibrationData?DateFilterType=greaterThan&Date=2021-08-01<br />  Example 2:<br />  \"All data from the year 2020\" = https://mycalibrationapi.azurewebsites.net/v1/CalibrationData?DateFilterType=inRange&Date=2021-01-01&DateTo=2021-12-31 <br />  Example 3:<br />  \"All data from the first day in January and February\" = https://mycalibrationapi.azurewebsites.net/v1/CalibrationData?DateFilterType=equals&Date=2021-01-01&Date=2021-02-01 <br /> (optional)
_date = ['_date_example'] # list[str] | Dispatch-date text in format 'yyyy-MM-dd' eg. \"2021-12-24\"<br />  Normally, this is a list with one element. Nevertheless, it is possible to GET calibration data from multiple dates. In this case DateFilterType must be 'equals' and DateTo must be null. (optional)
date_to = 'date_to_example' # str | Used when DateFilterType is 'inRange'.<br />  Data is gathered from 'Date' to 'DateTo'<br />  Date text in format 'yyyy-MM-dd' eg. \"2021-12-24\" (optional)
customer_product_types = ['customer_product_types_example'] # list[str] | To search for [Blanks] use \"blank\" (optional)
pressure_types = ['pressure_types_example'] # list[str] | Eg. [\"pa\",\"paa\",\"pr\"]  To see all possible enum strings, go to https://mycalibration.github.io/#filter-parameters (optional)
product_series = ['product_series_example'] # list[str] | Eg. [\"10LHP\",\"25Y\",\"46X\",\"K-102\"] (optional)
product_numbers = ['product_numbers_example'] # list[str] |  (optional)
serial_number_search_text = 'serial_number_search_text_example' # str | Use this to find all SerialNumbers that contains this text content. (optional)
pressure_min_filter_type = 'pressure_min_filter_type_example' # str | One of 'equals', 'greaterThan', 'lessThan', 'notEqual', 'inRange', 'lessThanOrEqual', 'greaterThanOrEqual'.<br />  When 'inRange' then 'PressureMinTo' is needed. (optional)
pressure_min = 1.2 # float | The exclusive lower bound of the \"Minimum Pressure\" (optional)
pressure_min_to = 1.2 # float | The exclusive upper bound of the \"Minimum Pressure\".<br />  Used when PressureMinFilterType is 'inRange'.<br />  Data is gathered from 'PressureMin' to 'PressureMinTo'.<br />  Date text in format 'yyyy-MM-dd' eg. \"2021-12-24\"<br /> (optional)
pressure_max_filter_type = 'pressure_max_filter_type_example' # str | One of 'equals', 'greaterThan', 'lessThan', 'notEqual', 'inRange', 'lessThanOrEqual', 'greaterThanOrEqual'.<br />  When 'inRange' then 'PressureMaxTo' is needed. (optional)
pressure_max = 1.2 # float | The exclusive lower bound of the \"Maximum Pressure\" (optional)
pressure_max_to = 1.2 # float | The exclusive upper bound of the \"Maximum Pressure\"<br />  Used when PressureMaxFilterType is 'inRange'.<br />  Data is gathered from 'PressureMax' to 'PressureMaxTo'<br />  Date text in format 'yyyy-MM-dd' eg. \"2021-12-24\" (optional)
pressure_unit = ['pressure_unit_example'] # list[str] | <list type=\"string\">List of the Pressure Unit</list> (optional)
temperature_min_filter_type = 'temperature_min_filter_type_example' # str | One of 'equals', 'greaterThan', 'lessThan', 'notEqual', 'inRange', 'lessThanOrEqual', 'greaterThanOrEqual'.<br />  When 'inRange' then 'TemperatureMinTo' is needed. (optional)
temperature_min = 1.2 # float | The exclusive lower bound of the \"Minimum Temperature\" (optional)
temperature_min_to = 1.2 # float | The exclusive upper bound of the \"Minimum Temperature\"<br />  Used when TemperatureMinFilterType is 'inRange'.<br />  Data is gathered from 'TemperatureMin' to 'TemperatureMinTo'<br />  Date text in format 'yyyy-MM-dd' eg. \"2021-12-24\" (optional)
temperature_max_filter_type = 'temperature_max_filter_type_example' # str | One of 'equals', 'greaterThan', 'lessThan', 'notEqual', 'inRange', 'lessThanOrEqual', 'greaterThanOrEqual'.<br />  When 'inRange' then 'TemperatureMaxTo' is needed. (optional)
temperature_max = 1.2 # float | The exclusive lower bound of the \"Maximum Temperature\" (optional)
temperature_max_to = 1.2 # float | The exclusive upper bound of the \"Maximum Temperature\"<br />  Used when TemperatureMaxFilterType is 'inRange'.<br />  Data is gathered from 'TemperatureMax' to 'TemperatureMaxTo'<br />  Date text in format 'yyyy-MM-dd' eg. \"2021-12-24\" (optional)
temperature_unit = ['temperature_unit_example'] # list[str] | <list type=\"string\">List of the Temperature Unit</list> (optional)
supply_min_filter_type = 'supply_min_filter_type_example' # str | One of 'equals', 'greaterThan', 'lessThan', 'notEqual', 'inRange', 'lessThanOrEqual', 'greaterThanOrEqual'.<br />  When 'inRange' then 'SupplyMinTo' is needed.<br />  Either Min/Max is used or Magnitude.<br /> (optional)
supply_min = 1.2 # float | The exclusive lower bound of the \"Minimum Supply\"<br />  Either Min/Max is used or Magnitude. (optional)
supply_min_to = 1.2 # float | The exclusive upper bound of the \"Minimum Supply\"<br />  Used when SupplyMinFilterType is 'inRange'.<br />  Data is gathered from 'SupplyMin' to 'SupplyMinTo'<br />  Date text in format 'yyyy-MM-dd' eg. \"2021-12-24\"<br />  Either Min/Max is used or Magnitude. (optional)
supply_max_filter_type = 'supply_max_filter_type_example' # str | One of 'equals', 'greaterThan', 'lessThan', 'notEqual', 'inRange', 'lessThanOrEqual', 'greaterThanOrEqual'.<br />  When 'inRange' then 'SupplyMaxTo' is needed.<br />  Either Min/Max is used or Magnitude. (optional)
supply_max = 1.2 # float | The exclusive lower bound of the \"Maximum Supply\"<br />  Either Min/Max is used or Magnitude. (optional)
supply_max_to = 1.2 # float | The exclusive upper bound of the \"Maximum Supply\"<br />  Used when SupplyMaxFilterType is 'inRange'.<br />  Data is gathered from 'SupplyMax' to 'SupplyMaxTo'<br />  Date text in format 'yyyy-MM-dd' eg. \"2021-12-24\"<br />  Either Min/Max is used or Magnitude. (optional)
supply_magnitude_filter_type = 'supply_magnitude_filter_type_example' # str | One of 'equals', 'greaterThan', 'lessThan', 'notEqual', 'inRange', 'lessThanOrEqual', 'greaterThanOrEqual'.<br />  When 'inRange' then 'SupplyMagnitudeTo' is needed.<br />  Either Min/Max is used or Magnitude. (optional)
supply_magnitude = 1.2 # float | The exclusive lower bound of the \"Supply Magnitude\"<br />  Either Min/Max is used or Magnitude. (optional)
supply_magnitude_to = 1.2 # float | The exclusive upper bound of the \"Supply Magnitude\"<br />  Used when SupplyMagnitudeFilterType is 'inRange'.<br />  Data is gathered from 'SupplyMagnitude' to 'SupplyMagnitudeTo'<br />  Either Min/Max is used or Magnitude. (optional)
supply_unit = ['supply_unit_example'] # list[str] | <list type=\"string\">List of the Supply Unit</list> (optional)
customer_reference_number_search_text = 'customer_reference_number_search_text_example' # str | Find all data with contains this search text (optional)
customer_order_number_search_text = 'customer_order_number_search_text_example' # str | Find all data with contains this search text (optional)
remarks_search_text = 'remarks_search_text_example' # str | Find all data with contains this search text (optional)

try:
    # Gathers all filtered data in one JSON response
    api_response = api_instance.calibration_data_get_calibration_data(included_ids=included_ids, excluded_ids=excluded_ids, order_numbers=order_numbers, order_positions=order_positions, date_filter_type=date_filter_type, _date=_date, date_to=date_to, customer_product_types=customer_product_types, pressure_types=pressure_types, product_series=product_series, product_numbers=product_numbers, serial_number_search_text=serial_number_search_text, pressure_min_filter_type=pressure_min_filter_type, pressure_min=pressure_min, pressure_min_to=pressure_min_to, pressure_max_filter_type=pressure_max_filter_type, pressure_max=pressure_max, pressure_max_to=pressure_max_to, pressure_unit=pressure_unit, temperature_min_filter_type=temperature_min_filter_type, temperature_min=temperature_min, temperature_min_to=temperature_min_to, temperature_max_filter_type=temperature_max_filter_type, temperature_max=temperature_max, temperature_max_to=temperature_max_to, temperature_unit=temperature_unit, supply_min_filter_type=supply_min_filter_type, supply_min=supply_min, supply_min_to=supply_min_to, supply_max_filter_type=supply_max_filter_type, supply_max=supply_max, supply_max_to=supply_max_to, supply_magnitude_filter_type=supply_magnitude_filter_type, supply_magnitude=supply_magnitude, supply_magnitude_to=supply_magnitude_to, supply_unit=supply_unit, customer_reference_number_search_text=customer_reference_number_search_text, customer_order_number_search_text=customer_order_number_search_text, remarks_search_text=remarks_search_text)
    pprint(api_response)
except ApiException as e:
    print("Exception when calling CalibrationDataApi->calibration_data_get_calibration_data: %s\n" % e)
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **included_ids** | [**list[str]**](str.md)| If null: Either are &#x27;ALL SELECTED&#x27; or some are unselected (and listed in ExcludedIds)&lt;br /&gt;  If not null: None are selected except those that are listed here.&lt;br /&gt;  It is not allowed to have IncludedIds AND ExcludedIds have listed values. One most be null or both most be null.&lt;br /&gt;  The list of included ids is limited to 50. More than 50 will throw an exception.&lt;br /&gt; | [optional] 
 **excluded_ids** | [**list[str]**](str.md)| If null: Either are &#x27;ALL SELECTED&#x27; or only some few are selected (and listed in IncludedIds)&lt;br /&gt;  If not null: All are selected and except those that are listed here.&lt;br /&gt;  It is not allowed to have IncludedIds AND ExcludedIds have listed values. One most be null or both most be null.&lt;br /&gt;  The list of excluded ids is limited to 50. More than 50 will throw an exception.&lt;br /&gt; | [optional] 
 **order_numbers** | [**list[str]**](str.md)| List of Order Numbers | [optional] 
 **order_positions** | [**list[str]**](str.md)| List of Order Positions | [optional] 
 **date_filter_type** | **str**| One of &#x27;equals&#x27;, &#x27;greaterThan&#x27;, &#x27;lessThan&#x27;, &#x27;notEqual&#x27;, &#x27;inRange&#x27;.&lt;br /&gt;  When &#x27;inRange&#x27; then &#x27;DateTo&#x27; is needed.&lt;br /&gt;  Example 1:&lt;br /&gt;  \&quot;All data newer than August 1st\&quot; &#x3D; https://mycalibrationapi.azurewebsites.net/v1/CalibrationData?DateFilterType&#x3D;greaterThan&amp;Date&#x3D;2021-08-01&lt;br /&gt;  Example 2:&lt;br /&gt;  \&quot;All data from the year 2020\&quot; &#x3D; https://mycalibrationapi.azurewebsites.net/v1/CalibrationData?DateFilterType&#x3D;inRange&amp;Date&#x3D;2021-01-01&amp;DateTo&#x3D;2021-12-31 &lt;br /&gt;  Example 3:&lt;br /&gt;  \&quot;All data from the first day in January and February\&quot; &#x3D; https://mycalibrationapi.azurewebsites.net/v1/CalibrationData?DateFilterType&#x3D;equals&amp;Date&#x3D;2021-01-01&amp;Date&#x3D;2021-02-01 &lt;br /&gt; | [optional] 
 **_date** | [**list[str]**](str.md)| Dispatch-date text in format &#x27;yyyy-MM-dd&#x27; eg. \&quot;2021-12-24\&quot;&lt;br /&gt;  Normally, this is a list with one element. Nevertheless, it is possible to GET calibration data from multiple dates. In this case DateFilterType must be &#x27;equals&#x27; and DateTo must be null. | [optional] 
 **date_to** | **str**| Used when DateFilterType is &#x27;inRange&#x27;.&lt;br /&gt;  Data is gathered from &#x27;Date&#x27; to &#x27;DateTo&#x27;&lt;br /&gt;  Date text in format &#x27;yyyy-MM-dd&#x27; eg. \&quot;2021-12-24\&quot; | [optional] 
 **customer_product_types** | [**list[str]**](str.md)| To search for [Blanks] use \&quot;blank\&quot; | [optional] 
 **pressure_types** | [**list[str]**](str.md)| Eg. [\&quot;pa\&quot;,\&quot;paa\&quot;,\&quot;pr\&quot;]  To see all possible enum strings, go to https://mycalibration.github.io/#filter-parameters | [optional] 
 **product_series** | [**list[str]**](str.md)| Eg. [\&quot;10LHP\&quot;,\&quot;25Y\&quot;,\&quot;46X\&quot;,\&quot;K-102\&quot;] | [optional] 
 **product_numbers** | [**list[str]**](str.md)|  | [optional] 
 **serial_number_search_text** | **str**| Use this to find all SerialNumbers that contains this text content. | [optional] 
 **pressure_min_filter_type** | **str**| One of &#x27;equals&#x27;, &#x27;greaterThan&#x27;, &#x27;lessThan&#x27;, &#x27;notEqual&#x27;, &#x27;inRange&#x27;, &#x27;lessThanOrEqual&#x27;, &#x27;greaterThanOrEqual&#x27;.&lt;br /&gt;  When &#x27;inRange&#x27; then &#x27;PressureMinTo&#x27; is needed. | [optional] 
 **pressure_min** | **float**| The exclusive lower bound of the \&quot;Minimum Pressure\&quot; | [optional] 
 **pressure_min_to** | **float**| The exclusive upper bound of the \&quot;Minimum Pressure\&quot;.&lt;br /&gt;  Used when PressureMinFilterType is &#x27;inRange&#x27;.&lt;br /&gt;  Data is gathered from &#x27;PressureMin&#x27; to &#x27;PressureMinTo&#x27;.&lt;br /&gt;  Date text in format &#x27;yyyy-MM-dd&#x27; eg. \&quot;2021-12-24\&quot;&lt;br /&gt; | [optional] 
 **pressure_max_filter_type** | **str**| One of &#x27;equals&#x27;, &#x27;greaterThan&#x27;, &#x27;lessThan&#x27;, &#x27;notEqual&#x27;, &#x27;inRange&#x27;, &#x27;lessThanOrEqual&#x27;, &#x27;greaterThanOrEqual&#x27;.&lt;br /&gt;  When &#x27;inRange&#x27; then &#x27;PressureMaxTo&#x27; is needed. | [optional] 
 **pressure_max** | **float**| The exclusive lower bound of the \&quot;Maximum Pressure\&quot; | [optional] 
 **pressure_max_to** | **float**| The exclusive upper bound of the \&quot;Maximum Pressure\&quot;&lt;br /&gt;  Used when PressureMaxFilterType is &#x27;inRange&#x27;.&lt;br /&gt;  Data is gathered from &#x27;PressureMax&#x27; to &#x27;PressureMaxTo&#x27;&lt;br /&gt;  Date text in format &#x27;yyyy-MM-dd&#x27; eg. \&quot;2021-12-24\&quot; | [optional] 
 **pressure_unit** | [**list[str]**](str.md)| &lt;list type&#x3D;\&quot;string\&quot;&gt;List of the Pressure Unit&lt;/list&gt; | [optional] 
 **temperature_min_filter_type** | **str**| One of &#x27;equals&#x27;, &#x27;greaterThan&#x27;, &#x27;lessThan&#x27;, &#x27;notEqual&#x27;, &#x27;inRange&#x27;, &#x27;lessThanOrEqual&#x27;, &#x27;greaterThanOrEqual&#x27;.&lt;br /&gt;  When &#x27;inRange&#x27; then &#x27;TemperatureMinTo&#x27; is needed. | [optional] 
 **temperature_min** | **float**| The exclusive lower bound of the \&quot;Minimum Temperature\&quot; | [optional] 
 **temperature_min_to** | **float**| The exclusive upper bound of the \&quot;Minimum Temperature\&quot;&lt;br /&gt;  Used when TemperatureMinFilterType is &#x27;inRange&#x27;.&lt;br /&gt;  Data is gathered from &#x27;TemperatureMin&#x27; to &#x27;TemperatureMinTo&#x27;&lt;br /&gt;  Date text in format &#x27;yyyy-MM-dd&#x27; eg. \&quot;2021-12-24\&quot; | [optional] 
 **temperature_max_filter_type** | **str**| One of &#x27;equals&#x27;, &#x27;greaterThan&#x27;, &#x27;lessThan&#x27;, &#x27;notEqual&#x27;, &#x27;inRange&#x27;, &#x27;lessThanOrEqual&#x27;, &#x27;greaterThanOrEqual&#x27;.&lt;br /&gt;  When &#x27;inRange&#x27; then &#x27;TemperatureMaxTo&#x27; is needed. | [optional] 
 **temperature_max** | **float**| The exclusive lower bound of the \&quot;Maximum Temperature\&quot; | [optional] 
 **temperature_max_to** | **float**| The exclusive upper bound of the \&quot;Maximum Temperature\&quot;&lt;br /&gt;  Used when TemperatureMaxFilterType is &#x27;inRange&#x27;.&lt;br /&gt;  Data is gathered from &#x27;TemperatureMax&#x27; to &#x27;TemperatureMaxTo&#x27;&lt;br /&gt;  Date text in format &#x27;yyyy-MM-dd&#x27; eg. \&quot;2021-12-24\&quot; | [optional] 
 **temperature_unit** | [**list[str]**](str.md)| &lt;list type&#x3D;\&quot;string\&quot;&gt;List of the Temperature Unit&lt;/list&gt; | [optional] 
 **supply_min_filter_type** | **str**| One of &#x27;equals&#x27;, &#x27;greaterThan&#x27;, &#x27;lessThan&#x27;, &#x27;notEqual&#x27;, &#x27;inRange&#x27;, &#x27;lessThanOrEqual&#x27;, &#x27;greaterThanOrEqual&#x27;.&lt;br /&gt;  When &#x27;inRange&#x27; then &#x27;SupplyMinTo&#x27; is needed.&lt;br /&gt;  Either Min/Max is used or Magnitude.&lt;br /&gt; | [optional] 
 **supply_min** | **float**| The exclusive lower bound of the \&quot;Minimum Supply\&quot;&lt;br /&gt;  Either Min/Max is used or Magnitude. | [optional] 
 **supply_min_to** | **float**| The exclusive upper bound of the \&quot;Minimum Supply\&quot;&lt;br /&gt;  Used when SupplyMinFilterType is &#x27;inRange&#x27;.&lt;br /&gt;  Data is gathered from &#x27;SupplyMin&#x27; to &#x27;SupplyMinTo&#x27;&lt;br /&gt;  Date text in format &#x27;yyyy-MM-dd&#x27; eg. \&quot;2021-12-24\&quot;&lt;br /&gt;  Either Min/Max is used or Magnitude. | [optional] 
 **supply_max_filter_type** | **str**| One of &#x27;equals&#x27;, &#x27;greaterThan&#x27;, &#x27;lessThan&#x27;, &#x27;notEqual&#x27;, &#x27;inRange&#x27;, &#x27;lessThanOrEqual&#x27;, &#x27;greaterThanOrEqual&#x27;.&lt;br /&gt;  When &#x27;inRange&#x27; then &#x27;SupplyMaxTo&#x27; is needed.&lt;br /&gt;  Either Min/Max is used or Magnitude. | [optional] 
 **supply_max** | **float**| The exclusive lower bound of the \&quot;Maximum Supply\&quot;&lt;br /&gt;  Either Min/Max is used or Magnitude. | [optional] 
 **supply_max_to** | **float**| The exclusive upper bound of the \&quot;Maximum Supply\&quot;&lt;br /&gt;  Used when SupplyMaxFilterType is &#x27;inRange&#x27;.&lt;br /&gt;  Data is gathered from &#x27;SupplyMax&#x27; to &#x27;SupplyMaxTo&#x27;&lt;br /&gt;  Date text in format &#x27;yyyy-MM-dd&#x27; eg. \&quot;2021-12-24\&quot;&lt;br /&gt;  Either Min/Max is used or Magnitude. | [optional] 
 **supply_magnitude_filter_type** | **str**| One of &#x27;equals&#x27;, &#x27;greaterThan&#x27;, &#x27;lessThan&#x27;, &#x27;notEqual&#x27;, &#x27;inRange&#x27;, &#x27;lessThanOrEqual&#x27;, &#x27;greaterThanOrEqual&#x27;.&lt;br /&gt;  When &#x27;inRange&#x27; then &#x27;SupplyMagnitudeTo&#x27; is needed.&lt;br /&gt;  Either Min/Max is used or Magnitude. | [optional] 
 **supply_magnitude** | **float**| The exclusive lower bound of the \&quot;Supply Magnitude\&quot;&lt;br /&gt;  Either Min/Max is used or Magnitude. | [optional] 
 **supply_magnitude_to** | **float**| The exclusive upper bound of the \&quot;Supply Magnitude\&quot;&lt;br /&gt;  Used when SupplyMagnitudeFilterType is &#x27;inRange&#x27;.&lt;br /&gt;  Data is gathered from &#x27;SupplyMagnitude&#x27; to &#x27;SupplyMagnitudeTo&#x27;&lt;br /&gt;  Either Min/Max is used or Magnitude. | [optional] 
 **supply_unit** | [**list[str]**](str.md)| &lt;list type&#x3D;\&quot;string\&quot;&gt;List of the Supply Unit&lt;/list&gt; | [optional] 
 **customer_reference_number_search_text** | **str**| Find all data with contains this search text | [optional] 
 **customer_order_number_search_text** | **str**| Find all data with contains this search text | [optional] 
 **remarks_search_text** | **str**| Find all data with contains this search text | [optional] 

### Return type

[**list[KellerSensorData]**](KellerSensorData.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **calibration_data_get_calibration_data_as_file**
> calibration_data_get_calibration_data_as_file(file_type=file_type, included_ids=included_ids, excluded_ids=excluded_ids, order_numbers=order_numbers, order_positions=order_positions, date_filter_type=date_filter_type, _date=_date, date_to=date_to, customer_product_types=customer_product_types, pressure_types=pressure_types, product_series=product_series, product_numbers=product_numbers, serial_number_search_text=serial_number_search_text, pressure_min_filter_type=pressure_min_filter_type, pressure_min=pressure_min, pressure_min_to=pressure_min_to, pressure_max_filter_type=pressure_max_filter_type, pressure_max=pressure_max, pressure_max_to=pressure_max_to, pressure_unit=pressure_unit, temperature_min_filter_type=temperature_min_filter_type, temperature_min=temperature_min, temperature_min_to=temperature_min_to, temperature_max_filter_type=temperature_max_filter_type, temperature_max=temperature_max, temperature_max_to=temperature_max_to, temperature_unit=temperature_unit, supply_min_filter_type=supply_min_filter_type, supply_min=supply_min, supply_min_to=supply_min_to, supply_max_filter_type=supply_max_filter_type, supply_max=supply_max, supply_max_to=supply_max_to, supply_magnitude_filter_type=supply_magnitude_filter_type, supply_magnitude=supply_magnitude, supply_magnitude_to=supply_magnitude_to, supply_unit=supply_unit, customer_reference_number_search_text=customer_reference_number_search_text, customer_order_number_search_text=customer_order_number_search_text, remarks_search_text=remarks_search_text)

Locates the filtered (optionalSearchParameter) data, bundles them and creates a download link

### Example
```python
from __future__ import print_function
import time
import swagger_client
from swagger_client.rest import ApiException
from pprint import pprint

# Configure API key authorization: Bearer
configuration = swagger_client.Configuration()
configuration.api_key['Authorization'] = 'YOUR_API_KEY'
# Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
# configuration.api_key_prefix['Authorization'] = 'Bearer'

# create an instance of the API class
api_instance = swagger_client.CalibrationDataApi(swagger_client.ApiClient(configuration))
file_type = swagger_client.ExportFileType() # ExportFileType | 1 = All calibration data items will be merged in one JSON list  2 = All calibration data items will be merged in one JSON list. This JSON file will be compressed to zip file  3 = Every calibration data items will stored as JSON file. All these files will be compressed to one single zip file  4 = Every calibration data items will stored as JSON file. All these files will be compressed to one single brotli file (optional)
included_ids = ['included_ids_example'] # list[str] | If null: Either are 'ALL SELECTED' or some are unselected (and listed in ExcludedIds)<br />  If not null: None are selected except those that are listed here.<br />  It is not allowed to have IncludedIds AND ExcludedIds have listed values. One most be null or both most be null.<br />  The list of included ids is limited to 50. More than 50 will throw an exception.<br /> (optional)
excluded_ids = ['excluded_ids_example'] # list[str] | If null: Either are 'ALL SELECTED' or only some few are selected (and listed in IncludedIds)<br />  If not null: All are selected and except those that are listed here.<br />  It is not allowed to have IncludedIds AND ExcludedIds have listed values. One most be null or both most be null.<br />  The list of excluded ids is limited to 50. More than 50 will throw an exception.<br /> (optional)
order_numbers = ['order_numbers_example'] # list[str] | List of Order Numbers (optional)
order_positions = ['order_positions_example'] # list[str] | List of Order Positions (optional)
date_filter_type = 'date_filter_type_example' # str | One of 'equals', 'greaterThan', 'lessThan', 'notEqual', 'inRange'.<br />  When 'inRange' then 'DateTo' is needed.<br />  Example 1:<br />  \"All data newer than August 1st\" = https://mycalibrationapi.azurewebsites.net/v1/CalibrationData?DateFilterType=greaterThan&Date=2021-08-01<br />  Example 2:<br />  \"All data from the year 2020\" = https://mycalibrationapi.azurewebsites.net/v1/CalibrationData?DateFilterType=inRange&Date=2021-01-01&DateTo=2021-12-31 <br />  Example 3:<br />  \"All data from the first day in January and February\" = https://mycalibrationapi.azurewebsites.net/v1/CalibrationData?DateFilterType=equals&Date=2021-01-01&Date=2021-02-01 <br /> (optional)
_date = ['_date_example'] # list[str] | Dispatch-date text in format 'yyyy-MM-dd' eg. \"2021-12-24\"<br />  Normally, this is a list with one element. Nevertheless, it is possible to GET calibration data from multiple dates. In this case DateFilterType must be 'equals' and DateTo must be null. (optional)
date_to = 'date_to_example' # str | Used when DateFilterType is 'inRange'.<br />  Data is gathered from 'Date' to 'DateTo'<br />  Date text in format 'yyyy-MM-dd' eg. \"2021-12-24\" (optional)
customer_product_types = ['customer_product_types_example'] # list[str] | To search for [Blanks] use \"blank\" (optional)
pressure_types = ['pressure_types_example'] # list[str] | Eg. [\"pa\",\"paa\",\"pr\"]  To see all possible enum strings, go to https://mycalibration.github.io/#filter-parameters (optional)
product_series = ['product_series_example'] # list[str] | Eg. [\"10LHP\",\"25Y\",\"46X\",\"K-102\"] (optional)
product_numbers = ['product_numbers_example'] # list[str] |  (optional)
serial_number_search_text = 'serial_number_search_text_example' # str | Use this to find all SerialNumbers that contains this text content. (optional)
pressure_min_filter_type = 'pressure_min_filter_type_example' # str | One of 'equals', 'greaterThan', 'lessThan', 'notEqual', 'inRange', 'lessThanOrEqual', 'greaterThanOrEqual'.<br />  When 'inRange' then 'PressureMinTo' is needed. (optional)
pressure_min = 1.2 # float | The exclusive lower bound of the \"Minimum Pressure\" (optional)
pressure_min_to = 1.2 # float | The exclusive upper bound of the \"Minimum Pressure\".<br />  Used when PressureMinFilterType is 'inRange'.<br />  Data is gathered from 'PressureMin' to 'PressureMinTo'.<br />  Date text in format 'yyyy-MM-dd' eg. \"2021-12-24\"<br /> (optional)
pressure_max_filter_type = 'pressure_max_filter_type_example' # str | One of 'equals', 'greaterThan', 'lessThan', 'notEqual', 'inRange', 'lessThanOrEqual', 'greaterThanOrEqual'.<br />  When 'inRange' then 'PressureMaxTo' is needed. (optional)
pressure_max = 1.2 # float | The exclusive lower bound of the \"Maximum Pressure\" (optional)
pressure_max_to = 1.2 # float | The exclusive upper bound of the \"Maximum Pressure\"<br />  Used when PressureMaxFilterType is 'inRange'.<br />  Data is gathered from 'PressureMax' to 'PressureMaxTo'<br />  Date text in format 'yyyy-MM-dd' eg. \"2021-12-24\" (optional)
pressure_unit = ['pressure_unit_example'] # list[str] | <list type=\"string\">List of the Pressure Unit</list> (optional)
temperature_min_filter_type = 'temperature_min_filter_type_example' # str | One of 'equals', 'greaterThan', 'lessThan', 'notEqual', 'inRange', 'lessThanOrEqual', 'greaterThanOrEqual'.<br />  When 'inRange' then 'TemperatureMinTo' is needed. (optional)
temperature_min = 1.2 # float | The exclusive lower bound of the \"Minimum Temperature\" (optional)
temperature_min_to = 1.2 # float | The exclusive upper bound of the \"Minimum Temperature\"<br />  Used when TemperatureMinFilterType is 'inRange'.<br />  Data is gathered from 'TemperatureMin' to 'TemperatureMinTo'<br />  Date text in format 'yyyy-MM-dd' eg. \"2021-12-24\" (optional)
temperature_max_filter_type = 'temperature_max_filter_type_example' # str | One of 'equals', 'greaterThan', 'lessThan', 'notEqual', 'inRange', 'lessThanOrEqual', 'greaterThanOrEqual'.<br />  When 'inRange' then 'TemperatureMaxTo' is needed. (optional)
temperature_max = 1.2 # float | The exclusive lower bound of the \"Maximum Temperature\" (optional)
temperature_max_to = 1.2 # float | The exclusive upper bound of the \"Maximum Temperature\"<br />  Used when TemperatureMaxFilterType is 'inRange'.<br />  Data is gathered from 'TemperatureMax' to 'TemperatureMaxTo'<br />  Date text in format 'yyyy-MM-dd' eg. \"2021-12-24\" (optional)
temperature_unit = ['temperature_unit_example'] # list[str] | <list type=\"string\">List of the Temperature Unit</list> (optional)
supply_min_filter_type = 'supply_min_filter_type_example' # str | One of 'equals', 'greaterThan', 'lessThan', 'notEqual', 'inRange', 'lessThanOrEqual', 'greaterThanOrEqual'.<br />  When 'inRange' then 'SupplyMinTo' is needed.<br />  Either Min/Max is used or Magnitude.<br /> (optional)
supply_min = 1.2 # float | The exclusive lower bound of the \"Minimum Supply\"<br />  Either Min/Max is used or Magnitude. (optional)
supply_min_to = 1.2 # float | The exclusive upper bound of the \"Minimum Supply\"<br />  Used when SupplyMinFilterType is 'inRange'.<br />  Data is gathered from 'SupplyMin' to 'SupplyMinTo'<br />  Date text in format 'yyyy-MM-dd' eg. \"2021-12-24\"<br />  Either Min/Max is used or Magnitude. (optional)
supply_max_filter_type = 'supply_max_filter_type_example' # str | One of 'equals', 'greaterThan', 'lessThan', 'notEqual', 'inRange', 'lessThanOrEqual', 'greaterThanOrEqual'.<br />  When 'inRange' then 'SupplyMaxTo' is needed.<br />  Either Min/Max is used or Magnitude. (optional)
supply_max = 1.2 # float | The exclusive lower bound of the \"Maximum Supply\"<br />  Either Min/Max is used or Magnitude. (optional)
supply_max_to = 1.2 # float | The exclusive upper bound of the \"Maximum Supply\"<br />  Used when SupplyMaxFilterType is 'inRange'.<br />  Data is gathered from 'SupplyMax' to 'SupplyMaxTo'<br />  Date text in format 'yyyy-MM-dd' eg. \"2021-12-24\"<br />  Either Min/Max is used or Magnitude. (optional)
supply_magnitude_filter_type = 'supply_magnitude_filter_type_example' # str | One of 'equals', 'greaterThan', 'lessThan', 'notEqual', 'inRange', 'lessThanOrEqual', 'greaterThanOrEqual'.<br />  When 'inRange' then 'SupplyMagnitudeTo' is needed.<br />  Either Min/Max is used or Magnitude. (optional)
supply_magnitude = 1.2 # float | The exclusive lower bound of the \"Supply Magnitude\"<br />  Either Min/Max is used or Magnitude. (optional)
supply_magnitude_to = 1.2 # float | The exclusive upper bound of the \"Supply Magnitude\"<br />  Used when SupplyMagnitudeFilterType is 'inRange'.<br />  Data is gathered from 'SupplyMagnitude' to 'SupplyMagnitudeTo'<br />  Either Min/Max is used or Magnitude. (optional)
supply_unit = ['supply_unit_example'] # list[str] | <list type=\"string\">List of the Supply Unit</list> (optional)
customer_reference_number_search_text = 'customer_reference_number_search_text_example' # str | Find all data with contains this search text (optional)
customer_order_number_search_text = 'customer_order_number_search_text_example' # str | Find all data with contains this search text (optional)
remarks_search_text = 'remarks_search_text_example' # str | Find all data with contains this search text (optional)

try:
    # Locates the filtered (optionalSearchParameter) data, bundles them and creates a download link
    api_instance.calibration_data_get_calibration_data_as_file(file_type=file_type, included_ids=included_ids, excluded_ids=excluded_ids, order_numbers=order_numbers, order_positions=order_positions, date_filter_type=date_filter_type, _date=_date, date_to=date_to, customer_product_types=customer_product_types, pressure_types=pressure_types, product_series=product_series, product_numbers=product_numbers, serial_number_search_text=serial_number_search_text, pressure_min_filter_type=pressure_min_filter_type, pressure_min=pressure_min, pressure_min_to=pressure_min_to, pressure_max_filter_type=pressure_max_filter_type, pressure_max=pressure_max, pressure_max_to=pressure_max_to, pressure_unit=pressure_unit, temperature_min_filter_type=temperature_min_filter_type, temperature_min=temperature_min, temperature_min_to=temperature_min_to, temperature_max_filter_type=temperature_max_filter_type, temperature_max=temperature_max, temperature_max_to=temperature_max_to, temperature_unit=temperature_unit, supply_min_filter_type=supply_min_filter_type, supply_min=supply_min, supply_min_to=supply_min_to, supply_max_filter_type=supply_max_filter_type, supply_max=supply_max, supply_max_to=supply_max_to, supply_magnitude_filter_type=supply_magnitude_filter_type, supply_magnitude=supply_magnitude, supply_magnitude_to=supply_magnitude_to, supply_unit=supply_unit, customer_reference_number_search_text=customer_reference_number_search_text, customer_order_number_search_text=customer_order_number_search_text, remarks_search_text=remarks_search_text)
except ApiException as e:
    print("Exception when calling CalibrationDataApi->calibration_data_get_calibration_data_as_file: %s\n" % e)
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **file_type** | [**ExportFileType**](.md)| 1 &#x3D; All calibration data items will be merged in one JSON list  2 &#x3D; All calibration data items will be merged in one JSON list. This JSON file will be compressed to zip file  3 &#x3D; Every calibration data items will stored as JSON file. All these files will be compressed to one single zip file  4 &#x3D; Every calibration data items will stored as JSON file. All these files will be compressed to one single brotli file | [optional] 
 **included_ids** | [**list[str]**](str.md)| If null: Either are &#x27;ALL SELECTED&#x27; or some are unselected (and listed in ExcludedIds)&lt;br /&gt;  If not null: None are selected except those that are listed here.&lt;br /&gt;  It is not allowed to have IncludedIds AND ExcludedIds have listed values. One most be null or both most be null.&lt;br /&gt;  The list of included ids is limited to 50. More than 50 will throw an exception.&lt;br /&gt; | [optional] 
 **excluded_ids** | [**list[str]**](str.md)| If null: Either are &#x27;ALL SELECTED&#x27; or only some few are selected (and listed in IncludedIds)&lt;br /&gt;  If not null: All are selected and except those that are listed here.&lt;br /&gt;  It is not allowed to have IncludedIds AND ExcludedIds have listed values. One most be null or both most be null.&lt;br /&gt;  The list of excluded ids is limited to 50. More than 50 will throw an exception.&lt;br /&gt; | [optional] 
 **order_numbers** | [**list[str]**](str.md)| List of Order Numbers | [optional] 
 **order_positions** | [**list[str]**](str.md)| List of Order Positions | [optional] 
 **date_filter_type** | **str**| One of &#x27;equals&#x27;, &#x27;greaterThan&#x27;, &#x27;lessThan&#x27;, &#x27;notEqual&#x27;, &#x27;inRange&#x27;.&lt;br /&gt;  When &#x27;inRange&#x27; then &#x27;DateTo&#x27; is needed.&lt;br /&gt;  Example 1:&lt;br /&gt;  \&quot;All data newer than August 1st\&quot; &#x3D; https://mycalibrationapi.azurewebsites.net/v1/CalibrationData?DateFilterType&#x3D;greaterThan&amp;Date&#x3D;2021-08-01&lt;br /&gt;  Example 2:&lt;br /&gt;  \&quot;All data from the year 2020\&quot; &#x3D; https://mycalibrationapi.azurewebsites.net/v1/CalibrationData?DateFilterType&#x3D;inRange&amp;Date&#x3D;2021-01-01&amp;DateTo&#x3D;2021-12-31 &lt;br /&gt;  Example 3:&lt;br /&gt;  \&quot;All data from the first day in January and February\&quot; &#x3D; https://mycalibrationapi.azurewebsites.net/v1/CalibrationData?DateFilterType&#x3D;equals&amp;Date&#x3D;2021-01-01&amp;Date&#x3D;2021-02-01 &lt;br /&gt; | [optional] 
 **_date** | [**list[str]**](str.md)| Dispatch-date text in format &#x27;yyyy-MM-dd&#x27; eg. \&quot;2021-12-24\&quot;&lt;br /&gt;  Normally, this is a list with one element. Nevertheless, it is possible to GET calibration data from multiple dates. In this case DateFilterType must be &#x27;equals&#x27; and DateTo must be null. | [optional] 
 **date_to** | **str**| Used when DateFilterType is &#x27;inRange&#x27;.&lt;br /&gt;  Data is gathered from &#x27;Date&#x27; to &#x27;DateTo&#x27;&lt;br /&gt;  Date text in format &#x27;yyyy-MM-dd&#x27; eg. \&quot;2021-12-24\&quot; | [optional] 
 **customer_product_types** | [**list[str]**](str.md)| To search for [Blanks] use \&quot;blank\&quot; | [optional] 
 **pressure_types** | [**list[str]**](str.md)| Eg. [\&quot;pa\&quot;,\&quot;paa\&quot;,\&quot;pr\&quot;]  To see all possible enum strings, go to https://mycalibration.github.io/#filter-parameters | [optional] 
 **product_series** | [**list[str]**](str.md)| Eg. [\&quot;10LHP\&quot;,\&quot;25Y\&quot;,\&quot;46X\&quot;,\&quot;K-102\&quot;] | [optional] 
 **product_numbers** | [**list[str]**](str.md)|  | [optional] 
 **serial_number_search_text** | **str**| Use this to find all SerialNumbers that contains this text content. | [optional] 
 **pressure_min_filter_type** | **str**| One of &#x27;equals&#x27;, &#x27;greaterThan&#x27;, &#x27;lessThan&#x27;, &#x27;notEqual&#x27;, &#x27;inRange&#x27;, &#x27;lessThanOrEqual&#x27;, &#x27;greaterThanOrEqual&#x27;.&lt;br /&gt;  When &#x27;inRange&#x27; then &#x27;PressureMinTo&#x27; is needed. | [optional] 
 **pressure_min** | **float**| The exclusive lower bound of the \&quot;Minimum Pressure\&quot; | [optional] 
 **pressure_min_to** | **float**| The exclusive upper bound of the \&quot;Minimum Pressure\&quot;.&lt;br /&gt;  Used when PressureMinFilterType is &#x27;inRange&#x27;.&lt;br /&gt;  Data is gathered from &#x27;PressureMin&#x27; to &#x27;PressureMinTo&#x27;.&lt;br /&gt;  Date text in format &#x27;yyyy-MM-dd&#x27; eg. \&quot;2021-12-24\&quot;&lt;br /&gt; | [optional] 
 **pressure_max_filter_type** | **str**| One of &#x27;equals&#x27;, &#x27;greaterThan&#x27;, &#x27;lessThan&#x27;, &#x27;notEqual&#x27;, &#x27;inRange&#x27;, &#x27;lessThanOrEqual&#x27;, &#x27;greaterThanOrEqual&#x27;.&lt;br /&gt;  When &#x27;inRange&#x27; then &#x27;PressureMaxTo&#x27; is needed. | [optional] 
 **pressure_max** | **float**| The exclusive lower bound of the \&quot;Maximum Pressure\&quot; | [optional] 
 **pressure_max_to** | **float**| The exclusive upper bound of the \&quot;Maximum Pressure\&quot;&lt;br /&gt;  Used when PressureMaxFilterType is &#x27;inRange&#x27;.&lt;br /&gt;  Data is gathered from &#x27;PressureMax&#x27; to &#x27;PressureMaxTo&#x27;&lt;br /&gt;  Date text in format &#x27;yyyy-MM-dd&#x27; eg. \&quot;2021-12-24\&quot; | [optional] 
 **pressure_unit** | [**list[str]**](str.md)| &lt;list type&#x3D;\&quot;string\&quot;&gt;List of the Pressure Unit&lt;/list&gt; | [optional] 
 **temperature_min_filter_type** | **str**| One of &#x27;equals&#x27;, &#x27;greaterThan&#x27;, &#x27;lessThan&#x27;, &#x27;notEqual&#x27;, &#x27;inRange&#x27;, &#x27;lessThanOrEqual&#x27;, &#x27;greaterThanOrEqual&#x27;.&lt;br /&gt;  When &#x27;inRange&#x27; then &#x27;TemperatureMinTo&#x27; is needed. | [optional] 
 **temperature_min** | **float**| The exclusive lower bound of the \&quot;Minimum Temperature\&quot; | [optional] 
 **temperature_min_to** | **float**| The exclusive upper bound of the \&quot;Minimum Temperature\&quot;&lt;br /&gt;  Used when TemperatureMinFilterType is &#x27;inRange&#x27;.&lt;br /&gt;  Data is gathered from &#x27;TemperatureMin&#x27; to &#x27;TemperatureMinTo&#x27;&lt;br /&gt;  Date text in format &#x27;yyyy-MM-dd&#x27; eg. \&quot;2021-12-24\&quot; | [optional] 
 **temperature_max_filter_type** | **str**| One of &#x27;equals&#x27;, &#x27;greaterThan&#x27;, &#x27;lessThan&#x27;, &#x27;notEqual&#x27;, &#x27;inRange&#x27;, &#x27;lessThanOrEqual&#x27;, &#x27;greaterThanOrEqual&#x27;.&lt;br /&gt;  When &#x27;inRange&#x27; then &#x27;TemperatureMaxTo&#x27; is needed. | [optional] 
 **temperature_max** | **float**| The exclusive lower bound of the \&quot;Maximum Temperature\&quot; | [optional] 
 **temperature_max_to** | **float**| The exclusive upper bound of the \&quot;Maximum Temperature\&quot;&lt;br /&gt;  Used when TemperatureMaxFilterType is &#x27;inRange&#x27;.&lt;br /&gt;  Data is gathered from &#x27;TemperatureMax&#x27; to &#x27;TemperatureMaxTo&#x27;&lt;br /&gt;  Date text in format &#x27;yyyy-MM-dd&#x27; eg. \&quot;2021-12-24\&quot; | [optional] 
 **temperature_unit** | [**list[str]**](str.md)| &lt;list type&#x3D;\&quot;string\&quot;&gt;List of the Temperature Unit&lt;/list&gt; | [optional] 
 **supply_min_filter_type** | **str**| One of &#x27;equals&#x27;, &#x27;greaterThan&#x27;, &#x27;lessThan&#x27;, &#x27;notEqual&#x27;, &#x27;inRange&#x27;, &#x27;lessThanOrEqual&#x27;, &#x27;greaterThanOrEqual&#x27;.&lt;br /&gt;  When &#x27;inRange&#x27; then &#x27;SupplyMinTo&#x27; is needed.&lt;br /&gt;  Either Min/Max is used or Magnitude.&lt;br /&gt; | [optional] 
 **supply_min** | **float**| The exclusive lower bound of the \&quot;Minimum Supply\&quot;&lt;br /&gt;  Either Min/Max is used or Magnitude. | [optional] 
 **supply_min_to** | **float**| The exclusive upper bound of the \&quot;Minimum Supply\&quot;&lt;br /&gt;  Used when SupplyMinFilterType is &#x27;inRange&#x27;.&lt;br /&gt;  Data is gathered from &#x27;SupplyMin&#x27; to &#x27;SupplyMinTo&#x27;&lt;br /&gt;  Date text in format &#x27;yyyy-MM-dd&#x27; eg. \&quot;2021-12-24\&quot;&lt;br /&gt;  Either Min/Max is used or Magnitude. | [optional] 
 **supply_max_filter_type** | **str**| One of &#x27;equals&#x27;, &#x27;greaterThan&#x27;, &#x27;lessThan&#x27;, &#x27;notEqual&#x27;, &#x27;inRange&#x27;, &#x27;lessThanOrEqual&#x27;, &#x27;greaterThanOrEqual&#x27;.&lt;br /&gt;  When &#x27;inRange&#x27; then &#x27;SupplyMaxTo&#x27; is needed.&lt;br /&gt;  Either Min/Max is used or Magnitude. | [optional] 
 **supply_max** | **float**| The exclusive lower bound of the \&quot;Maximum Supply\&quot;&lt;br /&gt;  Either Min/Max is used or Magnitude. | [optional] 
 **supply_max_to** | **float**| The exclusive upper bound of the \&quot;Maximum Supply\&quot;&lt;br /&gt;  Used when SupplyMaxFilterType is &#x27;inRange&#x27;.&lt;br /&gt;  Data is gathered from &#x27;SupplyMax&#x27; to &#x27;SupplyMaxTo&#x27;&lt;br /&gt;  Date text in format &#x27;yyyy-MM-dd&#x27; eg. \&quot;2021-12-24\&quot;&lt;br /&gt;  Either Min/Max is used or Magnitude. | [optional] 
 **supply_magnitude_filter_type** | **str**| One of &#x27;equals&#x27;, &#x27;greaterThan&#x27;, &#x27;lessThan&#x27;, &#x27;notEqual&#x27;, &#x27;inRange&#x27;, &#x27;lessThanOrEqual&#x27;, &#x27;greaterThanOrEqual&#x27;.&lt;br /&gt;  When &#x27;inRange&#x27; then &#x27;SupplyMagnitudeTo&#x27; is needed.&lt;br /&gt;  Either Min/Max is used or Magnitude. | [optional] 
 **supply_magnitude** | **float**| The exclusive lower bound of the \&quot;Supply Magnitude\&quot;&lt;br /&gt;  Either Min/Max is used or Magnitude. | [optional] 
 **supply_magnitude_to** | **float**| The exclusive upper bound of the \&quot;Supply Magnitude\&quot;&lt;br /&gt;  Used when SupplyMagnitudeFilterType is &#x27;inRange&#x27;.&lt;br /&gt;  Data is gathered from &#x27;SupplyMagnitude&#x27; to &#x27;SupplyMagnitudeTo&#x27;&lt;br /&gt;  Either Min/Max is used or Magnitude. | [optional] 
 **supply_unit** | [**list[str]**](str.md)| &lt;list type&#x3D;\&quot;string\&quot;&gt;List of the Supply Unit&lt;/list&gt; | [optional] 
 **customer_reference_number_search_text** | **str**| Find all data with contains this search text | [optional] 
 **customer_order_number_search_text** | **str**| Find all data with contains this search text | [optional] 
 **remarks_search_text** | **str**| Find all data with contains this search text | [optional] 

### Return type

void (empty response body)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **calibration_data_get_calibration_data_headers**
> list[MefistoViewModel] calibration_data_get_calibration_data_headers(skip=skip, take=take)

Get a list with all meta-information.

### Example
```python
from __future__ import print_function
import time
import swagger_client
from swagger_client.rest import ApiException
from pprint import pprint

# Configure API key authorization: Bearer
configuration = swagger_client.Configuration()
configuration.api_key['Authorization'] = 'YOUR_API_KEY'
# Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
# configuration.api_key_prefix['Authorization'] = 'Bearer'

# create an instance of the API class
api_instance = swagger_client.CalibrationDataApi(swagger_client.ApiClient(configuration))
skip = 0 # int | OPTIONAL. Skips the given number of rows. The opposite of Take. (optional) (default to 0)
take = 2147483647 # int | OPTIONAL. Takes only the first .. rows of meta information. The opposite of Skip. When not specified the API tries to get all rows. (optional) (default to 2147483647)

try:
    # Get a list with all meta-information.
    api_response = api_instance.calibration_data_get_calibration_data_headers(skip=skip, take=take)
    pprint(api_response)
except ApiException as e:
    print("Exception when calling CalibrationDataApi->calibration_data_get_calibration_data_headers: %s\n" % e)
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **skip** | **int**| OPTIONAL. Skips the given number of rows. The opposite of Take. | [optional] [default to 0]
 **take** | **int**| OPTIONAL. Takes only the first .. rows of meta information. The opposite of Skip. When not specified the API tries to get all rows. | [optional] [default to 2147483647]

### Return type

[**list[MefistoViewModel]**](MefistoViewModel.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **calibration_data_sync_calibration_data**
> str calibration_data_sync_calibration_data()

Only used for maintenance reasons. Do not use!

### Example
```python
from __future__ import print_function
import time
import swagger_client
from swagger_client.rest import ApiException
from pprint import pprint

# Configure API key authorization: Bearer
configuration = swagger_client.Configuration()
configuration.api_key['Authorization'] = 'YOUR_API_KEY'
# Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
# configuration.api_key_prefix['Authorization'] = 'Bearer'

# create an instance of the API class
api_instance = swagger_client.CalibrationDataApi(swagger_client.ApiClient(configuration))

try:
    # Only used for maintenance reasons. Do not use!
    api_response = api_instance.calibration_data_sync_calibration_data()
    pprint(api_response)
except ApiException as e:
    print("Exception when calling CalibrationDataApi->calibration_data_sync_calibration_data: %s\n" % e)
```

### Parameters
This endpoint does not need any parameter.

### Return type

**str**

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **me_get_me_details**
> int me_get_me_details()



### Example
```python
from __future__ import print_function
import time
import swagger_client
from swagger_client.rest import ApiException
from pprint import pprint

# Configure API key authorization: Bearer
configuration = swagger_client.Configuration()
configuration.api_key['Authorization'] = 'YOUR_API_KEY'
# Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
# configuration.api_key_prefix['Authorization'] = 'Bearer'

# create an instance of the API class
api_instance = swagger_client.CalibrationDataApi(swagger_client.ApiClient(configuration))

try:
    api_response = api_instance.me_get_me_details()
    pprint(api_response)
except ApiException as e:
    print("Exception when calling CalibrationDataApi->me_get_me_details: %s\n" % e)
```

### Parameters
This endpoint does not need any parameter.

### Return type

**int**

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **profile_get_profile**
> Profile profile_get_profile()



### Example
```python
from __future__ import print_function
import time
import swagger_client
from swagger_client.rest import ApiException
from pprint import pprint

# Configure API key authorization: Bearer
configuration = swagger_client.Configuration()
configuration.api_key['Authorization'] = 'YOUR_API_KEY'
# Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
# configuration.api_key_prefix['Authorization'] = 'Bearer'

# create an instance of the API class
api_instance = swagger_client.CalibrationDataApi(swagger_client.ApiClient(configuration))

try:
    api_response = api_instance.profile_get_profile()
    pprint(api_response)
except ApiException as e:
    print("Exception when calling CalibrationDataApi->profile_get_profile: %s\n" % e)
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

# **profile_update_profile**
> bool profile_update_profile(download_format=download_format, show_sub_customer=show_sub_customer)



### Example
```python
from __future__ import print_function
import time
import swagger_client
from swagger_client.rest import ApiException
from pprint import pprint

# Configure API key authorization: Bearer
configuration = swagger_client.Configuration()
configuration.api_key['Authorization'] = 'YOUR_API_KEY'
# Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
# configuration.api_key_prefix['Authorization'] = 'Bearer'

# create an instance of the API class
api_instance = swagger_client.CalibrationDataApi(swagger_client.ApiClient(configuration))
download_format = 'download_format_example' # str | Either \"zip\" or \"br\" (brotli). \"zip\" is default. (optional)
show_sub_customer = true # bool | Default = false (optional)

try:
    api_response = api_instance.profile_update_profile(download_format=download_format, show_sub_customer=show_sub_customer)
    pprint(api_response)
except ApiException as e:
    print("Exception when calling CalibrationDataApi->profile_update_profile: %s\n" % e)
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **download_format** | **str**| Either \&quot;zip\&quot; or \&quot;br\&quot; (brotli). \&quot;zip\&quot; is default. | [optional] 
 **show_sub_customer** | **bool**| Default &#x3D; false | [optional] 

### Return type

**bool**

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **sub_customer_update_sub_customers**
> bool sub_customer_update_sub_customers(sub_customer_number=sub_customer_number, included_ids=included_ids, excluded_ids=excluded_ids, order_numbers=order_numbers, order_positions=order_positions, date_filter_type=date_filter_type, _date=_date, date_to=date_to, customer_product_types=customer_product_types, pressure_types=pressure_types, product_series=product_series, product_numbers=product_numbers, serial_number_search_text=serial_number_search_text, pressure_min_filter_type=pressure_min_filter_type, pressure_min=pressure_min, pressure_min_to=pressure_min_to, pressure_max_filter_type=pressure_max_filter_type, pressure_max=pressure_max, pressure_max_to=pressure_max_to, pressure_unit=pressure_unit, temperature_min_filter_type=temperature_min_filter_type, temperature_min=temperature_min, temperature_min_to=temperature_min_to, temperature_max_filter_type=temperature_max_filter_type, temperature_max=temperature_max, temperature_max_to=temperature_max_to, temperature_unit=temperature_unit, supply_min_filter_type=supply_min_filter_type, supply_min=supply_min, supply_min_to=supply_min_to, supply_max_filter_type=supply_max_filter_type, supply_max=supply_max, supply_max_to=supply_max_to, supply_magnitude_filter_type=supply_magnitude_filter_type, supply_magnitude=supply_magnitude, supply_magnitude_to=supply_magnitude_to, supply_unit=supply_unit, customer_reference_number_search_text=customer_reference_number_search_text, customer_order_number_search_text=customer_order_number_search_text, remarks_search_text=remarks_search_text)



### Example
```python
from __future__ import print_function
import time
import swagger_client
from swagger_client.rest import ApiException
from pprint import pprint

# Configure API key authorization: Bearer
configuration = swagger_client.Configuration()
configuration.api_key['Authorization'] = 'YOUR_API_KEY'
# Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
# configuration.api_key_prefix['Authorization'] = 'Bearer'

# create an instance of the API class
api_instance = swagger_client.CalibrationDataApi(swagger_client.ApiClient(configuration))
sub_customer_number = 56 # int |  (optional)
included_ids = ['included_ids_example'] # list[str] | If null: Either are 'ALL SELECTED' or some are unselected (and listed in ExcludedIds)<br />  If not null: None are selected except those that are listed here.<br />  It is not allowed to have IncludedIds AND ExcludedIds have listed values. One most be null or both most be null.<br />  The list of included ids is limited to 50. More than 50 will throw an exception.<br /> (optional)
excluded_ids = ['excluded_ids_example'] # list[str] | If null: Either are 'ALL SELECTED' or only some few are selected (and listed in IncludedIds)<br />  If not null: All are selected and except those that are listed here.<br />  It is not allowed to have IncludedIds AND ExcludedIds have listed values. One most be null or both most be null.<br />  The list of excluded ids is limited to 50. More than 50 will throw an exception.<br /> (optional)
order_numbers = ['order_numbers_example'] # list[str] | List of Order Numbers (optional)
order_positions = ['order_positions_example'] # list[str] | List of Order Positions (optional)
date_filter_type = 'date_filter_type_example' # str | One of 'equals', 'greaterThan', 'lessThan', 'notEqual', 'inRange'.<br />  When 'inRange' then 'DateTo' is needed.<br />  Example 1:<br />  \"All data newer than August 1st\" = https://mycalibrationapi.azurewebsites.net/v1/CalibrationData?DateFilterType=greaterThan&Date=2021-08-01<br />  Example 2:<br />  \"All data from the year 2020\" = https://mycalibrationapi.azurewebsites.net/v1/CalibrationData?DateFilterType=inRange&Date=2021-01-01&DateTo=2021-12-31 <br />  Example 3:<br />  \"All data from the first day in January and February\" = https://mycalibrationapi.azurewebsites.net/v1/CalibrationData?DateFilterType=equals&Date=2021-01-01&Date=2021-02-01 <br /> (optional)
_date = ['_date_example'] # list[str] | Dispatch-date text in format 'yyyy-MM-dd' eg. \"2021-12-24\"<br />  Normally, this is a list with one element. Nevertheless, it is possible to GET calibration data from multiple dates. In this case DateFilterType must be 'equals' and DateTo must be null. (optional)
date_to = 'date_to_example' # str | Used when DateFilterType is 'inRange'.<br />  Data is gathered from 'Date' to 'DateTo'<br />  Date text in format 'yyyy-MM-dd' eg. \"2021-12-24\" (optional)
customer_product_types = ['customer_product_types_example'] # list[str] | To search for [Blanks] use \"blank\" (optional)
pressure_types = ['pressure_types_example'] # list[str] | Eg. [\"pa\",\"paa\",\"pr\"]  To see all possible enum strings, go to https://mycalibration.github.io/#filter-parameters (optional)
product_series = ['product_series_example'] # list[str] | Eg. [\"10LHP\",\"25Y\",\"46X\",\"K-102\"] (optional)
product_numbers = ['product_numbers_example'] # list[str] |  (optional)
serial_number_search_text = 'serial_number_search_text_example' # str | Use this to find all SerialNumbers that contains this text content. (optional)
pressure_min_filter_type = 'pressure_min_filter_type_example' # str | One of 'equals', 'greaterThan', 'lessThan', 'notEqual', 'inRange', 'lessThanOrEqual', 'greaterThanOrEqual'.<br />  When 'inRange' then 'PressureMinTo' is needed. (optional)
pressure_min = 1.2 # float | The exclusive lower bound of the \"Minimum Pressure\" (optional)
pressure_min_to = 1.2 # float | The exclusive upper bound of the \"Minimum Pressure\".<br />  Used when PressureMinFilterType is 'inRange'.<br />  Data is gathered from 'PressureMin' to 'PressureMinTo'.<br />  Date text in format 'yyyy-MM-dd' eg. \"2021-12-24\"<br /> (optional)
pressure_max_filter_type = 'pressure_max_filter_type_example' # str | One of 'equals', 'greaterThan', 'lessThan', 'notEqual', 'inRange', 'lessThanOrEqual', 'greaterThanOrEqual'.<br />  When 'inRange' then 'PressureMaxTo' is needed. (optional)
pressure_max = 1.2 # float | The exclusive lower bound of the \"Maximum Pressure\" (optional)
pressure_max_to = 1.2 # float | The exclusive upper bound of the \"Maximum Pressure\"<br />  Used when PressureMaxFilterType is 'inRange'.<br />  Data is gathered from 'PressureMax' to 'PressureMaxTo'<br />  Date text in format 'yyyy-MM-dd' eg. \"2021-12-24\" (optional)
pressure_unit = ['pressure_unit_example'] # list[str] | <list type=\"string\">List of the Pressure Unit</list> (optional)
temperature_min_filter_type = 'temperature_min_filter_type_example' # str | One of 'equals', 'greaterThan', 'lessThan', 'notEqual', 'inRange', 'lessThanOrEqual', 'greaterThanOrEqual'.<br />  When 'inRange' then 'TemperatureMinTo' is needed. (optional)
temperature_min = 1.2 # float | The exclusive lower bound of the \"Minimum Temperature\" (optional)
temperature_min_to = 1.2 # float | The exclusive upper bound of the \"Minimum Temperature\"<br />  Used when TemperatureMinFilterType is 'inRange'.<br />  Data is gathered from 'TemperatureMin' to 'TemperatureMinTo'<br />  Date text in format 'yyyy-MM-dd' eg. \"2021-12-24\" (optional)
temperature_max_filter_type = 'temperature_max_filter_type_example' # str | One of 'equals', 'greaterThan', 'lessThan', 'notEqual', 'inRange', 'lessThanOrEqual', 'greaterThanOrEqual'.<br />  When 'inRange' then 'TemperatureMaxTo' is needed. (optional)
temperature_max = 1.2 # float | The exclusive lower bound of the \"Maximum Temperature\" (optional)
temperature_max_to = 1.2 # float | The exclusive upper bound of the \"Maximum Temperature\"<br />  Used when TemperatureMaxFilterType is 'inRange'.<br />  Data is gathered from 'TemperatureMax' to 'TemperatureMaxTo'<br />  Date text in format 'yyyy-MM-dd' eg. \"2021-12-24\" (optional)
temperature_unit = ['temperature_unit_example'] # list[str] | <list type=\"string\">List of the Temperature Unit</list> (optional)
supply_min_filter_type = 'supply_min_filter_type_example' # str | One of 'equals', 'greaterThan', 'lessThan', 'notEqual', 'inRange', 'lessThanOrEqual', 'greaterThanOrEqual'.<br />  When 'inRange' then 'SupplyMinTo' is needed.<br />  Either Min/Max is used or Magnitude.<br /> (optional)
supply_min = 1.2 # float | The exclusive lower bound of the \"Minimum Supply\"<br />  Either Min/Max is used or Magnitude. (optional)
supply_min_to = 1.2 # float | The exclusive upper bound of the \"Minimum Supply\"<br />  Used when SupplyMinFilterType is 'inRange'.<br />  Data is gathered from 'SupplyMin' to 'SupplyMinTo'<br />  Date text in format 'yyyy-MM-dd' eg. \"2021-12-24\"<br />  Either Min/Max is used or Magnitude. (optional)
supply_max_filter_type = 'supply_max_filter_type_example' # str | One of 'equals', 'greaterThan', 'lessThan', 'notEqual', 'inRange', 'lessThanOrEqual', 'greaterThanOrEqual'.<br />  When 'inRange' then 'SupplyMaxTo' is needed.<br />  Either Min/Max is used or Magnitude. (optional)
supply_max = 1.2 # float | The exclusive lower bound of the \"Maximum Supply\"<br />  Either Min/Max is used or Magnitude. (optional)
supply_max_to = 1.2 # float | The exclusive upper bound of the \"Maximum Supply\"<br />  Used when SupplyMaxFilterType is 'inRange'.<br />  Data is gathered from 'SupplyMax' to 'SupplyMaxTo'<br />  Date text in format 'yyyy-MM-dd' eg. \"2021-12-24\"<br />  Either Min/Max is used or Magnitude. (optional)
supply_magnitude_filter_type = 'supply_magnitude_filter_type_example' # str | One of 'equals', 'greaterThan', 'lessThan', 'notEqual', 'inRange', 'lessThanOrEqual', 'greaterThanOrEqual'.<br />  When 'inRange' then 'SupplyMagnitudeTo' is needed.<br />  Either Min/Max is used or Magnitude. (optional)
supply_magnitude = 1.2 # float | The exclusive lower bound of the \"Supply Magnitude\"<br />  Either Min/Max is used or Magnitude. (optional)
supply_magnitude_to = 1.2 # float | The exclusive upper bound of the \"Supply Magnitude\"<br />  Used when SupplyMagnitudeFilterType is 'inRange'.<br />  Data is gathered from 'SupplyMagnitude' to 'SupplyMagnitudeTo'<br />  Either Min/Max is used or Magnitude. (optional)
supply_unit = ['supply_unit_example'] # list[str] | <list type=\"string\">List of the Supply Unit</list> (optional)
customer_reference_number_search_text = 'customer_reference_number_search_text_example' # str | Find all data with contains this search text (optional)
customer_order_number_search_text = 'customer_order_number_search_text_example' # str | Find all data with contains this search text (optional)
remarks_search_text = 'remarks_search_text_example' # str | Find all data with contains this search text (optional)

try:
    api_response = api_instance.sub_customer_update_sub_customers(sub_customer_number=sub_customer_number, included_ids=included_ids, excluded_ids=excluded_ids, order_numbers=order_numbers, order_positions=order_positions, date_filter_type=date_filter_type, _date=_date, date_to=date_to, customer_product_types=customer_product_types, pressure_types=pressure_types, product_series=product_series, product_numbers=product_numbers, serial_number_search_text=serial_number_search_text, pressure_min_filter_type=pressure_min_filter_type, pressure_min=pressure_min, pressure_min_to=pressure_min_to, pressure_max_filter_type=pressure_max_filter_type, pressure_max=pressure_max, pressure_max_to=pressure_max_to, pressure_unit=pressure_unit, temperature_min_filter_type=temperature_min_filter_type, temperature_min=temperature_min, temperature_min_to=temperature_min_to, temperature_max_filter_type=temperature_max_filter_type, temperature_max=temperature_max, temperature_max_to=temperature_max_to, temperature_unit=temperature_unit, supply_min_filter_type=supply_min_filter_type, supply_min=supply_min, supply_min_to=supply_min_to, supply_max_filter_type=supply_max_filter_type, supply_max=supply_max, supply_max_to=supply_max_to, supply_magnitude_filter_type=supply_magnitude_filter_type, supply_magnitude=supply_magnitude, supply_magnitude_to=supply_magnitude_to, supply_unit=supply_unit, customer_reference_number_search_text=customer_reference_number_search_text, customer_order_number_search_text=customer_order_number_search_text, remarks_search_text=remarks_search_text)
    pprint(api_response)
except ApiException as e:
    print("Exception when calling CalibrationDataApi->sub_customer_update_sub_customers: %s\n" % e)
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **sub_customer_number** | **int**|  | [optional] 
 **included_ids** | [**list[str]**](str.md)| If null: Either are &#x27;ALL SELECTED&#x27; or some are unselected (and listed in ExcludedIds)&lt;br /&gt;  If not null: None are selected except those that are listed here.&lt;br /&gt;  It is not allowed to have IncludedIds AND ExcludedIds have listed values. One most be null or both most be null.&lt;br /&gt;  The list of included ids is limited to 50. More than 50 will throw an exception.&lt;br /&gt; | [optional] 
 **excluded_ids** | [**list[str]**](str.md)| If null: Either are &#x27;ALL SELECTED&#x27; or only some few are selected (and listed in IncludedIds)&lt;br /&gt;  If not null: All are selected and except those that are listed here.&lt;br /&gt;  It is not allowed to have IncludedIds AND ExcludedIds have listed values. One most be null or both most be null.&lt;br /&gt;  The list of excluded ids is limited to 50. More than 50 will throw an exception.&lt;br /&gt; | [optional] 
 **order_numbers** | [**list[str]**](str.md)| List of Order Numbers | [optional] 
 **order_positions** | [**list[str]**](str.md)| List of Order Positions | [optional] 
 **date_filter_type** | **str**| One of &#x27;equals&#x27;, &#x27;greaterThan&#x27;, &#x27;lessThan&#x27;, &#x27;notEqual&#x27;, &#x27;inRange&#x27;.&lt;br /&gt;  When &#x27;inRange&#x27; then &#x27;DateTo&#x27; is needed.&lt;br /&gt;  Example 1:&lt;br /&gt;  \&quot;All data newer than August 1st\&quot; &#x3D; https://mycalibrationapi.azurewebsites.net/v1/CalibrationData?DateFilterType&#x3D;greaterThan&amp;Date&#x3D;2021-08-01&lt;br /&gt;  Example 2:&lt;br /&gt;  \&quot;All data from the year 2020\&quot; &#x3D; https://mycalibrationapi.azurewebsites.net/v1/CalibrationData?DateFilterType&#x3D;inRange&amp;Date&#x3D;2021-01-01&amp;DateTo&#x3D;2021-12-31 &lt;br /&gt;  Example 3:&lt;br /&gt;  \&quot;All data from the first day in January and February\&quot; &#x3D; https://mycalibrationapi.azurewebsites.net/v1/CalibrationData?DateFilterType&#x3D;equals&amp;Date&#x3D;2021-01-01&amp;Date&#x3D;2021-02-01 &lt;br /&gt; | [optional] 
 **_date** | [**list[str]**](str.md)| Dispatch-date text in format &#x27;yyyy-MM-dd&#x27; eg. \&quot;2021-12-24\&quot;&lt;br /&gt;  Normally, this is a list with one element. Nevertheless, it is possible to GET calibration data from multiple dates. In this case DateFilterType must be &#x27;equals&#x27; and DateTo must be null. | [optional] 
 **date_to** | **str**| Used when DateFilterType is &#x27;inRange&#x27;.&lt;br /&gt;  Data is gathered from &#x27;Date&#x27; to &#x27;DateTo&#x27;&lt;br /&gt;  Date text in format &#x27;yyyy-MM-dd&#x27; eg. \&quot;2021-12-24\&quot; | [optional] 
 **customer_product_types** | [**list[str]**](str.md)| To search for [Blanks] use \&quot;blank\&quot; | [optional] 
 **pressure_types** | [**list[str]**](str.md)| Eg. [\&quot;pa\&quot;,\&quot;paa\&quot;,\&quot;pr\&quot;]  To see all possible enum strings, go to https://mycalibration.github.io/#filter-parameters | [optional] 
 **product_series** | [**list[str]**](str.md)| Eg. [\&quot;10LHP\&quot;,\&quot;25Y\&quot;,\&quot;46X\&quot;,\&quot;K-102\&quot;] | [optional] 
 **product_numbers** | [**list[str]**](str.md)|  | [optional] 
 **serial_number_search_text** | **str**| Use this to find all SerialNumbers that contains this text content. | [optional] 
 **pressure_min_filter_type** | **str**| One of &#x27;equals&#x27;, &#x27;greaterThan&#x27;, &#x27;lessThan&#x27;, &#x27;notEqual&#x27;, &#x27;inRange&#x27;, &#x27;lessThanOrEqual&#x27;, &#x27;greaterThanOrEqual&#x27;.&lt;br /&gt;  When &#x27;inRange&#x27; then &#x27;PressureMinTo&#x27; is needed. | [optional] 
 **pressure_min** | **float**| The exclusive lower bound of the \&quot;Minimum Pressure\&quot; | [optional] 
 **pressure_min_to** | **float**| The exclusive upper bound of the \&quot;Minimum Pressure\&quot;.&lt;br /&gt;  Used when PressureMinFilterType is &#x27;inRange&#x27;.&lt;br /&gt;  Data is gathered from &#x27;PressureMin&#x27; to &#x27;PressureMinTo&#x27;.&lt;br /&gt;  Date text in format &#x27;yyyy-MM-dd&#x27; eg. \&quot;2021-12-24\&quot;&lt;br /&gt; | [optional] 
 **pressure_max_filter_type** | **str**| One of &#x27;equals&#x27;, &#x27;greaterThan&#x27;, &#x27;lessThan&#x27;, &#x27;notEqual&#x27;, &#x27;inRange&#x27;, &#x27;lessThanOrEqual&#x27;, &#x27;greaterThanOrEqual&#x27;.&lt;br /&gt;  When &#x27;inRange&#x27; then &#x27;PressureMaxTo&#x27; is needed. | [optional] 
 **pressure_max** | **float**| The exclusive lower bound of the \&quot;Maximum Pressure\&quot; | [optional] 
 **pressure_max_to** | **float**| The exclusive upper bound of the \&quot;Maximum Pressure\&quot;&lt;br /&gt;  Used when PressureMaxFilterType is &#x27;inRange&#x27;.&lt;br /&gt;  Data is gathered from &#x27;PressureMax&#x27; to &#x27;PressureMaxTo&#x27;&lt;br /&gt;  Date text in format &#x27;yyyy-MM-dd&#x27; eg. \&quot;2021-12-24\&quot; | [optional] 
 **pressure_unit** | [**list[str]**](str.md)| &lt;list type&#x3D;\&quot;string\&quot;&gt;List of the Pressure Unit&lt;/list&gt; | [optional] 
 **temperature_min_filter_type** | **str**| One of &#x27;equals&#x27;, &#x27;greaterThan&#x27;, &#x27;lessThan&#x27;, &#x27;notEqual&#x27;, &#x27;inRange&#x27;, &#x27;lessThanOrEqual&#x27;, &#x27;greaterThanOrEqual&#x27;.&lt;br /&gt;  When &#x27;inRange&#x27; then &#x27;TemperatureMinTo&#x27; is needed. | [optional] 
 **temperature_min** | **float**| The exclusive lower bound of the \&quot;Minimum Temperature\&quot; | [optional] 
 **temperature_min_to** | **float**| The exclusive upper bound of the \&quot;Minimum Temperature\&quot;&lt;br /&gt;  Used when TemperatureMinFilterType is &#x27;inRange&#x27;.&lt;br /&gt;  Data is gathered from &#x27;TemperatureMin&#x27; to &#x27;TemperatureMinTo&#x27;&lt;br /&gt;  Date text in format &#x27;yyyy-MM-dd&#x27; eg. \&quot;2021-12-24\&quot; | [optional] 
 **temperature_max_filter_type** | **str**| One of &#x27;equals&#x27;, &#x27;greaterThan&#x27;, &#x27;lessThan&#x27;, &#x27;notEqual&#x27;, &#x27;inRange&#x27;, &#x27;lessThanOrEqual&#x27;, &#x27;greaterThanOrEqual&#x27;.&lt;br /&gt;  When &#x27;inRange&#x27; then &#x27;TemperatureMaxTo&#x27; is needed. | [optional] 
 **temperature_max** | **float**| The exclusive lower bound of the \&quot;Maximum Temperature\&quot; | [optional] 
 **temperature_max_to** | **float**| The exclusive upper bound of the \&quot;Maximum Temperature\&quot;&lt;br /&gt;  Used when TemperatureMaxFilterType is &#x27;inRange&#x27;.&lt;br /&gt;  Data is gathered from &#x27;TemperatureMax&#x27; to &#x27;TemperatureMaxTo&#x27;&lt;br /&gt;  Date text in format &#x27;yyyy-MM-dd&#x27; eg. \&quot;2021-12-24\&quot; | [optional] 
 **temperature_unit** | [**list[str]**](str.md)| &lt;list type&#x3D;\&quot;string\&quot;&gt;List of the Temperature Unit&lt;/list&gt; | [optional] 
 **supply_min_filter_type** | **str**| One of &#x27;equals&#x27;, &#x27;greaterThan&#x27;, &#x27;lessThan&#x27;, &#x27;notEqual&#x27;, &#x27;inRange&#x27;, &#x27;lessThanOrEqual&#x27;, &#x27;greaterThanOrEqual&#x27;.&lt;br /&gt;  When &#x27;inRange&#x27; then &#x27;SupplyMinTo&#x27; is needed.&lt;br /&gt;  Either Min/Max is used or Magnitude.&lt;br /&gt; | [optional] 
 **supply_min** | **float**| The exclusive lower bound of the \&quot;Minimum Supply\&quot;&lt;br /&gt;  Either Min/Max is used or Magnitude. | [optional] 
 **supply_min_to** | **float**| The exclusive upper bound of the \&quot;Minimum Supply\&quot;&lt;br /&gt;  Used when SupplyMinFilterType is &#x27;inRange&#x27;.&lt;br /&gt;  Data is gathered from &#x27;SupplyMin&#x27; to &#x27;SupplyMinTo&#x27;&lt;br /&gt;  Date text in format &#x27;yyyy-MM-dd&#x27; eg. \&quot;2021-12-24\&quot;&lt;br /&gt;  Either Min/Max is used or Magnitude. | [optional] 
 **supply_max_filter_type** | **str**| One of &#x27;equals&#x27;, &#x27;greaterThan&#x27;, &#x27;lessThan&#x27;, &#x27;notEqual&#x27;, &#x27;inRange&#x27;, &#x27;lessThanOrEqual&#x27;, &#x27;greaterThanOrEqual&#x27;.&lt;br /&gt;  When &#x27;inRange&#x27; then &#x27;SupplyMaxTo&#x27; is needed.&lt;br /&gt;  Either Min/Max is used or Magnitude. | [optional] 
 **supply_max** | **float**| The exclusive lower bound of the \&quot;Maximum Supply\&quot;&lt;br /&gt;  Either Min/Max is used or Magnitude. | [optional] 
 **supply_max_to** | **float**| The exclusive upper bound of the \&quot;Maximum Supply\&quot;&lt;br /&gt;  Used when SupplyMaxFilterType is &#x27;inRange&#x27;.&lt;br /&gt;  Data is gathered from &#x27;SupplyMax&#x27; to &#x27;SupplyMaxTo&#x27;&lt;br /&gt;  Date text in format &#x27;yyyy-MM-dd&#x27; eg. \&quot;2021-12-24\&quot;&lt;br /&gt;  Either Min/Max is used or Magnitude. | [optional] 
 **supply_magnitude_filter_type** | **str**| One of &#x27;equals&#x27;, &#x27;greaterThan&#x27;, &#x27;lessThan&#x27;, &#x27;notEqual&#x27;, &#x27;inRange&#x27;, &#x27;lessThanOrEqual&#x27;, &#x27;greaterThanOrEqual&#x27;.&lt;br /&gt;  When &#x27;inRange&#x27; then &#x27;SupplyMagnitudeTo&#x27; is needed.&lt;br /&gt;  Either Min/Max is used or Magnitude. | [optional] 
 **supply_magnitude** | **float**| The exclusive lower bound of the \&quot;Supply Magnitude\&quot;&lt;br /&gt;  Either Min/Max is used or Magnitude. | [optional] 
 **supply_magnitude_to** | **float**| The exclusive upper bound of the \&quot;Supply Magnitude\&quot;&lt;br /&gt;  Used when SupplyMagnitudeFilterType is &#x27;inRange&#x27;.&lt;br /&gt;  Data is gathered from &#x27;SupplyMagnitude&#x27; to &#x27;SupplyMagnitudeTo&#x27;&lt;br /&gt;  Either Min/Max is used or Magnitude. | [optional] 
 **supply_unit** | [**list[str]**](str.md)| &lt;list type&#x3D;\&quot;string\&quot;&gt;List of the Supply Unit&lt;/list&gt; | [optional] 
 **customer_reference_number_search_text** | **str**| Find all data with contains this search text | [optional] 
 **customer_order_number_search_text** | **str**| Find all data with contains this search text | [optional] 
 **remarks_search_text** | **str**| Find all data with contains this search text | [optional] 

### Return type

**bool**

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

