using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    [Table("UserAddress", Schema = "app")]
    public class UserAddress : BaseModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Description { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int PostalCode { get; set; }
    }
}
