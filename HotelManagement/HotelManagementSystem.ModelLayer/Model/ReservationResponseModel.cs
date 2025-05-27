using HotelManagementSystem.ModelLayer.Model;

public class ReservationResponseModel
{
    public int ReservationId { get; set; }
    public DateTime CheckIn { get; set; }
    public DateTime CheckOut { get; set; }
    public int NumberOfMembers { get; set; }
    public int NumberOfNights { get; set; }
    public DateTime CreatedAt { get; set; }
    public int UserId { get; set; }
    public List<GuestsRequest> Guests { get; set; }
    public List<RoomRequest> Rooms { get; set; }
}