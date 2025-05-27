using HotelManagementSystem.ModelLayer;
using HotelManagementSystem.ModelLayer.Model;

namespace HotelManagementSystem.BusinessLayer.Interface
{
    public interface IDepartmentBL
    {
        public ResponseModel<DepartmentEntity> AddDepartment(AddDepartmentRequest departmentEntity);
        public ResponseModel<DepartmentEntity> UpdateDepartment(int id, AddDepartmentRequest departmentEntity);

        public ResponseModel<List<DepartmentEntity>> GetAllDepartments();
        public ResponseModel<DepartmentEntity> GetDepartmentById(int id);
        public ResponseModel<DepartmentEntity> DeleteDepartment(int id);
    }
}