using System.Collections.Generic;
using HotelManagementSystem.ModelLayer;
using HotelManagementSystem.ModelLayer.Model;

namespace HotelManagementSystem.BusinessLayer.Interface
{
    public interface IGuestsBL
    {
        public ResponseModel<Guest> AddGuest(GuestsRequest guest);
        public ResponseModel<Guest> UpdateGuest(int guestId, GuestsRequest guest);
        public ResponseModel<Guest> DeleteGuest(int guestId);
        
    }
}