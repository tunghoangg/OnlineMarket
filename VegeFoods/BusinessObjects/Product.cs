using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class Product
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }
        [Required]
        [StringLength(40)]
        public string ProductName { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public int UnitInStock { get; set; }
        [Required]
        public decimal UnitPrice { get; set; }
        [Required]
        public string ProductImage { get; set; }
        public string? Description { get; set; }

        public virtual Category? Category { get; set; }

        public static implicit operator Product(Task<Product> v)
        {
            throw new NotImplementedException();
        }
    }
}
