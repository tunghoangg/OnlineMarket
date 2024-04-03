using BusinessObjects;

namespace VegeFoodAPI.DTO
{
    public class ProductDTO
    {
        public string ProductName { get; set; }
        public int CategoryId{ get; set; }
        public int UnitInStock { get; set; }
        public decimal UnitPrice { get; set; }
        public string ProductImage { get; set; }
        public string Description { get; set; }
    }

    public class ProductResponse
    {
        public List<Product> Products { get; set; } = new List<Product>();
        public int Pages { get; set; }
        public int CurrentPage { get; set; }
    }
}
