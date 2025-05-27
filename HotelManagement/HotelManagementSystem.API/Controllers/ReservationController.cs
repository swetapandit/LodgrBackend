using HotelManagementSystem.BusinessLayer.Interface;
using HotelManagementSystem.ModelLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagementSystem.API.Controllers
{
    [Authorize(Roles = "Owner, Manager, Receptionist")]
    [ApiController]
    [Route("api/reservation")]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationBL reservationBL;
        public ReservationController(IReservationBL _reservationBL)
        {
            reservationBL = _reservationBL;
        }

        [HttpPost]
        public IActionResult CreateReservation(ReservationRequest reservationRequest)
        {
            if (reservationRequest == null || reservationRequest.CheckIn == default || reservationRequest.CheckOut == default)
            {
                return BadRequest(new { 
                    Success = false, 
                    Message = "Invalid reservation request." 
                });
            }

            var result = reservationBL.CreateReservation(reservationRequest);
            if (result == null || !result.Success)
            {
                return BadRequest(new { 
                    Success = false, 
                    Message = result?.Message ?? "Failed to create reservation." 
                });
            }

            return Ok(new { Success = true, Message = "Reservation created successfully.", Data = result.Data });
        }

        [HttpPut]
        [Route("{reservationId}")]
        public IActionResult UpdateReservation(int reservationId, UpdateReservationRequest reservationRequest)
        {
            if (reservationRequest == null || reservationRequest.CheckIn == default || reservationRequest.CheckOut == default)
            {
                return BadRequest(new { 
                    Success = false, 
                    Message = "Invalid reservation request." 
                });
            }

            var result = reservationBL.UpdateReservation(reservationId, reservationRequest);
            if (result == null || !result.Success)
            {
                return BadRequest(new { 
                    Success = false, 
                    Message = result?.Message ?? "Failed to update reservation." 
                });
            }

            return Ok(new { 
                Success = true, 
                Message = "Reservation updated successfully.", 
                Data = result.Data 
            });
        }

        [HttpPost("{reservationId}/rooms")]
        public IActionResult AddRoomsToReservation(int reservationId, List<int> roomIds)
        {
            if (reservationId <= 0 || roomIds == null || roomIds.Count == 0)
            {
                return BadRequest(new { 
                    Success = false, 
                    Message = "Invalid reservation ID or room IDs." 
                });
            }

            var result = reservationBL.AddRoomsToReservation(reservationId, roomIds);
            if (result == null || !result.Success)
            {
                return BadRequest(new { 
                    Success = false, 
                    Message = result?.Message ?? "Failed to add rooms to reservation." 
                });
            }

            return Ok(new { 
                Success = true, 
                Message = "Rooms added to reservation successfully.", 
                Data = result.Data 
            });
        }

        [HttpPost("{reservationId}/guests")]
        public IActionResult AddGuestsToReservation(int reservationId, List<int> guestIds)
        {
            if (reservationId <= 0 || guestIds == null || guestIds.Count == 0)
            {
                return BadRequest(new { 
                    Success = false, 
                    Message = "Invalid reservation ID or guest IDs." 
                });
            }

            var result = reservationBL.AddGuestsToReservation(reservationId, guestIds);
            if (result == null || !result.Success)
            {
                return BadRequest(new { 
                    Success = false, 
                    Message = result?.Message ?? "Failed to add guests to reservation." 
                });
            }

            return Ok(new { 
                Success = true, 
                Message = "Guests added to reservation successfully.", 
                Data = result.Data 
            });
        }
    }
}
