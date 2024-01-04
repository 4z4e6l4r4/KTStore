using KTStoreSite.Models;

namespace KTStoreSite.Areas.Admin.Services.Interfaces
{
    public interface ICategoryService
    {
        public Task<bool> AddCategoryAsync(Category category);
        public Task<List<Category>> GetAllCategoryAsync();
        public Task<Category> GetCategoryByIdAsync(int id);
        public Task<bool> UpdateCategoryAsync(Category category);
        public Task<bool> DeleteCategoryAsync(int id);


    }
}
