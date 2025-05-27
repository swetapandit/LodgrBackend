using System.ComponentModel.DataAnnotations;

public class Room
{
    [Key]
    public int RoomId { get; set; }

    [Required]
    public RoomTypeEnum RoomType { get; set; }

    [Range(0, int.MaxValue)]
    public int RatePerNight { get; set; }

    public bool IsAvailable { get; set; } = true;

    [Required]
    [Range(1, int.MaxValue)]
    public int RoomNumber { get; set; }
}

public enum RoomTypeEnum
{
    Economy,
    Deluxe,
    Luxurious
}
