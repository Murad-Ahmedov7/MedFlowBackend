
using Application.Business.Patients.Requests;
using Application.Business.Patients.Responses;
using Application.Infrastructure;
using AutoMapper;
using DataAccess.Core;
using Domain.ResponseModel;

namespace Application.Business.Patients.Commands;

internal sealed class UpdatePatientCommand : SysRequestHandler<UpdatePatientRequest, Result<PatientResponse>>
{
    private readonly SqlUnitOfWork _sqlUnitOfWork;
    private readonly IMapper _mapper;

    public UpdatePatientCommand(SqlUnitOfWork sqlUnitOfWork, IMapper mapper)
    {
        _sqlUnitOfWork = sqlUnitOfWork;
        _mapper = mapper;
    }

    public override async Task<Result<PatientResponse>> Handle(UpdatePatientRequest request, CancellationToken cancellationToken)
    {
        var patient = await _sqlUnitOfWork.PatientRepository.GetByIdAsync(request.Id, cancellationToken);

        ThrowNotFoundIfNull(patient, "Pasiyent tapılmadı");

        var existingPatient = await _sqlUnitOfWork.PatientRepository.GetPatientByFinAsync(request.Fin, cancellationToken);

        //if(existingPatient!=null)

        if (existingPatient is not null) ThrowUserError("Bu FIN artıq mövcuddur");

        _mapper.Map(request, patient);

   
        await _sqlUnitOfWork.SaveChangesAsync();

        var response = _mapper.Map<PatientResponse>(patient);

        return new Result<PatientResponse> { Data = response };
    }
}