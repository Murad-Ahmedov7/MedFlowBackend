

using Application.Business.Examinations.Responses;
using Domain.ResponseModel;
using MediatR;

namespace Application.Business.Examinations.Requests;

public record class GetExaminationByIdRequest:IRequest<Result<GetExaminationByIdResponse>>
{
    public Guid Id { get; set; }
}

