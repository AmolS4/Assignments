using Microsoft.AspNetCore.Mvc;
using MVCCore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCCore.Model;
namespace MVCCore.Controllers
{
    public class CategoryController : Controller
    {

        private readonly IService<Category, int> catService;
        public CategoryController(IService<Category, int> s)
        {
            catService = s;
        }
        public async Task<IActionResult> Index()
        {
            var res = await catService.GetAsync();
            return View(res);
        }

        public IActionResult Create()
        {
            return View(new Category());
        }


    }
}
