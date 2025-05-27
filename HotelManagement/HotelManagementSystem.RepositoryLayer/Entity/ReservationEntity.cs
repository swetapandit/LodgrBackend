using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Reservation
{
    [Key]
    public int ReservationId { get; set; }

    [DataType(DataType.Date)]
    public DateTime CheckIn { get; set; }

    [DataType(DataType.Date)]
    public DateTime CheckOut { get; set; }

    [DataType(DataType.Date)]
    public DateTime CreatedAt { get; set; }

    [Range(1, int.MaxValue)]
    public int NumberOfMembers { get; set; }

    [Required]
    public ReservationStatusEnum Status { get; set; }

    [Range(1, int.MaxValue)]
    public int NumberOfNights { get; set; }

    public int UserId { get; set; }
    [ForeignKey("UserId")]
    public User? User { get; set; }
    public ICollection<ReservationGuests> ReservationGuests { get; set; } = new List<ReservationGuests>();
}

public enum ReservationStatusEnum
{
    Pending,
    Confirmed,
}
