using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Producr.Data;
using MVC_Producr.Models.Domain.Entities;
using MVC_Producr.Models.ViewModels;

namespace MVC_Producr.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Post()
        {
            return View();
        }
        public async Task<IActionResult> Get()
        {
            var products = await _context.Products.ToListAsync();
            return View(products);
        }
        public IActionResult Delete()
        {
            return View();
        }

        public IActionResult Update()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add_Product(ProductViewModel product)
        {

            var _product = new Product()
            {
                ItemName = product.ItemName,
                Quantity = product.Quantity,
                Price = product.Price
            };

            await _context.Products.AddAsync(_product);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index","Admin");
        }


        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> Delete_Product(DeleteViewModel ProductName)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == ProductName.Id);
            if (product == null)
            {
                return RedirectToAction("Index","Home");
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Admin");

        }


        [HttpPost,ActionName("Update")]
        public async Task<IActionResult> Update_Product(UpdateViewModel model)
        {
            var productData = await _context.Products.FirstOrDefaultAsync(x=>x.Id == model.Id);

            productData.ItemName = model.ItemName;
            productData.Quantity = model.Quantity;
            productData.Price = model.Price;

            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Admin");

        }

    }
}
