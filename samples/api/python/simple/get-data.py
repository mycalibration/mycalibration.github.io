import requests
import json
from datetime import datetime

print('Starting...')
permanentAccessToken = 'bqCrDAQABACUKUpXST6JCEgPeStCyeHhfmNz/+yE29F+VbVeKl7eU....  ASK engineering@keller-pressure.com for your permanent acces token or look into the profile settings at https://mycalibration.azurewebsites.net/'

baseUrl       = 'https://mycalibrationapi.azurewebsites.net/v1/CalibrationData'
baseUrlExport = 'https://mycalibrationapi.azurewebsites.net/v1/CalibrationData/Export'
baseUrlCount  = 'https://mycalibrationapi.azurewebsites.net/v1/CalibrationData/Count'


# Example Query which 
#  - filters only calibration data of product type "17SHX"
#  - filters only calibration data from the year 2022 or older (order dispatch date)
# https://mycalibration.github.io/
filterParameters = '?DateFilterType=greaterThan&Date=2022-01-01&ProductSeries=17SHX'
#filterParameters = '?ProductSeries=9L' #9L often have MathMod data

# Generally, try to avoid loading more than 1000 calibration data as the query gets quite slow due to the serialization on the backend side. Exporting to a zip is faster (no serialization).
# If unsure there is the possibility to quickly check for the amount of calibration data available with the /Count endpoint:
# url = (baseUrlCount + filterParameters)

url = (baseUrl + filterParameters)

# Add the permanent access token to the header with the userOid key
headers = {'userOid' : permanentAccessToken}

resp = requests.get(url, headers=headers)
print(resp.status_code)

#print the first 100 characters of the response
print(resp.text[0:100] + ' ...')

calibrationData = json.loads(resp.text)

print(f'Loaded calibration data from {len(calibrationData)} sensors.')
if len(calibrationData) > 0 :
  sampleData = calibrationData[0]
  orderNumber             = sampleData['header']['orderNumber']
  orderTargetDispatchDate = datetime.fromisoformat(sampleData['header']['orderTargetDispatchDate'])
  orderPosition           = sampleData['header']['orderPosition']
  productSeries = sampleData['header']['productSeries']
  productNumber = sampleData['header']['productNumber']
  serialNumber  = sampleData['header']['serialNumber']
  compensatedPressureRangeMin  = sampleData['header']['compensatedPressureRange']['min']
  compensatedPressureRangeMax  = sampleData['header']['compensatedPressureRange']['max']
  compensatedPressureRangeUnit = sampleData['header']['compensatedPressureRange']['unit']
  compensatedTemperatureRangeMin  = sampleData['header']['compensatedTemperatureRange']['min']
  compensatedTemperatureRangeMax  = sampleData['header']['compensatedTemperatureRange']['max']
  compensatedTemperatureRangeUnit = sampleData['header']['compensatedTemperatureRange']['unit']

  print(f'The first sensor has the following calibration data: ')
  print(f' |')
  print(f' |- Order Number  : {orderNumber}')
  print(f' |- Dispatch Date : {orderTargetDispatchDate:%Y - %m - %d}')
  print(f' |- Position      : {orderPosition}')

  if sampleData['header']['customerProductType'] is not None:
    customerProductType = sampleData['header']['customerProductType']
    print(f' |- Customer Product Type : {customerProductType}')
  
  print(f' |- Product Series: {productSeries}')
  print(f' |- Product Number: {productNumber}')
  print(f' |- Serial Number : {serialNumber}')
  print(f' |- Calibrated    : From {compensatedPressureRangeMin} .. {compensatedPressureRangeMax} {compensatedPressureRangeUnit}')
  print(f' |- Calibrated    : From {compensatedTemperatureRangeMin} .. {compensatedTemperatureRangeMax} {compensatedTemperatureRangeUnit}')

  if 'compensationMethods' in sampleData:
    compensationMethods = sampleData['compensationMethods']
    if 'mathematicalModels' in compensationMethods and compensationMethods['mathematicalModels'] is not None:
      mathematicalModels = list(compensationMethods['mathematicalModels'].keys())
      mathematicalModelsCount = len(mathematicalModels)
      print(f' |- MathMods      : {mathematicalModelsCount} MathMods stored', end = '')
      if mathematicalModelsCount > 0:
        mathModText = ' & '.join(mathematicalModels)
        print(f': {mathModText}')
      else:
        print('')
      mathModText = json.dumps(compensationMethods['mathematicalModels'][mathematicalModels[0]], indent=2)  
      print(f'   MathMod Data would look like this  : {mathModText}')
    

'''

'''