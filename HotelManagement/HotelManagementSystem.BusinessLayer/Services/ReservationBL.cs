using System;
using HotelManagementSystem.BusinessLayer.Interface;
using HotelManagementSystem.ModelLayer;
using HotelManagementSystem.ModelLayer.Model;
using HotelManagementSystem.RepositoryLayer.Interface;

namespace HotelManagementSystem.BusinessLayer.Services
{
    public class ReservationBL : IReservationBL
    {
        private readonly IReservationRL reservationRL;
        public ReservationBL(IReservationRL _reservationRL)
        {
            reservationRL = _reservationRL;
        }

        public ResponseModel<Reservation> CreateReservation(ReservationRequest reservationRequest)
        {
            // Validate the reservation request
            if (reservationRequest.CheckIn >= reservationRequest.CheckOut)
            {
                return new ResponseModel<Reservation>
                {
                    Data = null,
                    Success = false,
                    Message = "Check-in date must be before check-out date."
                };
            }

            if (reservationRequest.NumberOfMembers <= 0)
            {
                return new ResponseModel<Reservation>
                {
                    Data = null,
                    Success = false,
                    Message = "Number of members must be greater than zero."
                };
            }

            // Call the repository to create the reservation
            var response = reservationRL.CreateReservation(reservationRequest);
            if (response != null)
            {
                return new ResponseModel<Reservation>
                {
                    Data = response?.Data,
                    Success = response.Success,
                    Message = response.Message
                };
            }
            else
            {
                return new ResponseModel<Reservation>
                {
                    Data = null,
                    Success = false,
                    Message = "Failed to create reservation."
                };
            }
        }
        public ResponseModel<Reservation> UpdateReservation(int reservationId, UpdateReservationRequest reservationRequest)
        {
            if(reservationRequest == null)
            {
                return new ResponseModel<Reservation>
                {
                    Data = null,
                    Success = false,
                    Message = "Invalid reservation request."
                };
            }
            // Validate the reservation request
            if (reservationRequest.CheckIn >= reservationRequest.CheckOut)
            {
                return new ResponseModel<Reservation>
                {
                    Data = null,
                    Success = false,
                    Message = "Check-in date must be before check-out date."
                };
            }

            if (reservationRequest.NumberOfMembers <= 0)
            {
                return new ResponseModel<Reservation>
                {
                    Data = null,
                    Success = false,
                    Message = "Number of members must be greater than zero."
                };
            }

            // Call the repository to update the reservation
            var response = reservationRL.UpdateReservation(reservationId,reservationRequest);
            if (response != null)
            {
                return new ResponseModel<Reservation>
                {
                    Data = response.Data,
                    Success = response.Success,
                    Message = response.Message
                };
            }
            else
            {
                return new ResponseModel<Reservation>
                {
                    Data = null,
                    Success = false,
                    Message = "Failed to update reservation."
                };
            }
        }
        // public ResponseModel<Reservation> GetReservationById(int reservationId)
        // {
        //     if (reservationId <= 0)
        //     {
        //         return new ResponseModel<Reservation>
        //         {
        //             Data = null,
        //             Success = false,
        //             Message = "Invalid reservation ID."
        //         };
        //     }

        //     // Call the repository to get the reservation by ID
        //     var response = reservationRL.GetReservationById(reservationId);
        //     if (response != null)
        //     {
        //         return new ResponseModel<Reservation>
        //         {
        //             Data = response.Data,
        //             Success = response.Success,
        //             Message = response.Message
        //         };
        //     }
        //     else
        //     {
        //         return new ResponseModel<Reservation>
        //         {
        //             Data = null,
        //             Success = false,
        //             Message = "Failed to get reservation."
        //         };
        //     }
        // }
        public ResponseModel<List<Room>> AddRoomsToReservation(int reservationId, List<int> roomIds)
        {
            if (reservationId <= 0 || roomIds == null || roomIds.Count == 0)
            {
                return new ResponseModel<List<Room>>
                {
                    Data = null,
                    Success = false,
                    Message = "Invalid reservation ID or room IDs."
                };
            }

            // Call the repository to add rooms to the reservation
            var response = reservationRL.AddRoomsToReservation(reservationId, roomIds);
            if (response != null)
            {
                return new ResponseModel<List<Room>>
                {
                    Data = response.Data,
                    Success = response.Success,
                    Message = response.Message
                };
            }
            else
            {
                return new ResponseModel<List<Room>>
                {
                    Data = null,
                    Success = false,
                    Message = "Failed to add rooms to reservation."
                };
            }
        }
        public ResponseModel<List<Guest>> AddGuestsToReservation(int reservationId, List<int> roomIds)
        {
            if (reservationId <= 0 || roomIds == null || roomIds.Count == 0)
            {
                return new ResponseModel<List<Guest>>
                {
                    Data = null,
                    Success = false,
                    Message = "Invalid reservation ID or room IDs."
                };
            }

            // Call the repository to add guests to the reservation
            var response = reservationRL.AddGuestsToReservation(reservationId, roomIds);
            if (response != null)
            {
                return new ResponseModel<List<Guest>>
                {
                    Data = response.Data,
                    Success = response.Success,
                    Message = response.Message
                };
            }
            else
            {
                return new ResponseModel<List<Guest>>
                {
                    Data = null,
                    Success = false,
                    Message = "Failed to add guests to reservation."
                };
            }
        }
    }
}