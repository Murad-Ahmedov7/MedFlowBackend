
using Application.Business.Receptionists.Requests;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedFlow.Api.Controllers;

[Authorize(Roles = "Admin")]
[Route("api/receptionists")]
[ApiController]
public class ReceptionistController : MedFlowApiController
{
    private readonly IMediator _mediator;

    public ReceptionistController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateReceptionistRequest request)
    {
        var response = await _mediator.Send(request);

        return Ok(response);
    }
}
