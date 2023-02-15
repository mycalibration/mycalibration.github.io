## Windows Forms Sample Application

![WindowsFormsSampleMyCalibration](https://github.com/mycalibration/mycalibration.github.io/blob/06a9a9543257466b6857ce8797532e647051290b/docs/media/WindowsFormsSampleMyCalibration.png?raw=true)

### Description
- Use the Permanent Access Token
- Load all available meatinfo (header-data) and show them in a TreeView  (OrderNumber -> OrderPosition -> SerialNumber)
- Choose one calibration data set by selecting a serial number
- Download the whole calibration data JSON and show it in a TextBox
- Also try to convert this JSON to the old obsolete text format by using the myCalibration converter DLL

### Prerequirements
To build, you need 
- VS 2022
- .NET6 SDK
- Access to Nuget for the two needed Nuget-packages

To use it, you need to be a registrated KELLER myCalibration user and a Permanent Access Token (available from engineering@keller-druck.com)

### License
https://github.com/mycalibration/mycalibration.github.io/blob/main/LICENSE.md
