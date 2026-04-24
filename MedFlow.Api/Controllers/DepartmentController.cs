
using Application.Business.Departments.Requests;
using Application.Business.DepartmentServices.Requests;
using AutoMapper.Features;
using Domain.Entities.Departments;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedFlow.Api.Controllers
{
    [Route("api/departments")]
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

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var request = new GetAllDepartmentsRequest();
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateDepartmentRequest request)
        {
            request.Id = id;
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [Authorize]
        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var request = new DeleteDepartmentRequest { Id = id };
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
            var request = new GetServicesByDepartmentRequest { Id = id };
            var response = await _mediator.Send(request);
            return Ok(response);
        }

    }
}

