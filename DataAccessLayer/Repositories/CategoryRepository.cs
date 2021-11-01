using Models.Classes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class CategoryRepository : ICategoryRepository<Category>
    {
        SerializerForXml serializerCategoryObject;
        List<Category> listOfCategories;


        public CategoryRepository()
        {
            serializerCategoryObject = new SerializerForXml();
            listOfCategories = new List<Category>();
            SetCurrentCategoriesToList();
        }
        public async Task CreateCategoryAsync(Category categoryObject)
        {
            try
            {
                listOfCategories.Add(categoryObject);
                await SaveCategoryChangesAsync();
            }
            catch(Exception) { }
        }

        public async Task DeleteCategoryAsync(int index)
        {
            try
            {
                listOfCategories.RemoveAt(index);
                await SaveCategoryChangesAsync();
            }
            catch (Exception) { }
        }

        public async void SetCurrentCategoriesToList()
        {
            listOfCategories = await GetCurrentCategoriesAsync();
        }

        public async Task<List<Category>> GetCurrentCategoriesAsync()
        {
            List<Category> listOfCategoriesDeserialized = new List<Category>();
            try
            {
                listOfCategoriesDeserialized = await serializerCategoryObject.CategoryDeserializeAsync();
            }
            catch (Exception)
            {
            }
            return listOfCategoriesDeserialized;
        }

        public async Task SaveCategoryChangesAsync()
        {
            await serializerCategoryObject.CategorySerializerAsync(listOfCategories);
        }

        public async Task UpdateCategoryAsync(int index, Category categoryObejct)
        {
            if (index >= 0)
            {
                listOfCategories[index] = categoryObejct;
            }
            await SaveCategoryChangesAsync();
        }

        public async Task<int> GetCategoryIndexAsync(string name)
        {
            int index = 0;
            List<Category> listOfCategory = await GetCurrentCategoriesAsync();
            foreach(Category categoryObject in listOfCategory)
            {
                if (categoryObject.Name.Equals(name))
                {
                    break;
                }
                index++;
            }
            return index;
        }
    }
}
