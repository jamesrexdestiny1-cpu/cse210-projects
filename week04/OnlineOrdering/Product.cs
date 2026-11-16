// The Product class stores information about an individual product
// and calculates the total cost based on its price and quantity.
public class Product
{
    // Private fields store the product's details.
    private string _name;
    private string _productId;
    private decimal _price;
    private int _quantity;

    // Constructor initializes the product's information when an object is created.
    public Product(string name, string productId, decimal price, int quantity)
    {
        _name = name;
        _productId = productId;
        _price = price;
        _quantity = quantity;
    }

    // Returns the name of the product.
    public string GetName()
    {
        return _name;
    }

    // Returns the unique ID assigned to the product.
    public string GetProductId()
    {
        return _productId;
    }

    // Calculates and returns the total cost of this product.
    // The total cost is the unit price multiplied by the quantity.
    public decimal GetTotalCost()
    {
        return _price * _quantity;
    }
}