
using Application.Business.DoctorSchedules.Requests;
using Application.Business.DoctorSchedules.Responses;
using Application.Infrastructure;
using AutoMapper;
using DataAccess.Core;
using Domain.ResponseModel;


namespace Application.Business.DoctorSchedules.Queries;



internal sealed class GetDoctorSchedulesByDoctorIdQuery : SysRequestHandler<GetDoctorSchedulesByDoctorIdRequest, ListResult<DoctorScheduleResponse>>
{
    private readonly SqlUnitOfWork _sqlUnitOfWork;
    private readonly IMapper _mapper;

    public GetDoctorSchedulesByDoctorIdQuery(SqlUnitOfWork sqlUnitOfWork, IMapper mapper)
    {
        _sqlUnitOfWork = sqlUnitOfWork;
        _mapper = mapper;
    }

    public override async Task<ListResult<DoctorScheduleResponse>> Handle(GetDoctorSchedulesByDoctorIdRequest request, CancellationToken cancellationToken)
    {

        var doctorSchedules=await _sqlUnitOfWork.DoctorScheduleRepository.GetAllAsync(cancellationToken);

        var response =_mapper.Map<List<DoctorScheduleResponse>>(doctorSchedules);

        return new ListResult<DoctorScheduleResponse> { Data = response };
    }

}

