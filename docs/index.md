![KELLER myCalibration Logo](./media/KELLER_Logo_myCalibration.png?raw=true "logo")

Table of Contents
=================

 * [1) Overview](#1-overview)
 * [2) Web App](#2-web-app)
 * [3) Web API](#3-web-api)
 * [4) The JSON Schema](#4-the-json-schema)
 * [5) Sample Software](#5-sample-software)
 * [6) FAQ](#6-faq)

---

## 1) Overview
'KELLER myCalibration' is a service for KELLER customers. Via KELLER myCalibration, customers can access digital calibration data of their KELLER sensors.

### Data
![Web App UI](./media/json-example.jpg)

#### Contents
myCalibration is designed with data from various KELLER transducers and transmitters in mind. As an example, it can be used to hold information of Mathematical Compensation Models as well as X-line transmitter calibration data.

#### Format
Calibration data is available in JSON file format. Thanks to its widespread use and a broad availability of programming libraries, this format allows for an easy and quick integration in customer software. What is more, as a quick check, JSON data can be inspected in any text editor.

#### Structure
The structure of the JSON file is defined in a JSON schema. This schema is made publicly available, allowing a full integration in customer software.

### Access
#### Web App
A user interface that is accessible over any standard web browser gives customers access to calibration data of their sensors. Customer data is only accessible after an individual login and cannot be seen by others.
After using various search and filter functionalities, the user can download calibration data of individually selected sensors or perform a bulk download of multiple datasets.

#### Web API
A REST API is available for automated access. Customers can integrate this API into their processes. This allows them e.g. to automatically download the calibration data of newly received sensors and integrate this into their production processes.

---

## 2) Web App

The web app is here: [https://sensweb.azurewebsites.net/](https://sensweb.azurewebsites.net)

![Web App UI](./media/web-app-example.png?raw=true)

There is a free demo user account with the username '*Demo1234*' and the password '*Demo1234*'.

### Sign Up & Sign In
Signing up a user account can be done with the help of engineering@keller-druck.com
There is already a free demo account '**Demo1234**' with the password '**Demo1234**' to see some demo data.  

![login example](./media/login-demo1234.png?raw=true)


---

## 3) Web API
The Web API's URL is https://senswebapi.azurewebsites.net/

The OpenAPI specification page is: [https://senswebapi.azurewebsites.net/swagger/index.html](https://senswebapi.azurewebsites.net/swagger/index.html)

All the calibration data can be exported as
- JSON meta-information (header only) 
- zip file with the filtered and compressed JSON files (header+data)
- brotli file with the filtered and compressed JSON files (header+data)

swagger json: https://senswebapi.azurewebsites.net/swagger/v1/swagger.json

### API endpoints


#### GET /v1/Me
Responds with an overview about the logged-in user and the data the user has access to.
#### GET /v1/CalibrationData/Headers
Responds with the meta-information about the calibration data. See [Header data](#generalizedcalibrationdataheader). See [filter parameters](#filter-parameters).
#### GET /v1/CalibrationData
Responds with the filtered calibration data in JSON form. See [filter parameters](#filter-parameters). See [filter parameters](#filter-parameters).

#### GET /v1/CalibrationData/Export
Exports the filtered calibration data as ZIP or BROTLI file with the calibration files (JSON)

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ---- |
| fileType | query |  | No | integer |

##### ExportFileType

| Name | Type | Description | Required |
| ---- | ---- | ----------- | -------- |
| ExportFileType | integer |  |  |

#### POST /v1/CalibrationData/
##### Parameters

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ---- |
| fileType | query |  | No | integer |


### GeneralizedCalibrationDataHeader

| Name | Type | Description | Required |
| ---- | ---- | ----------- | -------- |
| CompensatedPressureRange | object | - Range of physical quantities consisting of a minimum and maximum magnitude and a unit of  measurement<br /> - Pressure range of the mathematical compensation model<br /> - Pressure range over which the sensors characteristics have been compensated | No |
| CompensatedTemperatureRange | object | - Range of physical quantities consisting of a minimum and maximum magnitude and a unit of measurement<br /> - Temperature range of the mathematical compensation model<br /> - Temperature range over which the sensors characteristics have been compensated | No |
| CreationDate | string | File creation date | No |
| CustomerName | string | Customer name | No |
| CustomerNumber | integer | KELLER customer identification number | No |
| CustomerOrderNumber | string | Customer internal purchase order number | No |
| CustomerProductType | string | Customer internal product type | No |
| CustomerReferenceNumber | string | Customer internal reference number | No |
| ElectricSupply | object | Unit of measurement | No |
| OrderNumber | integer | KELLER purchase order number | No |
| OrderPosition | integer | KELLER purchase order position | No |
| OrderTargetDispatchDate | string | Targeted dispatch date of the order | No |
| PressureType | string | KELLER product pressure mode | No |
| ProductNumber | string |  | No |
| ProductSeries | string | KELLER product series | No |
| ProductType | string | KELLER product type | No |
| Remarks | string |  | No |
| SerialNumber | string | KELLER product serial number | No |

### Filter parameters

| Name | Located in | Description | Required | Schema  |
| ---- | ---------- | ----------- | -------- | ------- |
| fileType | query  |             | No       | integer |
| IncludedIds | query | If null: Either are 'ALL SELECTED' or some are unselected (and listed in ExcludedIds)<br />  If not null: None are selected except those that are listed here.<br />  It is not allowed to have IncludedIds AND ExcludedIds have listed values. One most be null or both most be null.<br />  The list of included ids is limited to 50. More than 50 will throw an exception.<br /> | No | [ string ] |
| ExcludedIds | query | If null: Either are 'ALL SELECTED' or only some few are selected (and listed in IncludedIds)<br />  If not null: All are selected and except those that are listed here.<br />  It is not allowed to have IncludedIds AND ExcludedIds have listed values. One most be null or both most be null.<br />  The list of excluded ids is limited to 50. More than 50 will throw an exception.<br /> | No | [ string ] |
| OrderNumbers | query | List of Order Numbers | No | [ string ] |
| OrderPositions | query | List of Order Positions | No | [ string ] |
| DateFilterType | query | One of 'equals', 'greaterThan', 'lessThan', 'notEqual', 'inRange'.<br />  When 'inRange' then 'DateTo' is needed.<br />  Example 1:<br />  "All data newer than August 1st" = <https://senswebapi.azurewebsites.net/v1/CalibrationData?DateFilterType=greaterThan&Date=2021-08-01><br />  Example 2:<br />  "All data from the year 2020" = <https://senswebapi.azurewebsites.net/v1/CalibrationData?DateFilterType=inRange&Date=2021-01-01&DateTo=2021-12-31> <br />  Example 3:<br />  "All data from the first day in January and February" = <https://senswebapi.azurewebsites.net/v1/CalibrationData?DateFilterType=equals&Date=2021-01-01&Date=2021-02-01> <br /> | No | string |
| Date | query | Dispatch-date text in format 'yyyy-MM-dd' eg. "2021-12-24"<br />  Normally, this is a list with one element. Nevertheless, it is possible to GET calibration data from multiple dates. In this case DateFilterType must be 'equals' and DateTo must be null. | No | [ string ] |
| DateTo | query | Used when DateFilterType is 'inRange'.<br />  Data is gathered from 'Date' to 'DateTo'<br />  Date text in format 'yyyy-MM-dd' eg. "2021-12-24" | No | string |
| CustomerProductTypes | query | To search for [Blanks] use "blank" | No | [ string ] |
| PressureTypes | query | Eg. ["PA","PAA","PR"] | No | [ string ] |
| ProductSeries | query | Eg. ["10LHP","25Y","46X","K-102"] | No | [ string ] |
| ProductNumbers | query |  | No | [ string ] |
| SerialNumberSearchText | query | Use this to find all SerialNumbers that contains this text content. | No | string |
| PressureMinFilterType | query | One of 'equals', 'greaterThan', 'lessThan', 'notEqual', 'inRange', 'lessThanOrEqual', 'greaterThanOrEqual'.<br />  When 'inRange' then 'PressureMinTo' is needed. | No | string |
| PressureMin | query | The exclusive lower bound of the "Minimum Pressure" | No | double |
| PressureMinTo | query | The exclusive upper bound of the "Minimum Pressure".<br />  Used when PressureMinFilterType is 'inRange'.<br />  Data is gathered from 'PressureMin' to 'PressureMinTo'.<br />  Date text in format 'yyyy-MM-dd' eg. "2021-12-24"<br /> | No | double |
| PressureMaxFilterType | query | One of 'equals', 'greaterThan', 'lessThan', 'notEqual', 'inRange', 'lessThanOrEqual', 'greaterThanOrEqual'.<br />  When 'inRange' then 'PressureMaxTo' is needed. | No | string |
| PressureMax | query | /// TODO: greaterOrEqualThan???<br />  The exclusive lower bound of the "Maximum Pressure" | No | double |
| PressureMaxTo | query | TODO: greaterOrEqualThan???  The exclusive upper bound of the "Maximum Pressure"<br />  Used when PressureMaxFilterType is 'inRange'.<br />  Data is gathered from 'PressureMax' to 'PressureMaxTo'<br />  Date text in format 'yyyy-MM-dd' eg. "2021-12-24" | No | double |
| PressureUnit | query | <list type="string">List of the Pressure Unit</list> | No | [ string ] |
| TemperatureMinFilterType | query | One of 'equals', 'greaterThan', 'lessThan', 'notEqual', 'inRange', 'lessThanOrEqual', 'greaterThanOrEqual'.<br />  When 'inRange' then 'TemperatureMinTo' is needed. | No | string |
| TemperatureMin | query | /// TODO: greaterOrEqualThan???<br />  The exclusive lower bound of the "Minimum Temperature" | No | double |
| TemperatureMinTo | query | TODO: greaterOrEqualThan???<br />  The exclusive upper bound of the "Minimum Temperature"<br />  Used when TemperatureMinFilterType is 'inRange'.<br />  Data is gathered from 'TemperatureMin' to 'TemperatureMinTo'<br />  Date text in format 'yyyy-MM-dd' eg. "2021-12-24" | No | double |
| TemperatureMaxFilterType | query | One of 'equals', 'greaterThan', 'lessThan', 'notEqual', 'inRange', 'lessThanOrEqual', 'greaterThanOrEqual'.<br />  When 'inRange' then 'TemperatureMaxTo' is needed. | No | string |
| TemperatureMax | query | /// TODO: greaterOrEqualThan???<br />  The exclusive lower bound of the "Maximum Temperature" | No | double |
| TemperatureMaxTo | query | TODO: greaterOrEqualThan???  The exclusive upper bound of the "Maximum Temperature"<br />  Used when TemperatureMaxFilterType is 'inRange'.<br />  Data is gathered from 'TemperatureMax' to 'TemperatureMaxTo'<br />  Date text in format 'yyyy-MM-dd' eg. "2021-12-24" | No | double |
| TemperatureUnit | query | <list type="string">List of the Temperature Unit</list> | No | [ string ] |
| SupplyMinFilterType | query | One of 'equals', 'greaterThan', 'lessThan', 'notEqual', 'inRange', 'lessThanOrEqual', 'greaterThanOrEqual'.<br />  When 'inRange' then 'SupplyMinTo' is needed.<br />  Either Min/Max is used or Magnitude.<br /> | No | string |
| SupplyMin | query | TODO: greaterOrEqualThan???<br />  The exclusive lower bound of the "Minimum Supply"<br />  Either Min/Max is used or Magnitude. | No | double |
| SupplyMinTo | query | TODO: greaterOrEqualThan???<br />  The exclusive upper bound of the "Minimum Supply"<br />  Used when SupplyMinFilterType is 'inRange'.<br />  Data is gathered from 'SupplyMin' to 'SupplyMinTo'<br />  Date text in format 'yyyy-MM-dd' eg. "2021-12-24"<br />  Either Min/Max is used or Magnitude. | No | double |
| SupplyMaxFilterType | query | One of 'equals', 'greaterThan', 'lessThan', 'notEqual', 'inRange', 'lessThanOrEqual', 'greaterThanOrEqual'.<br />  When 'inRange' then 'SupplyMaxTo' is needed.<br />  Either Min/Max is used or Magnitude. | No | string |
| SupplyMax | query | /// TODO: greaterOrEqualThan???<br />  The exclusive lower bound of the "Maximum Supply"<br />  Either Min/Max is used or Magnitude. | No | double |
| SupplyMaxTo | query | TODO: greaterOrEqualThan???<br />  The exclusive upper bound of the "Maximum Supply"<br />  Used when SupplyMaxFilterType is 'inRange'.<br />  Data is gathered from 'SupplyMax' to 'SupplyMaxTo'<br />  Date text in format 'yyyy-MM-dd' eg. "2021-12-24"<br />  Either Min/Max is used or Magnitude. | No | double |
| SupplyMagnitudeFilterType | query | One of 'equals', 'greaterThan', 'lessThan', 'notEqual', 'inRange', 'lessThanOrEqual', 'greaterThanOrEqual'.<br />  When 'inRange' then 'SupplyMagnitudeTo' is needed.<br />  Either Min/Max is used or Magnitude. | No | string |
| SupplyMagnitude | query | /// TODO: greaterOrEqualThan???<br />  The exclusive lower bound of the "Supply Magnitude"<br />  Either Min/Max is used or Magnitude. | No | double |
| SupplyMagnitudeTo | query | TODO: greaterOrEqualThan???<br />  The exclusive upper bound of the "Supply Magnitude"<br />  Used when SupplyMagnitudeFilterType is 'inRange'.<br />  Data is gathered from 'SupplyMagnitude' to 'SupplyMagnitudeTo'<br />  Either Min/Max is used or Magnitude. | No | double |
| SupplyUnit | query | <list type="string">List of the Supply Unit</list> | No | [ string ] |
| CustomerReferenceNumberSearchText | query | Find all data with contains this search text | No | string |
| CustomerOrderNumberSearchText | query | Find all data with contains this search text | No | string |
| RemarksSearchText | query | Find all data with contains this search text | No | string |



### Example queries

TODO

### Generate client SW using the OpenAPI/swagger schema. 
https://editor.swagger.io/

---


## 4) The JSON Schema

The schema can be downloaded as JSON Schema [here](https://github.com/mycalibration/mycalibration.github.io/blob/main/schema/keller-sensor-data.schema.json).

| Root objects |  Explanation | 
| ------------ | ------------ | 
| Version |  Version string for the schema with semantic versioning (MAJOR.MINOR.PATCH)  E.g. "1.0.0" | 
| Header |  Meta-information data to identify the sensor data | 
| CompensationMethods | MathMod data | 
| Measurements | Measurements point of the T/P-calibration-curve | 


![login example](./media/keller-sensor-data.png?raw=true)


<style type="text/css">
.tg  {border-collapse:collapse;border-spacing:0;}
.tg td{border-color:black;border-style:solid;border-width:1px;font-family:Arial, sans-serif;font-size:14px;
  overflow:hidden;padding:10px 5px;word-break:normal;}
.tg th{border-color:black;border-style:solid;border-width:1px;font-family:Arial, sans-serif;font-size:14px;
  font-weight:normal;overflow:hidden;padding:10px 5px;word-break:normal;}
.tg .tg-0lax{text-align:left;vertical-align:top}
</style>
<table class="tg">
<thead>
  <tr>
    <th class="tg-0lax">Root object</th>
    <th class="tg-0lax">Object</th>
    <th class="tg-0lax">Schema Description</th>
    <th class="tg-0lax">Explanation</th>
    <th class="tg-0lax">Type</th>
    <th class="tg-0lax">Example</th>
  </tr>
</thead>
<tbody>
  <tr>
    <td class="tg-0lax">version *</td>
    <td class="tg-0lax"> </td>
    <td class="tg-0lax">Version&nbsp;of the corresponding JSON Schema</td>
    <td class="tg-0lax">Version&nbsp;for the schema with semantic versioning (MAJOR.MINOR.PATCH)</td>
    <td class="tg-0lax">string</td>
    <td class="tg-0lax">"1.0.0"</td>
  </tr>
  <tr>
    <td class="tg-0lax" rowspan="23">header&nbsp;*</td>
    <td class="tg-0lax"> </td>
    <td class="tg-0lax">Header data</td>
    <td class="tg-0lax">Meta-information&nbsp;to identify and catalogize the calibration data stored in measurements</td>
    <td class="tg-0lax"> </td>
    <td class="tg-0lax"> </td>
  </tr>
  <tr>
    <td class="tg-0lax">creationDate</td>
    <td class="tg-0lax">File creation date</td>
    <td class="tg-0lax"> </td>
    <td class="tg-0lax">string</td>
    <td class="tg-0lax">"2022-03-22"</td>
  </tr>
  <tr>
    <td class="tg-0lax">orderTargetDispatchDate&nbsp;*</td>
    <td class="tg-0lax">Targeted&nbsp;dispatch date of the order</td>
    <td class="tg-0lax"> </td>
    <td class="tg-0lax">string</td>
    <td class="tg-0lax">"2022-03-15"</td>
  </tr>
  <tr>
    <td class="tg-0lax">orderNumber&nbsp;*</td>
    <td class="tg-0lax">KELLER purchase order&nbsp;number</td>
    <td class="tg-0lax"> </td>
    <td class="tg-0lax">int</td>
    <td class="tg-0lax">9990016</td>
  </tr>
  <tr>
    <td class="tg-0lax">orderPosition&nbsp;*</td>
    <td class="tg-0lax">KELLER purchase order&nbsp;position</td>
    <td class="tg-0lax"> </td>
    <td class="tg-0lax">int</td>
    <td class="tg-0lax">3</td>
  </tr>
  <tr>
    <td class="tg-0lax">customerProductType&nbsp;*</td>
    <td class="tg-0lax">Customer internal product&nbsp;type</td>
    <td class="tg-0lax"> </td>
    <td class="tg-0lax">string</td>
    <td class="tg-0lax">"9990016-123"</td>
  </tr>
  <tr>
    <td class="tg-0lax">pressureType&nbsp;*</td>
    <td class="tg-0lax">Pressure type</td>
    <td class="tg-0lax"> </td>
    <td class="tg-0lax">string</td>
    <td class="tg-0lax">"PAA"</td>
  </tr>
  <tr>
    <td class="tg-0lax">productSeries&nbsp;*</td>
    <td class="tg-0lax">KELLER product series</td>
    <td class="tg-0lax"> </td>
    <td class="tg-0lax">string</td>
    <td class="tg-0lax">"33X"</td>
  </tr>
  <tr>
    <td class="tg-0lax">productType&nbsp;*</td>
    <td class="tg-0lax">KELLER product type</td>
    <td class="tg-0lax"> </td>
    <td class="tg-0lax">string</td>
    <td class="tg-0lax">"PAA-33X"</td>
  </tr>
  <tr>
    <td class="tg-0lax">productNumber&nbsp;*</td>
    <td class="tg-0lax">KELLER product number</td>
    <td class="tg-0lax"> </td>
    <td class="tg-0lax">string</td>
    <td class="tg-0lax">"1234567.0001"</td>
  </tr>
  <tr>
    <td class="tg-0lax">serialNumber&nbsp;*</td>
    <td class="tg-0lax">KELLER product serial&nbsp;number</td>
    <td class="tg-0lax"> </td>
    <td class="tg-0lax">string</td>
    <td class="tg-0lax">"I123456"</td>
  </tr>
  <tr>
    <td class="tg-0lax">compensatedPressureRange&nbsp;*</td>
    <td class="tg-0lax">Pressure&nbsp;range over which the sensors characteristics have been compensated</td>
    <td class="tg-0lax"> </td>
    <td class="tg-0lax">object</td>
    <td class="tg-0lax">{"max":&nbsp;1.0,"min": 0.0,"unit": "bar"}</td>
  </tr>
  <tr>
    <td class="tg-0lax">compensatedTemperatureRange&nbsp;*</td>
    <td class="tg-0lax">Temperature&nbsp;range over which the sensors characteristics have been compensated</td>
    <td class="tg-0lax"> </td>
    <td class="tg-0lax">object</td>
    <td class="tg-0lax">{"max":&nbsp;70.0,  "min": 15.0, "unit": "°C"}</td>
  </tr>
  <tr>
    <td class="tg-0lax" rowspan="5">electricSupply&nbsp;*</td>
    <td class="tg-0lax" rowspan="5">Nominal electric supply</td>
    <td class="tg-0lax" rowspan="5"> <br><br><br><br></td>
    <td class="tg-0lax" rowspan="5">object</td>
    <td class="tg-0lax" rowspan="5">{"unit":&nbsp;"V","max": 24.0,"min": 4.5} or&nbsp;{"unit": "mA","magnitude": 1.0}</td>
  </tr>
  <tr>
  </tr>
  <tr>
  </tr>
  <tr>
  </tr>
  <tr>
  </tr>
  <tr>
    <td class="tg-0lax">customerReferenceNumber&nbsp;*</td>
    <td class="tg-0lax">Customer internal reference&nbsp;number</td>
    <td class="tg-0lax"> </td>
    <td class="tg-0lax">string</td>
    <td class="tg-0lax">"Jane&nbsp;Doe"</td>
  </tr>
  <tr>
    <td class="tg-0lax">remarks&nbsp;*</td>
    <td class="tg-0lax"> </td>
    <td class="tg-0lax"> </td>
    <td class="tg-0lax">string</td>
    <td class="tg-0lax">""</td>
  </tr>
  <tr>
    <td class="tg-0lax">customerName&nbsp;*</td>
    <td class="tg-0lax">Customer name</td>
    <td class="tg-0lax"> </td>
    <td class="tg-0lax">string</td>
    <td class="tg-0lax">"DemoData Inc."</td>
  </tr>
  <tr>
    <td class="tg-0lax">customerNumber&nbsp;*</td>
    <td class="tg-0lax">KELLER customer&nbsp;identification number</td>
    <td class="tg-0lax"> </td>
    <td class="tg-0lax">string</td>
    <td class="tg-0lax">"9990016 Rev. 2"</td>
  </tr>
  <tr>
    <td class="tg-0lax">customerOrderNumber&nbsp;*</td>
    <td class="tg-0lax">Customer&nbsp;internal purchase order number</td>
    <td class="tg-0lax"> </td>
    <td class="tg-0lax"> </td>
    <td class="tg-0lax">"123456700012"</td>
  </tr>
  <tr>
    <td class="tg-0lax" rowspan="27">measurements[] *</td>
    <td class="tg-0lax"> </td>
    <td class="tg-0lax">Array&nbsp;of individual measurements. Item order corresponds to order in measurement&nbsp;sequence.</td>
    <td class="tg-0lax"> </td>
    <td class="tg-0lax">Array of Measurement</td>
    <td class="tg-0lax"> </td>
  </tr>
  <tr>
    <td class="tg-0lax">reference *</td>
    <td class="tg-0lax">KELLER&nbsp;reference to original measurement data</td>
    <td class="tg-0lax"> </td>
    <td class="tg-0lax">string</td>
    <td class="tg-0lax">"TSX_ABCD567P89"</td>
  </tr>
  <tr>
    <td class="tg-0lax">environment&nbsp;*</td>
    <td class="tg-0lax">Real&nbsp;conditions of the measurement point environment</td>
    <td class="tg-0lax"> </td>
    <td class="tg-0lax">object</td>
    <td class="tg-0lax">{<br>&nbsp;&nbsp;&nbsp;    "pressure": {<br>&nbsp;&nbsp;&nbsp;        "magnitude": 0.1000031,<br>&nbsp;&nbsp;&nbsp;        "unit": "bar"<br>&nbsp;&nbsp;&nbsp;    },<br>&nbsp;&nbsp;&nbsp;    "temperature": {<br>&nbsp;&nbsp;&nbsp;        "magnitude": 14.6304,<br>&nbsp;&nbsp;&nbsp;        "unit": "°C"<br>&nbsp;&nbsp;&nbsp;    },<br>&nbsp;&nbsp;&nbsp;    "barometer": {<br>&nbsp;&nbsp;&nbsp;        "magnitude": 0.970963,<br>&nbsp;&nbsp;&nbsp;        "unit": "bar"<br>&nbsp;&nbsp;&nbsp;    }<br>&nbsp;&nbsp;&nbsp;}</td>
  </tr>
  <tr>
    <td class="tg-0lax">environmentTarget</td>
    <td class="tg-0lax">Target&nbsp;conditions of the measurement point environment</td>
    <td class="tg-0lax"> </td>
    <td class="tg-0lax">object</td>
    <td class="tg-0lax">{<br>&nbsp;&nbsp;&nbsp;    "pressure": {<br>&nbsp;&nbsp;&nbsp;        "magnitude": 0.1,<br>&nbsp;&nbsp;&nbsp;        "unit": "bar"<br>&nbsp;&nbsp;&nbsp;    },<br>&nbsp;&nbsp;&nbsp;    "temperature": {<br>&nbsp;&nbsp;&nbsp;        "magnitude": 15,<br>&nbsp;&nbsp;&nbsp;        "unit": "°C"<br>&nbsp;&nbsp;&nbsp;    }<br>&nbsp;&nbsp;&nbsp;}</td>
  </tr>
  <tr>
    <td class="tg-0lax">raw</td>
    <td class="tg-0lax">Raw measurement values</td>
    <td class="tg-0lax"> </td>
    <td class="tg-0lax">object</td>
    <td class="tg-0lax">{<br>&nbsp;&nbsp;&nbsp;    "bridgeResistance": {<br>&nbsp;&nbsp;&nbsp;       &nbsp;"magnitude": 3391.10116554,<br>&nbsp;&nbsp;&nbsp;       &nbsp;"unit": "Ohm"<br>&nbsp;&nbsp;&nbsp;    },<br>&nbsp;&nbsp;&nbsp;    "signal": {<br>&nbsp;&nbsp;&nbsp;       &nbsp;"magnitude": 24.238461872,<br>&nbsp;&nbsp;&nbsp;        "unit":&nbsp;"mV"<br>&nbsp;&nbsp;&nbsp;    }<br>&nbsp;&nbsp;&nbsp;}</td>
  </tr>
  <tr>
    <td class="tg-0lax" rowspan="22">compensated</td>
    <td class="tg-0lax" rowspan="22">Compensated&nbsp;measurement data by different compensation methods</td>
    <td class="tg-0lax" rowspan="22"> <br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br></td>
    <td class="tg-0lax" rowspan="22">object</td>
    <td class="tg-0lax" rowspan="22">{<br>&nbsp;&nbsp;&nbsp;    "compensationCircuitOutputs": {<br>&nbsp;&nbsp;&nbsp;        "P1": {<br>&nbsp;&nbsp;&nbsp;            "measuredValue":&nbsp;{<br>&nbsp;&nbsp;&nbsp;               &nbsp;"magnitude": 0.03000106,<br>&nbsp;&nbsp;&nbsp;                "unit":&nbsp;"bar"<br>&nbsp;&nbsp;&nbsp;            },<br>&nbsp;&nbsp;&nbsp;            "nominalValue":&nbsp;"magnitude": 0.02999711,<br>&nbsp;&nbsp;&nbsp;            "unit":&nbsp;"bar"<br>&nbsp;&nbsp;&nbsp;        }<br>&nbsp;&nbsp;&nbsp;    },<br>&nbsp;&nbsp;&nbsp;    "TOB1": {<br>&nbsp;&nbsp;&nbsp;        "measuredValue": {<br>&nbsp;&nbsp;&nbsp;            "magnitude":&nbsp;14.59302,<br>&nbsp;&nbsp;&nbsp;            "unit":&nbsp;"°C"<br>&nbsp;&nbsp;&nbsp;        },<br>&nbsp;&nbsp;&nbsp;        "nominalValue": {<br>&nbsp;&nbsp;&nbsp;            "magnitude":&nbsp;14.6313,<br>&nbsp;&nbsp;&nbsp;            "unit":&nbsp;"°C"<br>&nbsp;&nbsp;&nbsp;        }<br>&nbsp;&nbsp;&nbsp;    }<br>&nbsp;&nbsp;&nbsp;}</td>
  </tr>
  <tr>
  </tr>
  <tr>
  </tr>
  <tr>
  </tr>
  <tr>
  </tr>
  <tr>
  </tr>
  <tr>
  </tr>
  <tr>
  </tr>
  <tr>
  </tr>
  <tr>
  </tr>
  <tr>
  </tr>
  <tr>
  </tr>
  <tr>
  </tr>
  <tr>
  </tr>
  <tr>
  </tr>
  <tr>
  </tr>
  <tr>
  </tr>
  <tr>
  </tr>
  <tr>
  </tr>
  <tr>
  </tr>
  <tr>
  </tr>
  <tr>
  </tr>
  <tr>
    <td class="tg-0lax" rowspan="3">compensationMethods</td>
    <td class="tg-0lax"> </td>
    <td class="tg-0lax">Information on different&nbsp;compensation methods</td>
    <td class="tg-0lax"> </td>
    <td class="tg-0lax"> </td>
    <td class="tg-0lax"> </td>
  </tr>
  <tr>
    <td class="tg-0lax">mathematicalModel</td>
    <td class="tg-0lax">A mathematical compensation&nbsp;model</td>
    <td class="tg-0lax"> </td>
    <td class="tg-0lax">object</td>
    <td class="tg-0lax">{<br>&nbsp;&nbsp;&nbsp;    "MM0324": {<br>&nbsp;&nbsp;&nbsp;        "compensatedPressureRange": {<br>&nbsp;&nbsp;&nbsp;            "max": 0.35,<br>&nbsp;&nbsp;&nbsp;            "min": 0.03,<br>&nbsp;&nbsp;&nbsp;            "unit":&nbsp;"bar"<br>&nbsp;&nbsp;&nbsp;        },<br>&nbsp;&nbsp;&nbsp;        "compensatedTemperatureRange":&nbsp;{<br>&nbsp;&nbsp;&nbsp;            "max": 80.0,<br>&nbsp;&nbsp;&nbsp;            "min": -10.0,<br>&nbsp;&nbsp;&nbsp;            "unit":&nbsp;"°C"<br>&nbsp;&nbsp;&nbsp;        },<br>&nbsp;&nbsp;&nbsp;        "electricSupply": {<br>&nbsp;&nbsp;&nbsp;            "magnitude": 1.0,<br>&nbsp;&nbsp;&nbsp;            "unit":&nbsp;"mA"<br>&nbsp;&nbsp;&nbsp;        },<br>&nbsp;&nbsp;&nbsp;        "modelType":&nbsp;"MM0324",<br>&nbsp;&nbsp;&nbsp;        "parts": {<br>&nbsp;&nbsp;&nbsp;            "pressure": {<br>&nbsp;&nbsp;&nbsp;           &nbsp;    "coefficients": [[1.8578428692012365,&nbsp;-0.0017637338444390805, 6.089070597524738E-07, -9.469256273591509E-11,&nbsp;5.4899128873639585E-15],<br>&nbsp;&nbsp;&nbsp; [-0.0972735455799812, 0.00010464739112826799,&nbsp;-3.9404534306891384E-08, 6.5906859977677644E-12, -4.1433054700020206E-16],&nbsp;... etc. ]<br>&nbsp;&nbsp;&nbsp;               &nbsp;"description": "P  = f(Sig,R)",<br>&nbsp;&nbsp;&nbsp;                "inputs":&nbsp;["Sig", "Rb"],<br>&nbsp;&nbsp;&nbsp;                "output":&nbsp;"P"<br>&nbsp;&nbsp;&nbsp;            },<br>&nbsp;&nbsp;&nbsp;            "temperature": {<br>&nbsp;&nbsp;&nbsp;           &nbsp;    "coefficients": [[-7875.716974895135,&nbsp;4.720765539450497, -0.036522641391128374], [7.760050026358172, ...etc.&nbsp;],],<br>&nbsp;&nbsp;&nbsp;               &nbsp;"description": "T  = f(R,Sig)",<br>&nbsp;&nbsp;&nbsp;                "inputs":&nbsp;["Rb", "Sig"],<br>&nbsp;&nbsp;&nbsp;                "output":&nbsp;"T"<br>&nbsp;&nbsp;&nbsp;            }<br>&nbsp;&nbsp;&nbsp;        }<br>&nbsp;&nbsp;&nbsp;    }<br>&nbsp;&nbsp;&nbsp;}</td>
  </tr>
  <tr>
    <td class="tg-0lax">compensationCircuit</td>
    <td class="tg-0lax">Compensation circuit</td>
    <td class="tg-0lax"> </td>
    <td class="tg-0lax">object</td>
    <td class="tg-0lax">&nbsp;&nbsp;&nbsp;{<br>&nbsp;&nbsp;&nbsp;    "outputs": {<br>&nbsp;&nbsp;&nbsp;        "P1": {<br>&nbsp;&nbsp;&nbsp;            "description":&nbsp;"proident in enim"<br>&nbsp;&nbsp;&nbsp;        },<br>&nbsp;&nbsp;&nbsp;        "TOB1": {<br>&nbsp;&nbsp;&nbsp;            "description":&nbsp;"dolor sit consequat elit"<br>&nbsp;&nbsp;&nbsp;        }<br>&nbsp;&nbsp;&nbsp;    },<br>&nbsp;&nbsp;&nbsp;    "description": "amet aliquip laborum&nbsp;consequat"<br>&nbsp;&nbsp;&nbsp;}</td>
  </tr>
</tbody>
</table>

---

## 5) Sample Software
todo

Github repo:

- /docs - This documentation
- /schema
  - keller-sensor-data.schema.json - The schema describing the JSON data
- /samples
  - /data-model/ExchangeDataContext.cs - Example of a C# data model that can handle JSON files using the schema.
  - /api/
    - /csharp/ - C# sample SW to get data from the myCalibration API
    - /python/ - Python sample SW to get data from the myCalibration API


---

## 6) FAQ

 - *Can I try out the myCalibration service?*  
 ...

 - *How can I automatically download the data and store it into my database / SCADA / file system?*  
 ...

 - *What is the easiest way to develop a software to download the data?*  
 ...

 - *I have the JSON file. How to I parse these file to extract the information I need?*  
 ...

 - *Where do I get a permanent access token from to access the API?*   
...
---
