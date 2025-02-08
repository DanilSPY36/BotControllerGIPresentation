using SharedLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.DataTransferObjects
{
    public class UserRegisterDto
    {
        public UserRegisterDto()
        {
        }

        private UserRegisterDto(string userName, string email, string password)
        {
            UserName = userName;
            Password = password;
            Email = email;
        }

        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public static UserRegisterDto Create(string Name, string Email, string passowrd)
        { 
            return new UserRegisterDto(Name, Email, passowrd);
        }
    }
}
