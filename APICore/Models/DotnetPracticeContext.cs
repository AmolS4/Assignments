using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APICore.Models
{
    public partial class DotnetPracticeContext : DbContext
    {
        //public DotnetPracticeContext()
        //{
        //}

        public DotnetPracticeContext(DbContextOptions<DotnetPracticeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<ExceptionHistory> ExceptionHistory { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Vendors> Vendors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Data Source=IMCMBCP129-MSL2\\SQLEXPRESS2017;Initial Catalog=DotnetPractice;User Id=Citiustechdemo;Password=Citiustech_2222;MultipleActiveResultSets=true");
//            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.CatId);

                entity.Property(e => e.CategoryName).HasMaxLength(50);
            });

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.HasKey(e => e.CustomerRowId);

                entity.HasIndex(e => e.CustomerId)
                    .IsUnique();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.CustomerName)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.DeptNo);

                entity.Property(e => e.DeptName)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Location).HasMaxLength(50);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmpNo);

                entity.Property(e => e.Designation).HasMaxLength(50);

                entity.Property(e => e.Ename)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.HasOne(d => d.DeptNoNavigation)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.DeptNo)
                    .HasConstraintName("FK_Employee_Department");
            });

            modelBuilder.Entity<ExceptionHistory>(entity =>
            {
                entity.HasKey(e => e.LogId);

                entity.Property(e => e.ActionMethod).HasMaxLength(100);

                entity.Property(e => e.ControllerName).HasMaxLength(100);

                entity.Property(e => e.ExceptionHandled).HasMaxLength(100);

                entity.Property(e => e.LogGuid)
                    .HasColumnName("LogGUID")
                    .HasMaxLength(150);

                entity.Property(e => e.RequestTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.OrderRowId);

                entity.HasIndex(e => e.CustomerRowId);

                entity.HasIndex(e => e.OrderId)
                    .IsUnique();

                entity.Property(e => e.OrderId).IsRequired();

                entity.HasOne(d => d.CustomerRow)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerRowId);
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasKey(e => e.ProductRowId);

                entity.HasIndex(e => e.VendorRowId);

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.HasOne(d => d.Cat)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CatId)
                    .HasConstraintName("FK_Products_Category");

                entity.HasOne(d => d.VendorRow)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.VendorRowId);
            });

            modelBuilder.Entity<Vendors>(entity =>
            {
                entity.HasKey(e => e.VendorRowId);

                entity.HasIndex(e => e.VendorId)
                    .IsUnique();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.VendorId).IsRequired();

                entity.Property(e => e.VendorName)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
