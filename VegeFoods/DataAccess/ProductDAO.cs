using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ProductDAO
    {
        public static List<Product> GetProducts()
        {
            var listProducts = new List<Product>();
            try
            {
                using (var context = new VegeFoodDBContext())
                {
                    listProducts = context.Products.Include(c => c.Category).ToList();

                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return listProducts;
        }

        public static Product FindProductById(int proId)
        {
            Product p = new Product();
            try
            {
                using (var context = new VegeFoodDBContext())
                {
                    p = context.Products.Include(c => c.Category).SingleOrDefault(x => x.ProductId == proId);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return p;
        }

        public static List<Product> SearchProductByName(string name)
        {
            List<Product> products = new List<Product>();
            try
            {
                using (var context = new VegeFoodDBContext())
                {
                    products = context.Products.Include(c => c.Category).Where(x => x.ProductName.Contains(name)).ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return products;
        }

        public static void SaveProduct(Product p)
        {
            try
            {
                using (var context = new VegeFoodDBContext())
                {
                    context.Products.Add(p);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void UpdateProduct(Product p)
        {
            try
            {
                using (var context = new VegeFoodDBContext())
                {
                    context.Entry<Product>(p).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void DeleteProduct(Product p)
        {
            try
            {
                using (var context = new VegeFoodDBContext())
                {
                    var p1 = context.Products.SingleOrDefault(
                        c => c.ProductId == p.ProductId);
                    context.Products.Remove(p1);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
