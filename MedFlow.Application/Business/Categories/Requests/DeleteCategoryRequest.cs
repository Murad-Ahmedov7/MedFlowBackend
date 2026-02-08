using Domain.ResponseModel;
using MediatR;

namespace Application.Business.Categories.Requests;

public record class DeleteCategoryRequest : IRequest<Result>
{
    public Guid Id { get; set; }
}