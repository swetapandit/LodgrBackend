using System.Collections.Generic;
using HotelManagementSystem.ModelLayer;
using HotelManagementSystem.ModelLayer.Model;

namespace HotelManagementSystem.RepositoryLayer.Interface
{
    public interface IReservationRL
    {
        ResponseModel<Reservation> CreateReservation(ReservationRequest reservationRequest);
        ResponseModel<Reservation> UpdateReservation(int reservationId, UpdateReservationRequest reservationRequest);
        // ResponseModel<Reservation> GetReservationById(int reservationId);
        public ResponseModel<List<Room>> AddRoomsToReservation(int reservationId, List<int> roomIds);
        public ResponseModel<List<Guest>> AddGuestsToReservation(int reservationId, List<int> roomIds);
    }
}