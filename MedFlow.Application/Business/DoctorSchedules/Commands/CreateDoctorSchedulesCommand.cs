



using Application.Business.DoctorSchedules.Requests;
using Application.Business.DoctorSchedules.Responses;
using Application.Infrastructure;
using AutoMapper;
using Azure;
using DataAccess.Core;
using Domain.Entities.DoctorSchedules;
using Domain.Exceptions;
using Domain.ResponseModel;



namespace Application.Business.DoctorSchedules.Commands;

internal sealed class CreateDoctorSchedulesCommand : SysRequestHandler<CreateDoctorSchedulesReqeust, ListResult<DoctorScheduleResponse>>
{
    private readonly SqlUnitOfWork _sqlUnitOfWork;

    private readonly IMapper _mapper;


    public CreateDoctorSchedulesCommand(SqlUnitOfWork sqlUnitOfWork, IMapper mapper, ICurrentUserService currentUserService)
        : base(currentUserService)
    {
        _sqlUnitOfWork = sqlUnitOfWork;
        _mapper = mapper;
    }


    public override async Task<ListResult<DoctorScheduleResponse>> Handle(CreateDoctorSchedulesReqeust request, CancellationToken cancellationToken)
    {
     
        var newDoctorSchedules = _mapper.Map<List<DoctorSchedule>>(request.Schedules);

           
        var dayOfWeeks = await _sqlUnitOfWork.DoctorScheduleRepository.GetDayOfWeeksByDoctorIdAsync(request.DoctorId, cancellationToken);


        foreach (var schedule in newDoctorSchedules)
        {
            schedule.DoctorId = request.DoctorId;
            schedule.CreatedAt=DateTime.UtcNow;
            schedule.CreatedBy=GetCurrentUserIdOrThrow();


            if (dayOfWeeks.Contains(schedule.DayOfWeek))
            {
                throw new ConflictException("Schedule for this DayOfWeek already exists for the doctor.");
            }

            _sqlUnitOfWork.DoctorScheduleRepository.Add(schedule);
        }

        await _sqlUnitOfWork.SaveChangesAsync();

        var result = _mapper.Map<List<DoctorScheduleResponse>>(newDoctorSchedules);

        return new ListResult<DoctorScheduleResponse> { Data = result };

    }

}




