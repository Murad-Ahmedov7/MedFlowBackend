using Application.Business.Categories.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MedFlow.Api.Controllers;

public class CategoryController : MedFlowApiController
{
    private readonly IMediator _mediator;

    public CategoryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCategoryRequest request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var request = new GetAllCategoriesRequest();
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        var request = new GetCategoryByIdRequest { Id = id };
        var response = await _mediator.Send(request);
        return OkOrNotFound(response);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateCategoryRequest request)
    {
        request.Id = id;
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var request = new DeleteCategoryRequest { Id = id };
        var response = await _mediator.Send(request);
        return Ok(response);
    }
}
