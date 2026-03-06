using Application.Business.Patients.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace MedFlow.Api.Controllers;

[Route("api/patient")]
[ApiController]
public class PatientController : MedFlowApiController
{
    private readonly IMediator _mediator;

    public PatientController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatePatientRequest request)
    {
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
    public async Task <IActionResult> GetByName([FromQuery] string? firstName, [FromQuery] string? lastName)
    {
        var request = new GetPatientsByNameRequest() { FirstName = firstName, LastName = lastName };
        var response=await _mediator.Send(request);
        return Ok(response);
    }

}

