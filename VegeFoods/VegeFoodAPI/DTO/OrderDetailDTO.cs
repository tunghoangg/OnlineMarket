﻿using BusinessObjects;

namespace VegeFoodAPI.DTO
{
    public class OrderDetailDTO
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public virtual Product? Product { get; set; }
    }
}
