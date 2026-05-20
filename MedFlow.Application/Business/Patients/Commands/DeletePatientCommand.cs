
using Application.Business.Patients.Requests;
using Application.Infrastructure;
using DataAccess.Core;
using Domain.Entities.Departments;
using Domain.ResponseModel;

namespace Application.Business.Patients.Commands;

internal sealed class DeletePatientCommand : SysRequestHandler<DeletePatientRequest, Result>
{
    private readonly SqlUnitOfWork _sqlUnitOfWork;

    public DeletePatientCommand(SqlUnitOfWork sqlUnitOfWork)
    {
        _sqlUnitOfWork = sqlUnitOfWork;
    }

    public override async Task<Result> Handle(DeletePatientRequest request, CancellationToken cancellationToken)
    {
        var patient=await _sqlUnitOfWork.PatientRepository.GetByIdAsync(request.Id,cancellationToken);

        ThrowNotFoundIfNull(patient, "Patient Not Found");

        _sqlUnitOfWork.PatientRepository.Delete(patient!);

        await _sqlUnitOfWork.SaveChangesAsync();

        return new Result();
    }
}
