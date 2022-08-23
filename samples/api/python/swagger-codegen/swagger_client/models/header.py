# coding: utf-8

"""
    myCalibration OpenAPI 3 Specification

    myCalibration API  # noqa: E501

    OpenAPI spec version: 1.22.178.1
    Contact: engineering@keller-druck.com
    Generated by: https://github.com/swagger-api/swagger-codegen.git
"""

import pprint
import re  # noqa: F401

import six

class Header(object):
    """NOTE: This class is auto generated by the swagger code generator program.

    Do not edit the class manually.
    """
    """
    Attributes:
      swagger_types (dict): The key is attribute name
                            and the value is attribute type.
      attribute_map (dict): The key is attribute name
                            and the value is json key in definition.
    """
    swagger_types = {
        'creation_date': 'datetime',
        'remarks': 'str',
        'serial_number': 'str',
        'product_number': 'str',
        'product_type': 'str',
        'pressure_type': 'PressureType',
        'product_series': 'str',
        'compensated_temperature_range': 'PhysicalQuantityRange',
        'compensated_pressure_range': 'PhysicalQuantityRange',
        'electric_supply': 'HeaderElectricSupply',
        'order_number': 'int',
        'order_position': 'int',
        'order_target_dispatch_date': 'datetime',
        'customer_name': 'str',
        'customer_number': 'int',
        'customer_order_number': 'str',
        'customer_reference_number': 'str',
        'customer_product_type': 'str'
    }

    attribute_map = {
        'creation_date': 'CreationDate',
        'remarks': 'Remarks',
        'serial_number': 'SerialNumber',
        'product_number': 'ProductNumber',
        'product_type': 'ProductType',
        'pressure_type': 'PressureType',
        'product_series': 'ProductSeries',
        'compensated_temperature_range': 'CompensatedTemperatureRange',
        'compensated_pressure_range': 'CompensatedPressureRange',
        'electric_supply': 'ElectricSupply',
        'order_number': 'OrderNumber',
        'order_position': 'OrderPosition',
        'order_target_dispatch_date': 'OrderTargetDispatchDate',
        'customer_name': 'CustomerName',
        'customer_number': 'CustomerNumber',
        'customer_order_number': 'CustomerOrderNumber',
        'customer_reference_number': 'CustomerReferenceNumber',
        'customer_product_type': 'CustomerProductType'
    }

    def __init__(self, creation_date=None, remarks=None, serial_number=None, product_number=None, product_type=None, pressure_type=None, product_series=None, compensated_temperature_range=None, compensated_pressure_range=None, electric_supply=None, order_number=None, order_position=None, order_target_dispatch_date=None, customer_name=None, customer_number=None, customer_order_number=None, customer_reference_number=None, customer_product_type=None):  # noqa: E501
        """Header - a model defined in Swagger"""  # noqa: E501
        self._creation_date = None
        self._remarks = None
        self._serial_number = None
        self._product_number = None
        self._product_type = None
        self._pressure_type = None
        self._product_series = None
        self._compensated_temperature_range = None
        self._compensated_pressure_range = None
        self._electric_supply = None
        self._order_number = None
        self._order_position = None
        self._order_target_dispatch_date = None
        self._customer_name = None
        self._customer_number = None
        self._customer_order_number = None
        self._customer_reference_number = None
        self._customer_product_type = None
        self.discriminator = None
        if creation_date is not None:
            self.creation_date = creation_date
        if remarks is not None:
            self.remarks = remarks
        if serial_number is not None:
            self.serial_number = serial_number
        if product_number is not None:
            self.product_number = product_number
        if product_type is not None:
            self.product_type = product_type
        if pressure_type is not None:
            self.pressure_type = pressure_type
        if product_series is not None:
            self.product_series = product_series
        if compensated_temperature_range is not None:
            self.compensated_temperature_range = compensated_temperature_range
        if compensated_pressure_range is not None:
            self.compensated_pressure_range = compensated_pressure_range
        if electric_supply is not None:
            self.electric_supply = electric_supply
        if order_number is not None:
            self.order_number = order_number
        if order_position is not None:
            self.order_position = order_position
        if order_target_dispatch_date is not None:
            self.order_target_dispatch_date = order_target_dispatch_date
        if customer_name is not None:
            self.customer_name = customer_name
        if customer_number is not None:
            self.customer_number = customer_number
        if customer_order_number is not None:
            self.customer_order_number = customer_order_number
        if customer_reference_number is not None:
            self.customer_reference_number = customer_reference_number
        if customer_product_type is not None:
            self.customer_product_type = customer_product_type

    @property
    def creation_date(self):
        """Gets the creation_date of this Header.  # noqa: E501

        File creation date  # noqa: E501

        :return: The creation_date of this Header.  # noqa: E501
        :rtype: datetime
        """
        return self._creation_date

    @creation_date.setter
    def creation_date(self, creation_date):
        """Sets the creation_date of this Header.

        File creation date  # noqa: E501

        :param creation_date: The creation_date of this Header.  # noqa: E501
        :type: datetime
        """

        self._creation_date = creation_date

    @property
    def remarks(self):
        """Gets the remarks of this Header.  # noqa: E501


        :return: The remarks of this Header.  # noqa: E501
        :rtype: str
        """
        return self._remarks

    @remarks.setter
    def remarks(self, remarks):
        """Sets the remarks of this Header.


        :param remarks: The remarks of this Header.  # noqa: E501
        :type: str
        """

        self._remarks = remarks

    @property
    def serial_number(self):
        """Gets the serial_number of this Header.  # noqa: E501

        KELLER product serial number  # noqa: E501

        :return: The serial_number of this Header.  # noqa: E501
        :rtype: str
        """
        return self._serial_number

    @serial_number.setter
    def serial_number(self, serial_number):
        """Sets the serial_number of this Header.

        KELLER product serial number  # noqa: E501

        :param serial_number: The serial_number of this Header.  # noqa: E501
        :type: str
        """

        self._serial_number = serial_number

    @property
    def product_number(self):
        """Gets the product_number of this Header.  # noqa: E501

        KELLER product number  # noqa: E501

        :return: The product_number of this Header.  # noqa: E501
        :rtype: str
        """
        return self._product_number

    @product_number.setter
    def product_number(self, product_number):
        """Sets the product_number of this Header.

        KELLER product number  # noqa: E501

        :param product_number: The product_number of this Header.  # noqa: E501
        :type: str
        """

        self._product_number = product_number

    @property
    def product_type(self):
        """Gets the product_type of this Header.  # noqa: E501

        KELLER product type  # noqa: E501

        :return: The product_type of this Header.  # noqa: E501
        :rtype: str
        """
        return self._product_type

    @product_type.setter
    def product_type(self, product_type):
        """Sets the product_type of this Header.

        KELLER product type  # noqa: E501

        :param product_type: The product_type of this Header.  # noqa: E501
        :type: str
        """

        self._product_type = product_type

    @property
    def pressure_type(self):
        """Gets the pressure_type of this Header.  # noqa: E501


        :return: The pressure_type of this Header.  # noqa: E501
        :rtype: PressureType
        """
        return self._pressure_type

    @pressure_type.setter
    def pressure_type(self, pressure_type):
        """Sets the pressure_type of this Header.


        :param pressure_type: The pressure_type of this Header.  # noqa: E501
        :type: PressureType
        """

        self._pressure_type = pressure_type

    @property
    def product_series(self):
        """Gets the product_series of this Header.  # noqa: E501

        KELLER product series  # noqa: E501

        :return: The product_series of this Header.  # noqa: E501
        :rtype: str
        """
        return self._product_series

    @product_series.setter
    def product_series(self, product_series):
        """Sets the product_series of this Header.

        KELLER product series  # noqa: E501

        :param product_series: The product_series of this Header.  # noqa: E501
        :type: str
        """

        self._product_series = product_series

    @property
    def compensated_temperature_range(self):
        """Gets the compensated_temperature_range of this Header.  # noqa: E501


        :return: The compensated_temperature_range of this Header.  # noqa: E501
        :rtype: PhysicalQuantityRange
        """
        return self._compensated_temperature_range

    @compensated_temperature_range.setter
    def compensated_temperature_range(self, compensated_temperature_range):
        """Sets the compensated_temperature_range of this Header.


        :param compensated_temperature_range: The compensated_temperature_range of this Header.  # noqa: E501
        :type: PhysicalQuantityRange
        """

        self._compensated_temperature_range = compensated_temperature_range

    @property
    def compensated_pressure_range(self):
        """Gets the compensated_pressure_range of this Header.  # noqa: E501


        :return: The compensated_pressure_range of this Header.  # noqa: E501
        :rtype: PhysicalQuantityRange
        """
        return self._compensated_pressure_range

    @compensated_pressure_range.setter
    def compensated_pressure_range(self, compensated_pressure_range):
        """Sets the compensated_pressure_range of this Header.


        :param compensated_pressure_range: The compensated_pressure_range of this Header.  # noqa: E501
        :type: PhysicalQuantityRange
        """

        self._compensated_pressure_range = compensated_pressure_range

    @property
    def electric_supply(self):
        """Gets the electric_supply of this Header.  # noqa: E501


        :return: The electric_supply of this Header.  # noqa: E501
        :rtype: HeaderElectricSupply
        """
        return self._electric_supply

    @electric_supply.setter
    def electric_supply(self, electric_supply):
        """Sets the electric_supply of this Header.


        :param electric_supply: The electric_supply of this Header.  # noqa: E501
        :type: HeaderElectricSupply
        """

        self._electric_supply = electric_supply

    @property
    def order_number(self):
        """Gets the order_number of this Header.  # noqa: E501

        KELLER purchase order number  # noqa: E501

        :return: The order_number of this Header.  # noqa: E501
        :rtype: int
        """
        return self._order_number

    @order_number.setter
    def order_number(self, order_number):
        """Sets the order_number of this Header.

        KELLER purchase order number  # noqa: E501

        :param order_number: The order_number of this Header.  # noqa: E501
        :type: int
        """

        self._order_number = order_number

    @property
    def order_position(self):
        """Gets the order_position of this Header.  # noqa: E501

        KELLER purchase order position  # noqa: E501

        :return: The order_position of this Header.  # noqa: E501
        :rtype: int
        """
        return self._order_position

    @order_position.setter
    def order_position(self, order_position):
        """Sets the order_position of this Header.

        KELLER purchase order position  # noqa: E501

        :param order_position: The order_position of this Header.  # noqa: E501
        :type: int
        """

        self._order_position = order_position

    @property
    def order_target_dispatch_date(self):
        """Gets the order_target_dispatch_date of this Header.  # noqa: E501

        Targeted dispatch date of the order  # noqa: E501

        :return: The order_target_dispatch_date of this Header.  # noqa: E501
        :rtype: datetime
        """
        return self._order_target_dispatch_date

    @order_target_dispatch_date.setter
    def order_target_dispatch_date(self, order_target_dispatch_date):
        """Sets the order_target_dispatch_date of this Header.

        Targeted dispatch date of the order  # noqa: E501

        :param order_target_dispatch_date: The order_target_dispatch_date of this Header.  # noqa: E501
        :type: datetime
        """

        self._order_target_dispatch_date = order_target_dispatch_date

    @property
    def customer_name(self):
        """Gets the customer_name of this Header.  # noqa: E501

        Customer name  # noqa: E501

        :return: The customer_name of this Header.  # noqa: E501
        :rtype: str
        """
        return self._customer_name

    @customer_name.setter
    def customer_name(self, customer_name):
        """Sets the customer_name of this Header.

        Customer name  # noqa: E501

        :param customer_name: The customer_name of this Header.  # noqa: E501
        :type: str
        """

        self._customer_name = customer_name

    @property
    def customer_number(self):
        """Gets the customer_number of this Header.  # noqa: E501

        KELLER customer identification number  # noqa: E501

        :return: The customer_number of this Header.  # noqa: E501
        :rtype: int
        """
        return self._customer_number

    @customer_number.setter
    def customer_number(self, customer_number):
        """Sets the customer_number of this Header.

        KELLER customer identification number  # noqa: E501

        :param customer_number: The customer_number of this Header.  # noqa: E501
        :type: int
        """

        self._customer_number = customer_number

    @property
    def customer_order_number(self):
        """Gets the customer_order_number of this Header.  # noqa: E501

        Customer internal purchase order number  # noqa: E501

        :return: The customer_order_number of this Header.  # noqa: E501
        :rtype: str
        """
        return self._customer_order_number

    @customer_order_number.setter
    def customer_order_number(self, customer_order_number):
        """Sets the customer_order_number of this Header.

        Customer internal purchase order number  # noqa: E501

        :param customer_order_number: The customer_order_number of this Header.  # noqa: E501
        :type: str
        """

        self._customer_order_number = customer_order_number

    @property
    def customer_reference_number(self):
        """Gets the customer_reference_number of this Header.  # noqa: E501

        Customer internal reference number  # noqa: E501

        :return: The customer_reference_number of this Header.  # noqa: E501
        :rtype: str
        """
        return self._customer_reference_number

    @customer_reference_number.setter
    def customer_reference_number(self, customer_reference_number):
        """Sets the customer_reference_number of this Header.

        Customer internal reference number  # noqa: E501

        :param customer_reference_number: The customer_reference_number of this Header.  # noqa: E501
        :type: str
        """

        self._customer_reference_number = customer_reference_number

    @property
    def customer_product_type(self):
        """Gets the customer_product_type of this Header.  # noqa: E501

        Customer internal product type  # noqa: E501

        :return: The customer_product_type of this Header.  # noqa: E501
        :rtype: str
        """
        return self._customer_product_type

    @customer_product_type.setter
    def customer_product_type(self, customer_product_type):
        """Sets the customer_product_type of this Header.

        Customer internal product type  # noqa: E501

        :param customer_product_type: The customer_product_type of this Header.  # noqa: E501
        :type: str
        """

        self._customer_product_type = customer_product_type

    def to_dict(self):
        """Returns the model properties as a dict"""
        result = {}

        for attr, _ in six.iteritems(self.swagger_types):
            value = getattr(self, attr)
            if isinstance(value, list):
                result[attr] = list(map(
                    lambda x: x.to_dict() if hasattr(x, "to_dict") else x,
                    value
                ))
            elif hasattr(value, "to_dict"):
                result[attr] = value.to_dict()
            elif isinstance(value, dict):
                result[attr] = dict(map(
                    lambda item: (item[0], item[1].to_dict())
                    if hasattr(item[1], "to_dict") else item,
                    value.items()
                ))
            else:
                result[attr] = value
        if issubclass(Header, dict):
            for key, value in self.items():
                result[key] = value

        return result

    def to_str(self):
        """Returns the string representation of the model"""
        return pprint.pformat(self.to_dict())

    def __repr__(self):
        """For `print` and `pprint`"""
        return self.to_str()

    def __eq__(self, other):
        """Returns true if both objects are equal"""
        if not isinstance(other, Header):
            return False

        return self.__dict__ == other.__dict__

    def __ne__(self, other):
        """Returns true if both objects are not equal"""
        return not self == other