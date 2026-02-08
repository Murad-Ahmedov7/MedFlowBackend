using Application.Business.Categories.Requests;
using Application.Business.Categories.Responses;
using Application.Infrastructure;
using AutoMapper;
using DataAccess.Core;
using Domain.ResponseModel;

namespace Application.Business.Categories.Queries;

internal sealed class GetAllCategoriesQuery : SysRequestHandler<GetAllCategoriesRequest, ListResult<GetAllCategoriesResponse>>
{
    private readonly SqlUnitOfWork _sqlUnitOfWork;
    private readonly IMapper _mapper;

    public GetAllCategoriesQuery(SqlUnitOfWork sqlUnitOfWork, IMapper mapper)
    {
        _sqlUnitOfWork = sqlUnitOfWork;
        _mapper = mapper;
    }

    public override async Task<ListResult<GetAllCategoriesResponse>> Handle(GetAllCategoriesRequest request, CancellationToken cancellationToken)
    {
        var categories = await _sqlUnitOfWork.CategoryRepository.GetAllAsync(cancellationToken);

        var response = _mapper.Map<List<GetAllCategoriesResponse>>(categories);

        return new ListResult<GetAllCategoriesResponse> { Data = response };
    }
}
