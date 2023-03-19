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
            var myConfig = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var vat = myConfig.GetValue<double>("VAT:keyForVat");

            var totalPrice = new TotalPriceWithVAT()
            {
                Price = product.Price,
                ProductName = product.ItemName,
                Quantity = product.Quantity,
                TotalPriceWithVat = (int)((product.Quantity * product.Price) * (1+vat))
            };

            var history = new ProductHistory()
            {
                WhenWasChanged = DateTime.UtcNow,
                Discription = $"{product.ItemName} is added to database.Quantity - {product.Quantity}.Price - {product.Price} from ADMIN"
            };

            await _context.ProductHistorys.AddAsync(history);
            await _context.TotalPriceWithVATs.AddAsync(totalPrice);
            await _context.Products.AddAsync(_product);
            await _context.SaveChangesAsync();
            return RedirectToAction("Get_Products","Admin");
        }


        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> Delete_Product(DeleteViewModel ProductName)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == ProductName.Id);
            if (product == null)
            {
                return RedirectToAction("Index","Home");
            }
            var history = new ProductHistory()
            {
                WhenWasChanged = DateTime.UtcNow,
                Discription = $"{product.ItemName} is deleted from database from ADMIN"
            };

            await _context.ProductHistorys.AddAsync(history);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction("Get_Products", "Admin");

        }


        [HttpPost,ActionName("Update")]
        public async Task<IActionResult> Update_Product(UpdateViewModel model)
        {
            var productData = await _context.Products.FirstOrDefaultAsync(x=>x.Id == model.Id);

            productData.ItemName = model.ItemName;
            productData.Quantity = model.Quantity;
            productData.Price = model.Price;

            var history = new ProductHistory()
            {
                WhenWasChanged = DateTime.UtcNow,
                Discription = $"{model.ItemName} is updated .Quantity was changed to - {model.Quantity}.Price was changed to - {model.Price} From ADMIN"
            };
            await _context.ProductHistorys.AddAsync(history);
            await _context.SaveChangesAsync();
            return RedirectToAction("Get_Products", "Admin");

        }

        [HttpGet]
        public async Task<IActionResult> Get_Products()
        {
            var product = await _context.Products.ToListAsync();
            return View(product);
        }


        [HttpGet,ActionName("Get_History")]
        public async Task<IActionResult> Get_History(GetHistoryViewModel getHistory)
        {
            var changes = await _context.ProductHistorys.Where(x=>x.WhenWasChanged <= getHistory.DateFor && 
                                                                  x.WhenWasChanged >= getHistory.DateFrom).ToListAsync();


            return View(changes);
        }
    }
}
