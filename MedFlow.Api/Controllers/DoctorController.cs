

using Application.Business.Doctors.Requests;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedFlow.Api.Controllers;

[Authorize(Roles = "Admin, Receptionist")]
[Route("api/doctors")]
[ApiController]
public class DoctorController : MedFlowApiController
{
    private readonly IMediator _mediator;


    public DoctorController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateDoctorRequest request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var request = new GetAllDoctorsRequest();
        var response = await _mediator.Send(request);
        return Ok(response);
    }
}