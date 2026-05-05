
using Application.Business.Services.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace MedFlow.Api.Controllers
{
    [Route("api/service")]
    [ApiController]
    public class ServiceController : MedFlowApiController
    {
        private readonly IMediator _mediator;

        public ServiceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var request = new GetServiceByIdRequest { Id = id };

            var response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var request = new GetAllServicesRequest();

            var response = await _mediator.Send(request);

            return Ok(response);
        }
    }
}
