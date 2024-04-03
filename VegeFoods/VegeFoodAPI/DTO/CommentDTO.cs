using BusinessObjects;
using System.ComponentModel.DataAnnotations;

namespace VegeFoodAPI.DTO
{
    public class CommentDTO
    {
        public string CommentText { get; set; }
        public int Rating { get; set; }
    }
    public class CommentResponse
    {
        public List<Comment> Comments { get; set; } = new List<Comment>();
        public int Pages { get; set; }
        public int CurrentPage { get; set; }
    }
}
