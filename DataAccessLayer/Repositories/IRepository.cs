using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public interface IRepository<T> where T : class
    {
        void Create(T instance, string fileName);
        //void Delete(int index);
        //void Update(int index, T instance);
        void SaveChanges(T instance, string fileName);
        
        
    }
}
