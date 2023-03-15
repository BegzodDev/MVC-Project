using Microsoft.EntityFrameworkCore;
using MVC_Producr.Models.Domain.Entities;
using MVC_Producr.Models.ViewModels;

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
        public DbSet<MVC_Producr.Models.ViewModels.DeleteViewModel>? DeleteViewModel { get; set; }

       
    }

}
