using HotelManagementSystem.ModelLayer;
using HotelManagementSystem.ModelLayer.Model;

namespace HotelManagementSystem.BusinessLayer.Interface
{
    public interface IRoomsBL
    {
        List<Room> GetAllRooms();
        Room GetRoomById(int roomNumber);
        public ResponseModel<Room> AddRoom(RoomRequest roomRequest);
        public ResponseModel<Room> UpdateRoom(int roomNumber, RoomRequest roomRequest);
        public ResponseModel<bool> DeleteRoom(int roomId);
    }

}