using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Customer customer1 = new Customer("John Doe", new Address("123 Main St", "New York", "NY", "USA"));
        Customer customer2 = new Customer("Jane Smith", new Address("456 Elm St", "Toronto", "ON", "Canada"));

        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Laptop", "P1001", 800, 1));
        order1.AddProduct(new Product("Mouse", "P1002", 20, 2));

        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Tablet", "P2001", 300, 1));
        order2.AddProduct(new Product("Keyboard", "P2002", 50, 1));

        Console.WriteLine("Order 1:");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine("Total Price: $" + order1.GetTotalCost());

        Console.WriteLine("\nOrder 2:");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine("Total Price: $" + order2.GetTotalCost());
    }
}