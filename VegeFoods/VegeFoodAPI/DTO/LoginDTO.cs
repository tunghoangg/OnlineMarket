using System.ComponentModel.DataAnnotations;

namespace VegeFoodAPI.DTO
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "UserName is a required field.")]
        [StringLength(50)]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is a required field.")]
        public string Password { get; set; }
    }
    public class RegistorDTO
    {
        public string username {  get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string fullName { get; set; }
    }
}
