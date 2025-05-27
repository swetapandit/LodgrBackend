using HotelManagementSystem.ModelLayer;
using HotelManagementSystem.ModelLayer.Model;

namespace HotelManagementSystem.RepositoryLayer.Interface
{
    public interface IGuestsRL
    {
        public ResponseModel<Guest> AddGuest(GuestsRequest guest);
        public ResponseModel<Guest> UpdateGuest(int guestId, GuestsRequest guest);
        public ResponseModel<Guest> DeleteGuest(int guestId);
    }
}