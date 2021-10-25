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
            
                //return names;

            }
            catch (Exception) { }
            
            return catagoryNames;
            
        }
    }    
}
