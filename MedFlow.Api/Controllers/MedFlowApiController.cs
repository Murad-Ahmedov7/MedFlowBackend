using MedFlow.Api.Infrastructures;
using Microsoft.AspNetCore.Mvc;

namespace MedFlow.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MedFlowApiController : ControllerBase
{
    protected IActionResult BadRequestX(string message)
    {
        return BadRequest(new HttpErrorResponse(message));
    }

    protected IActionResult NotFoundX()
    {
        return NotFound(new HttpErrorResponse("Məlumat tapılmadı"));
    }

    protected IActionResult OkOrNotFound(object? data)
    {
        if (data is null) return NotFoundX();

        return Ok(data);
    }
}
