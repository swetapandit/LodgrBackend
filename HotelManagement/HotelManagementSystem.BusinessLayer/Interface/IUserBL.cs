using System;
using HotelManagementSystem.ModelLayer;

namespace HotelManagementSystem.BusinessLayer.Interface
{
    public interface IUserBL
    {
        Task<ResponseModel<User>> RegisterUser(RegisterRequest registerRequest);
        public ResponseModel<object> LoginUser(LoginRequest loginRequest);
    }
}