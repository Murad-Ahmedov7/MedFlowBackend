

using Application.Business.Examinations.Requests;
using Application.Business.Examinations.Responses;
using Application.Infrastructure;
using AutoMapper;
using DataAccess.Core;
using Domain.Entities.Examinations;
using Domain.ResponseModel;

public sealed class CreateExaminationCommand : SysRequestHandler<CreateExaminationRequest, Result<CreateExaminationResponse>>
{
    private readonly SqlUnitOfWork _sqlUnitOfWork;

    private readonly IMapper _mapper;

    public CreateExaminationCommand(SqlUnitOfWork sqlUnitOfWork, IMapper mapper, ICurrentUserService currentUserService)
        : base(currentUserService)
    {
        _sqlUnitOfWork = sqlUnitOfWork;
        _mapper = mapper;
    }
    public override async Task<Result<CreateExaminationResponse>> Handle(CreateExaminationRequest request, CancellationToken cancellationToken)
    {
        var appointment=await _sqlUnitOfWork.AppointmentRepository.GetByIdAsync(request.AppointmentId,cancellationToken);

        ThrowNotFoundIfNull(appointment, "Appointment not found");
        var newExamination=_mapper.Map<Examination>(request);

        newExamination.CreatedAt = DateTime.UtcNow;

        newExamination.CreatedBy = GetCurrentUserIdOrThrow();

        _sqlUnitOfWork.ExaminationRepository.Add(newExamination);
        await _sqlUnitOfWork.SaveChangesAsync();

        var result=_mapper.Map<CreateExaminationResponse>(newExamination);

        return new Result<CreateExaminationResponse> { Data = result };
    }
}



