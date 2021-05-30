using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShiftLogger.Domain;
using ShiftLogger.Model;
using ShiftLogger.Model.Request;


namespace ShiftLogger.Controllers
{
    [Route("api/shift")]
    public class ShiftController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IRepository<ShiftLog> _repository;

        public ShiftController(IMediator mediator, IRepository<ShiftLog> repository)
        {
            _mediator = mediator;
            _repository = repository;
        }
        
        [HttpGet]
        public IActionResult GetAll() =>
            Ok(_repository.GetAll().Select(shift => (ShiftLogView)shift).ToArray());
        
        [HttpGet("{id:int}")]
        public IActionResult Get(int id) =>
             _repository.Get(id) is ShiftLog log
                 ? Ok(log)
                 : NotFound();
        
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var resp = await _mediator.Send(new DeleteShifLogRequest(id));
            return resp.Success
                ? NoContent()
                : BadRequest();
        }

        [HttpPost]
        [ProducesResponseType(typeof(ShiftLog), 201)]
        public async Task<IActionResult> Post([FromBody] CreateShiftLogRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var result = await _mediator.Send(request);
            return result.Success
                ? Created($"api/shift/{result.Value.Id}", result.Value)
                : BadRequest(result.Error);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(typeof(ShiftLog), 200)]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateShiftLogRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var result = await _mediator.Send(request);
            return result.Success
                ? Ok(result.Value)
                : BadRequest(result.Error);
        }
    }
}