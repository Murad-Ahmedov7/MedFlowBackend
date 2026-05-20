using Application.Business.Patients.Requests;
using Application.Business.Patients.Responses;
using Application.Infrastructure;
using AutoMapper;
using DataAccess.Core;
using Domain.ResponseModel;
using MediatR;

namespace Application.Business.Patients.Queries;

internal sealed class GetAllPatientsQuery : SysRequestHandler<GetAllPatientsRequest, ListResult<PatientResponse>>
{
    private readonly SqlUnitOfWork _sqlUnitOfWork;

    private readonly IMapper _mapper;

    public GetAllPatientsQuery(SqlUnitOfWork sqlUnitOfWork, IMapper mapper)
    {
        _sqlUnitOfWork = sqlUnitOfWork;
        _mapper = mapper;
    }

    public override async Task<ListResult<PatientResponse>> Handle(GetAllPatientsRequest request, CancellationToken cancellationToken)
    {
        var patients = await _sqlUnitOfWork.PatientRepository.GetAllAsync(cancellationToken);

        var response = _mapper.Map<List<PatientResponse>>(patients);

        return new ListResult<PatientResponse> { Data = response };
    }
}
