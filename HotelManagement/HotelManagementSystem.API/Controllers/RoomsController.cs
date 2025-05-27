using HotelManagementSystem.BusinessLayer.Interface;
using HotelManagementSystem.ModelLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagementSystem.API.Controllers
{
    [ApiController]
    [Route("api/rooms")]
    [Authorize(Roles = "Manager,Receptionist,Owner")]
    public class RoomsController : ControllerBase
    {
        private readonly IRoomsBL? roomsBL;
        public RoomsController(IRoomsBL? _roomsBL)
        {
            roomsBL = _roomsBL;
        }
        [HttpGet]
        public IActionResult GetAllRooms()
        {
            var rooms = roomsBL?.GetAllRooms();
            if (rooms == null || rooms.Count == 0)
            {
                return NotFound(new { 
                    Success = false, 
                    Message = "No rooms found!" 
                });
            }
            return Ok(new { 
                Success = true, 
                Message = "List of all rooms", 
                Data = rooms 
            });
        }

        [HttpGet("{roomNumber}")]
        [Authorize(Roles = "Manager,Receptionist,Owner")]
        public IActionResult GetRoomById(int roomNumber)
        {
            var room = roomsBL?.GetRoomById(roomNumber);
            if (room == null)
            {
                return NotFound(new { 
                    Success = false, 
                    Message = $"Room with ID {roomNumber} not found!" 
                });
            }
            return Ok(new { 
                Success = true, 
                Message = $"Room Fetched Successfully", 
                Data = room 
            });
        }

        [HttpPost]
        [Authorize(Roles = "Manager")]
        public IActionResult CreateRoom(RoomRequest roomRequest)
        {
            if (roomRequest == null)
            {
                return BadRequest(new { 
                    Success = false, 
                    Message = "Invalid request data!" 
                });
            }

            try
            {
                var result = roomsBL?.AddRoom(roomRequest);
                if (result == null || !result.Success)
                {
                    return BadRequest(new { 
                        Success = false, 
                        Message = result?.Message ?? "Failed to add room!" 
                    });
                }

                return Ok(new { 
                    Success = true, 
                    Message = result.Message, 
                    Data = result.Data 
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { 
                    Success = false, 
                    Message = ex.Message 
                });
            }
        }

        [HttpPut("{roomNumber}")]
        [Authorize(Roles = "Manager")]
        public IActionResult UpdateRoom(int roomNumber, RoomRequest roomRequest)
        {
            if (roomRequest == null)
            {
                return BadRequest(new { 
                    Success = false, 
                    Message = "Invalid request data!" 
                });
            }

            try
            {
                var result = roomsBL?.UpdateRoom(roomNumber, roomRequest);
                if (result == null || !result.Success)
                {
                    return BadRequest(new { 
                        Success = false, 
                        Message = result?.Message ?? "Failed to update room!" 
                    });
                }

                return Ok(new { 
                    Success = true, 
                    Message = result.Message, 
                    Data = result.Data 
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { 
                    Success = false, 
                    Message = ex.Message 
                });
            }
        }

        [HttpDelete("{roomNumber}")]
        [Authorize(Roles = "Manager")]
        public IActionResult DeleteRoom(int roomNumber)
        {
            try
            {
                var result = roomsBL?.DeleteRoom(roomNumber);
                if (result == null || !result.Success)
                {
                    return BadRequest(new { 
                        Success = false, 
                        Message = result?.Message ?? "Failed to delete room!" 
                    });
                }

                return Ok(new { 
                    Success = true, 
                    Message = result.Message 
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { 
                    Success = false, 
                    Message = ex.Message 
                });
            }
        }
    }
}
