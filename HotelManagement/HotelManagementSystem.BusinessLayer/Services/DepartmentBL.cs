using System;
using System.Collections.Generic;
using Azure;
using HotelManagementSystem.BusinessLayer.Interface;
using HotelManagementSystem.ModelLayer;
using HotelManagementSystem.ModelLayer.Model;
using HotelManagementSystem.RepositoryLayer.Interface;

namespace HotelManagementSystem.BusinessLayer.Services
{
    public class DepartmentBL : IDepartmentBL
    {
        private readonly IDepartmentRL _departmentRL;
        public DepartmentBL(IDepartmentRL departmentRL)
        {
            _departmentRL = departmentRL;
        }
    
        public ResponseModel<DepartmentEntity> AddDepartment(AddDepartmentRequest departmentEntity)
        {
            return _departmentRL.AddDepartment(departmentEntity);
        }

        public ResponseModel<DepartmentEntity> UpdateDepartment(int id, AddDepartmentRequest departmentEntity)
        {
            return _departmentRL.UpdateDepartment(id, departmentEntity);
        }

        public ResponseModel<DepartmentEntity> GetDepartmentById(int id)
        {
            var department = _departmentRL.GetDepartmentById(id);
            if (department == null)
            {
                return new ResponseModel<DepartmentEntity>
                {
                    Success = false,
                    Message = "Department not found."
                };
            }
            return new ResponseModel<DepartmentEntity>
            {
                Data = department.Data,
                Success = true,
                Message = "Department retrieved successfully."
            };
        }

        public ResponseModel<List<DepartmentEntity>> GetAllDepartments()
        {
            var departments = _departmentRL.GetAllDepartments();
            if (departments == null || departments.Data == null || departments.Data.Count == 0)
            {
                return new ResponseModel<List<DepartmentEntity>>
                {
                    Success = false,
                    Message = "No departments found."
                };
            }
            return new ResponseModel<List<DepartmentEntity>>
            {
                Data = departments.Data,
                Success = true,
                Message = "Departments retrieved successfully."
            };
        }

        public ResponseModel<DepartmentEntity> DeleteDepartment(int id)
        {
            var department = _departmentRL.GetDepartmentById(id);
            if (department == null || !department.Success)
            {
                return new ResponseModel<DepartmentEntity>
                {
                    Success = false,
                    Message = "Department not found."
                };
            }
            _departmentRL.DeleteDepartment(id);
            return new ResponseModel<DepartmentEntity>
            {
                Success = true,
                Message = "Department deleted successfully."
            };
        }
    }
}