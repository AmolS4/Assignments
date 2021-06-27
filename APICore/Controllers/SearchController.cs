using APICore.Models;
using APICore.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICore.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SearchController : ControllerBase
    {

        private readonly IService<Category, int> catServ;
        private readonly IService<Products, int> prodServ;
		private DotnetPracticeContext context;

		public SearchController(IService<Products, int> proservice, IService<Category, int> catservice,DotnetPracticeContext c)
        {
            prodServ = proservice;
            catServ = catservice;
			context = c;

		}


		[HttpPost]
		[ActionName("PostQueryStringAsync")]
		//public async Task<IActionResult> PostQueryStringAsync(string CategoryId, string CategoryName, int BasePrice,string SubCategoryName)
		public async Task<IActionResult> PostQueryStringAsync(string catname)
		{

			//string name = await context.Category.Where(c => c.CategoryName == catname).FirstOrDefault().Cat

			//var result = (from a in context.Category
			//			  join c in context.Products on a.CategoryName && c.ProductName
			//			  select new { category = a, products = c });

			//await catServ.CreateAsync(cat);
			//return Ok(cat);
			return Ok();
		}


	}
}
