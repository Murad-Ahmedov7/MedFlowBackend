using Application.Business.Categories.Responses;
using Domain.ResponseModel;
using MediatR;

namespace Application.Business.Categories.Requests;

public record class UpdateCategoryRequest : IRequest<Result<UpdateCategoryResponse>>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
}
