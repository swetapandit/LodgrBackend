using HotelManagementSystem.BusinessLayer.Interface;
using HotelManagementSystem.ModelLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagementSystem.API.Controllers
{
    [ApiController]
    [Route("api/guests")]
    [Authorize(Roles = "Receptionist")]
    public class GuestsController : ControllerBase
    {
        private readonly IGuestsBL guestBL;
        public GuestsController(IGuestsBL _guestBL)
        {
            guestBL = _guestBL;
        }

        [HttpPost]
        public IActionResult CreateGuest(GuestsRequest guestRequest)
        {
            if (guestRequest == null || string.IsNullOrEmpty(guestRequest.Name) || string.IsNullOrEmpty(guestRequest.Email))
            {
                return BadRequest(new { 
                    Success = false, 
                    Message = "Invalid guest request."
                });
            }

            var result = guestBL.AddGuest(guestRequest);
            if (result == null || !result.Success)
            {
                return BadRequest(new { 
                    Success = false, 
                    Message = result?.Message
                });
            }

            return Ok(new { 
                Success = true, 
                Message = result.Message, 
                Data = result.Data 
            });
        }

        [HttpPut("{guestId}")]
        public IActionResult UpdateGuest(int guestId, GuestsRequest guestRequest)
        {
            if (guestRequest == null || string.IsNullOrEmpty(guestRequest.Name) || string.IsNullOrEmpty(guestRequest.Email))
            {
                return BadRequest(new { 
                    Success = false, 
                    Message = "Invalid guest request."
                });
            }

            var result = guestBL.UpdateGuest(guestId, guestRequest);
            if (result == null || !result.Success)
            {
                return BadRequest(new { 
                    Success = false, 
                    Message = result?.Message
                });
            }

            return Ok(new { 
                Success = true, 
                Message = result.Message, 
                Data = result.Data 
            });
        }

        [HttpDelete("{guestId}")]
        public IActionResult DeleteGuest(int guestId)
        {
            var result = guestBL.DeleteGuest(guestId);
            if (result == null || !result.Success)
            {
                return BadRequest(new { 
                    Success = false, 
                    Message = result?.Message
                });
            }

            return Ok(new { 
                Success = true, 
                Message = result.Message, 
                Data = result.Data 
            });
        }
    }
}
