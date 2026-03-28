
using Application.Business.Invoices.Requests;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedFlow.Api.Controllers;

[Route("api")]
[ApiController]
public class InvoiceController : MedFlowApiController
{
    private readonly IMediator _mediator;

    public InvoiceController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [Authorize(Roles = "Admin,Receptionist,Doctor")]
    [HttpGet("invoice/{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        var request = new GetInvoiceByIdRequest { Id = id };

        var response = await _mediator.Send(request);

        return Ok(response);
    }

    [Authorize(Roles = "Admin,Receptionist")]
    [HttpGet("invoice")]
    public async Task<IActionResult> GetAll()
    {
        var request = new GetInvoicesRequest();

        var response = await _mediator.Send(request);

        return Ok(response);
    }

    [Authorize(Roles = "Admin,Receptionist")]
    [HttpPost("patient/{id}/invoices")] 
    public async Task<IActionResult> CreateInvoice([FromRoute] Guid id, [FromBody] CreateInvoiceRequest request)
    {
        request.PatientId = id;

        var response = await _mediator.Send(request);

        return Ok(response);
    }

    [Authorize(Roles = "Admin,Receptionist,Doctor")]
    [HttpGet("patient{id}/invoices")]
    public async Task<IActionResult> GetAllInvoices([FromRoute] Guid id)
    {
        var request = new GetPatientInvoicesRequest { Id = id };

        var response = await _mediator.Send(request);

        return Ok(response);
    }

}
