using BusinessObjects;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        public void CreateCategory(Category c)
        {
            CategoryDAO.CreateCategory(c);
        }

        public void DeleteCategory(Category c)
        {
            CategoryDAO.DeleteCategory(c);
        }

        public Category FindCategoryById(int cId)
        {
            return CategoryDAO.FindCategoryById(cId);
        }

        public List<Category> GetCategories()
        {
            return CategoryDAO.GetCategories();
        }

        public void UpdateCategory(Category c)
        {
            CategoryDAO.UpdateCategory(c);
        }
    }
}
