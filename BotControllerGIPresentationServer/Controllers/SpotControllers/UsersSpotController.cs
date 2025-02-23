using BotControllerGIPresentationServer.IRepositories.SpotIRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedLibrary.Models;

namespace BotControllerGIPresentationServer.Controllers.SpotControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersSpotController : ControllerBase
    {
        private readonly IUserSpotsRepository _repository;

        public UsersSpotController(IUserSpotsRepository repository)
        {
            _repository = repository;
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<UsersSpot>>> GetAll()
        {
            var items = await _repository.GetAllAsync();
            return Ok(items);
        }
        [HttpGet("GetUserSpotsByUserId/{UserId:int}")]
        public async Task<ActionResult<IEnumerable<UsersSpot>>> GetUserSpotsByUserId(int UserId) 
        {
            var result = await _repository.GetUserSpotsByUserId(UserId);
            if(result is not null) 
            {
                return Ok(result);
            }
            else 
            {
                return BadRequest();
            }
        }   

 
        [HttpPost("Add")]
        public async Task<ActionResult<UsersSpot>> Add(UsersSpot item)
        {
            var newItem = await _repository.AddAsync(item);
            if (newItem is not null)
            {
                return Ok(newItem);
            }
            else { return BadRequest(); }
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
        public async Task<ActionResult<UsersSpot>> Update(UsersSpot updatedItem)
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
