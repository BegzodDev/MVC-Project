using Microsoft.EntityFrameworkCore;
using MVC_Producr.Models.Domain.Entities;
using MVC_Producr.Models.ViewModels;

namespace MVC_Producr.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<User> Users { get; set; } 
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductHistory> ProductHistorys { get; set; }
        public DbSet<TotalPriceWithVAT> TotalPriceWithVATs { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>().HasData(
                new Admin
                {
                    Id = 1,
                    UserName = "Admin",
                    Password = "12345",
                });
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    ItemName = "olma",
                    Quantity = 3,
                    Price = 20000
                },
                new Product
                {
                    Id = 2,
                    ItemName = "banan",
                    Quantity = 5,
                    Price = 10000
                });
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    UserName = "Bob",
                    Password = "12345"
                });
        }
    }

}
