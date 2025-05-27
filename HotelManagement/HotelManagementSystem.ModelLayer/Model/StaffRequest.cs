namespace HotelManagementSystem.ModelLayer.Model
{
    public class StaffRequest
    {
        public int StaffId { get; set; }
        public int DepartmentId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Designation { get; set; }
        public int Salary { get; set; }
    }
}