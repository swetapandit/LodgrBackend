// Request model
    public class RegisterRequest
    {
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

        public string? Role { get; set; }
        public string? SecretKey { get; set; }
    }
