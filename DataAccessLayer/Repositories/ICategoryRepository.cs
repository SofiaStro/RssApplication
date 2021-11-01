using Models.Classes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public interface ICategoryRepository<T> where T : Category
    {
        Task CreateAsync(T instance);
        Task DeleteAsync(int index);
        Task UpdateAsync(int index, T instance);
        Task SaveChangesAsync();
        Task<int> GetIndexAsync(string name);
        Task<List<T>> GetCurrentCategorysAsync();

    }
}
