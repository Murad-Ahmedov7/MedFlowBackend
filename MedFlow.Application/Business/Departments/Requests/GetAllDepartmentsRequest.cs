


using Application.Business.Departments.Responses;
using Domain.ResponseModel;
using MediatR;

namespace Application.Business.Departments.Requests;

public record class GetAllDepartmentsRequest : IRequest<ListResult<DepartmentResponse>>
{

}
