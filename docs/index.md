![KELLER myCalibration Logo](./media/KELLER_Logo_myCalibration.png?raw=true "logo")

Table of Contents
=================

 * [1) Overview](#1-overview)
 * [2) Web App](#2-web-app)
 * [3) Web API](#3-web-api)
 * [4) The JSON Schema](#4-the-json-schema)
 * [5) Sample Software](#5-sample-software)

---

## 1) Overview
'KELLER myCalibration' is a service for KELLER customers. Via KELLER myCalibration, customers can access digital calibration data of their KELLER sensors.

### Data
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


## 2) Web App
The web app is here: [https://sensweb.azurewebsites.net/](https://sensweb.azurewebsites.net)

![Web App UI](./media/web-app-example.png?raw=true)

There is a free demo user account with the user name 'demo1234' and the password 'demo1234'.

### Sign Up & Sign In
Signing up a user account can be done with the help of engineering@keller-druck.com
There is already a free demo account  'demo1234' with the password 'demo1234' to see some demo data-
![login example](./media/login-demo1234.png?raw=true)


## 3) Web API
The Web API's URL is https://senswebapi.azurewebsites.net/

The OpenAPI specification page is: [https://senswebapi.azurewebsites.net/swagger/index.html](https://senswebapi.azurewebsites.net/swagger/index.html)

All the calibration data can be exported as
- JSON meta-information (header only) 
- zip file with the filtered and compressed JSON files (header+data)
- brotli file with the filtered and compressed JSON files (header+data)

swagger json: https://senswebapi.azurewebsites.net/swagger/v1/swagger.json

### Filter possibilities



### Generate client SW using the OpenAPI/swagger schema. 
https://editor.swagger.io/

## 4) The JSON Schema


## 5) Sample Software
todo

Github repo:
/docs
/json-schema
/samples
 - json-schema -> C# classes
 - Web API access sample C#



---
---
---
### Markdown

Test: [About](https://myCalibration.github.io/about)

Markdown is a lightweight and easy-to-use syntax for styling your writing. It includes conventions for

```markdown
Syntax highlighted code block

# Header 1
## Header 2
### Header 3

- Bulleted
- List

1. Numbered
2. List

**Bold** and _Italic_ and `Code` text

[Link](url) and ![Image](src)
```
