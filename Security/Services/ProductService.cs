using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Security.Models;
using Microsoft.EntityFrameworkCore;

namespace MVCCore.Services
{
    public class ProductService : IService<Products, int>
    {
        private DotnetPracticeContext context;

        public ProductService(DotnetPracticeContext c)
        {
            //context = new DotnetPracticeContext();
            context = c;
        }
        public async Task<Products> CreateAsync(Products entity)
        {
            var res = await context.Products.AddAsync(entity);
            await context.SaveChangesAsync();
            return res.Entity; // newly created entity object
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var recordToDelete = await context.Products.FindAsync(id);
            if (recordToDelete == null) return false; // record not found
                                                      // delete the record
            context.Products.Remove(recordToDelete);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Products>> GetAsync()
        {
            var result = await context.Products.ToListAsync();
            return result;
        }

        public async Task<Products> GetAsync(int id)
        {
            try
            {
                var result = await context.Products.FindAsync(id);
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<Products> UpdateAsync(int id, Products entity)
        {
            try
            {
                var result = await context.Products.FindAsync(id);
                if (result == null) throw new Exception($"Record not found, update operation is failed");


                result.ProductId = entity.ProductId;
                result.ProductName = entity.ProductName;
                result.UnitPrice = entity.UnitPrice;
                result.CategoryName = entity.CategoryName;

                // modify the record 
                //context.Entry(result).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }








    }
}
