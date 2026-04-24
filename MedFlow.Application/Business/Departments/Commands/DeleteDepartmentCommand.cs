

using Application.Business.Departments.Requests;
using Application.Infrastructure;
using DataAccess.Core;
using Domain.ResponseModel;

namespace Application.Business.Departments.Commands;

internal sealed class DeleteDepartmentCommand : SysRequestHandler<DeleteDepartmentRequest, Result>
{
    private readonly SqlUnitOfWork _sqlUnitOfWork;

    public DeleteDepartmentCommand(SqlUnitOfWork sqlUnitOfWork)
    {
        _sqlUnitOfWork = sqlUnitOfWork;
    }

    public override async Task<Result> Handle(DeleteDepartmentRequest request, CancellationToken cancellationToken)
    {
        var department = await _sqlUnitOfWork.DepartmentRepository.GetByIdAsync(request.Id, cancellationToken);

        ThrowNotFoundIfNull(department, "Department Not Found");

        _sqlUnitOfWork.DepartmentRepository.Delete(department!);

        await _sqlUnitOfWork.SaveChangesAsync();

        return new Result();
    }
}
