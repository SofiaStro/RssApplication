using Models.Classes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public interface ICategoryRepository<T> where T : Category
    {
        Task CreateCategoryAsync(T instance);
        Task DeleteCategoryAsync(int index);
        Task UpdateCategoryAsync(int index, T instance);
        Task SaveCategoryChangesAsync();
        Task<int> GetCategoryIndexAsync(string name);
        Task<List<T>> GetCurrentCategoriesAsync();
    }
}
