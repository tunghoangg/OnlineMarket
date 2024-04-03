using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class CategoryDAO
    {
        public static List<Category> GetCategories()
        {
            var listCategories = new List<Category>();
            try
            {
                using (var context = new VegeFoodDBContext())
                {
                    listCategories = context.Categories.ToList();

                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return listCategories;
        }

        public static void CreateCategory(Category c)
        {
            try
            {
                using (var context = new VegeFoodDBContext())
                {
                    context.Categories.Add(c);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void UpdateCategory(Category c)
        {
            try
            {
                using (var context = new VegeFoodDBContext())
                {
                    context.Entry<Category>(c).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void DeleteCategory(Category c)
        {
            try
            {
                using (var context = new VegeFoodDBContext())
                {
                    var c1 = context.Products.SingleOrDefault(
                        context => context.CategoryId == c.CategoryId);
                    context.Products.Remove(c1);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static Category FindCategoryById(int cId)
        {
            Category c = new Category();
            try
            {
                using (var context = new VegeFoodDBContext())
                {
                    c = context.Categories.SingleOrDefault(x => x.CategoryId == cId);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return c;
        }
    }
}
