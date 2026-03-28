
using Application.Business.Payments.Requests;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedFlow.Api.Controllers;

[Route("api/invoice")]
[ApiController]
public class PaymentController : MedFlowApiController
{
    private readonly IMediator _mediator;

    public PaymentController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [Authorize(Roles = "Admin,Receptionist")]
    [HttpPost("{id}/payment")]
    public async Task<IActionResult> Create([FromRoute] Guid id,[FromBody] CreatePaymentRequest request)
    {
        request.InvoiceId = id;

        var response= await _mediator.Send(request);

        return Ok(response);
    }

}