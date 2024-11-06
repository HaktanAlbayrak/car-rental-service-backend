using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.Context;

public class CarDbContext : DbContext
{
    public DbSet<Car> Cars { get; set; }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Color> Colors { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Rental> Rentals { get; set; }
    public DbSet<CarImage> CarImages { get; set; }
    public DbSet<OperationClaim> OperationClaims { get; set; }
    public DbSet<UserOperationClaim> UserOperationClaims { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=ISTN38990;Database=RentACar;Trusted_Connection=true;TrustServerCertificate=True");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Car>()
            .HasOne(c => c.Brand)
            .WithMany(b => b.Cars)
            .HasForeignKey(c => c.BrandId);

        modelBuilder.Entity<Car>()
            .HasOne(c => c.Color)
            .WithMany(co => co.Cars)
            .HasForeignKey(c => c.ColorId);


        modelBuilder.Entity<Car>()
           .HasOne(c => c.Rental)
           .WithOne(r => r.Car)
           .HasForeignKey<Rental>(r => r.CarId)
           .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Rental>()
           .HasOne(r => r.Customer)
           .WithMany(c => c.Rentals)
           .HasForeignKey(r => r.CustomerId)
           .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Car>()
            .HasMany(c => c.CarImages)
            .WithOne(ci => ci.Car)
            .HasForeignKey(ci => ci.CarId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<UserOperationClaim>()
            .HasOne(uoc => uoc.User)
            .WithMany(u => u.UserOperationClaims)
            .HasForeignKey(uoc => uoc.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<UserOperationClaim>()
            .HasOne(uoc => uoc.OperationClaim)
            .WithMany(oc => oc.UserOperationClaims)
            .HasForeignKey(uoc => uoc.OperationClaimId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<User>()
            .Property(u => u.PasswordHash)
            .HasColumnType("varbinary(500)");

        modelBuilder.Entity<User>()
            .Property(u => u.PasswordSalt)
            .HasColumnType("varbinary(500)");
    }
}
