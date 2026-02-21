using Application.Business.Categories.Responses;
using Domain.ResponseModel;
using MediatR;

namespace Application.Business.Categories.Requests;

public record class CreateCategoryRequest : IRequest<Result<CreateCategoryResponse>>
{
    public string Name { get; set; } = string.Empty;
}
    