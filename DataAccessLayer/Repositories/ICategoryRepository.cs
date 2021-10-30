using Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public interface ICategoryRepository<T> : IRepository<T> where T : Category
    {
        //T GetByName(string name);

        Task CreateAsync(T instance);
        Task DeleteAsync(int index);
        Task UpdateAsync(int index, T instance);
        Task SaveChangesAsync();
        Task<int> GetIndexAsync(string name);
        Task<List<T>> GetCurrentCategorysAsync();

    }
}
