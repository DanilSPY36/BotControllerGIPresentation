namespace SharedLibrary.DataTransferObjects
{
    public class UserLoginDto
    {
        public UserLoginDto()
        {
        }

        private UserLoginDto(int id, string password, string email)
        {
            Id = id;
            Password = password;
            Email = email;
        }

        public int Id { get; set; }
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

    }
}
