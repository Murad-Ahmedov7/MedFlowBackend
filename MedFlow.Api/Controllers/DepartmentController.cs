
using Application.Business.Departments.Requests;
using Application.Business.DepartmentServices.Requests;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedFlow.Api.Controllers
{
    [Route("api/department")]
    [ApiController]
    public class DepartmentController : MedFlowApiController
    {
        private readonly IMediator _mediator;

        public DepartmentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateDepartmentRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("{id}/services")]
        public async Task<IActionResult> AddDepartmentService(Guid id, [FromBody] CreateDepartmentServiceRequest request)
        {
            request.DepartmentId = id;
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [Authorize(Roles = "Admin,Receptionist")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var request = new GetDepartmentByIdRequest { Id = id };
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [Authorize]
        [HttpGet("{id}/services")]
        public async Task<IActionResult> GetServicesByDepartmentId(Guid id)
        {
            var request=new GetServicesByDepartmentRequest { Id = id };
            var response= await _mediator.Send(request);
            return Ok(response);
        }
    }
}
