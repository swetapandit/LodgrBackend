using System;
using System.Collections.Generic;
using HotelManagementSystem.BusinessLayer.Interface;
using HotelManagementSystem.ModelLayer;
using HotelManagementSystem.ModelLayer.Model;
using HotelManagementSystem.RepositoryLayer.Interface;

namespace HotelManagementSystem.BusinessLayer.Services
{
    public class StaffBL : IStaffBL
    {
        private readonly IStaffRL _staffRL;
        public StaffBL(IStaffRL staffRL)
        {
            _staffRL = staffRL;
        }
        
        public ResponseModel<Staff> AddStaff(StaffRequest staff)
        {
            return _staffRL.AddStaff(staff);            
        }
        public ResponseModel<Staff> DeleteStaff(int id)
        {
            return _staffRL.DeleteStaff(id);
        }
        public ResponseModel<List<Staff>> GetAllStaff()
        {
            return _staffRL.GetAllStaff();
        }
        
        public ResponseModel<Staff> UpdateStaff(int id, StaffRequest staff)
        {
            return _staffRL.UpdateStaff(id, staff);
        }
        public ResponseModel<Staff> GetStaffById(int id)
        {
            return _staffRL.GetStaffById(id);
        }
    }
}