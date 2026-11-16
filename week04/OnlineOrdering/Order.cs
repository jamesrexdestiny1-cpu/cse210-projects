// These namespaces provide tools for working with lists and building strings.
using System.Collections.Generic;
using System.Text;

// The Order class manages a customer's order.
// It stores the products, calculates the total cost,
// and generates packing and shipping labels.
public class Order
{
    // Private fields store the products in the order and the customer who placed it.
    private List<Product> _products;
    private Customer _customer;

    // Constructor receives the customer and creates an empty product list.
    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    // Adds a Product object to the order's product list.
    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    // Calculates the total order cost, including the shipping fee.
    public decimal GetTotalCost()
    {
        // Start with zero before adding the cost of each product.
        decimal productTotal = 0;

        // Go through every product and add its total cost to the order.
        foreach (Product product in _products)
        {
            productTotal += product.GetTotalCost();
        }

        // Determine the shipping fee based on the customer's location.
        decimal shippingCost;

        if (_customer.IsInUSA())
        {
            // Customers living in the USA pay $5 for shipping.
            shippingCost = 5.00m;
        }
        else
        {
            // Customers living outside the USA pay $35 for shipping.
            shippingCost = 35.00m;
        }

        // Add the one-time shipping fee to the combined product cost.
        return productTotal + shippingCost;
    }

    // Creates and returns a packing label containing each product's name and ID.
    public string GetPackingLabel()
    {
        // StringBuilder makes it easier to build a multi-line label.
        StringBuilder label = new StringBuilder();

        // Add the heading and separator to the packing label.
        label.AppendLine("PACKING LABEL");
        label.AppendLine("------------------------------");

        // Display the name and product ID of every product in the order.
        foreach (Product product in _products)
        {
            label.AppendLine(
                $"Product: {product.GetName()}"
            );

            label.AppendLine(
                $"Product ID: {product.GetProductId()}"
            );

            // Add an empty line to separate the products.
            label.AppendLine();
        }

        // Convert the completed label into a string and return it.
        return label.ToString();
    }

    // Creates and returns a shipping label containing the customer's name and address.
    public string GetShippingLabel()
    {
        // Create a StringBuilder to assemble the shipping label.
        StringBuilder label = new StringBuilder();

        // Add the shipping label heading and separator.
        label.AppendLine("SHIPPING LABEL");
        label.AppendLine("------------------------------");

        // Add the customer's name to the shipping label.
        label.AppendLine(_customer.GetName());

        // Retrieve the customer's address and add the formatted address.
        label.AppendLine(_customer.GetAddress().GetFullAddress());

        // Return the completed shipping label as a string.
        return label.ToString();
    }
}