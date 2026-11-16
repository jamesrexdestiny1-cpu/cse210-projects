using System;

// The Program class contains the Main method,
// which is the starting point of the application.
class Program
{
    static void Main(string[] args)
    {
        // ==========================================
        // FIRST ORDER: CUSTOMER LIVING IN THE USA
        // ==========================================

        // Create the first customer's address.
        Address address1 = new Address(
            "25 Main Street",
            "New York",
            "New York",
            "USA"
        );

        // Create the first customer and assign the address.
        Customer customer1 = new Customer(
            "John Smith",
            address1
        );

        // Create the first product: Laptop.
        Product product1 = new Product(
            "Laptop",
            "P001",
            850.00m,
            1
        );

        // Create the second product: Wireless Mouse.
        Product product2 = new Product(
            "Wireless Mouse",
            "P002",
            25.00m,
            2
        );

        // Create the third product: Laptop Bag.
        Product product3 = new Product(
            "Laptop Bag",
            "P003",
            40.00m,
            1
        );

        // Create the first order and associate it with the first customer.
        Order order1 = new Order(customer1);

        // Add all three products to the first order.
        order1.AddProduct(product1);
        order1.AddProduct(product2);
        order1.AddProduct(product3);


        // ==========================================
        // SECOND ORDER: CUSTOMER LIVING IN NIGERIA
        // ==========================================

        // Create the second customer's address.
        Address address2 = new Address(
            "15 Admiralty Way",
            "Lekki",
            "Lagos",
            "Nigeria"
        );

        // Create the second customer and assign the address.
        Customer customer2 = new Customer(
            "James Ovie",
            address2
        );

        // Create the first product: Smartphone.
        Product product4 = new Product(
            "Smartphone",
            "P004",
            500.00m,
            1
        );

        // Create the second product: Headphones.
        Product product5 = new Product(
            "Headphones",
            "P005",
            60.00m,
            2
        );

        // Create the third product: Phone Charger.
        Product product6 = new Product(
            "Phone Charger",
            "P006",
            20.00m,
            1
        );

        // Create the second order and associate it with the second customer.
        Order order2 = new Order(customer2);

        // Add all three products to the second order.
        order2.AddProduct(product4);
        order2.AddProduct(product5);
        order2.AddProduct(product6);


        // ==========================================
        // DISPLAY THE FIRST ORDER'S INFORMATION
        // ==========================================

        // Display a heading for the first customer's order.
        Console.WriteLine("====================================");
        Console.WriteLine("          CUSTOMER ORDER 1");
        Console.WriteLine("====================================");

        // Generate and display the packing label.
        Console.WriteLine(order1.GetPackingLabel());

        // Generate and display the shipping label.
        Console.WriteLine(order1.GetShippingLabel());

        // Calculate and display the first order's total cost.
        Console.WriteLine(
            $"Total Order Cost: ${order1.GetTotalCost():F2}"
        );


        // ==========================================
        // DISPLAY THE SECOND ORDER'S INFORMATION
        // ==========================================

        // Display a heading for the second customer's order.
        Console.WriteLine("\n====================================");
        Console.WriteLine("          CUSTOMER ORDER 2");
        Console.WriteLine("====================================");

        // Generate and display the packing label.
        Console.WriteLine(order2.GetPackingLabel());

        // Generate and display the shipping label.
        Console.WriteLine(order2.GetShippingLabel());

        // Calculate and display the second order's total cost.
        Console.WriteLine(
            $"Total Order Cost: ${order2.GetTotalCost():F2}"
        );


        // Display a final message after processing both orders.
        Console.WriteLine("\n====================================");
        Console.WriteLine("       ORDER PROCESSING COMPLETE");
        Console.WriteLine("====================================");
    }
}