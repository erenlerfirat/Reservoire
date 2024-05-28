using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    [Table("Reservation", Schema = "app")]
    public class Reservation : BaseModel
    {
        public int Id { get; set; }
        public int BusinessOwnerUserId { get; set; }
        public int UserId { get; set; }
        public string Description { get; set; }
        public short Status {  get; set; }
        public DateTime ReservationDate { get; set; }
    }
}
