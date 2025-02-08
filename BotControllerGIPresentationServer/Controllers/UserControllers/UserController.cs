using BotControllerGIPresentationServer.IRepositories;
using BotControllerGIPresentationServer.IRepositories.UserIRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedLibrary.DataTransferObjects;
using SharedLibrary.Models;

namespace BotControllerGIPresentationServer.Controllers.UserControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repository;

        public UserController(IUserRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<User>>> GetAll()
        {
            var items = await _repository.GetAllAsync();
            return Ok(items);
        }

        [HttpGet("GetByEmail")]
        public async Task<ActionResult<User>> GetByEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return BadRequest("Email не может быть пустым.");
            }

            try
            {
                var user = await _repository.GetByEmail(email);
                if (user == null)
                {
                    return NotFound("Пользователь не найден.");
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ошибка сервера: {ex.Message}");
            }
        }

        [HttpPost("Add")]
        public async Task<ActionResult<User>> Add(User item)
        {
            var newItem = await _repository.AddAsync(item);
            if (newItem is not null)
            {
                return Ok(newItem);
            }
            else { return BadRequest(); }
        }

        [HttpPost("RegisterNewUser")]
        public async Task<ActionResult<UserRegisterDto>> RegisterNewUser(UserRegisterDto userDto) 
        {
            var newUser = new User() 
            {
                IsAccess = true,
                Email = userDto.Email,
                PasswordHash = userDto.Password,
                Name = userDto.UserName,
            };
            var newUserInDB = await _repository.AddAsync(newUser);
            return Ok(newUser);
        }
        //[HttpGet("LoginUser")]
        //public async Task<ActionResult<UserLoginDto>> LoginUser(UserLoginDto userDto)
        //{

        //}

        [HttpDelete("Delete/{ItemId:int}")]
        public async Task<ActionResult> Delete(int ItemId)
        {
            var result = await _repository.DeleteAsync(ItemId);
            if (result)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPut("Update")]
        public async Task<ActionResult<User>> Update(User updatedItem)
        {
            var item = await _repository.UpdateAsync(updatedItem);
            if (item is not null)
            {
                return Ok(item);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
