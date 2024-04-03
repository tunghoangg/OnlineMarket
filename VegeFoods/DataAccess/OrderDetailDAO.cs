using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class OrderDetailDAO
    {
        //public List<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
        public static List<OrderDetail> ViewOrderDetails(int orderId)
        {
            List<OrderDetail> o = new List<OrderDetail>();
            try
            {
                using (var context = new VegeFoodDBContext())
                {
                    o = context.OrderDetails.Include(p => p.Product).Where(x => x.OrderId == orderId).ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return o;
        }
        public static void AddOrderDetails(List<OrderDetail> o) 
        {
            try
            {
                using (var context = new VegeFoodDBContext())
                {
                    context.OrderDetails.AddRange(o);
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
