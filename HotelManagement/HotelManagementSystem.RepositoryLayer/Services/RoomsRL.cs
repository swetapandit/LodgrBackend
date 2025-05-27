using System;
using System.Collections.Generic;
using HotelManagementSystem.ModelLayer;
using HotelManagementSystem.ModelLayer.Model;
using HotelManagementSystem.RepositoryLayer.Interface;

namespace HotelManagementSystem.RepositoryLayer.Services
{
    public class RoomsRL : IRoomsRL
    {
        private readonly HotelManagementContext context;
        public RoomsRL(HotelManagementContext _context)
        {
            context = _context;
        }

        public List<Room> GetAllRooms()
        {
            return context.Rooms.ToList();
        }

        public Room GetRoomById(int roomNumber)
        {
            return context.Rooms.FirstOrDefault(r => r.RoomNumber == roomNumber);
        }

        public ResponseModel<Room> AddRoom(RoomRequest roomRequest)
        {
            // var roomTypeEnum = Enum.Parse<RoomTypeEnum>(roomRequest.RoomType);
            var existingRoom = context.Rooms.FirstOrDefault(r => r.RoomNumber == roomRequest.RoomNumber);
            if (existingRoom != null)
            {
                return new ResponseModel<Room>
                {
                    Data = null,
                    Success = false,
                    Message = "Room already exists"
                };
            }

            var newRoom = new Room
            {
                RoomType = Enum.Parse<RoomTypeEnum>(roomRequest.RoomType),
                RatePerNight = roomRequest.RatePerNight,
                RoomNumber = roomRequest.RoomNumber,
            };

            context.Rooms.Add(newRoom);
            context.SaveChanges();

            return new ResponseModel<Room>
            {
                Data = newRoom,
                Success = true,
                Message = "Room added successfully"
            };
        }

        public ResponseModel<bool> DeleteRoom(int roomNumber)
        {
            var existingRoom = context.Rooms.FirstOrDefault(r => r.RoomNumber == roomNumber);
            if (existingRoom == null)
            {
            return new ResponseModel<bool>
            {
                Data = false,
                Success = false,
                Message = "Room not found"
            };
            }

            context.Rooms.Remove(existingRoom);
            context.SaveChanges();

            return new ResponseModel<bool>
            {
            Data = true,
            Success = true,
            Message = "Room deleted successfully"
            };
        }

        public ResponseModel<Room> UpdateRoom(int roomNumber, RoomRequest roomRequest)
        {
            var existingRoom = context.Rooms.FirstOrDefault(r => r.RoomNumber == roomNumber);
            if (existingRoom == null)
            {
                return new ResponseModel<Room>
                {
                    Data = null,
                    Success = false,
                    Message = "Room not found"
                };
            }

            existingRoom.RoomType = Enum.Parse<RoomTypeEnum>(roomRequest.RoomType);
            existingRoom.RatePerNight = roomRequest.RatePerNight;

            context.Rooms.Update(existingRoom);
            context.SaveChanges();

            return new ResponseModel<Room>
            {
                Data = existingRoom,
                Success = true,
                Message = "Room updated successfully"
            };
        }
    }
}