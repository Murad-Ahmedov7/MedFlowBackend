using Application.Business.Categories.Requests;
using Application.Business.Categories.Responses;
using Application.Infrastructure;
using AutoMapper;
using DataAccess.Core;
using Domain.Entities;
using Domain.ResponseModel;

namespace Application.Business.Categories.Commands;

internal sealed class CreateCategoryCommand : SysRequestHandler<CreateCategoryRequest, Result<CreateCategoryResponse>>
{
    private readonly SqlUnitOfWork _sqlUnitOfWork;
    private readonly IMapper _mapper;

    public CreateCategoryCommand(SqlUnitOfWork sqlUnitOfWork, IMapper mapper, ICurrentUserService currentUserService)
        : base(currentUserService)
    {
        _sqlUnitOfWork = sqlUnitOfWork;
        _mapper = mapper;
    }

    public override async Task<Result<CreateCategoryResponse>> Handle(CreateCategoryRequest request, CancellationToken cancellationToken)
    {
        var newCategory = _mapper.Map<Category>(request);
        newCategory.CreatedAt = DateTime.UtcNow;
        newCategory.CreatedBy = GetCurrentUserIdOrThrow();
        _sqlUnitOfWork.CategoryRepository.Add(newCategory);
        await _sqlUnitOfWork.SaveChangesAsync();
        var mappedNewCategory = _mapper.Map<CreateCategoryResponse>(newCategory);
        return new Result<CreateCategoryResponse> { Data = mappedNewCategory };
    }
}
