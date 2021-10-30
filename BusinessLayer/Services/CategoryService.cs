using DataAccessLayer.Repositories;
using Models.Classes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class CategoryService
    { 
        ICategoryRepository<Category> categoryRepository;

        public CategoryService()
        {
            categoryRepository = new CategoryRepository();
        }

        public async Task CreateAsync(string name)
        {
            Category newCategory = null;

            newCategory = new Category(name);

            await categoryRepository.CreateAsync(newCategory);
        }

        public async Task DeleteAsync(string name)
        {
            int index = await categoryRepository.GetIndexAsync(name);
            await categoryRepository.DeleteAsync(index);
        }

        public async Task<List<string>> InputCategoryAsync()
        {
            List<string> catagoryNames = new List<string>();
            try
            {
                List<Category> listOfCategorys = await categoryRepository.GetCurrentCategorysAsync();
                
                //int index = 0;

                foreach (Category item in listOfCategorys)
                {
                    catagoryNames.Add(item.Name);
                    //index++;
                }
            }
            catch (Exception) { }
            
            return catagoryNames;
        }

        public async Task ChangeCategoryNameAsync(string oldName, string newName)
        {
            int index = await categoryRepository.GetIndexAsync(oldName);

            Category newCategory = new Category(newName);
            await categoryRepository.UpdateAsync(index, newCategory);
        }
    }    
}
