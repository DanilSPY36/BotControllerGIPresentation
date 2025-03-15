using BotControllerGIPresentationServer.IRepositories.UserIRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using SharedLibrary.Models;

namespace BotControllerGIPresentationServer.Controllers.UserControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotcoffeeController : ControllerBase
    {
        private readonly IHotcoffeeRepository _repository;

        public HotcoffeeController(IHotcoffeeRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<Hotcoffee>>> GetAll()
        {
            var items = await _repository.GetAllAsync();
            if(items is not null) 
            {
                return Ok(items);
            }
            else 
            {
                return BadRequest();
            }
        }
        [HttpPost("Add")]
        public async Task<ActionResult<Hotcoffee>> Add(Hotcoffee item)
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
        public async Task<ActionResult<Hotcoffee>> Update(Hotcoffee updatedItem)
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
