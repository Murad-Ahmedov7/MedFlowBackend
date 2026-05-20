

using Application.Business.Patients.Requests;
using Application.Business.Patients.Responses;
using Application.Infrastructure;
using AutoMapper;
using DataAccess.Core;
using Domain.ResponseModel;

namespace Application.Business.Patients.Queries;

internal sealed class GetPatientByIdQuery : SysRequestHandler<GetPatientByIdRequest, Result<PatientResponse>>
{
    private readonly SqlUnitOfWork _sqlUnitOfWork;
    private readonly IMapper _mapper;

    public GetPatientByIdQuery(SqlUnitOfWork sqlUnitOfWork, IMapper mapper)
    {
        _sqlUnitOfWork = sqlUnitOfWork;
        _mapper = mapper;
    }

    public override async Task<Result<PatientResponse>> Handle(GetPatientByIdRequest request, CancellationToken cancellationToken)
    {
        var patient = await _sqlUnitOfWork.PatientRepository.GetByIdAsync(request.Id, cancellationToken);

        ThrowNotFoundIfNull(patient, "Pasiyent tapılmadı");

        var response = _mapper.Map<PatientResponse>(patient);

        return new Result<PatientResponse> { Data = response };
    }
}
