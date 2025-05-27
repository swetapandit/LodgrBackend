using System.ComponentModel.DataAnnotations;

public class DepartmentEntity
{
    [Key]
    public int DepartmentId { get; set; }
    [Required]
    public string? Name { get; set; }
    public string? Description { get; set; }
}
