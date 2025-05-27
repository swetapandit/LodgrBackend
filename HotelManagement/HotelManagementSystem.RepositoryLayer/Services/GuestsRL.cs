using System;
using System.Collections.Generic;
using HotelManagementSystem.ModelLayer;
using HotelManagementSystem.ModelLayer.Model;
using HotelManagementSystem.RepositoryLayer.Interface;

namespace HotelManagementSystem.RepositoryLayer.Services
{
    public class GuestsRL : IGuestsRL
    {
        private readonly HotelManagementContext hotelManagementContext;
        public GuestsRL(HotelManagementContext _hotelManagementContext)
        {
            hotelManagementContext = _hotelManagementContext;
        }

        public ResponseModel<Guest> AddGuest(GuestsRequest guest)
        {
            if (guest == null)
            {
                return new ResponseModel<Guest>()
                {
                    Success = false,
                    Message = "Guest details cannot be null",
                    Data = null
                };
            }

            // Add logic to save guest to database
            var newGuest = new Guest
            {
                Name = guest.Name,
                Email = guest.Email,
                MemberCode = guest.MemberCode
            };

            hotelManagementContext.Guests.Add(newGuest);
            hotelManagementContext.SaveChanges();

            return new ResponseModel<Guest>()
            {
                Success = true,
                Message = "Guest added successfully",
                Data = newGuest
            };

        }
        public ResponseModel<Guest> UpdateGuest(int guestId, GuestsRequest guest)
        {
            if (guest == null)
            {
                return new ResponseModel<Guest>()
                {
                    Success = false,
                    Message = "Guest details cannot be null",
                    Data = null
                };
            }

            var existingGuest = hotelManagementContext.Guests.Find(guestId);
            if (existingGuest == null)
            {
                return new ResponseModel<Guest>()
                {
                    Success = false,
                    Message = "Guest not found",
                    Data = null
                };
            }

            existingGuest.Name = guest.Name;
            existingGuest.Email = guest.Email;
            existingGuest.MemberCode = guest.MemberCode;

            hotelManagementContext.SaveChanges();

            return new ResponseModel<Guest>()
            {
                Success = true,
                Message = "Guest updated successfully",
                Data = existingGuest
            };
        }
        public ResponseModel<Guest> DeleteGuest(int guestId)
        {
            var existingGuest = hotelManagementContext.Guests.Find(guestId);
            if (existingGuest == null)
            {
                return new ResponseModel<Guest>()
                {
                    Success = false,
                    Message = "Guest not found",
                    Data = null
                };
            }

            hotelManagementContext.Guests.Remove(existingGuest);
            hotelManagementContext.SaveChanges();

            return new ResponseModel<Guest>()
            {
                Success = true,
                Message = "Guest deleted successfully",
                Data = existingGuest
            };
        }
    }
}