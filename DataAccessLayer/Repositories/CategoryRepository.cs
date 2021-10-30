using Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataAccessLayer.Repositories
{
    public class CategoryRepository : ICategoryRepository<Category>
    {
        SerializerForXml serializerCategoryObject;
        List<Category> listOfCategorys;


        public CategoryRepository()
        {
            serializerCategoryObject = new SerializerForXml();
            listOfCategorys = new List<Category>();
            SetCurrentCategorysToList();
        }
        public async Task CreateAsync(Category categoryObject)
        {
            listOfCategorys.Add(categoryObject);
            await SaveChangesAsync();
        }

        public async Task DeleteAsync(int index)
        {
            listOfCategorys.RemoveAt(index);
            await SaveChangesAsync();
        }

        public async void SetCurrentCategorysToList()
        {
            listOfCategorys = await GetCurrentCategorysAsync();
        }

        public async Task<List<Category>> GetCurrentCategorysAsync()
        {
            List<Category> listOfCategorysDeserialized = new List<Category>();
            try
            {
                listOfCategorysDeserialized = await serializerCategoryObject.CategoryDeserializeAsync();
            }
            catch (Exception)
            {
                //FIXA DENNA!! 

            }
            return listOfCategorysDeserialized;
        }

        public async Task SaveChangesAsync()
        {
            await serializerCategoryObject.CategorySerializerAsync(listOfCategorys);
        }

        public async Task UpdateAsync(int index, Category categoryObejct)
        {
            if (index >= 0)
            {
                listOfCategorys[index] = categoryObejct;
            }
            await SaveChangesAsync();
        }

        public async Task<int> GetIndexAsync(string name)
        {
            //return await Task.Run(() =>
            //{
            // Göra om foreach loopen till en LINQ? om det går?
            int index = 0;
            List<Category> listOfCategory = await GetCurrentCategorysAsync();
            foreach(Category category in listOfCategory)
            {
                if (category.Name.Equals(name))
                {
                    break;
                }
                index++;
            }
            return index;
            //return GetCurrentCategorysAsync().FindIndex(c => c.Name.Equals(name));
            //});
        }
    }
}
