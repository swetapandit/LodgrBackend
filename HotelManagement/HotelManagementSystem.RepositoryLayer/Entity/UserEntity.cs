using System.ComponentModel.DataAnnotations;

public enum UserRole
{
    Owner,
    Manager,
    Receptionist
}

public class User
{
    [Key]
    public int UserId { get; set; }

    [Required]
    [StringLength(100)]
    public string? UserName { get; set; }

    [Range(0, 120)]
    public int Age { get; set; }

    [Phone]
    public string? PhoneNumber { get; set; }

    [Required]
    public UserRole Role { get; set; }

    [EmailAddress]
    public string? Email { get; set; }

    public string? Gender { get; set; }

    [Required]
    [StringLength(100)]
    public string? Password { get; set; }

    [StringLength(200)]
    public string? Address { get; set; }

    [StringLength(20)]
    public string? NIC { get; set; }

    [Range(0, int.MaxValue)]
    public int Salary { get; set; }

    [DataType(DataType.Date)]
    public DateTime CreatedAt { get; set; }
}
