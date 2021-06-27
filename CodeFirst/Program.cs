using CodeFirst.Models;
using System;

namespace CodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new CodefirstDBContext())
            {
                var vendor = new Vendor()
                {
                    VendorId = "100",
                    VendorName = "JIO",
                    Address = "MUMBAI",
                    City = "Mumbai",
                    Email = "jio@gmail.com"
                };
                var vendor1 = new Vendor()
                {
                    VendorId = "101",
                    VendorName = "Vodafone",
                    Address = "delhi",
                    City = "delhi",
                    Email = "voda@gmail.com"
                };

                var product = new Product()
                {
                    ProductId = "Sku10",
                    ProductName = "jio phone",
                    CategoryName = "Mobile",
                    UnitPrice = 2000,
                    VendorRowId = 1,

                };

                var product1 = new Product()
                {
                    ProductId = "Sku20",
                    ProductName = "Banana",
                    CategoryName = "Vegetable",
                    UnitPrice = 40,
                    VendorRowId = 2,

                };

                var product2 = new Product()
                {
                    ProductId = "Sku30",
                    ProductName = "Apple",
                    CategoryName = "Vegetable",
                    UnitPrice = 100,
                    VendorRowId = 2,

                };

                var product3 = new Product()
                {
                    ProductId = "Sku40",
                    ProductName = "Apple",
                    CategoryName = "Mobile",
                    UnitPrice = 4000,
                    VendorRowId = 1,

                };
                context.Products.Add(product1);
                context.Products.Add(product2);
                context.Products.Add(product3);
              
                context.SaveChanges();

                Console.WriteLine("Enter Vender  name");
                string name = Console.ReadLine();
                try
                {
                    var vend = context.Vendors.Find(name);
                    

                    if (vend.VendorName == name)
                    {
                        foreach (var item in context.Products)
                        {
                            Console.WriteLine($"{item.ProductId}  {item.ProductName}  {item.UnitPrice} {item.VendorRowId}");
                        }

                    }
                }
                catch (Exception ex)
                {

                    throw ex;
                }

            }
        }



















    }
}

