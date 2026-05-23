

using Application.Business.Patients.Requests;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace MedFlow.Api.Controllers;

[Route("api/patients")]
[ApiController]
public class PatientController : MedFlowApiController
{
    private readonly IMediator _mediator;

    public PatientController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [Authorize(Roles = "Admin,Receptionist")]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatePatientRequest request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var request = new GetAllPatientsRequest();
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [Authorize(Roles = "Admin,Receptionist")]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        var request = new GetPatientByIdRequest { Id = id };
        var response = await _mediator.Send(request);
        return Ok(response);
    }



    [HttpGet("by-fin/{fin}")]
    public async Task<IActionResult> GetByFin([FromRoute] string fin)
    {
        var request = new GetPatientByFinRequest() { Fin = fin };
        var response = await _mediator.Send(request);
        return OkOrNotFound(response);
    }

    [HttpGet("by-phone")]
    public async Task<IActionResult> GetByPhone([FromQuery] string phone)
    {
        var request = new GetPatientsByPhoneRequest() { Phone = phone };
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpGet("by-name")]
    public async Task<IActionResult> GetByName([FromQuery] string? firstName, [FromQuery] string? lastName)
    {
        var request = new GetPatientsByNameRequest() { FirstName = firstName, LastName = lastName };
        var response = await _mediator.Send(request);
        return Ok(response);
    }
    
    [Authorize(Roles = "Admin,Receptionist")]
    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdatePatientRequest request)
    {
        request.Id = id;
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [Authorize(Roles = "Admin,Receptionist")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var request = new DeletePatientRequest { Id = id };
        var response = await _mediator.Send(request);
        return Ok(response);
    }

}