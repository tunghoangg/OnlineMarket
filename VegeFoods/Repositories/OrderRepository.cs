using BusinessObjects;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class OrderRepository : IOrderRepository
    {
        public void AddOrder(Order o)
        {
            OrderDAO.AddOrder(o);
        }

        public Order FindOrderById(int oId)
        {
            return OrderDAO.FindOrderById(oId);
        }

        public List<Order> GetOrders()
        {
            return OrderDAO.GetOrders();
        }

        public List<Order> GetOrdersByAccountId(int accountId)
        {
            return OrderDAO.GetOrdersByAccountId(accountId);
        }

        public void UpdateOrder(Order o)
        {
            OrderDAO.UpdateOrder(o);
        }
    }
}
