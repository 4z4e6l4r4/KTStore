using KTStoreSite.Areas.Admin.Services.Interfaces;
using KTStoreSite.Data;
using KTStoreSite.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace KTStoreSite.Areas.Admin.Services.Models
{
    public class CategoryService : ICategoryService
    {
        ApplicationDbContext db;
        public CategoryService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public Task<bool> AddCategoryAsync(Category category)
        {
            var result = false;
            if (category != null)
            {
                db.Category.AddAsync(category);
                db.SaveChanges();
            }
            return Task.FromResult(result);
        }

        public Task<bool> DeleteCategoryAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Category>> GetAllCategoryAsync()
        {
            var list = await  db.Category.Where(x => !x.IsDelete).ToListAsync();

            return list;
        }

        public Task<Category> GetCategoryByIdAsync(int id)
        {
            var category = db.Category.FirstOrDefaultAsync(x => x.Id == id && !x.IsDelete);
            return category;
        }

        public async Task<bool> UpdateCategoryAsync(Category category)
        {
            var updateCategory = await db.Category.FirstOrDefaultAsync(x => x.Id == category.Id && !x.IsDelete);
            var result = false;
            if (updateCategory != null)
            {
                updateCategory.Name = category.Name;
                updateCategory.Description = category.Description;
                updateCategory.IsStatus = category.IsStatus;
                if (String.IsNullOrEmpty(category.Image))
                {
                    updateCategory.Image = category.Image;
                }
                updateCategory.Image = category.Image;

                await db.SaveChangesAsync(); // Değişiklikleri kaydet
                result = true;
            }
            return result;

        }
    }
}
