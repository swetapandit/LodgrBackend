using System;
using System.Collections.Generic;
using HotelManagementSystem.BusinessLayer.Interface;
using HotelManagementSystem.ModelLayer;
using HotelManagementSystem.ModelLayer.Model;
using HotelManagementSystem.RepositoryLayer.Interface;

namespace HotelManagementSystem.BusinessLayer.Services
{
    public class GuestsBL : IGuestsBL
    {
        private readonly IGuestsRL _guestsRL;
        public GuestsBL(IGuestsRL guestsRL)
        {
            _guestsRL = guestsRL;
        }
        public ResponseModel<Guest> AddGuest(GuestsRequest guest)
        {
            return _guestsRL.AddGuest(guest);   
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

            // Add logic to update guest in database
            var updatedGuest = new Guest
            {
                Name = guest.Name,
                Email = guest.Email,
                MemberCode = guest.MemberCode
            };

            return _guestsRL.UpdateGuest(guestId, guest);
        }
        public ResponseModel<Guest> DeleteGuest(int guestId)
        {
            if (guestId <= 0)
            {
                return new ResponseModel<Guest>()
                {
                    Success = false,
                    Message = "Invalid guest ID",
                    Data = null
                };
            }

            // Add logic to delete guest from database
            return _guestsRL.DeleteGuest(guestId);
        }
    }
}