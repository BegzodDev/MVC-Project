using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Producr.Data;
using MVC_Producr.Models;
using MVC_Producr.Models.Domain.Entities;

namespace MVC_Producr.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;            
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await _context.Products.ToListAsync();
            return View(products);
        }


        [HttpPost]
        public async Task<IActionResult> Register(UserViewModel model)
        {
            var oneUser = new User()
            {
                UserName = model.UserName,
                Password = model.Password
            };

            await _context.Users.AddAsync(oneUser);
            await _context.SaveChangesAsync();
            return RedirectToAction("Register");
        }
    }
}
