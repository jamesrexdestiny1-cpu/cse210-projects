// The Customer class stores a customer's name and address.
// It also provides a method to check whether the customer lives in the USA.
public class Customer
{
    // Private fields store the customer's name and Address object.
    private string _name;
    private Address _address;

    // Constructor initializes the customer's name and address.
    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    // Returns the customer's name.
    public string GetName()
    {
        return _name;
    }

    // Returns the customer's Address object.
    public Address GetAddress()
    {
        return _address;
    }

    // Checks whether the customer lives in the USA.
    // It calls the IsInUSA() method belonging to the Address class.
    public bool IsInUSA()
    {
        return _address.IsInUSA();
    }
}