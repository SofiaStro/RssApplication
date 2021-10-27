using DataAccessLayer.Repositories;
using Models.Classes;
using System;
using System.Collections.Generic;

namespace BusinessLayer.Services
{
    public class CategoryService
    { 
        ICategoryRepository<Category> categoryRepository;

        public CategoryService()
        {
            categoryRepository = new CategoryRepository();
        }

        public void Create(string name)
        {
            Category newCategory = null;

            newCategory = new Category(name);

            categoryRepository.Create(newCategory);
        }

        public void Delete(string name)
        {
            int index = categoryRepository.GetIndex(name);
            categoryRepository.Delete(index);
        }

        public List<string> InputCategory()
        {
            List<string> catagoryNames = new List<string>();
            try
            {
                List<Category> listOfCategorys = categoryRepository.GetCurrentCategorys();
                
                int index = 0;

                foreach (Category item in listOfCategorys)
                {
                    catagoryNames.Add(item.Name);
                    index++;
                }
            }
            catch (Exception) { }
            
            return catagoryNames;
        }

        public void ChangeCategoryName(string oldName, string newName)
        {
            int index = categoryRepository.GetIndex(oldName);

            Category newCategory = new Category(newName);
            categoryRepository.Update(index, newCategory);
        }
    }    
}
