

using Application.Business.Examinations.Requests;
using Application.Business.Examinations.Responses;
using Application.Infrastructure;
using AutoMapper;
using DataAccess.Core;
using Domain.ResponseModel;

namespace Application.Business.Examinations.Queries
{
    public sealed class GetExaminationByIdQuery : SysRequestHandler<GetExaminationByIdRequest, Result<GetExaminationByIdResponse>>
    {
        private readonly IMapper _mapper;
        private readonly SqlUnitOfWork _sqlUnitOfWork;

        public GetExaminationByIdQuery(IMapper mapper, SqlUnitOfWork sqlUnitOfWork)
        {
            _mapper = mapper;
            _sqlUnitOfWork = sqlUnitOfWork;
        }

        public override async Task<Result<GetExaminationByIdResponse>> Handle(GetExaminationByIdRequest request, CancellationToken cancellationToken)
        {
            var examination = await _sqlUnitOfWork.ExaminationRepository.GetByIdAsync(request.Id, cancellationToken);

            ThrowNotFoundIfNull(examination, "Examination Not Found");

            var result=_mapper.Map<GetExaminationByIdResponse>(examination);

            return new Result<GetExaminationByIdResponse> { Data = result };
        }
    }
}
