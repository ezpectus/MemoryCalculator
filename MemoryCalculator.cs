using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

public static class MemoryCalculator
{
    private static readonly object _lock = new object();

    public static long GetObjectSize<T>(T obj)
    {
        if (obj == null)
        {
            return 0;
        }

        lock (_lock)
        {
            if (typeof(T).IsValueType)
            {
                return Marshal.SizeOf<T>();
            }

            if (obj is string str)
            {
                return str.Length * 2 + 2 * IntPtr.Size; // Approximate string size
            }

            if (obj is IEnumerable<object> enumerable)
            {
                long totalSize = 0;
                foreach (var item in enumerable)
                {
                    totalSize += GetObjectSize(item);
                }
                return totalSize;
            }

            // Approximate size for reference types. This is not 100% accurate.
            return IntPtr.Size;

        }
    }

    public static long GetEnumerableSize<T>(IEnumerable<T> collection)
    {
        if (collection == null)
        {
            return 0;
        }

        lock (_lock)
        {
            long totalSize = 0;
            foreach (var item in collection)
            {
                totalSize += GetObjectSize(item);
            }
            return totalSize;
        }
    }
}

public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }
    public DateTime DateOfBirth { get; set; }
    public bool IsActive { get; set; }
    public decimal CreditLimit { get; set; }
    public long PhoneNumber { get; set; }
    public Guid UniqueIdentifier { get; set; }
    public List<Invoice> Invoices { get; set; } = new List<Invoice>();
}

public class Invoice
{
    public int InvoiceId { get; set; }
    public decimal Amount { get; set; }
    public DateTime InvoiceDate { get; set; }
}
