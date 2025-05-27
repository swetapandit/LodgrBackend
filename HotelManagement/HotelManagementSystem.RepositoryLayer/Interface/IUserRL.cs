using System;
using HotelManagementSystem.ModelLayer;
namespace HotelManagementSystem.RepositoryLayer.Interface
{
    public interface IUserRL
    {
        public ResponseModel<User> RegisterUser(RegisterRequest registerRequest);
        public ResponseModel<User> LoginUser(LoginRequest loginRequest);
    }
}