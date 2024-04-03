using BusinessObjects;

namespace VegeFoodAPI.DTO
{
    public class UserDTO
    {
        public int AccountId { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string role { get; set; }
    }

    public class UserResponse
    {
        public List<UserDTO> Users { get; set; } = new List<UserDTO>();
        public int Pages { get; set; }
        public int CurrentPage { get; set; }
    }
}
