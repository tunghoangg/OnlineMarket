using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IOrderRepository
    {
        void UpdateOrder(Order o);
        List<Order> GetOrders();
        Order FindOrderById(int oId);
        void AddOrder(Order o);
        List<Order> GetOrdersByAccountId(int accountId);
    }
}
