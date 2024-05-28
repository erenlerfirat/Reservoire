namespace Domain.Dtos
{
    public class ReservationRequest
    {
        public int BusinessOwnerUserId { get; set; }
        public int UserId { get; set; }
        public string Description { get; set; }
        public DateTime ReservationDate { get; set; }
    }
}
