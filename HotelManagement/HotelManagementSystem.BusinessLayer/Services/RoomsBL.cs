using System;
using HotelManagementSystem.API.Helpers;
using HotelManagementSystem.BusinessLayer.Interface;
using HotelManagementSystem.ModelLayer;
using HotelManagementSystem.ModelLayer.Model;
using HotelManagementSystem.RepositoryLayer.Interface;
using Microsoft.Extensions.Configuration;

namespace HotelManagementSystem.BusinessLayer.Services
{
    public class RoomsBL : IRoomsBL
    {
        private readonly IRoomsRL _roomsRL;
        private readonly IConfiguration _configuration;

        public RoomsBL(IRoomsRL roomsRL, IConfiguration configuration)
        {
            _roomsRL = roomsRL;
            _configuration = configuration;
        }

        // Method to get all rooms
        public List<Room> GetAllRooms()
        {
            return _roomsRL.GetAllRooms();
        }

        // Method to get room by ID
        public Room GetRoomById(int roomNumber)
        {
            return _roomsRL.GetRoomById(roomNumber);
        }

        // Method to add a new room
        public ResponseModel<Room> AddRoom(RoomRequest roomRequest)
        {
            return _roomsRL.AddRoom(roomRequest);
        }

        // Method to update room details
        public ResponseModel<Room> UpdateRoom(int roomNumber, RoomRequest roomRequest)
        {
            return _roomsRL.UpdateRoom(roomNumber, roomRequest);
        }
        // Method to delete a room
        public ResponseModel<bool> DeleteRoom(int roomNumber)
        {
            return _roomsRL.DeleteRoom(roomNumber);
        }
    
    }
}