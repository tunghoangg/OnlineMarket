using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class Order
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }
        [Required]
        public int CustomerId { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        [Required(ErrorMessage = "Address is a required field.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Phone is a required field.")]
        [MaxLength(10, ErrorMessage = "Phone number must include 10 digits")]
        public string Phone { get; set; }

        public DateTime? ShipDate { get; set; }

        [Required]
        public string Status { get; set; }

        public virtual User? Customer { get; set; }
    }
}
