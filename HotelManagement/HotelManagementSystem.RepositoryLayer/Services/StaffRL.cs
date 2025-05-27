using System;
using System.Collections.Generic;
using HotelManagementSystem.ModelLayer;
using HotelManagementSystem.ModelLayer.Model;
using HotelManagementSystem.RepositoryLayer.Interface;

namespace HotelManagementSystem.RepositoryLayer.Services
{
    public class StaffRL : IStaffRL
    {
        private readonly HotelManagementContext context;
        public StaffRL(HotelManagementContext _context)
        {
            context = _context;
        }

        // Example method to add staff
        public ResponseModel<Staff> AddStaff(StaffRequest staff)
        {
            // Check if the department exists
            var existingDepartment = context.Departments.FirstOrDefault(d => d.DepartmentId == staff.DepartmentId);
            if (existingDepartment == null)
            {
                return new ResponseModel<Staff>
                {
                    Data = null,
                    Success = false,
                    Message = "The specified department does not exist. Please create the department first."
                };
            }

            // Check if the staff already exists
            var existingStaff = context.Staffs.FirstOrDefault(s => s.Email == staff.Email);
            if (existingStaff != null)
            {
                return new ResponseModel<Staff>
                {
                    Data = null,
                    Success = false,
                    Message = "Staff already exists"
                };
            }

            // Create a new staff object
            var newStaff = new Staff
            {
                DepartmentId = staff.DepartmentId,
                Name = staff.Name,
                Email = staff.Email,
                Designation = staff.Designation,
                Salary = staff.Salary,
                
            };

            // Add the new staff to the database
            context.Staffs.Add(newStaff);
            context.SaveChanges();

            return new ResponseModel<Staff>
            {
                Data = newStaff,
                Success = true,
                Message = "Staff added successfully"
            };
        }

        public ResponseModel<Staff> UpdateStaff(int id, StaffRequest staff)
        {
            // Check if the staff exists
            var existingStaff = context.Staffs.FirstOrDefault(s => s.StaffId == id);
            if (existingStaff == null)
            {
                return new ResponseModel<Staff>
                {
                    Data = null,
                    Success = false,
                    Message = "Staff not found"
                };
            }

            // Update the staff details
            existingStaff.Name = staff.Name;
            existingStaff.Email = staff.Email;
            existingStaff.Designation = staff.Designation;
            existingStaff.Salary = staff.Salary;
            
            context.Staffs.Update(existingStaff);
            context.SaveChanges();

            return new ResponseModel<Staff>
            {
                Data = existingStaff,
                Success = true,
                Message = "Staff updated successfully"
            };
        }
        public ResponseModel<Staff> GetStaffById(int id)
        {
            // Check if the staff exists
            var existingStaff = context.Staffs.FirstOrDefault(s => s.StaffId == id);
            if (existingStaff == null)
            {
                return new ResponseModel<Staff>
                {
                    Data = null,
                    Success = false,
                    Message = "Staff not found"
                };
            }

            return new ResponseModel<Staff>
            {
                Data = existingStaff,
                Success = true,
                Message = "Staff retrieved successfully"
            };
        }
        public ResponseModel<List<Staff>> GetAllStaff()
        {
            var staffList = context.Staffs.ToList();
            if (staffList == null || staffList.Count == 0)
            {
                return new ResponseModel<List<Staff>>
                {
                    Data = null,
                    Success = false,
                    Message = "No staff found"
                };
            }

            return new ResponseModel<List<Staff>>
            {
                Data = staffList,
                Success = true,
                Message = "Staff retrieved successfully"
            };
        }

        public ResponseModel<Staff> DeleteStaff(int id)
        {
            // Check if the staff exists
            var existingStaff = context.Staffs.FirstOrDefault(s => s.StaffId == id);
            if (existingStaff == null)
            {
                return new ResponseModel<Staff>
                {
                    Data = null,
                    Success = false,
                    Message = "Staff not found"
                };
            }

            // Remove the staff from the database
            context.Staffs.Remove(existingStaff);
            context.SaveChanges();

            return new ResponseModel<Staff>
            {
                Data = existingStaff,
                Success = true,
                Message = "Staff deleted successfully"
            };
        }
    }
}