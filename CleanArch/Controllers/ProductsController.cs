using CleanArch.Application.DTOs;
using CleanArch.Application.Interfaces;
using CleanArch.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CleanArch.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductServices _productServices;
        private readonly ICategoryServices _categoryServices;

        public ProductsController(IProductServices productServices, ICategoryServices categoryServices)
        {
            _productServices = productServices;
            _categoryServices = categoryServices;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await _productServices.GetProductsAsync();
            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.CategoryId = new SelectList(await _categoryServices.GetCategoriesAsync(), "ID", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductDTO product)
        {
            if (ModelState.IsValid)
            {
                await _productServices.AddAsync(product);
                return RedirectToAction(nameof(Index));
            }

            return View(product);
        }

    }
}
