using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APICore.Models;
using APICore.Services;
namespace APICore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IService<Category, int> catServ;


        public CategoryController(IService<Category, int> service)
        {
            catServ = service;
        }


        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var result = await catServ.GetAsync();
            return Ok(result);
        }

        [HttpGet("{id}")] // the id is accepted in Header as URL Parameter
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await catServ.GetAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(Category data)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await catServ.CreateAsync(data);
                    return Ok(result);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpPut("{id}")] // the id is accepted in Header as URL Parameter
        public async Task<IActionResult> PutAsync(int id, Category data)
        {
            if (ModelState.IsValid)
            {
                var result = await catServ.UpdateAsync(id, data);
                return Ok(result);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await catServ.DeleteAsync(id);
            return Ok(result);
        }


    }
}
