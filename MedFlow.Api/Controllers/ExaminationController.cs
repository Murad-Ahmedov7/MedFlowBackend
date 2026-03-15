
using Application.Business.Examinations.Requests;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedFlow.Api.Controllers;

[Route("api/examination")]
[ApiController]
public class ExaminationController : MedFlowApiController
{
    private readonly IMediator _mediator;
    public ExaminationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [Authorize(Roles = "Admin,Doctor")]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateExaminationRequest request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);

    }
    [Authorize(Roles = "Admin,Doctor,Receptionist")]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        var request = new GetExaminationByIdRequest { Id = id };

        var response = await _mediator.Send(request);

        return Ok(response);
    }
}
