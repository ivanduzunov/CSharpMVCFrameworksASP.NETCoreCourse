using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CarDealer.Data.Models;

namespace CarDealer.Data
{
    public class CarDealerDbContext : IdentityDbContext<User>
    {
        public CarDealerDbContext(DbContextOptions<CarDealerDbContext> options)
            : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Sale> Sales { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<Part> Parts { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Sale>()
                .HasOne(s => s.Car)
                .WithMany(c => c.Sales)
                .HasForeignKey(s => s.CarId);

            builder.Entity<Sale>()
                .HasOne(s => s.Customer)
                .WithMany(c => c.Sales)
                .HasForeignKey(s => s.CustomerId);

            builder.Entity<Supplier>()
                .HasMany(s => s.Parts)
                .WithOne(p => p.Supplier)
                .HasForeignKey(p => p.SupplierId);

            builder.Entity<PartCar>()
                .HasKey(pk => new { pk.PartId, pk.CarId });

            builder.Entity<PartCar>()
                .HasOne(pk => pk.Car)
                .WithMany(pk => pk.Parts)
                .HasForeignKey(pk => pk.CarId);

            builder.Entity<PartCar>()
               .HasOne(pk => pk.Part)
               .WithMany(pk => pk.Cars)
               .HasForeignKey(pk => pk.PartId);



            base.OnModelCreating(builder);
        }
    }
}
