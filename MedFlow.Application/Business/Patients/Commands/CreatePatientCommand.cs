
using Application.Business.Patients.Requests;
using Application.Business.Patients.Responses;
using Application.Infrastructure;
using AutoMapper;
using DataAccess.Core;
using Domain.Entities.Patients;
using Domain.ResponseModel;

namespace Application.Business.Patients.Commands;

internal sealed class CreatePatientCommand : SysRequestHandler<CreatePatientRequest, Result<CreatePatientResponse>>
{
    private readonly SqlUnitOfWork _sqlUnitOfWork;

    private readonly IMapper _mapper;


    public CreatePatientCommand(SqlUnitOfWork sqlUnitOfWork, IMapper mapper, ICurrentUserService currentUserService)
        : base(currentUserService)
    {
        _sqlUnitOfWork = sqlUnitOfWork;
        _mapper = mapper;
    }


    public override async Task<Result<CreatePatientResponse>> Handle(CreatePatientRequest request, CancellationToken cancellationToken)
    {
        var existingPatient = await _sqlUnitOfWork.PatientRepository
        .GetPatientByFinAsync(request.Fin, cancellationToken);

        //if(existingPatient!=null)

        if (existingPatient is not null) ThrowUserError("Bu FIN artıq mövcuddur");

        var newPatient = _mapper.Map<Patient>(request);

        newPatient.CreatedAt = DateTime.UtcNow;

        newPatient.CreatedBy = GetCurrentUserIdOrThrow();

        _sqlUnitOfWork.PatientRepository.Add(newPatient);

        await _sqlUnitOfWork.SaveChangesAsync();

        var mappedNewPatient = _mapper.Map<CreatePatientResponse>(newPatient);

        return new Result<CreatePatientResponse> { Data = mappedNewPatient };

    }



}
