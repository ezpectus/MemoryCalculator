using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        // Create a complex Customer object
        var customer = new Customer
        {
            Id = 1,
            Name = "John Doe",
            Address = "123 Main St",
            Email = "john.doe@example.com",
            DateOfBirth = new DateTime(1990, 1, 1),
            IsActive = true,
            CreditLimit = 1000.00m,
            PhoneNumber = 1234567890,
            UniqueIdentifier = Guid.NewGuid(),
            Invoices = new List<Invoice>
            {
                new Invoice { InvoiceId = 1, Amount = 100.00m, InvoiceDate = DateTime.Now },
                new Invoice { InvoiceId = 2, Amount = 200.00m, InvoiceDate = DateTime.Now.AddDays(-7) }
            }
        };

        // Calculate and display the size of the single Customer object
        long customerSize = MemoryCalculator.GetObjectSize(customer);
        Console.WriteLine($"Size of single Customer object: {customerSize} bytes");

        // Create a list of 100,000 Customer objects
        var customers = new List<Customer>();
        for (int i = 0; i < 100000; i++)
        {
            customers.Add(new Customer
            {
                Id = i,
                Name = "Customer " + i,
                Address = "Address " + i,
                Email = "customer" + i + "@example.com",
                DateOfBirth = new DateTime(1985, 1, 1),
                IsActive = true,
                CreditLimit = 500.00m,
                PhoneNumber = 9876543210,
                UniqueIdentifier = Guid.NewGuid(),
                Invoices = new List<Invoice>
                {
                    new Invoice { InvoiceId = 1, Amount = 50.00m, InvoiceDate = DateTime.Now },
                    new Invoice { InvoiceId = 2, Amount = 75.00m, InvoiceDate = DateTime.Now.AddDays(-14) }
                }
            });
        }

        // Calculate and display the total size of the Customer list
        long customersSize = MemoryCalculator.GetEnumerableSize(customers);
        Console.WriteLine($"Total size of 100,000 Customer objects: {customersSize} bytes");
    }
}
