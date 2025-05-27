using HotelManagementSystem.API.Helpers;
using HotelManagementSystem.BusinessLayer.Interface;
using HotelManagementSystem.ModelLayer;
using HotelManagementSystem.RepositoryLayer.Interface;
using Microsoft.Extensions.Configuration;

namespace HotelManagementSystem.BusinessLayer.Services
{
    public class UserBL : IUserBL
    {
        private readonly IUserRL userRL;
        private readonly IConfiguration configuration;
        private readonly IEmailSender _emailSender;

        public UserBL(IUserRL _userRL, IConfiguration _configuration, IEmailSender emailSender)
        {
            userRL = _userRL;
            configuration = _configuration;
            _emailSender = emailSender;
        }

        public async Task<ResponseModel<User>> RegisterUser(RegisterRequest registerRequest)
        {
            // Validate SecretKey for Owner role
            if (registerRequest.Role == "Owner")
            {
                var storedSecretKey = configuration["SecretKey"];
                if (registerRequest.SecretKey != storedSecretKey)
                {
                    return new ResponseModel<User>
                    {
                        Data = null,
                        Success = false,
                        Message = "Invalid Secret Key",
                        StatusCode = 401
                    };
                }
            }
            var subject = "Welcome to the Hotel Lotus";
            var message = $"Welcome to the Hotel Lotus. Your email is: {registerRequest.Email}. Your password is: {registerRequest.Password}";
            // Send email without including Action in response
            try
            {
                await _emailSender.SendEmailAsync(registerRequest.Email, subject, message);
            }
            catch (Exception ex)
            {
                return new ResponseModel<User>
                {
                    Data = null,
                    Success = false,
                    Message = $"Email error: {ex.Message}",
                    StatusCode = 500
                };
            }
            // Delegate to the Repository Layer for database operations
            return userRL.RegisterUser(registerRequest);
        }

        public ResponseModel<object> LoginUser(LoginRequest loginRequest)
        {
            // Validate user credentials
            var userResponse = userRL.LoginUser(loginRequest);
            if (userResponse == null || !userResponse.Success || userResponse.Data == null)
            {
                return new ResponseModel<object>
                {
                    Data = null,
                    Success = false,
                    Message = userResponse?.Message ?? "Invalid email or password",
                    StatusCode = 401
                };
            }
            // Sanitize user object by removing sensitive information like password
            var sanitizedUser = new
            {
                UserId = userResponse.Data.UserId,
                UserName = userResponse.Data.UserName,
                Email = userResponse.Data.Email,
                Role = userResponse.Data.Role
            };
            // Generate JWT token
            string token;
            try
            {
                token = JwtHelper.GenerateJwtToken(userResponse.Data, configuration);
            }
            catch (Exception ex)
            {
                return new ResponseModel<object>
                {
                    Data = null,
                    Success = false,
                    Message = $"Token generation failed: {ex.Message}",
                    StatusCode = 500
                };
            }

            return new ResponseModel<object>
            {
                Data = new { Token = token, User = sanitizedUser },
                Success = true,
                Message = "Login successful",
                StatusCode = 200
            };
        }
    }
}