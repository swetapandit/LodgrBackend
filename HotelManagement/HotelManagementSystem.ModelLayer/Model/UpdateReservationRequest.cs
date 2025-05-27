namespace HotelManagementSystem.ModelLayer.Model
{
    public class UpdateReservationRequest
    {
        public int ReservationId { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int NumberOfMembers { get; set; }
        public int NumberOfNights { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now.Date;
    }
}