
using Application.Business.Patients.Requests;
using Application.Business.Patients.Responses;
using Application.Infrastructure;
using AutoMapper;
using DataAccess.Core;
using Domain.Entities.Patients;
using Domain.ResponseModel;

namespace Application.Business.Patients.Commands;

internal sealed class CreatePatientCommand : SysRequestHandler<CreatePatientRequest, Result<PatientResponse>>
{
    private readonly SqlUnitOfWork _sqlUnitOfWork;

    private readonly IMapper _mapper;


    public CreatePatientCommand(SqlUnitOfWork sqlUnitOfWork, IMapper mapper, ICurrentUserService currentUserService)
        : base(currentUserService)
    {
        _sqlUnitOfWork = sqlUnitOfWork;
        _mapper = mapper;
    }


    public override async Task<Result<PatientResponse>> Handle(CreatePatientRequest request, CancellationToken cancellationToken)
    {
        var newPatient = _mapper.Map<Patient>(request);
        newPatient.CreatedAt = DateTime.UtcNow;
        newPatient.CreatedBy = GetCurrentUserIdOrThrow();
        _sqlUnitOfWork.PatientRepository.Add(newPatient);
        await _sqlUnitOfWork.SaveChangesAsync();
        var mappedNewPatient = _mapper.Map<PatientResponse>(newPatient);
        return new Result<PatientResponse> { Data = mappedNewPatient };
    }



}

