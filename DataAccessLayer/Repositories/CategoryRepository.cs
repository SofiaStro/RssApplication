using Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            listOfCategorys = GetCurrentCategorys();
        }
        public void Create(Category categoryObject)
        {
            listOfCategorys.Add(categoryObject);
            SaveChanges();
        }

        public void Delete(int index)
        {
            listOfCategorys.RemoveAt(index);
            SaveChanges();
        }

        public List<Category> GetCurrentCategorys()
        {
            List<Category> listOfCategorysDeserialized = new List<Category>();
            try
            {
                listOfCategorysDeserialized = serializerCategoryObject.CategoryDeserialize();
            }
            catch (Exception)
            {
                //FIXA DENNA!! 

            }

            return listOfCategorysDeserialized;
        }

        public void SaveChanges()
        {
            serializerCategoryObject.CategorySerializer(listOfCategorys);
        }

        public void Update(int index, Category categoryObejct)
        {
            if (index >= 0)
            {
                listOfCategorys[index] = categoryObejct;
            }
            SaveChanges();
        }
    }
}
