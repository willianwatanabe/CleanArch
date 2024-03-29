﻿using CleanArch.Application.DTOs;
using CleanArch.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CleanArch.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductServices _productServices;
        private readonly ICategoryServices _categoryServices;
        private readonly IWebHostEnvironment _environment;

        public ProductsController(IProductServices productServices, ICategoryServices categoryServices, IWebHostEnvironment environment)
        {
            _productServices = productServices;
            _categoryServices = categoryServices;
            _environment = environment;
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


        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null)
                return NotFound();

            var productDTO = await _productServices.GetByIdAsync(id.Value);
            var categories = await _categoryServices.GetCategoriesAsync();

            ViewBag.CategoryId = new SelectList(categories, "ID", "Name", productDTO.CategoryId);

            return View(productDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductDTO productDto)
        {
            if (ModelState.IsValid)
            {
                await _productServices.UpdateAsync(productDto);
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null)
                return NotFound();

            var productDTO = await _productServices.GetByIdAsync(id.Value);

            return View(productDTO);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _productServices.RemoveAsync(id);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id is null)
                return NotFound();

            var productDTO = await _productServices.GetByIdAsync(id.Value);
            var wwwroot = _environment.WebRootPath;
            var image = Path.Combine(wwwroot, "images\\" + productDTO.Image);
            var exists = System.IO.File.Exists(image);
            ViewBag.Image = exists;

            return View(productDTO);
        }
    }
}
