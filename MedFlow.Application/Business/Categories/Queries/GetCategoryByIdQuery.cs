using Application.Business.Categories.Requests;
using Application.Business.Categories.Responses;
using Application.Infrastructure;
using AutoMapper;
using DataAccess.Core;
using Domain.ResponseModel;

namespace Application.Business.Categories.Queries;

internal sealed class GetCategoryByIdQuery : SysRequestHandler<GetCategoryByIdRequest, Result<GetCategoryByIdResponse>>
{
    private readonly SqlUnitOfWork _sqlUnitOfWork;
    private readonly IMapper _mapper;

    public GetCategoryByIdQuery(SqlUnitOfWork sqlUnitOfWork, IMapper mapper)
    {
        _sqlUnitOfWork = sqlUnitOfWork;
        _mapper = mapper;
    }

    public override async Task<Result<GetCategoryByIdResponse>> Handle(GetCategoryByIdRequest request, CancellationToken cancellationToken)
    {
        var category = await _sqlUnitOfWork.CategoryRepository.GetByIdAsync(request.Id, cancellationToken);

        ThrowUserErrorIfNull(category, "Kateqoriya tapılmadı");

        var response = _mapper.Map<GetCategoryByIdResponse>(category);
        return new Result<GetCategoryByIdResponse> { Data = response };
    }
}
