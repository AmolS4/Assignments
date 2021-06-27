using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using MVCCore.Services;
using Security.Models;
using Microsoft.AspNetCore.Authorization;

namespace Security.Controllers
{
    public class CategoryController : Controller
    {

        private readonly IService<Category, int> catService;
        public CategoryController(IService<Category, int> s)
        {
            catService = s;
        }
        [Authorize(Policy = "readpolicy")]
        public async Task<IActionResult> Index()
        {
            var res = await catService.GetAsync();
            return View(res);
        }
		[Authorize(Policy = "writepolicy")]
		public IActionResult Create()
        {
            return View(new Category());
        }


		[HttpPost]
		public async Task<IActionResult> Create(Category data)
		{
			//try
			//{
			if (ModelState.IsValid)
			{
				
				if (data.CategoryName == string.Empty) throw new Exception("Modle is invalid");
				var res = await catService.CreateAsync(data);

				return RedirectToAction("Index");
			}
			else
			{
				return View(data);
			}
			
		}
		[Authorize(Policy = "writepolicy")]
		public async Task<IActionResult> Edit(int id)
		{
			var res = await catService.GetAsync(id);
			return View(res);
		}
		[Authorize(Policy = "writepolicy")]
		[HttpPost]
		public async Task<IActionResult> Edit(int id, Category data)
		{
			try
			{
				if (ModelState.IsValid)
				{
					var res = await catService.UpdateAsync(id, data);
					return RedirectToAction("Index");
				}
				else
				{
					return View(data);
				}
			}
			catch (Exception ex)
			{
				return View("Error");
			}
		}
		[Authorize(Policy = "writepolicy")]
		public async Task<IActionResult> Delete(int id)
		{
			var res = await catService.DeleteAsync(id);
			return RedirectToAction("Index");
		}

	}
}
