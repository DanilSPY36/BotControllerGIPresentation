using BotControllerGIPresentationServer.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedLibrary.Models;

namespace BotControllerGIPresentationServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VolumesDimController : ControllerBase
    {
        private readonly IVolumesDimRepository _repository;

        public VolumesDimController(IVolumesDimRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<Ttk>>> GetAll()
        {
            var items = await _repository.GetAllAsync();
            return Ok(items);
        }
        [HttpPost("Add")]
        public async Task<ActionResult<VolumesDim>> Add(VolumesDim item)
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
        public async Task<ActionResult<VolumesDim>> Update(VolumesDim updatedItem)
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
