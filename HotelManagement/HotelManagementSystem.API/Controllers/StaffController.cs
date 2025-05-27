using HotelManagementSystem.BusinessLayer.Interface;
using HotelManagementSystem.ModelLayer.Model;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagementSystem.API.Controllers
{
    [ApiController]
    [Route("api/staff")]
    public class StaffController : ControllerBase
    {
        private readonly IStaffBL staffBL;
        public StaffController(IStaffBL _staffBL)
        {
            staffBL = _staffBL;
        }

        [HttpPost]
        public IActionResult CreateStaff(StaffRequest staff)
        {
            if (staff == null)
            {
                return BadRequest(new { 
                    Success = false, 
                    Message = "Invalid staff data"
                });
            }

            if (staff.DepartmentId <= 0)
            {
                return BadRequest(new { 
                    Success = false, 
                    Message = "A valid DepartmentId is required."
                });
            }

            try
            {
                var result = staffBL.AddStaff(staff);
                if (result == null || !result.Success)
                {
                    return BadRequest(new { 
                        Success = false, 
                        Message = result?.Message ?? "Failed to add staff!"
                    });
                }

                return Ok(new { 
                    Success = true, 
                    Message = "Staff added successfully!", 
                    Data = result.Data 
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { 
                    Success = false, 
                    Message = $"Internal server error: {ex.Message}"
                });
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStaff(int id, StaffRequest staff)
        {
            if (staff == null || id <= 0)
            {
                return BadRequest(new { 
                    Success = false, 
                    Message = "Invalid staff data or ID"
                });
            }

            try
            {
                var result = staffBL.UpdateStaff(id, staff);
                if (result == null || !result.Success)
                {
                    return BadRequest(new { 
                        Success = false, 
                        Message = result?.Message ?? "Failed to update staff!"
                    });
                }
                return Ok(new { 
                    Success = true, 
                    Message = "Staff updated successfully!", 
                    Data = result.Data 
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { 
                    Success = false, 
                    Message = $"Internal server error: {ex.Message}"
                });
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetStaffById(int id)
        {
            if (id <= 0)
            {
                return BadRequest(new { 
                    Success = false, 
                    Message = "Invalid staff ID"
                });
            }

            try
            {
                var result = staffBL.GetStaffById(id);
                if (result == null || !result.Success)
                {
                    return NotFound(new { 
                        Success = false, 
                        Message = result?.Message ?? "Staff not found!"
                    });
                }
                return Ok(new { 
                    Success = true, 
                    Message = "Staff retrieved successfully!", 
                    Data = result.Data 
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { 
                    Success = false, 
                    Message = $"Internal server error: {ex.Message}"
                });
            }
        }

        [HttpGet]
        public IActionResult GetAllStaff()
        {
            try
            {
                var result = staffBL.GetAllStaff();
                if (result == null || !result.Success)
                {
                    return NotFound(new { 
                        Success = false, 
                        Message = result?.Message ?? "No staff found!"
                    });
                }
                return Ok(new { 
                    Success = true, 
                    Message = "Staff retrieved successfully!", 
                    Data = result.Data 
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { 
                    Success = false, 
                    Message = $"Internal server error: {ex.Message}"
                });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStaff(int id)
        {
            if (id <= 0)
            {
                return BadRequest(new { 
                    Success = false, 
                    Message = "Invalid staff ID"
                });
            }

            try
            {
                var result = staffBL.DeleteStaff(id);
                if (result == null || !result.Success)
                {
                    return NotFound(new { 
                        Success = false, 
                        Message = result?.Message ?? "Staff not found!"
                    });
                }
                return Ok(new { 
                    Success = true, 
                    Message = "Staff deleted successfully!"
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { 
                    Success = false, 
                    Message = $"Internal server error: {ex.Message}"
                });
            }
        }
    }
}
