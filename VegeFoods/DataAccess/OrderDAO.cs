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
    public class OrderDAO
    {
        public static List<Order> GetOrders()
        {
            var listOrders = new List<Order>();
            try
            {
                using (var context = new VegeFoodDBContext())
                {
                    listOrders = context.Orders.Include(c => c.Customer).ToList();

                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return listOrders;
        }

        public static void UpdateOrder(Order o)
        {
            try
            {
                using (var context = new VegeFoodDBContext())
                {
                    context.Entry<Order>(o).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static Order FindOrderById(int oId)
        {
            Order o = new Order();
            try
            {
                using (var context = new VegeFoodDBContext())
                {
                    o = context.Orders.SingleOrDefault(x => x.OrderId == oId);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return o;
        }
        public static void AddOrder(Order o)
        {
            try
            {
                using (var context = new VegeFoodDBContext())
                {
                    context.Orders.Add(o);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static List<Order> GetOrdersByAccountId(int accountId)
        {
            var listOrders = new List<Order>();
            try
            {
                using (var context = new VegeFoodDBContext())
                {
                    listOrders = context.Orders.Where(x => x.CustomerId == accountId).ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return listOrders;
        }
    }
}
