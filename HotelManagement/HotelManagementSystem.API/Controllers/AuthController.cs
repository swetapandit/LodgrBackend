using HotelManagementSystem.BusinessLayer.Interface;
using HotelManagementSystem.ModelLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

#nullable disable
namespace HotelManagementSystem.API.Controllers
{
    [ApiController]
    [Route("/api/auth/")]
    public class AuthController : ControllerBase
    {
        private readonly IUserBL userBL;
        public AuthController(IUserBL _userBL)
        {
            userBL = _userBL;
        }

        [Authorize(Roles = "Owner")]
        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser(RegisterRequest registerRequest)
        {
            if (registerRequest == null)
            {
                return BadRequest(new { 
                    success = false, 
                    message = "Invalid request data provided!"
                });
            }

            try
            {
                var result = await userBL.RegisterUser(registerRequest);
                if (result != null && result.Success)
                {
                    return Ok(new { 
                        success = true, 
                        message = result.Message, 
                        data = result.Data 
                    });
                }
                else
                {
                    return BadRequest(new { 
                        success = false, 
                        message = result?.Message ?? "Registration failed!"
                    });
                }
            }
            catch (Exception ex)
            {
                // Log the exception (use a logging framework)
                return StatusCode(500, new { 
                    success = false, 
                    message = "An error occurred while processing your request."
                });
            }
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult LoginUser(LoginRequest loginRequest)
        {
            if (loginRequest == null || string.IsNullOrEmpty(loginRequest.Email) || string.IsNullOrEmpty(loginRequest.Password))
            {
                return BadRequest(new { success = false, message = "Email and Password are required!"});
            }

            try
            {
                var result = userBL.LoginUser(loginRequest);
                if (result == null)
                {
                    return StatusCode(500, new { 
                        success = false, 
                        message = "An unexpected error occurred during login."
                    });
                }

                if (result.Success)
                {
                    return Ok(new { 
                        success = true, 
                        message = result.Message, 
                        data = result.Data 
                    });
                }
                else
                {
                    return Unauthorized(new { 
                        success = false, 
                        message = result?.Message ?? "Login failed!"
                    });
                }
            }
            catch (Exception ex)
            {
                // Log the exception (use a logging framework)
                return StatusCode(500, new { 
                    success = false, 
                    message = $"An error occurred: {ex.Message}"
                });
            }
        }
    }
}
