using Microsoft.AspNetCore.Mvc;
using MVC_Producr.Data;
using MVC_Producr.Models.Domain.Entities;
using MVC_Producr.Models.ViewModels;

namespace MVC_Producr.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;   
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserViewModel model)
        {
            var user = new User()
            {
                UserName = model.UserName,
                Password = model.Password
            };
            foreach (var item in _context.Users)
            {
                if (item.UserName == user.UserName)
                {
                    throw new Exception("User is Exsist");
                }
            }
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index","Home");
        }
    }
}
