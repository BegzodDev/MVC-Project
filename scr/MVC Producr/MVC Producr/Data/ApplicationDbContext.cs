using Microsoft.EntityFrameworkCore;
using MVC_Producr.Models.Domain.Entities;

namespace MVC_Producr.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<User> Users { get; set; } 
        public DbSet<Product> Products { get; set; }

       
    }

}
