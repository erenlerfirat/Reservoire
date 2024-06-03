using Domain.Models;

namespace Domain.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string LastName { get; set; }
        public UserAddress? UserAddress { get; set; }

    }
}
