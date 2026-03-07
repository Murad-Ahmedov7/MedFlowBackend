
using Application.Business.Doctors.Responses;
using Domain.ResponseModel;
using MediatR;

namespace Application.Business.Doctors.Requests;
public record class GetAllDoctorsRequest : IRequest<ListResult<DoctorResponse>>
{

}

