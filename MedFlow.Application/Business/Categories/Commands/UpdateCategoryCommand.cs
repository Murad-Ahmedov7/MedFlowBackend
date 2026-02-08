using Application.Business.Categories.Requests;
using Application.Business.Categories.Responses;
using Application.Infrastructure;
using AutoMapper;
using DataAccess.Core;
using Domain.ResponseModel;

namespace Application.Business.Categories.Commands;

internal sealed class UpdateCategoryCommand : SysRequestHandler<UpdateCategoryRequest, Result<UpdateCategoryResponse>>
{
    private readonly SqlUnitOfWork _sqlUnitOfWork;
    private readonly IMapper _mapper;

    public UpdateCategoryCommand(SqlUnitOfWork sqlUnitOfWork, IMapper mapper)
    {
        _sqlUnitOfWork = sqlUnitOfWork;
        _mapper = mapper;
    }

    public override async Task<Result<UpdateCategoryResponse>> Handle(UpdateCategoryRequest request, CancellationToken cancellationToken)
    {
        var category = await _sqlUnitOfWork.CategoryRepository.GetByIdAsync(request.Id, cancellationToken);

        ThrowUserErrorIfNull(category, "Kateqoriya tapılmadı");

        category!.Name = request.Name;
        _sqlUnitOfWork.CategoryRepository.Update(category);
        await _sqlUnitOfWork.SaveChangesAsync();

        var response = _mapper.Map<UpdateCategoryResponse>(category);
        return new Result<UpdateCategoryResponse> { Data = response };
    }
}
