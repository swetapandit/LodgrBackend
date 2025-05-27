using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Guest
{
    [Key]
    public int GuestId { get; set; }

    [Required]
    [StringLength(100)]
    public string? Name { get; set; }

    [Range(0, 120)]
    public int Age { get; set; }

    [Phone]
    public string? PhoneNumber { get; set; }

    [EmailAddress]
    public string? Email { get; set; }

    public string? Gender { get; set; }

    [StringLength(200)]
    public string? Address { get; set; }

    public DateTime CreatedAt { get; set; }

    [StringLength(50)]
    public string? MemberCode { get; set; }
}