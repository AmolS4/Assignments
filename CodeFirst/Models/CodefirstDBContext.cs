using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeFirst.Models
{
    public class CodefirstDBContext : DbContext
	{
        public DbSet<Customer> Customers { get; set; }
		public DbSet<Product> Products { get; set; }

		public DbSet<Order> Orders { get; set; }
		public DbSet<Vendor> Vendors { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Data Source=IMCMBCP129-MSL2\\SQLEXPRESS2017;Initial Catalog=DotnetPractice;User Id=Citiustechdemo;Password=Citiustech_2222;MultipleActiveResultSets=true");	
		}



		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// use the fluent API to establish One-to-Many Relationship with Foreign Key
			modelBuilder.Entity<Product>()
					   .HasOne(c => c.Vendor) // navigation key for One-to-One Ralationship
					   .WithMany(c => c.Products) // One-to-Many Relationships from vendor-to-Product
					   .HasForeignKey(p => p.VendorRowId); // Map the VendorId of Product with VendorId of Vendor to use it as Foreign Key


			modelBuilder.Entity<Order>()
					   .HasOne(c => c.Customer) // navigation key for One-to-One Ralationship
					   .WithMany(c => c.Orders) // One-to-Many Relationships from Customer-to-Orders
					   .HasForeignKey(p => p.CustomerRowId); // Map the CustomerRowId of Order with CustomerRowId of Customer to use it as Foreign Key



			// defining Unique constraints 

			modelBuilder.Entity<Customer>(entity =>
			{
				entity.HasIndex(p => p.CustomerId).IsUnique();
			});


			modelBuilder.Entity<Vendor>(entity =>
			{
				entity.HasIndex(p => p.VendorId).IsUnique();
			});

			modelBuilder.Entity<Order>(entity =>
			{
				entity.HasIndex(p => p.OrderId).IsUnique();
			});

			
				modelBuilder.Entity<Product>().HasData(
	               new Product { ProductId = "Sku30", ProductName = "Apple", CategoryName = "First post", UnitPrice = 10, VendorRowId=1 });
			
			//modelBuilder.Entity<Vendor>().Property(p => p.VendorName).IsConcurrencyToken();

		}



	}
}
