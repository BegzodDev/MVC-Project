﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Producr.Data;
using MVC_Producr.Models;
using MVC_Producr.Models.Domain.Entities;

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

        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductViewModel product)
        {

            var _product = new Product()
            {
                ItemName = product.ItemName,
                Quantity = product.Quantity,
                Price = product.Price
            };

            await _context.Products.AddAsync(_product);
            await _context.SaveChangesAsync();
            return View(product);
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _context.Products.ToListAsync();
            return View(products);
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(string ProductName)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.ItemName == ProductName);

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return View(product);
        }


        [HttpPut]
        public async Task<IActionResult> Update(string product,ProductViewModel productChanges)
        {
            var productData = await _context.Products.FirstOrDefaultAsync(x=>x.ItemName == product);

            productData.ItemName = productChanges.ItemName;
            productData.Quantity = productChanges.Quantity;
            productData.Price = productChanges.Price;

            await _context.SaveChangesAsync();
            return View(productData);
        }

    }
}
