using BotControllerGIPresentationServer.IRepositories;
using BotControllerGIPresentationServer.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedLibrary.Models;

namespace BotControllerGIPresentationServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KbjuTtkController : ControllerBase
    {
        private readonly IKbjuTtkRepository _repository;

        public KbjuTtkController(IKbjuTtkRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<KbjuTtk>>> GetAll()
        {
            var items = await _repository.GetAllAsync();
            return Ok(items);
        }

        [HttpGet("GetById/{itemId:int}")]
        public async Task<ActionResult<KbjuTtk>> GetById(int itemId)
        {
            var items = await _repository.GetByIDAsync(itemId);
            return Ok(items);
        }

        [HttpGet("GetKbjuTtkByTtkId/{TtkItemId:int}")]
        public async Task<ActionResult<IEnumerable<KbjuTtk>>> GetKbjuTtkByTtkId(int TtkItemId)
        {
            var items = await _repository.GetKbjuTtkByTtkId(TtkItemId);
            return Ok(items);
        }


        [HttpPost("Add")]
        public async Task<ActionResult<KbjuTtk>> Add(KbjuTtk item)
        {
            var newItem = await _repository.AddAsync(item);
            if (newItem is not null)
            {
                return Ok(newItem);
            }
            else { return BadRequest(); }
        }
        [HttpPut("Update")]
        public async Task<ActionResult<KbjuTtk>> Update(KbjuTtk updatedItem)
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
