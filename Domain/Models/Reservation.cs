using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
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
