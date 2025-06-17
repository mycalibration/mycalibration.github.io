# myCalibration OpenAPI 3 Specification
myCalibration API

## Version: 1.22.238.1

**Contact information:**  
KELLER Pressure
https://mycalibration.azurewebsites.net/  
engineering@keller-pressure.com  

### /v1/Profile

#### GET
##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | Success |

#### PUT
##### Summary:



##### Parameters

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ---- |
| downloadFormat | query | Either "zip" or "br" (brotli). "zip" is default. | No | string |
| showSubCustomer | query | Default = false | No | boolean |

##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | Success |

### /v1/SubCustomers

#### GET
##### Summary:

Respond with information regarding subcustomers if there are any.

##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | Success |

### /v1/CalibrationData/SubCustomers/{subCustomerNumber}

#### PUT
##### Parameters

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ---- |
| subCustomerNumber | path |  | Yes | integer |
| subCustomerOrderNumber | query |  | No | string |
| subCustomerPosition | query |  | No | string |
| IncludedIds | query | If null: Either are 'ALL SELECTED' or some are unselected (and listed in ExcludedIds)<br />  If not null: None are selected except those that are listed here.<br />  It is not allowed to have IncludedIds AND ExcludedIds have listed values. One most be null or both most be null.<br />  The list of included ids is limited to 50. More than 50 will throw an exception.<br /> | No | [ string ] |
| ExcludedIds | query | If null: Either are 'ALL SELECTED' or only some few are selected (and listed in IncludedIds)<br />  If not null: All are selected and except those that are listed here.<br />  It is not allowed to have IncludedIds AND ExcludedIds have listed values. One most be null or both most be null.<br />  The list of excluded ids is limited to 50. More than 50 will throw an exception.<br /> | No | [ string ] |
| OrderNumbers | query | List of Order Numbers | No | [ string ] |
| OrderPositions | query | List of Order Positions | No | [ string ] |
| DateFilterType | query | One of 'equals', 'greaterThan', 'lessThan', 'notEqual', 'inRange'.<br />  When 'inRange' then 'DateTo' is needed.<br />  Example 1:<br />  "All data newer than August 1st" = https://mycalibrationapi.azurewebsites.net/v1/CalibrationData?DateFilterType=greaterThan&Date=2021-08-01<br />  Example 2:<br />  "All data from the year 2020" = https://mycalibrationapi.azurewebsites.net/v1/CalibrationData?DateFilterType=inRange&Date=2021-01-01&DateTo=2021-12-31 <br />  Example 3:<br />  "All data from the first day in January and February" = https://mycalibrationapi.azurewebsites.net/v1/CalibrationData?DateFilterType=equals&Date=2021-01-01&Date=2021-02-01 <br /> | No | string |
| Date | query | Dispatch-date text in format 'yyyy-MM-dd' eg. "2021-12-24"<br />  Normally, this is a list with one element. Nevertheless, it is possible to GET calibration data from multiple dates. In this case DateFilterType must be 'equals' and DateTo must be null. | No | [ string ] |
| DateTo | query | Used when DateFilterType is 'inRange'.<br />  Data is gathered from 'Date' to 'DateTo'<br />  Date text in format 'yyyy-MM-dd' eg. "2021-12-24" | No | string |
| CustomerProductTypes | query | To search for [Blanks] use "blank" | No | [ string ] |
| PressureTypes | query | Eg. ["pa","paa","pr"]  To see all possible enum strings, go to https://mycalibration.github.io/#filter-parameters | No | [ string ] |
| ProductSeries | query | Eg. ["10LHP","25Y","46X","K-102"] | No | [ string ] |
| ProductNumbers | query |  | No | [ string ] |
| SerialNumberSearchText | query | Use this to find all SerialNumbers that contains this text content. | No | string |
| PressureMinFilterType | query | One of 'equals', 'greaterThan', 'lessThan', 'notEqual', 'inRange', 'lessThanOrEqual', 'greaterThanOrEqual'.<br />  When 'inRange' then 'PressureMinTo' is needed. | No | string |
| PressureMin | query | The exclusive lower bound of the "Minimum Pressure" | No | double |
| PressureMinTo | query | The exclusive upper bound of the "Minimum Pressure".<br />  Used when PressureMinFilterType is 'inRange'.<br />  Data is gathered from 'PressureMin' to 'PressureMinTo'.<br />  Date text in format 'yyyy-MM-dd' eg. "2021-12-24"<br /> | No | double |
| PressureMaxFilterType | query | One of 'equals', 'greaterThan', 'lessThan', 'notEqual', 'inRange', 'lessThanOrEqual', 'greaterThanOrEqual'.<br />  When 'inRange' then 'PressureMaxTo' is needed. | No | string |
| PressureMax | query | The exclusive lower bound of the "Maximum Pressure" | No | double |
| PressureMaxTo | query | The exclusive upper bound of the "Maximum Pressure"<br />  Used when PressureMaxFilterType is 'inRange'.<br />  Data is gathered from 'PressureMax' to 'PressureMaxTo'<br />  Date text in format 'yyyy-MM-dd' eg. "2021-12-24" | No | double |
| PressureUnit | query | <list type="string">List of the Pressure Unit</list> | No | [ string ] |
| TemperatureMinFilterType | query | One of 'equals', 'greaterThan', 'lessThan', 'notEqual', 'inRange', 'lessThanOrEqual', 'greaterThanOrEqual'.<br />  When 'inRange' then 'TemperatureMinTo' is needed. | No | string |
| TemperatureMin | query | The exclusive lower bound of the "Minimum Temperature" | No | double |
| TemperatureMinTo | query | The exclusive upper bound of the "Minimum Temperature"<br />  Used when TemperatureMinFilterType is 'inRange'.<br />  Data is gathered from 'TemperatureMin' to 'TemperatureMinTo'<br />  Date text in format 'yyyy-MM-dd' eg. "2021-12-24" | No | double |
| TemperatureMaxFilterType | query | One of 'equals', 'greaterThan', 'lessThan', 'notEqual', 'inRange', 'lessThanOrEqual', 'greaterThanOrEqual'.<br />  When 'inRange' then 'TemperatureMaxTo' is needed. | No | string |
| TemperatureMax | query | The exclusive lower bound of the "Maximum Temperature" | No | double |
| TemperatureMaxTo | query | The exclusive upper bound of the "Maximum Temperature"<br />  Used when TemperatureMaxFilterType is 'inRange'.<br />  Data is gathered from 'TemperatureMax' to 'TemperatureMaxTo'<br />  Date text in format 'yyyy-MM-dd' eg. "2021-12-24" | No | double |
| TemperatureUnit | query | <list type="string">List of the Temperature Unit</list> | No | [ string ] |
| SupplyMinFilterType | query | One of 'equals', 'greaterThan', 'lessThan', 'notEqual', 'inRange', 'lessThanOrEqual', 'greaterThanOrEqual'.<br />  When 'inRange' then 'SupplyMinTo' is needed.<br />  Either Min/Max is used or Magnitude.<br /> | No | string |
| SupplyMin | query | The exclusive lower bound of the "Minimum Supply"<br />  Either Min/Max is used or Magnitude. | No | double |
| SupplyMinTo | query | The exclusive upper bound of the "Minimum Supply"<br />  Used when SupplyMinFilterType is 'inRange'.<br />  Data is gathered from 'SupplyMin' to 'SupplyMinTo'<br />  Date text in format 'yyyy-MM-dd' eg. "2021-12-24"<br />  Either Min/Max is used or Magnitude. | No | double |
| SupplyMaxFilterType | query | One of 'equals', 'greaterThan', 'lessThan', 'notEqual', 'inRange', 'lessThanOrEqual', 'greaterThanOrEqual'.<br />  When 'inRange' then 'SupplyMaxTo' is needed.<br />  Either Min/Max is used or Magnitude. | No | string |
| SupplyMax | query | The exclusive lower bound of the "Maximum Supply"<br />  Either Min/Max is used or Magnitude. | No | double |
| SupplyMaxTo | query | The exclusive upper bound of the "Maximum Supply"<br />  Used when SupplyMaxFilterType is 'inRange'.<br />  Data is gathered from 'SupplyMax' to 'SupplyMaxTo'<br />  Date text in format 'yyyy-MM-dd' eg. "2021-12-24"<br />  Either Min/Max is used or Magnitude. | No | double |
| SupplyMagnitudeFilterType | query | One of 'equals', 'greaterThan', 'lessThan', 'notEqual', 'inRange', 'lessThanOrEqual', 'greaterThanOrEqual'.<br />  When 'inRange' then 'SupplyMagnitudeTo' is needed.<br />  Either Min/Max is used or Magnitude. | No | string |
| SupplyMagnitude | query | The exclusive lower bound of the "Supply Magnitude"<br />  Either Min/Max is used or Magnitude. | No | double |
| SupplyMagnitudeTo | query | The exclusive upper bound of the "Supply Magnitude"<br />  Used when SupplyMagnitudeFilterType is 'inRange'.<br />  Data is gathered from 'SupplyMagnitude' to 'SupplyMagnitudeTo'<br />  Either Min/Max is used or Magnitude. | No | double |
| SupplyUnit | query | <list type="string">List of the Supply Unit</list> | No | [ string ] |
| CustomerReferenceNumberSearchText | query | Find all data with contains this search text | No | string |
| CustomerOrderNumberSearchText | query | Find all data with contains this search text | No | string |
| RemarksSearchText | query | Find all data with contains this search text | No | string |

##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | Success |

### /v1/CalibrationData/Headers

#### GET
##### Summary:

Get a list with all meta-information.

##### Parameters

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ---- |
| skip | query | OPTIONAL. Skips the given number of rows. The opposite of Take. | No | integer |
| take | query | OPTIONAL. Takes only the first .. rows of meta information. The opposite of Skip. When not specified the API tries to get all rows. | No | integer |

##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | Success |

### /v1/CalibrationData

#### GET
##### Summary:

Gathers all filtered data in one JSON response

##### Parameters

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ---- |
| IncludedIds | query | If null: Either are 'ALL SELECTED' or some are unselected (and listed in ExcludedIds)<br />  If not null: None are selected except those that are listed here.<br />  It is not allowed to have IncludedIds AND ExcludedIds have listed values. One most be null or both most be null.<br />  The list of included ids is limited to 50. More than 50 will throw an exception.<br /> | No | [ string ] |
| ExcludedIds | query | If null: Either are 'ALL SELECTED' or only some few are selected (and listed in IncludedIds)<br />  If not null: All are selected and except those that are listed here.<br />  It is not allowed to have IncludedIds AND ExcludedIds have listed values. One most be null or both most be null.<br />  The list of excluded ids is limited to 50. More than 50 will throw an exception.<br /> | No | [ string ] |
| OrderNumbers | query | List of Order Numbers | No | [ string ] |
| OrderPositions | query | List of Order Positions | No | [ string ] |
| DateFilterType | query | One of 'equals', 'greaterThan', 'lessThan', 'notEqual', 'inRange'.<br />  When 'inRange' then 'DateTo' is needed.<br />  Example 1:<br />  "All data newer than August 1st" = https://mycalibrationapi.azurewebsites.net/v1/CalibrationData?DateFilterType=greaterThan&Date=2021-08-01<br />  Example 2:<br />  "All data from the year 2020" = https://mycalibrationapi.azurewebsites.net/v1/CalibrationData?DateFilterType=inRange&Date=2021-01-01&DateTo=2021-12-31 <br />  Example 3:<br />  "All data from the first day in January and February" = https://mycalibrationapi.azurewebsites.net/v1/CalibrationData?DateFilterType=equals&Date=2021-01-01&Date=2021-02-01 <br /> | No | string |
| Date | query | Dispatch-date text in format 'yyyy-MM-dd' eg. "2021-12-24"<br />  Normally, this is a list with one element. Nevertheless, it is possible to GET calibration data from multiple dates. In this case DateFilterType must be 'equals' and DateTo must be null. | No | [ string ] |
| DateTo | query | Used when DateFilterType is 'inRange'.<br />  Data is gathered from 'Date' to 'DateTo'<br />  Date text in format 'yyyy-MM-dd' eg. "2021-12-24" | No | string |
| CustomerProductTypes | query | To search for [Blanks] use "blank" | No | [ string ] |
| PressureTypes | query | Eg. ["pa","paa","pr"]  To see all possible enum strings, go to https://mycalibration.github.io/#filter-parameters | No | [ string ] |
| ProductSeries | query | Eg. ["10LHP","25Y","46X","K-102"] | No | [ string ] |
| ProductNumbers | query |  | No | [ string ] |
| SerialNumberSearchText | query | Use this to find all SerialNumbers that contains this text content. | No | string |
| PressureMinFilterType | query | One of 'equals', 'greaterThan', 'lessThan', 'notEqual', 'inRange', 'lessThanOrEqual', 'greaterThanOrEqual'.<br />  When 'inRange' then 'PressureMinTo' is needed. | No | string |
| PressureMin | query | The exclusive lower bound of the "Minimum Pressure" | No | double |
| PressureMinTo | query | The exclusive upper bound of the "Minimum Pressure".<br />  Used when PressureMinFilterType is 'inRange'.<br />  Data is gathered from 'PressureMin' to 'PressureMinTo'.<br />  Date text in format 'yyyy-MM-dd' eg. "2021-12-24"<br /> | No | double |
| PressureMaxFilterType | query | One of 'equals', 'greaterThan', 'lessThan', 'notEqual', 'inRange', 'lessThanOrEqual', 'greaterThanOrEqual'.<br />  When 'inRange' then 'PressureMaxTo' is needed. | No | string |
| PressureMax | query | The exclusive lower bound of the "Maximum Pressure" | No | double |
| PressureMaxTo | query | The exclusive upper bound of the "Maximum Pressure"<br />  Used when PressureMaxFilterType is 'inRange'.<br />  Data is gathered from 'PressureMax' to 'PressureMaxTo'<br />  Date text in format 'yyyy-MM-dd' eg. "2021-12-24" | No | double |
| PressureUnit | query | <list type="string">List of the Pressure Unit</list> | No | [ string ] |
| TemperatureMinFilterType | query | One of 'equals', 'greaterThan', 'lessThan', 'notEqual', 'inRange', 'lessThanOrEqual', 'greaterThanOrEqual'.<br />  When 'inRange' then 'TemperatureMinTo' is needed. | No | string |
| TemperatureMin | query | The exclusive lower bound of the "Minimum Temperature" | No | double |
| TemperatureMinTo | query | The exclusive upper bound of the "Minimum Temperature"<br />  Used when TemperatureMinFilterType is 'inRange'.<br />  Data is gathered from 'TemperatureMin' to 'TemperatureMinTo'<br />  Date text in format 'yyyy-MM-dd' eg. "2021-12-24" | No | double |
| TemperatureMaxFilterType | query | One of 'equals', 'greaterThan', 'lessThan', 'notEqual', 'inRange', 'lessThanOrEqual', 'greaterThanOrEqual'.<br />  When 'inRange' then 'TemperatureMaxTo' is needed. | No | string |
| TemperatureMax | query | The exclusive lower bound of the "Maximum Temperature" | No | double |
| TemperatureMaxTo | query | The exclusive upper bound of the "Maximum Temperature"<br />  Used when TemperatureMaxFilterType is 'inRange'.<br />  Data is gathered from 'TemperatureMax' to 'TemperatureMaxTo'<br />  Date text in format 'yyyy-MM-dd' eg. "2021-12-24" | No | double |
| TemperatureUnit | query | <list type="string">List of the Temperature Unit</list> | No | [ string ] |
| SupplyMinFilterType | query | One of 'equals', 'greaterThan', 'lessThan', 'notEqual', 'inRange', 'lessThanOrEqual', 'greaterThanOrEqual'.<br />  When 'inRange' then 'SupplyMinTo' is needed.<br />  Either Min/Max is used or Magnitude.<br /> | No | string |
| SupplyMin | query | The exclusive lower bound of the "Minimum Supply"<br />  Either Min/Max is used or Magnitude. | No | double |
| SupplyMinTo | query | The exclusive upper bound of the "Minimum Supply"<br />  Used when SupplyMinFilterType is 'inRange'.<br />  Data is gathered from 'SupplyMin' to 'SupplyMinTo'<br />  Date text in format 'yyyy-MM-dd' eg. "2021-12-24"<br />  Either Min/Max is used or Magnitude. | No | double |
| SupplyMaxFilterType | query | One of 'equals', 'greaterThan', 'lessThan', 'notEqual', 'inRange', 'lessThanOrEqual', 'greaterThanOrEqual'.<br />  When 'inRange' then 'SupplyMaxTo' is needed.<br />  Either Min/Max is used or Magnitude. | No | string |
| SupplyMax | query | The exclusive lower bound of the "Maximum Supply"<br />  Either Min/Max is used or Magnitude. | No | double |
| SupplyMaxTo | query | The exclusive upper bound of the "Maximum Supply"<br />  Used when SupplyMaxFilterType is 'inRange'.<br />  Data is gathered from 'SupplyMax' to 'SupplyMaxTo'<br />  Date text in format 'yyyy-MM-dd' eg. "2021-12-24"<br />  Either Min/Max is used or Magnitude. | No | double |
| SupplyMagnitudeFilterType | query | One of 'equals', 'greaterThan', 'lessThan', 'notEqual', 'inRange', 'lessThanOrEqual', 'greaterThanOrEqual'.<br />  When 'inRange' then 'SupplyMagnitudeTo' is needed.<br />  Either Min/Max is used or Magnitude. | No | string |
| SupplyMagnitude | query | The exclusive lower bound of the "Supply Magnitude"<br />  Either Min/Max is used or Magnitude. | No | double |
| SupplyMagnitudeTo | query | The exclusive upper bound of the "Supply Magnitude"<br />  Used when SupplyMagnitudeFilterType is 'inRange'.<br />  Data is gathered from 'SupplyMagnitude' to 'SupplyMagnitudeTo'<br />  Either Min/Max is used or Magnitude. | No | double |
| SupplyUnit | query | <list type="string">List of the Supply Unit</list> | No | [ string ] |
| CustomerReferenceNumberSearchText | query | Find all data with contains this search text | No | string |
| CustomerOrderNumberSearchText | query | Find all data with contains this search text | No | string |
| RemarksSearchText | query | Find all data with contains this search text | No | string |

##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | Success |

### /v1/CalibrationData/New

#### PUT
##### Summary:

Gathers all NEW data. 'New data' is calibration data that was never requested with this request. A second request might return an empty list.
Optionally, if the new data could not be stored, then with 'countOfHoursDataWasAlreadyRequested' the data requested will be shown again back to the given hours.
Optionally, 'countOfHoursDataWasAlreadyAssigned' can be used

##### Parameters

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ---- |
| take | query |  | No | integer |
| countOfHoursDataWasAlreadyRequested | query |  | No | integer |
| countOfHoursDataWasAlreadyAssigned | query |  | No | integer |

##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | Success |

### /v1/CalibrationData/Count

#### GET
##### Summary:

Get the count of the calibration data set based on the optional search parameters.
If optionalSearchParameter or its fields are null then the returned number is the amount of all sensors the account has access to.
You can use this to quickly find out how many files you request with a given query.

##### Parameters

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ---- |
| IncludedIds | query | If null: Either are 'ALL SELECTED' or some are unselected (and listed in ExcludedIds)<br />  If not null: None are selected except those that are listed here.<br />  It is not allowed to have IncludedIds AND ExcludedIds have listed values. One most be null or both most be null.<br />  The list of included ids is limited to 50. More than 50 will throw an exception.<br /> | No | [ string ] |
| ExcludedIds | query | If null: Either are 'ALL SELECTED' or only some few are selected (and listed in IncludedIds)<br />  If not null: All are selected and except those that are listed here.<br />  It is not allowed to have IncludedIds AND ExcludedIds have listed values. One most be null or both most be null.<br />  The list of excluded ids is limited to 50. More than 50 will throw an exception.<br /> | No | [ string ] |
| OrderNumbers | query | List of Order Numbers | No | [ string ] |
| OrderPositions | query | List of Order Positions | No | [ string ] |
| DateFilterType | query | One of 'equals', 'greaterThan', 'lessThan', 'notEqual', 'inRange'.<br />  When 'inRange' then 'DateTo' is needed.<br />  Example 1:<br />  "All data newer than August 1st" = https://mycalibrationapi.azurewebsites.net/v1/CalibrationData?DateFilterType=greaterThan&Date=2021-08-01<br />  Example 2:<br />  "All data from the year 2020" = https://mycalibrationapi.azurewebsites.net/v1/CalibrationData?DateFilterType=inRange&Date=2021-01-01&DateTo=2021-12-31 <br />  Example 3:<br />  "All data from the first day in January and February" = https://mycalibrationapi.azurewebsites.net/v1/CalibrationData?DateFilterType=equals&Date=2021-01-01&Date=2021-02-01 <br /> | No | string |
| Date | query | Dispatch-date text in format 'yyyy-MM-dd' eg. "2021-12-24"<br />  Normally, this is a list with one element. Nevertheless, it is possible to GET calibration data from multiple dates. In this case DateFilterType must be 'equals' and DateTo must be null. | No | [ string ] |
| DateTo | query | Used when DateFilterType is 'inRange'.<br />  Data is gathered from 'Date' to 'DateTo'<br />  Date text in format 'yyyy-MM-dd' eg. "2021-12-24" | No | string |
| CustomerProductTypes | query | To search for [Blanks] use "blank" | No | [ string ] |
| PressureTypes | query | Eg. ["pa","paa","pr"]  To see all possible enum strings, go to https://mycalibration.github.io/#filter-parameters | No | [ string ] |
| ProductSeries | query | Eg. ["10LHP","25Y","46X","K-102"] | No | [ string ] |
| ProductNumbers | query |  | No | [ string ] |
| SerialNumberSearchText | query | Use this to find all SerialNumbers that contains this text content. | No | string |
| PressureMinFilterType | query | One of 'equals', 'greaterThan', 'lessThan', 'notEqual', 'inRange', 'lessThanOrEqual', 'greaterThanOrEqual'.<br />  When 'inRange' then 'PressureMinTo' is needed. | No | string |
| PressureMin | query | The exclusive lower bound of the "Minimum Pressure" | No | double |
| PressureMinTo | query | The exclusive upper bound of the "Minimum Pressure".<br />  Used when PressureMinFilterType is 'inRange'.<br />  Data is gathered from 'PressureMin' to 'PressureMinTo'.<br />  Date text in format 'yyyy-MM-dd' eg. "2021-12-24"<br /> | No | double |
| PressureMaxFilterType | query | One of 'equals', 'greaterThan', 'lessThan', 'notEqual', 'inRange', 'lessThanOrEqual', 'greaterThanOrEqual'.<br />  When 'inRange' then 'PressureMaxTo' is needed. | No | string |
| PressureMax | query | The exclusive lower bound of the "Maximum Pressure" | No | double |
| PressureMaxTo | query | The exclusive upper bound of the "Maximum Pressure"<br />  Used when PressureMaxFilterType is 'inRange'.<br />  Data is gathered from 'PressureMax' to 'PressureMaxTo'<br />  Date text in format 'yyyy-MM-dd' eg. "2021-12-24" | No | double |
| PressureUnit | query | <list type="string">List of the Pressure Unit</list> | No | [ string ] |
| TemperatureMinFilterType | query | One of 'equals', 'greaterThan', 'lessThan', 'notEqual', 'inRange', 'lessThanOrEqual', 'greaterThanOrEqual'.<br />  When 'inRange' then 'TemperatureMinTo' is needed. | No | string |
| TemperatureMin | query | The exclusive lower bound of the "Minimum Temperature" | No | double |
| TemperatureMinTo | query | The exclusive upper bound of the "Minimum Temperature"<br />  Used when TemperatureMinFilterType is 'inRange'.<br />  Data is gathered from 'TemperatureMin' to 'TemperatureMinTo'<br />  Date text in format 'yyyy-MM-dd' eg. "2021-12-24" | No | double |
| TemperatureMaxFilterType | query | One of 'equals', 'greaterThan', 'lessThan', 'notEqual', 'inRange', 'lessThanOrEqual', 'greaterThanOrEqual'.<br />  When 'inRange' then 'TemperatureMaxTo' is needed. | No | string |
| TemperatureMax | query | The exclusive lower bound of the "Maximum Temperature" | No | double |
| TemperatureMaxTo | query | The exclusive upper bound of the "Maximum Temperature"<br />  Used when TemperatureMaxFilterType is 'inRange'.<br />  Data is gathered from 'TemperatureMax' to 'TemperatureMaxTo'<br />  Date text in format 'yyyy-MM-dd' eg. "2021-12-24" | No | double |
| TemperatureUnit | query | <list type="string">List of the Temperature Unit</list> | No | [ string ] |
| SupplyMinFilterType | query | One of 'equals', 'greaterThan', 'lessThan', 'notEqual', 'inRange', 'lessThanOrEqual', 'greaterThanOrEqual'.<br />  When 'inRange' then 'SupplyMinTo' is needed.<br />  Either Min/Max is used or Magnitude.<br /> | No | string |
| SupplyMin | query | The exclusive lower bound of the "Minimum Supply"<br />  Either Min/Max is used or Magnitude. | No | double |
| SupplyMinTo | query | The exclusive upper bound of the "Minimum Supply"<br />  Used when SupplyMinFilterType is 'inRange'.<br />  Data is gathered from 'SupplyMin' to 'SupplyMinTo'<br />  Date text in format 'yyyy-MM-dd' eg. "2021-12-24"<br />  Either Min/Max is used or Magnitude. | No | double |
| SupplyMaxFilterType | query | One of 'equals', 'greaterThan', 'lessThan', 'notEqual', 'inRange', 'lessThanOrEqual', 'greaterThanOrEqual'.<br />  When 'inRange' then 'SupplyMaxTo' is needed.<br />  Either Min/Max is used or Magnitude. | No | string |
| SupplyMax | query | The exclusive lower bound of the "Maximum Supply"<br />  Either Min/Max is used or Magnitude. | No | double |
| SupplyMaxTo | query | The exclusive upper bound of the "Maximum Supply"<br />  Used when SupplyMaxFilterType is 'inRange'.<br />  Data is gathered from 'SupplyMax' to 'SupplyMaxTo'<br />  Date text in format 'yyyy-MM-dd' eg. "2021-12-24"<br />  Either Min/Max is used or Magnitude. | No | double |
| SupplyMagnitudeFilterType | query | One of 'equals', 'greaterThan', 'lessThan', 'notEqual', 'inRange', 'lessThanOrEqual', 'greaterThanOrEqual'.<br />  When 'inRange' then 'SupplyMagnitudeTo' is needed.<br />  Either Min/Max is used or Magnitude. | No | string |
| SupplyMagnitude | query | The exclusive lower bound of the "Supply Magnitude"<br />  Either Min/Max is used or Magnitude. | No | double |
| SupplyMagnitudeTo | query | The exclusive upper bound of the "Supply Magnitude"<br />  Used when SupplyMagnitudeFilterType is 'inRange'.<br />  Data is gathered from 'SupplyMagnitude' to 'SupplyMagnitudeTo'<br />  Either Min/Max is used or Magnitude. | No | double |
| SupplyUnit | query | <list type="string">List of the Supply Unit</list> | No | [ string ] |
| CustomerReferenceNumberSearchText | query | Find all data with contains this search text | No | string |
| CustomerOrderNumberSearchText | query | Find all data with contains this search text | No | string |
| RemarksSearchText | query | Find all data with contains this search text | No | string |

##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | Success |

### /v1/CalibrationData/List

#### GET
##### Summary:

Get a list of all identifier strings of the calibration data set defined by the optional search parameters.

##### Parameters

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ---- |
| IncludedIds | query | If null: Either are 'ALL SELECTED' or some are unselected (and listed in ExcludedIds)<br />  If not null: None are selected except those that are listed here.<br />  It is not allowed to have IncludedIds AND ExcludedIds have listed values. One most be null or both most be null.<br />  The list of included ids is limited to 50. More than 50 will throw an exception.<br /> | No | [ string ] |
| ExcludedIds | query | If null: Either are 'ALL SELECTED' or only some few are selected (and listed in IncludedIds)<br />  If not null: All are selected and except those that are listed here.<br />  It is not allowed to have IncludedIds AND ExcludedIds have listed values. One most be null or both most be null.<br />  The list of excluded ids is limited to 50. More than 50 will throw an exception.<br /> | No | [ string ] |
| OrderNumbers | query | List of Order Numbers | No | [ string ] |
| OrderPositions | query | List of Order Positions | No | [ string ] |
| DateFilterType | query | One of 'equals', 'greaterThan', 'lessThan', 'notEqual', 'inRange'.<br />  When 'inRange' then 'DateTo' is needed.<br />  Example 1:<br />  "All data newer than August 1st" = https://mycalibrationapi.azurewebsites.net/v1/CalibrationData?DateFilterType=greaterThan&Date=2021-08-01<br />  Example 2:<br />  "All data from the year 2020" = https://mycalibrationapi.azurewebsites.net/v1/CalibrationData?DateFilterType=inRange&Date=2021-01-01&DateTo=2021-12-31 <br />  Example 3:<br />  "All data from the first day in January and February" = https://mycalibrationapi.azurewebsites.net/v1/CalibrationData?DateFilterType=equals&Date=2021-01-01&Date=2021-02-01 <br /> | No | string |
| Date | query | Dispatch-date text in format 'yyyy-MM-dd' eg. "2021-12-24"<br />  Normally, this is a list with one element. Nevertheless, it is possible to GET calibration data from multiple dates. In this case DateFilterType must be 'equals' and DateTo must be null. | No | [ string ] |
| DateTo | query | Used when DateFilterType is 'inRange'.<br />  Data is gathered from 'Date' to 'DateTo'<br />  Date text in format 'yyyy-MM-dd' eg. "2021-12-24" | No | string |
| CustomerProductTypes | query | To search for [Blanks] use "blank" | No | [ string ] |
| PressureTypes | query | Eg. ["pa","paa","pr"]  To see all possible enum strings, go to https://mycalibration.github.io/#filter-parameters | No | [ string ] |
| ProductSeries | query | Eg. ["10LHP","25Y","46X","K-102"] | No | [ string ] |
| ProductNumbers | query |  | No | [ string ] |
| SerialNumberSearchText | query | Use this to find all SerialNumbers that contains this text content. | No | string |
| PressureMinFilterType | query | One of 'equals', 'greaterThan', 'lessThan', 'notEqual', 'inRange', 'lessThanOrEqual', 'greaterThanOrEqual'.<br />  When 'inRange' then 'PressureMinTo' is needed. | No | string |
| PressureMin | query | The exclusive lower bound of the "Minimum Pressure" | No | double |
| PressureMinTo | query | The exclusive upper bound of the "Minimum Pressure".<br />  Used when PressureMinFilterType is 'inRange'.<br />  Data is gathered from 'PressureMin' to 'PressureMinTo'.<br />  Date text in format 'yyyy-MM-dd' eg. "2021-12-24"<br /> | No | double |
| PressureMaxFilterType | query | One of 'equals', 'greaterThan', 'lessThan', 'notEqual', 'inRange', 'lessThanOrEqual', 'greaterThanOrEqual'.<br />  When 'inRange' then 'PressureMaxTo' is needed. | No | string |
| PressureMax | query | The exclusive lower bound of the "Maximum Pressure" | No | double |
| PressureMaxTo | query | The exclusive upper bound of the "Maximum Pressure"<br />  Used when PressureMaxFilterType is 'inRange'.<br />  Data is gathered from 'PressureMax' to 'PressureMaxTo'<br />  Date text in format 'yyyy-MM-dd' eg. "2021-12-24" | No | double |
| PressureUnit | query | <list type="string">List of the Pressure Unit</list> | No | [ string ] |
| TemperatureMinFilterType | query | One of 'equals', 'greaterThan', 'lessThan', 'notEqual', 'inRange', 'lessThanOrEqual', 'greaterThanOrEqual'.<br />  When 'inRange' then 'TemperatureMinTo' is needed. | No | string |
| TemperatureMin | query | The exclusive lower bound of the "Minimum Temperature" | No | double |
| TemperatureMinTo | query | The exclusive upper bound of the "Minimum Temperature"<br />  Used when TemperatureMinFilterType is 'inRange'.<br />  Data is gathered from 'TemperatureMin' to 'TemperatureMinTo'<br />  Date text in format 'yyyy-MM-dd' eg. "2021-12-24" | No | double |
| TemperatureMaxFilterType | query | One of 'equals', 'greaterThan', 'lessThan', 'notEqual', 'inRange', 'lessThanOrEqual', 'greaterThanOrEqual'.<br />  When 'inRange' then 'TemperatureMaxTo' is needed. | No | string |
| TemperatureMax | query | The exclusive lower bound of the "Maximum Temperature" | No | double |
| TemperatureMaxTo | query | The exclusive upper bound of the "Maximum Temperature"<br />  Used when TemperatureMaxFilterType is 'inRange'.<br />  Data is gathered from 'TemperatureMax' to 'TemperatureMaxTo'<br />  Date text in format 'yyyy-MM-dd' eg. "2021-12-24" | No | double |
| TemperatureUnit | query | <list type="string">List of the Temperature Unit</list> | No | [ string ] |
| SupplyMinFilterType | query | One of 'equals', 'greaterThan', 'lessThan', 'notEqual', 'inRange', 'lessThanOrEqual', 'greaterThanOrEqual'.<br />  When 'inRange' then 'SupplyMinTo' is needed.<br />  Either Min/Max is used or Magnitude.<br /> | No | string |
| SupplyMin | query | The exclusive lower bound of the "Minimum Supply"<br />  Either Min/Max is used or Magnitude. | No | double |
| SupplyMinTo | query | The exclusive upper bound of the "Minimum Supply"<br />  Used when SupplyMinFilterType is 'inRange'.<br />  Data is gathered from 'SupplyMin' to 'SupplyMinTo'<br />  Date text in format 'yyyy-MM-dd' eg. "2021-12-24"<br />  Either Min/Max is used or Magnitude. | No | double |
| SupplyMaxFilterType | query | One of 'equals', 'greaterThan', 'lessThan', 'notEqual', 'inRange', 'lessThanOrEqual', 'greaterThanOrEqual'.<br />  When 'inRange' then 'SupplyMaxTo' is needed.<br />  Either Min/Max is used or Magnitude. | No | string |
| SupplyMax | query | The exclusive lower bound of the "Maximum Supply"<br />  Either Min/Max is used or Magnitude. | No | double |
| SupplyMaxTo | query | The exclusive upper bound of the "Maximum Supply"<br />  Used when SupplyMaxFilterType is 'inRange'.<br />  Data is gathered from 'SupplyMax' to 'SupplyMaxTo'<br />  Date text in format 'yyyy-MM-dd' eg. "2021-12-24"<br />  Either Min/Max is used or Magnitude. | No | double |
| SupplyMagnitudeFilterType | query | One of 'equals', 'greaterThan', 'lessThan', 'notEqual', 'inRange', 'lessThanOrEqual', 'greaterThanOrEqual'.<br />  When 'inRange' then 'SupplyMagnitudeTo' is needed.<br />  Either Min/Max is used or Magnitude. | No | string |
| SupplyMagnitude | query | The exclusive lower bound of the "Supply Magnitude"<br />  Either Min/Max is used or Magnitude. | No | double |
| SupplyMagnitudeTo | query | The exclusive upper bound of the "Supply Magnitude"<br />  Used when SupplyMagnitudeFilterType is 'inRange'.<br />  Data is gathered from 'SupplyMagnitude' to 'SupplyMagnitudeTo'<br />  Either Min/Max is used or Magnitude. | No | double |
| SupplyUnit | query | <list type="string">List of the Supply Unit</list> | No | [ string ] |
| CustomerReferenceNumberSearchText | query | Find all data with contains this search text | No | string |
| CustomerOrderNumberSearchText | query | Find all data with contains this search text | No | string |
| RemarksSearchText | query | Find all data with contains this search text | No | string |

##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | Success |

### /v1/CalibrationData/Export

#### GET
##### Summary:

Locates the filtered (optionalSearchParameter) data, bundles them and creates a download link

##### Parameters

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ---- |
| fileType | query | 1 = All calibration data items will be merged in one JSON list  2 = All calibration data items will be merged in one JSON list. This JSON file will be compressed to zip file  3 = Every calibration data items will stored as JSON file. All these files will be compressed to one single zip file  4 = Every calibration data items will stored as JSON file. All these files will be compressed to one single brotli file | No | [ExportFileType](#ExportFileType) |
| IncludedIds | query | If null: Either are 'ALL SELECTED' or some are unselected (and listed in ExcludedIds)<br />  If not null: None are selected except those that are listed here.<br />  It is not allowed to have IncludedIds AND ExcludedIds have listed values. One most be null or both most be null.<br />  The list of included ids is limited to 50. More than 50 will throw an exception.<br /> | No | [ string ] |
| ExcludedIds | query | If null: Either are 'ALL SELECTED' or only some few are selected (and listed in IncludedIds)<br />  If not null: All are selected and except those that are listed here.<br />  It is not allowed to have IncludedIds AND ExcludedIds have listed values. One most be null or both most be null.<br />  The list of excluded ids is limited to 50. More than 50 will throw an exception.<br /> | No | [ string ] |
| OrderNumbers | query | List of Order Numbers | No | [ string ] |
| OrderPositions | query | List of Order Positions | No | [ string ] |
| DateFilterType | query | One of 'equals', 'greaterThan', 'lessThan', 'notEqual', 'inRange'.<br />  When 'inRange' then 'DateTo' is needed.<br />  Example 1:<br />  "All data newer than August 1st" = https://mycalibrationapi.azurewebsites.net/v1/CalibrationData?DateFilterType=greaterThan&Date=2021-08-01<br />  Example 2:<br />  "All data from the year 2020" = https://mycalibrationapi.azurewebsites.net/v1/CalibrationData?DateFilterType=inRange&Date=2021-01-01&DateTo=2021-12-31 <br />  Example 3:<br />  "All data from the first day in January and February" = https://mycalibrationapi.azurewebsites.net/v1/CalibrationData?DateFilterType=equals&Date=2021-01-01&Date=2021-02-01 <br /> | No | string |
| Date | query | Dispatch-date text in format 'yyyy-MM-dd' eg. "2021-12-24"<br />  Normally, this is a list with one element. Nevertheless, it is possible to GET calibration data from multiple dates. In this case DateFilterType must be 'equals' and DateTo must be null. | No | [ string ] |
| DateTo | query | Used when DateFilterType is 'inRange'.<br />  Data is gathered from 'Date' to 'DateTo'<br />  Date text in format 'yyyy-MM-dd' eg. "2021-12-24" | No | string |
| CustomerProductTypes | query | To search for [Blanks] use "blank" | No | [ string ] |
| PressureTypes | query | Eg. ["pa","paa","pr"]  To see all possible enum strings, go to https://mycalibration.github.io/#filter-parameters | No | [ string ] |
| ProductSeries | query | Eg. ["10LHP","25Y","46X","K-102"] | No | [ string ] |
| ProductNumbers | query |  | No | [ string ] |
| SerialNumberSearchText | query | Use this to find all SerialNumbers that contains this text content. | No | string |
| PressureMinFilterType | query | One of 'equals', 'greaterThan', 'lessThan', 'notEqual', 'inRange', 'lessThanOrEqual', 'greaterThanOrEqual'.<br />  When 'inRange' then 'PressureMinTo' is needed. | No | string |
| PressureMin | query | The exclusive lower bound of the "Minimum Pressure" | No | double |
| PressureMinTo | query | The exclusive upper bound of the "Minimum Pressure".<br />  Used when PressureMinFilterType is 'inRange'.<br />  Data is gathered from 'PressureMin' to 'PressureMinTo'.<br />  Date text in format 'yyyy-MM-dd' eg. "2021-12-24"<br /> | No | double |
| PressureMaxFilterType | query | One of 'equals', 'greaterThan', 'lessThan', 'notEqual', 'inRange', 'lessThanOrEqual', 'greaterThanOrEqual'.<br />  When 'inRange' then 'PressureMaxTo' is needed. | No | string |
| PressureMax | query | The exclusive lower bound of the "Maximum Pressure" | No | double |
| PressureMaxTo | query | The exclusive upper bound of the "Maximum Pressure"<br />  Used when PressureMaxFilterType is 'inRange'.<br />  Data is gathered from 'PressureMax' to 'PressureMaxTo'<br />  Date text in format 'yyyy-MM-dd' eg. "2021-12-24" | No | double |
| PressureUnit | query | <list type="string">List of the Pressure Unit</list> | No | [ string ] |
| TemperatureMinFilterType | query | One of 'equals', 'greaterThan', 'lessThan', 'notEqual', 'inRange', 'lessThanOrEqual', 'greaterThanOrEqual'.<br />  When 'inRange' then 'TemperatureMinTo' is needed. | No | string |
| TemperatureMin | query | The exclusive lower bound of the "Minimum Temperature" | No | double |
| TemperatureMinTo | query | The exclusive upper bound of the "Minimum Temperature"<br />  Used when TemperatureMinFilterType is 'inRange'.<br />  Data is gathered from 'TemperatureMin' to 'TemperatureMinTo'<br />  Date text in format 'yyyy-MM-dd' eg. "2021-12-24" | No | double |
| TemperatureMaxFilterType | query | One of 'equals', 'greaterThan', 'lessThan', 'notEqual', 'inRange', 'lessThanOrEqual', 'greaterThanOrEqual'.<br />  When 'inRange' then 'TemperatureMaxTo' is needed. | No | string |
| TemperatureMax | query | The exclusive lower bound of the "Maximum Temperature" | No | double |
| TemperatureMaxTo | query | The exclusive upper bound of the "Maximum Temperature"<br />  Used when TemperatureMaxFilterType is 'inRange'.<br />  Data is gathered from 'TemperatureMax' to 'TemperatureMaxTo'<br />  Date text in format 'yyyy-MM-dd' eg. "2021-12-24" | No | double |
| TemperatureUnit | query | <list type="string">List of the Temperature Unit</list> | No | [ string ] |
| SupplyMinFilterType | query | One of 'equals', 'greaterThan', 'lessThan', 'notEqual', 'inRange', 'lessThanOrEqual', 'greaterThanOrEqual'.<br />  When 'inRange' then 'SupplyMinTo' is needed.<br />  Either Min/Max is used or Magnitude.<br /> | No | string |
| SupplyMin | query | The exclusive lower bound of the "Minimum Supply"<br />  Either Min/Max is used or Magnitude. | No | double |
| SupplyMinTo | query | The exclusive upper bound of the "Minimum Supply"<br />  Used when SupplyMinFilterType is 'inRange'.<br />  Data is gathered from 'SupplyMin' to 'SupplyMinTo'<br />  Date text in format 'yyyy-MM-dd' eg. "2021-12-24"<br />  Either Min/Max is used or Magnitude. | No | double |
| SupplyMaxFilterType | query | One of 'equals', 'greaterThan', 'lessThan', 'notEqual', 'inRange', 'lessThanOrEqual', 'greaterThanOrEqual'.<br />  When 'inRange' then 'SupplyMaxTo' is needed.<br />  Either Min/Max is used or Magnitude. | No | string |
| SupplyMax | query | The exclusive lower bound of the "Maximum Supply"<br />  Either Min/Max is used or Magnitude. | No | double |
| SupplyMaxTo | query | The exclusive upper bound of the "Maximum Supply"<br />  Used when SupplyMaxFilterType is 'inRange'.<br />  Data is gathered from 'SupplyMax' to 'SupplyMaxTo'<br />  Date text in format 'yyyy-MM-dd' eg. "2021-12-24"<br />  Either Min/Max is used or Magnitude. | No | double |
| SupplyMagnitudeFilterType | query | One of 'equals', 'greaterThan', 'lessThan', 'notEqual', 'inRange', 'lessThanOrEqual', 'greaterThanOrEqual'.<br />  When 'inRange' then 'SupplyMagnitudeTo' is needed.<br />  Either Min/Max is used or Magnitude. | No | string |
| SupplyMagnitude | query | The exclusive lower bound of the "Supply Magnitude"<br />  Either Min/Max is used or Magnitude. | No | double |
| SupplyMagnitudeTo | query | The exclusive upper bound of the "Supply Magnitude"<br />  Used when SupplyMagnitudeFilterType is 'inRange'.<br />  Data is gathered from 'SupplyMagnitude' to 'SupplyMagnitudeTo'<br />  Either Min/Max is used or Magnitude. | No | double |
| SupplyUnit | query | <list type="string">List of the Supply Unit</list> | No | [ string ] |
| CustomerReferenceNumberSearchText | query | Find all data with contains this search text | No | string |
| CustomerOrderNumberSearchText | query | Find all data with contains this search text | No | string |
| RemarksSearchText | query | Find all data with contains this search text | No | string |

##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | Success |

### /v1/CalibrationData/Sync

#### GET
##### Summary:

Only used for maintenance reasons. Do not use!

##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | Success |
