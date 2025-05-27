using System;
using HotelManagementSystem.ModelLayer;
using HotelManagementSystem.ModelLayer.Model;
using HotelManagementSystem.RepositoryLayer.Interface;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementSystem.RepositoryLayer.Services
{
    public class ReservationRL : IReservationRL
    {
        private readonly HotelManagementContext context;
        public ReservationRL(HotelManagementContext _context)
        {
            context = _context;
        }
        public ResponseModel<Reservation> CreateReservation(ReservationRequest reservationRequest)
        {
            var newReservation = new Reservation
            {
                CheckIn = reservationRequest.CheckIn,
                CheckOut = reservationRequest.CheckOut,
                NumberOfMembers = reservationRequest.NumberOfMembers,
                NumberOfNights = reservationRequest.NumberOfNights,
                CreatedAt = DateTime.Now,
                UserId = reservationRequest.UserId
            };

            context.Reservations.Add(newReservation);
            context.SaveChanges();

            return new ResponseModel<Reservation>
            {
                Data = newReservation,
                Success = true,
                Message = "Reservation created successfully."
            };
        }
        public ResponseModel<Reservation> UpdateReservation(int reservationId, UpdateReservationRequest reservationRequest)
        {

            var existingReservation = context.Reservations.Find(reservationId);
            if (existingReservation == null)
            {
                return new ResponseModel<Reservation>
                {
                    Data = null,
                    Success = false,
                    Message = "Reservation not found."
                };
            }

            existingReservation.CheckIn = reservationRequest.CheckIn.Date;
            existingReservation.CheckOut = reservationRequest.CheckOut.Date;
            existingReservation.NumberOfMembers = reservationRequest.NumberOfMembers;
            existingReservation.NumberOfNights = reservationRequest.NumberOfNights;
            existingReservation.UserId = reservationRequest.UserId;
            existingReservation.CreatedAt = DateTime.Now.Date;

            context.SaveChanges();

            return new ResponseModel<Reservation>
            {
                Data = existingReservation,
                Success = true,
                Message = "Reservation updated successfully."
            };
        }
        // public ResponseModel<ReservationResponseModel> GetReservationById(int reservationId)
        // {
        //     // Find the reservation by ID and include related guests and rooms
        //     var reservation = context.Reservations
        //         .Include(r => r.ReservationGuests)
        //         .ThenInclude(rg => rg.Guest)
        //         .Include(r => r.ReservationRooms)
        //         .ThenInclude(rr => rr.Room)
        //         .FirstOrDefault(r => r.ReservationId == reservationId);

        //     if (reservation == null)
        //     {
        //         return new ResponseModel<ReservationResponseModel>
        //         {
        //             Data = null,
        //             Success = false,
        //             Message = "Reservation not found."
        //         };
        //     }

        //     // Map the reservation, guests, and rooms to a custom response model
        //     var reservationWithDetails = new ReservationResponseModel
        //     {
        //         ReservationId = reservation.ReservationId,
        //         CheckIn = reservation.CheckIn,
        //         CheckOut = reservation.CheckOut,
        //         NumberOfMembers = reservation.NumberOfMembers,
        //         NumberOfNights = reservation.NumberOfNights,
        //         CreatedAt = reservation.CreatedAt,
        //         UserId = reservation.UserId,
        //         Guests = reservation.ReservationGuests.Select(rg => new GuestsRequest
        //         {
        //             Name = rg.Guest.Name,
        //             Email = rg.Guest.Email,
        //         }).ToList(),
        //         Rooms = reservation.ReservationRooms.Select(rr => new RoomRequest
        //         {
        //             RoomType = rr.Room.RoomType,
        //             RatePerNight = rr.Room.RatePerNight
        //         }).ToList()
        //     };

        //     return new ResponseModel<ReservationResponseModel>
        //     {
        //         Data = reservationWithDetails,
        //         Success = true,
        //         Message = "Reservation with guests and rooms retrieved successfully."
        //     };
        // }
        public ResponseModel<List<Room>> AddRoomsToReservation(int reservationId, List<int> roomIds)
        {
            // Find the reservation by ID
            var reservation = context.Reservations.Find(reservationId);
            if (reservation == null)
            {
                return new ResponseModel<List<Room>>
                {
                    Data = null,
                    Success = false,
                    Message = "Reservation not found."
                };
            }

            // Find the rooms by their IDs
            var rooms = context.Rooms.Where(r => roomIds.Contains(r.RoomId) && r.IsAvailable).ToList();
            if (rooms.Count == 0)
            {
                return new ResponseModel<List<Room>>
                {
                    Data = null,
                    Success = false,
                    Message = "No available rooms found for the provided IDs."
                };
            }

            // Check for duplicate room assignments
            var existingRoomIds = context.ReservationRooms
                .Where(rr => rr.ReservationId == reservationId)
                .Select(rr => rr.RoomId)
                .ToHashSet();

            var newRoomIds = roomIds.Except(existingRoomIds).ToList();
            if (newRoomIds.Count == 0)
            {
                return new ResponseModel<List<Room>>
                {
                    Data = null,
                    Success = false,
                    Message = "All provided rooms are already assigned to this reservation."
                };
            }

            // Add each new room to the reservation and mark it as unavailable
            var addedRooms = new List<Room>();
            foreach (var roomId in newRoomIds)
            {
                var room = rooms.FirstOrDefault(r => r.RoomId == roomId);
                if (room != null)
                {
                    // Add the room to the reservation
                    var reservationRoom = new ReservationRooms
                    {
                        ReservationId = reservationId,
                        RoomId = room.RoomId
                    };
                    context.ReservationRooms.Add(reservationRoom);

                    // Mark the room as unavailable
                    room.IsAvailable = false;

                    addedRooms.Add(room);
                }
            }

            // Save changes to the database
            context.SaveChanges();

            return new ResponseModel<List<Room>>
            {
                Data = addedRooms,
                Success = true,
                Message = "Rooms added to reservation successfully."
            };
        }
        public ResponseModel<List<Guest>> AddGuestsToReservation(int reservationId, List<int> guestIds)
        {
            // Find the reservation by ID
            var reservation = context.Reservations.Find(reservationId);
            if (reservation == null)
            {
                return new ResponseModel<List<Guest>>
                {
                    Data = null,
                    Success = false,
                    Message = "Reservation not found."
                };
            }

            // Find the guests by their IDs
            var guests = context.Guests.Where(g => guestIds.Contains(g.GuestId)).ToList();
            if (guests.Count == 0)
            {
                return new ResponseModel<List<Guest>>
                {
                    Data = null,
                    Success = false,
                    Message = "No guests found for the provided IDs."
                };
            }

            // Check for duplicate guest assignments
            var existingGuestIds = context.ReservationGuests
                .Where(rg => rg.ReservationId == reservationId)
                .Select(rg => rg.GuestId)
                .ToHashSet();

            var newGuestIds = guestIds.Except(existingGuestIds).ToList();
            if (newGuestIds.Count == 0)
            {
                return new ResponseModel<List<Guest>>
                {
                    Data = null,
                    Success = false,
                    Message = "All provided guests are already assigned to this reservation."
                };
            }

            // Add each new guest to the reservation
            var addedGuests = new List<Guest>();
            foreach (var guestId in newGuestIds)
            {
                var guest = guests.FirstOrDefault(g => g.GuestId == guestId);
                if (guest != null)
                {
                    // Add the guest to the reservation
                    var reservationGuest = new ReservationGuests
                    {
                        ReservationId = reservationId,
                        GuestId = guest.GuestId
                    };
                    context.ReservationGuests.Add(reservationGuest);

                    addedGuests.Add(guest);
                }
            }

            // Save changes to the database
            context.SaveChanges();

            return new ResponseModel<List<Guest>>
            {
                Data = addedGuests,
                Success = true,
                Message = "Guests added to reservation successfully."
            };
        }
    }
}