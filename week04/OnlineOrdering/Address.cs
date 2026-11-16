// The Address class stores a customer's location information.
// It can also determine whether the address is within the USA.
using System;

public class Address
{
    // Private fields hold the different parts of the customer's address.
    private string _streetAddress;
    private string _city;
    private string _stateProvince;
    private string _country;

    // Constructor initializes all the address fields.
    public Address(string streetAddress, string city,
                   string stateProvince, string country)
    {
        _streetAddress = streetAddress;
        _city = city;
        _stateProvince = stateProvince;
        _country = country;
    }

    // Checks whether the customer's country is the United States.
    // OrdinalIgnoreCase allows "USA" to match regardless of letter case.
    public bool IsInUSA()
    {
        return _country.Equals(
            "USA",
            StringComparison.OrdinalIgnoreCase
        );
    }

    // Combines all the address fields into one formatted string.
    // Newline characters separate the street, city/state, and country.
    public string GetFullAddress()
    {
        return $"{_streetAddress}\n{_city}, {_stateProvince}\n{_country}";
    }
}