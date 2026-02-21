using Application.Business.Categories.Requests;
using Application.Business.Users.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MedFlow.Api.Controllers;

[Route("api/auth")]
[ApiController]
public class AuthController : MedFlowApiController
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Create([FromBody] RegisterUserRequest request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }


    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginUserRequest request)
    {
        var response = await _mediator.Send(request);

        return Ok(response);
    }

    [HttpPost("refresh-token")]
    public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequest request)
    {
        var response = await _mediator.Send(request);

        return Ok(response);
    }
}
