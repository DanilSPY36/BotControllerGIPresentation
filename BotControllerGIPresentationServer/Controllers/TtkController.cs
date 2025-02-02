using BotControllerGIPresentationServer.GenericRepositories;
using BotControllerGIPresentationServer.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SharedLibrary.Models;

namespace BotControllerGIPresentationServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TtkController : ControllerBase
    {
        private readonly ITtkRepository _repository;

        public TtkController(ITtkRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<Ttk>>> GetAll()
        {
            var items = await _repository.GetAllAsync();
            return Ok(items);
        }
        [HttpGet("GetTtkItemsByCategoryId/{itemId:int}")]
        public async Task<ActionResult<IEnumerable<Ttk>>> GetTtkItemsByCategoryId(int itemId)
        {
            var items = await _repository.GetTtkItemsByCategoryId(itemId);
            return Ok(items);
        }
        [HttpGet("GetTtkItemsByVolumeId/{volumeId:int}")]
        public async Task<ActionResult<IEnumerable<Ttk>>> GetTtkItemsByVolumeId(int volumeId)
        {
            var items = await _repository.GetTtkItemsByVolumeId(volumeId);
            return Ok(items);
        }
        [HttpGet("GetTtkItemsByContainerId/{containerId:int}")]
        public async Task<ActionResult<IEnumerable<Ttk>>> GetTtkItemsByContainerId(int containerId)
        {
            var items = await _repository.GetTtkItemsByContainerId(containerId);
            return Ok(items);
        }

        [HttpGet("GetById/{itemId:int}")]
        public async Task<ActionResult<Ttk>> GetById(int itemId)
        {
            var items = await _repository.GetByIDAsync(itemId);
            return Ok(items);
        }


        [HttpPost("Add")]
        public async Task<ActionResult<Ttk>> Add(Ttk item)
        {
            var newItem = await _repository.AddAsync(item);
            if(newItem is not null)
            {
                return Ok(newItem);
            }
            else { return BadRequest(); }
        }
        [HttpPut("Update")]
        public async Task<ActionResult<Ttk>> Update(Ttk updatedItem)
        {
            var item = await _repository.UpdateAsync(updatedItem);
            if(item is not null)
            {
                return Ok(item);
            }
            else
            {
                return BadRequest();
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

    }
}
