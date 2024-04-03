using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AccountId { get; set; }

        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is a required field.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Fullname is a required field.")]
        public string FullName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string? Address { get; set; }

        [Required(ErrorMessage = "Phone is a required field.")]
        [MaxLength(10, ErrorMessage = "Phone number must include 10 digits")]
        public string Phone { get; set; }

        [Required]
        public string role { get; set; }
    }
}
