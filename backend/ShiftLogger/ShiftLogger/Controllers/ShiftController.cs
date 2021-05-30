using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShiftLogger.Application;
using ShiftLogger.Infra;
using ShiftLogger.Model;

namespace ShiftLogger.Controllers
{
    [Route("api/shift")]
    public class ShiftController : Controller
    {
        private readonly IRepository<ShiftLog> _repository;
        private readonly IMediator _mediator;

        public ShiftController(IRepository<ShiftLog> repository, IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }
        
        [HttpGet]
        public IActionResult GetAll() =>
            Ok(_repository.GetAll());

        [HttpGet("{id:int}")]
        public IActionResult Get(int id) =>
             _repository.Get(id) is ShiftLog log
                 ? Ok(log)
                 : NotFound();

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            _repository.Delete(id);
            return NoContent();
        }

        [HttpPost]
        [ProducesResponseType(typeof(ShiftLog), 201)]
        public async Task<IActionResult> Post([FromBody] CreateShiftLogRequest request)
        {
            var entity = await _mediator.Send(request);
            return Created($"api/shift/{entity.Id}", entity);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(typeof(ShiftLog), 200)]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateShiftLogRequest request)
        {
            var entity = await _mediator.Send(request);
            return Ok();
        }
    }
}