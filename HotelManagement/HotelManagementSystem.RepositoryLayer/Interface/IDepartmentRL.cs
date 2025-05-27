using System.Collections.Generic;
using HotelManagementSystem.ModelLayer;
using HotelManagementSystem.ModelLayer.Model;

namespace HotelManagementSystem.RepositoryLayer.Interface
{
    public interface IDepartmentRL
    {
        public ResponseModel<DepartmentEntity> AddDepartment(AddDepartmentRequest departmentEntity);
        
        public ResponseModel<List<DepartmentEntity>> GetAllDepartments();
        public ResponseModel<DepartmentEntity> GetDepartmentById(int id);
        public ResponseModel<DepartmentEntity> UpdateDepartment(int id, AddDepartmentRequest departmentEntity);
        public ResponseModel<DepartmentEntity> DeleteDepartment(int id);
    }
}