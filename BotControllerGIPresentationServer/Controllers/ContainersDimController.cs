using BotControllerGIPresentationServer.GenericRepositories;
using BotControllerGIPresentationServer.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedLibrary.Models;

namespace BotControllerGIPresentationServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContainersDimController : ControllerBase
    {
        private readonly IContainerDimRepository _repository;

        public ContainersDimController(IContainerDimRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<ContainersDim>>> GetAll()
        {
            var items = await _repository.GetAllAsync();
            return Ok(items);
        }
        [HttpPost("Add")]
        public async Task<ActionResult<ContainersDim>> Add(ContainersDim item)
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
        public async Task<ActionResult<ContainersDim>> Update(ContainersDim updatedItem)
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
