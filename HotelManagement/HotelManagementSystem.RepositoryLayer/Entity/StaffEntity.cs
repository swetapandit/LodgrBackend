using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Staff
{
    [Key]
    public int StaffId { get; set; }

    [Required]
    public int DepartmentId { get; set; }
    [ForeignKey("DepartmentId")]
    public DepartmentEntity? Department { get; set; }
    [Required]
    [StringLength(100)]
    public string? Name { get; set; }

    [Range(18, 65)]
    public int Age { get; set; }

    [Phone]
    public string? PhoneNumber { get; set; }

    [EmailAddress]
    public string? Email { get; set; }

    public string? Gender { get; set; }

    [StringLength(200)]
    public string? Address { get; set; }

    [DataType(DataType.Date)]
    public DateTime CreatedAt { get; set; }

    [StringLength(100)]
    public string? Designation { get; set; }

    [StringLength(20)]
    public string? NIC { get; set; }

    [Range(0, int.MaxValue)]
    public int Salary { get; set; }

    // public ICollection<Staff>? Staffs { get; set; }

}
