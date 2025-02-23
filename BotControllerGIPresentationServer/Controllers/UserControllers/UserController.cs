using BotControllerGIPresentationServer.IRepositories;
using BotControllerGIPresentationServer.IRepositories.UserIRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedLibrary.DataTransferObjects;
using SharedLibrary.Models;
using System.Net.Http;

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
        [HttpGet("GetUserDTOByUserId/{UserId:int}")]
        public async Task<ActionResult<UserDTO>> GetUserDTOByUserId(int UserId) 
        {
            try
            {
                var user = await _repository.GetUserDTOByUserId(UserId);
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
        [HttpGet("GetTEST")]
        public ActionResult<IEnumerable<User>> GetTEST()
        {
            if (HttpContext.Request.Cookies.TryGetValue("test", out var cookieValue))
            {
                return Ok(cookieValue);
            }
            else
            {
                return Ok();
            }
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

        [HttpPost("Login")]
        public async Task<ActionResult<string>> Login(UserLoginDto userLoginDto)
        {
            var token = await _repository.Login(userLoginDto.Email, userLoginDto.Password);
            if (!string.IsNullOrEmpty(token)) 
            {
                HttpContext.Response.Cookies.Append("test", token);
                return Ok(token);
            }
            else 
            {
                return BadRequest(string.Empty);
            }

        }

        [HttpGet("Logout")]
        public ActionResult<bool> Logout()
        {
            HttpContext.Response.Cookies.Delete("test");
            return Ok(true);
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
        [HttpPost("CheckUserEmail")]
        public async Task<ActionResult<bool>> CheckUserEmail([FromBody] string userDtoEmail) 
        {
            var result = await _repository.CheckUserEmail(userDtoEmail);
            if (result) 
            {
                return Ok(result);
            }
            else 
            {
                return BadRequest(result);
            }
        }
        [HttpPost("Register")]
        public async Task<ActionResult<string>> Register(UserRegisterDto userDto) 
        {
            
            var token = await _repository.Register(userDto.UserName, userDto.Email, userDto.Password);
            if (token is not null)
            {
                HttpContext.Response.Cookies.Append("test", token);
                return Ok(token); 
            }
            else
            {
                return BadRequest(string.Empty);
            }
        }

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
