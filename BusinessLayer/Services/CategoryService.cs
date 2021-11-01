using DataAccessLayer.Repositories;
using Models.Classes;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace BusinessLayer.Services
{
    public class CategoryService
    {
        ICategoryRepository<Category> categoryRepository;

        public CategoryService()
        {
            categoryRepository = new CategoryRepository();
        }

        public async Task CreateCategoryAsync(string name)
        {
            Category newCategory = null;

            newCategory = new Category(name);

            await categoryRepository.CreateCategoryAsync(newCategory);
        }

        public async Task DeleteCategoryAsync(string name)
        {
            int index = await categoryRepository.GetCategoryIndexAsync(name);
            await categoryRepository.DeleteCategoryAsync(index);
        }

        public async Task<List<string>> GetListOfCategoryNamesAsync()
        {
            List<string> listOfCategoryNames = new List<string>();
            try
            {
                List<Category> listOfCategories = await categoryRepository.GetCurrentCategoriesAsync();
                listOfCategoryNames = listOfCategories.Select(category => category.Name).ToList();
            }
            catch (Exception) { }

            return listOfCategoryNames;
        }

        public async Task ChangeCategoryNameAsync(string oldName, string newName)
        {
            try
            {
                int index = await categoryRepository.GetCategoryIndexAsync(oldName);

                Category newCategory = new Category(newName);
                await categoryRepository.UpdateCategoryAsync(index, newCategory);
            }
            catch (Exception) { }

        }
    }  
}
