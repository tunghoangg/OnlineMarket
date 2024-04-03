using BusinessObjects;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        public void AddOrderDetails(List<OrderDetail> order)
        {
          OrderDetailDAO.AddOrderDetails(order);
        }

        public List<OrderDetail> ViewOrderDetails(int orderId)
        {
            return OrderDetailDAO.ViewOrderDetails(orderId);
        }

    }
}
