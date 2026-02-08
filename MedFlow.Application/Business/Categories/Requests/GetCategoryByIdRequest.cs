using Application.Business.Categories.Responses;
using Domain.ResponseModel;
using MediatR;

namespace Application.Business.Categories.Requests;

public record class GetCategoryByIdRequest : IRequest<Result<GetCategoryByIdResponse>>
{
    public Guid Id { get; set; }
}
