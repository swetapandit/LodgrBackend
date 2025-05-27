using HotelManagementSystem.ModelLayer;
using HotelManagementSystem.ModelLayer.Model;

namespace HotelManagementSystem.BusinessLayer.Interface
{
    public interface IStaffBL
    {   

        public ResponseModel<Staff> UpdateStaff(int id, StaffRequest staff);
        public ResponseModel<Staff> AddStaff(StaffRequest staff);
        public ResponseModel<Staff> GetStaffById(int id);
        public ResponseModel<List<Staff>> GetAllStaff();
        public ResponseModel<Staff> DeleteStaff(int id);
    }

}