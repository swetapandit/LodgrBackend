using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class ReservationRooms
{
    [Key, Column(Order = 0)]
    public int ReservationId { get; set; }
    [ForeignKey("ReservationId")]
    public Reservation? Reservation { get; set; }
    
    [Key, Column(Order = 1)]
    public int RoomId { get; set; }
    [ForeignKey("RoomId")]
    public Room? Room { get; set; }
}
