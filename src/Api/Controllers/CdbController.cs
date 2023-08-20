using Application.Dtos;
using CalculoCDB.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CalculoCDB.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CdbController : ControllerBase
    {

        private readonly IMediator _mediator;

        public CdbController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CdbRequestViewModel model)
        {
            var result = await _mediator.Send(new CdbServiceRequest { Cash = model.Cash, Deadline = model.Deadline });
            return Ok(result);

        }
    }
}
