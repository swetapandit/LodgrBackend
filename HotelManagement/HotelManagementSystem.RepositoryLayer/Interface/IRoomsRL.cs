using HotelManagementSystem.ModelLayer;
using HotelManagementSystem.ModelLayer.Model;

namespace HotelManagementSystem.RepositoryLayer.Interface
{
    public interface IRoomsRL
    {
        List<Room> GetAllRooms();
        Room GetRoomById(int roomNumber);
        ResponseModel<Room> AddRoom(RoomRequest roomRequest);
        ResponseModel<Room> UpdateRoom(int roomNumber, RoomRequest roomRequest);
        public ResponseModel<bool> DeleteRoom(int roomId);
    }
}