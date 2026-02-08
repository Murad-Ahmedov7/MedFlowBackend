using Application.Business.Categories.Requests;
using Application.Infrastructure;
using DataAccess.Core;
using Domain.ResponseModel;

namespace Application.Business.Categories.Commands;

internal sealed class DeleteCategoryCommand : SysRequestHandler<DeleteCategoryRequest, Result>
{
    private readonly SqlUnitOfWork _sqlUnitOfWork;

    public DeleteCategoryCommand(SqlUnitOfWork sqlUnitOfWork)
    {
        _sqlUnitOfWork = sqlUnitOfWork;
    }

    public override async Task<Result> Handle(DeleteCategoryRequest request, CancellationToken cancellationToken)
    {
        var category = await _sqlUnitOfWork.CategoryRepository.GetByIdAsync(request.Id, cancellationToken);

        ThrowUserErrorIfNull(category, "Kateqoriya tapılmadı");

        _sqlUnitOfWork.CategoryRepository.Delete(category!);
        await _sqlUnitOfWork.SaveChangesAsync();

        return new Result();
    }
}
