using HotelManagementSystem.ModelLayer;
using HotelManagementSystem.RepositoryLayer.Interface;
using Microsoft.Extensions.Configuration;


namespace HotelManagementSystem.RepositoryLayer.Services
{
    public class UserRL : IUserRL
    {
        private readonly HotelManagementContext hotelManagementContext;

        public UserRL(HotelManagementContext _hotelManagementContext)
        {
            hotelManagementContext = _hotelManagementContext;
        }

        public ResponseModel<User> RegisterUser(RegisterRequest registerRequest)
        {
            
            // Check if the user already exists
            var existingUser = hotelManagementContext.Users.FirstOrDefault(g => g.Email == registerRequest.Email);
            // Get secret key from appsettings
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            var secretKeyFromConfig = configuration["SecretKey"];

            // Check if secret key is invalid
            if (registerRequest.SecretKey != secretKeyFromConfig)
            {
                return new ResponseModel<User>
                {
                    Data = null,
                    Success = false,
                    Message = "Invalid secret key",
                    StatusCode = 403
                };
            }

            // Check if user already exists
            if (existingUser != null)
            {
                return new ResponseModel<User>
                {
                    Data = existingUser,
                    Success = false,
                    Message = "User already exists",
                    StatusCode = 409
                };
            }
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(registerRequest.Password);
            // Create a new user
            var newUser = new User
            {
                UserName = registerRequest.UserName,
                Email = registerRequest.Email,
                Password = hashedPassword,
                Role = Enum.Parse<UserRole>(registerRequest.Role)
            };

            hotelManagementContext.Users.Add(newUser);
            hotelManagementContext.SaveChanges();

            return new ResponseModel<User>
            {
                Data = newUser,
                Success = true,
                Message = "User Registered Successfully",
                StatusCode = 200
            };
        }

        public ResponseModel<User> LoginUser(LoginRequest loginRequest)
        {
            try
            {
                var user = hotelManagementContext.Users.FirstOrDefault(g => g.Email == loginRequest.Email && g.Password == loginRequest.Password);
                if (user == null)
                {
                    return new ResponseModel<User>
                    {
                        Data = null,
                        Success = false,
                        Message = "Invalid email or password",
                        StatusCode = 401
                    };
                }

                return new ResponseModel<User>
                {
                    Data = user,
                    Success = true,
                    Message = "User Logged In Successfully",
                    StatusCode = 200
                };
            }
            catch (Exception ex)
            {
                return new ResponseModel<User>
                {
                    Data = null,
                    Success = false,
                    Message = $"Database error: {ex.Message}",
                    StatusCode = 500
                };
            }
        }
    }
}