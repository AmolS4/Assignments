using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCCore.Model;
using Microsoft.EntityFrameworkCore;
namespace MVCCore.Services
{
    public class CategoryService : IService<Category, int>
    {
        private DotnetPracticeContext context;

        public CategoryService(DotnetPracticeContext c)
        {
            //context = new DotnetPracticeContext();
            context = c;
        }


        public async Task<Category> CreateAsync(Category entity)
        {
            var res = await context.Category.AddAsync(entity);
            await context.SaveChangesAsync();
            return res.Entity; // newly created entity object
        }


        public async Task<bool> DeleteAsync(int id)
        {
            var recordToDelete = await context.Category.FindAsync(id);
            if (recordToDelete == null) return false; // record not found
                                                      // delete the record
            context.Category.Remove(recordToDelete);
            await context.SaveChangesAsync();
            return true;
        }


        public async Task<IEnumerable<Category>> GetAsync()
        {
            var result = await context.Category.ToListAsync();
            return result;
        }


        public async Task<Category> GetAsync(int id)
        {
            try
            {
                var result = await context.Category.FindAsync(id);
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



        public async Task<Category> UpdateAsync(int id, Category entity)
        {
            try
            {
                var result = await context.Category.FindAsync(id);
                if (result == null) throw new Exception($"Record not found, update operation is failed");


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
