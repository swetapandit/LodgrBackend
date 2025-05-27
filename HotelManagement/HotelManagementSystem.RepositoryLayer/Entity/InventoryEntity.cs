using System.ComponentModel.DataAnnotations;

public class InventoryEntity
{
    [Key]
    public int InventoryId { get; set; }

    [Required]
    public int RoomId { get; set; }

    public Room? Room { get; set; }

    [Required]
    [StringLength(100)]
    public string? ItemName { get; set; }

    [Range(0, int.MaxValue)]
    public int Quantity { get; set; }
}
