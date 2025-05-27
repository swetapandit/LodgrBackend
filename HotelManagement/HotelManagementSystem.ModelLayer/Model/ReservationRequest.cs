namespace HotelManagementSystem.ModelLayer.Model
{
    public class ReservationRequest
    {
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int NumberOfMembers { get; set; }
        public int NumberOfNights { get; set; }
        public int CreatedAt { get; set; }
        public int UserId { get; set; }
    }
}