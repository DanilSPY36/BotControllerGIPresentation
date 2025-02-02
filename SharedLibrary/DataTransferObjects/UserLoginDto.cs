namespace SharedLibrary.DataTransferObjects
{
    public class UserLoginDto
    {
        private UserLoginDto(int id, string passwordHash, string email)
        {
            Id = id;
            PasswordHash = passwordHash;
            Email = email;
        }

        public int Id { get; set; }
        public string PasswordHash { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

    }
}
