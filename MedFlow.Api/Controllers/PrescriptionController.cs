
using Application.Business.Prescriptions.Requests;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedFlow.Api.Controllers;

[Route("api/prescription")]
[ApiController]

public class PrescriptionController : MedFlowApiController
{
    private readonly IMediator _mediator;

    public PrescriptionController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [Authorize(Roles = "Doctor")]
    [HttpPost]
    public async Task<IActionResult> Create(CreatePrescriptionRequest request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [Authorize(Roles = "Doctor,Admin,Receptionist")]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        var request = new GetPrescriptionByIdRequest { Id = id };

        var response = await _mediator.Send(request);

        return Ok(response);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var request = new GetAllPrescriptionsRequest();
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [Authorize(Roles = "Doctor")]
    [HttpPost("{id}/medicine")]

    public async Task<IActionResult> AddPrescriptionItem([FromRoute] Guid id, [FromBody] AddPrescriptionItemRequest request)
    {
        request.PrescriptionId = id;

        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [Authorize(Roles = "Doctor,Admin,Receptionist")]
    [HttpGet("{id}/medicines")]

    public async Task<IActionResult> GetPrescriptionItems([FromRoute] Guid id)
    {
        var request = new GetPrescriptionItemsRequest { Id = id };

        var response = await _mediator.Send(request);

        return Ok(response);
    }

}


