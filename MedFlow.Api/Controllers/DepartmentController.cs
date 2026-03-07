
using Application.Business.Departments.Requests;
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


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateDepartmentRequest request)
        {
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
    }
}
