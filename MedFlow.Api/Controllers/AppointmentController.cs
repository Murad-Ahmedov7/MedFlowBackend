
using Application.Business.Appointments.Requests;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MedFlow.Api.Controllers;

[Route("api/appoinment")]
[ApiController]
public class AppointmentController : MedFlowApiController
{
    private readonly IMediator _mediator;

    public AppointmentController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [Authorize(Roles = "Admin, Receptionist")]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateAppointmentRequest request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [Authorize(Roles = "Admin, Receptionist")]
    [HttpGet("{id}")]

    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        var request = new GetAppointmentByIdRequest() { Id = id };
        var response = await _mediator.Send(request);
        return Ok(response);
    }


    [Authorize(Roles = "Admin, Receptionist")]
    [HttpGet]

    public async Task<IActionResult> GetAll()
    {
        var request = new GetAllAppointmentsRequest();

        var response = await _mediator.Send(request);

        return Ok(response);
    }

    [Authorize(Roles = "Admin,Receptionist,Doctor")]
    [HttpGet("today")]

    public async Task<IActionResult> GetTodayAppointments()
    {
        var request = new GetTodayAppointmentsRequest();
        var response = await _mediator.Send(request);
        return Ok(response);
    }


    [Authorize(Roles = "Admin,Doctor")]
    [HttpPatch("{id}/status")]
    public async Task<IActionResult> UpdateAppointmentStatus([FromRoute] Guid id, [FromBody] UpdateAppointmentStatusRequest request)
    {

        request.Id = id;
        var response = await _mediator.Send(request);
        return Ok(response);
    }
}

