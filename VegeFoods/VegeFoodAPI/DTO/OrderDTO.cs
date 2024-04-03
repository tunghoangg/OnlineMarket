using BusinessObjects;

namespace VegeFoodAPI.DTO
{
    public class OrderDTO
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public string OrderDate { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public DateTime? ShipDate { get; set; }
        public string Status { get; set; }
        public virtual User? Customer { get; set; }
    }

    public class CreateOrderDTOForCustomer
    {
        public int CustomerId { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
    public class OrderDetailDTOCreate { 
        public int productId {  get; set; }
        public int quantity { get; set; }   
    }
    public class OrderResponse
    {
        public List<OrderDTO> Orders { get; set; } = new List<OrderDTO>();
        public int Pages { get; set; }
        public int CurrentPage { get; set; }
    }

    public class OrderAdminDTO
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public string OrderDate { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string ShipDate { get; set; }
        public string Status { get; set; }
    }
}
