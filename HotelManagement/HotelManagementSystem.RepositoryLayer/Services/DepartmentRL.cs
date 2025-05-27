using System;
using System.Collections.Generic;
using HotelManagementSystem.ModelLayer;
using HotelManagementSystem.ModelLayer.Model;
using HotelManagementSystem.RepositoryLayer.Interface;

namespace HotelManagementSystem.RepositoryLayer.Services
{
    public class DepartmentRL : IDepartmentRL
    {
        private readonly HotelManagementContext context;
        public DepartmentRL(HotelManagementContext _context)
        {
            context = _context;
        }

        public ResponseModel<DepartmentEntity> AddDepartment(AddDepartmentRequest departmentEntity)
        {
            var existingDepartment = context.Departments.FirstOrDefault(d => d.Name == departmentEntity.Name);
            if (existingDepartment != null)
            {
                return new ResponseModel<DepartmentEntity>
                {
                    Success = false,
                    Message = "Department already exists."
                };
            }
            var newDepartment = new DepartmentEntity
            {
                Name = departmentEntity.Name,
                Description = departmentEntity.Description
            };
            context.Departments.Add(newDepartment);
            context.SaveChanges();
            return new ResponseModel<DepartmentEntity>
            {
                Data = newDepartment,
                Success = true,
                Message = "Department added successfully."
            };
        }

        public ResponseModel<DepartmentEntity> UpdateDepartment(int id, AddDepartmentRequest departmentEntity)
        {
            var existingDepartment = context.Departments.Find(id);
            if (existingDepartment == null)
            {
                return new ResponseModel<DepartmentEntity>
                {
                    Success = false,
                    Message = "Department not found."
                };
            }
            existingDepartment.Name = departmentEntity.Name;
            existingDepartment.Description = departmentEntity.Description;
            context.SaveChanges();
            return new ResponseModel<DepartmentEntity>
            {
                Data = existingDepartment,
                Success = true,
                Message = "Department updated successfully."
            };
        }

        public ResponseModel<DepartmentEntity> GetDepartmentById(int id)
        {
            var department = context.Departments.Find(id);
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
                Data = department,
                Success = true,
                Message = "Department retrieved successfully."
            };
        }

        public ResponseModel<List<DepartmentEntity>> GetAllDepartments()
        {
            var departments = context.Departments.ToList();
            if (departments == null || departments.Count == 0)
            {
                return new ResponseModel<List<DepartmentEntity>>
                {
                    Success = false,
                    Message = "No departments found."
                };
            }
            return new ResponseModel<List<DepartmentEntity>>
            {
                Data = departments,
                Success = true,
                Message = "Departments retrieved successfully."
            };
        }

        public ResponseModel<DepartmentEntity> DeleteDepartment(int id)
        {
            var department = context.Departments.Find(id);
            if (department == null)
            {
                return new ResponseModel<DepartmentEntity>
                {
                    Success = false,
                    Message = "Department not found."
                };
            }
            context.Departments.Remove(department);
            context.SaveChanges();
            return new ResponseModel<DepartmentEntity>
            {
                Data = department,
                Success = true,
                Message = "Department deleted successfully."
            };
        }
    }
}