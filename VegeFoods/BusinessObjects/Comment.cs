using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class Comment
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CommentId { get; set; }
        [Required]
        public int AccountId{ get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public string CommentText { get; set; }
        [Required]
        public int Rating { get; set; }

        public virtual Product? Product { get; set; }
        public virtual User? User { get; set; }
    }
}
