using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class ReservationGuests
{
    [Key, Column(Order = 0)]
    public int ReservationId { get; set; }
    public Reservation? Reservation { get; set; }

    [Key, Column(Order = 1)]
    public int GuestId { get; set; }
    public Guest? Guest { get; set; }
}