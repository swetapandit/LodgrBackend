using HotelManagementSystem.BusinessLayer.Interface;
using HotelManagementSystem.ModelLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagementSystem.API.Controllers
{
    [Authorize(Roles = "Owner")]
    [ApiController]
    [Route("api/department")]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentBL departmentBL;

        public DepartmentController(IDepartmentBL _departmentBL)
        {
            departmentBL = _departmentBL;
        }

        [HttpPost]
        public IActionResult CreateDepartment(AddDepartmentRequest departmentEntity)
        {
            if (departmentEntity == null)
            {
                return BadRequest(new { 
                    success = false, 
                    message = "Invalid department data"
                });
            }
            try
            {
                var result = departmentBL.AddDepartment(departmentEntity);
                if (result == null || !result.Success)
                {
                    return BadRequest(new { 
                        success = false, 
                        message = result?.Message ?? "Failed to add department!"
                    });
                }
                return Ok(new { 
                    success = true, 
                    message = "Department added successfully!", 
                    data = result.Data 
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { 
                    success = false, 
                    message = $"Internal server error: {ex.Message}"
                });
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateDepartment(int id, AddDepartmentRequest departmentEntity)
        {
            if (departmentEntity == null || id <= 0)
            {
                return BadRequest(new { 
                    success = false, 
                    message = "Invalid department data"
                });
            }
            try
            {
                var result = departmentBL.UpdateDepartment(id, departmentEntity);
                if (result == null || !result.Success)
                {
                    return BadRequest(new { 
                        success = false, 
                        message = result?.Message ?? "Failed to update department!"
                    });
                }
                return Ok(new { 
                    success = true, 
                    message = "Department updated successfully!", 
                    data = result.Data 
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { 
                    success = false, 
                    message = $"Internal server error: {ex.Message}"
                });
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetDepartment(int id)
        {
            if (id <= 0)
            {
                return BadRequest(new { 
                    success = false, 
                    message = "Invalid department ID"
                });
            }
            try
            {
                var result = departmentBL.GetDepartmentById(id);
                if (result == null || !result.Success)
                {
                    return NotFound(new { 
                        success = false, 
                        message = result?.Message ?? "Department not found!"
                    });
                }
                return Ok(new { 
                    success = true, 
                    message = "Department retrieved successfully!", 
                    data = result.Data 
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { 
                    success = false, 
                    message = $"Internal server error: {ex.Message}"
                });
            }
        }

        [HttpGet]
        public IActionResult GetAllDepartments()
        {
            try
            {
                var result = departmentBL.GetAllDepartments();
                if (result == null || !result.Success)
                {
                    return NotFound(new { 
                        success = false, 
                        message = result?.Message ?? "No departments found!"
                    });
                }
                return Ok(new { 
                    success = true, 
                    message = "Departments retrieved successfully!", 
                    data = result.Data 
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { 
                    success = false, 
                    message = $"Internal server error: {ex.Message}"
                });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDepartment(int id)
        {
            if (id <= 0)
            {
                return BadRequest(new { 
                    success = false, 
                    message = "Invalid department ID"
                });
            }
            try
            {
                var result = departmentBL.DeleteDepartment(id);
                if (result == null || !result.Success)
                {
                    return NotFound(new { 
                        success = false, 
                        message = result?.Message ?? "Department not found!"
                    });
                }
                return Ok(new { 
                    success = true, 
                    message = "Department deleted successfully!"
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { 
                    success = false, 
                    message = $"Internal server error: {ex.Message}"
                });
            }
        }
    }
}
