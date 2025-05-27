using HotelManagementSystem.ModelLayer;
using HotelManagementSystem.ModelLayer.Model;

namespace HotelManagementSystem.BusinessLayer.Interface
{
    public interface IReservationBL
    {
        public ResponseModel<Reservation> CreateReservation(ReservationRequest reservationRequest);
        public ResponseModel<Reservation> UpdateReservation(int reservationId, UpdateReservationRequest reservationRequest);
        // public ResponseModel<Reservation> GetReservationById(int reservationId);
        public ResponseModel<List<Room>> AddRoomsToReservation(int reservationId, List<int> roomIds);
        
        public ResponseModel<List<Guest>> AddGuestsToReservation(int reservationId, List<int> roomIds);
    }
}