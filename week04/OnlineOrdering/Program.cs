using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("123 Maple Street", "Vineyard", "Utah", "USA");
        Customer customer1 = new Customer("Emily Carter", address1);

        Address address2 = new Address("45 King's Road", "London", "England", "United Kingdom");
        Customer customer2 = new Customer("Oliver Bennett", address2);

        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Wireless Mouse", "A100", 25.99m, 2));
        order1.AddProduct(new Product("Mechanical Keyboard", "A205", 79.50m, 1));
        order1.AddProduct(new Product("USB-C Hub", "A310", 34.75m, 3));

        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Desk Lamp", "B150", 22.00m, 1));
        order2.AddProduct(new Product("Notebook Set", "B220", 12.25m, 4));

        List<Order> orders = new List<Order> { order1, order2 };

        foreach (Order order in orders)
        {
            Console.WriteLine("Packing Label:");
            Console.WriteLine(order.GetPackingLabel());
            Console.WriteLine();

            Console.WriteLine("Shipping Label:");
            Console.WriteLine(order.GetShippingLabel());
            Console.WriteLine();

            Console.WriteLine($"Total Price: {order.GetTotalCost():C}");
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine();
        }
    }
}