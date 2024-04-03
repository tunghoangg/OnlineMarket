using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface ICategoryRepository
    {
        void CreateCategory(Category c);
        void DeleteCategory(Category c);
        void UpdateCategory(Category c);
        List<Category> GetCategories();
        Category FindCategoryById(int cId);
    }
}
