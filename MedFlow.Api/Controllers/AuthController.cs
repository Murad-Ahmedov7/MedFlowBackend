
using Application.Business.Users.Requests;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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

    [Authorize(Roles = "Admin,Receptionist")]
    [HttpPost("sign-up")]
    public async Task<IActionResult> SignUp([FromBody] SignUpUserRequest request)
    {
        var response = await _mediator.Send(request);

        return Ok(response);
    }


    [HttpPost("sign-in")]
    public async Task<IActionResult> SignIn([FromBody] SignInUserRequest request)
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