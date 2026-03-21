
using Application.Business.Prescriptions.Requests;
using Application.Business.Prescriptions.Responses;
using Application.Infrastructure;
using AutoMapper;
using DataAccess.Core;
using Domain.Entities.Prescriptions;
using Domain.Exceptions;
using Domain.ResponseModel;

namespace Application.Business.Prescriptions.Commands
{
    public sealed class CreatePrescriptionCommand : SysRequestHandler<CreatePrescriptionRequest,Result<PrescriptionResponse>>
    {
        private readonly SqlUnitOfWork _sqlUnitOfWork;
        private readonly IMapper _mapper;

        public CreatePrescriptionCommand(SqlUnitOfWork sqlUnitOfWork, IMapper mapper, ICurrentUserService currentUserService)
            :base(currentUserService)
        {
            _sqlUnitOfWork = sqlUnitOfWork;
            _mapper = mapper;
        }

        public override async Task<Result<PrescriptionResponse>> Handle(CreatePrescriptionRequest request, CancellationToken cancellationToken)
        {
            var examination = await _sqlUnitOfWork.ExaminationRepository.GetByIdAsync(request.ExaminationId, cancellationToken);

            ThrowNotFoundIfNull(examination, "Examination Not Found");

            var prescriptionExists=await _sqlUnitOfWork.PrescriptionRepository.PrescriptionExistsForExaminationAsync(request.ExaminationId, cancellationToken);

            if (prescriptionExists)  throw new ConflictException("A prescription for this examination already exists.");

            var newPrescription = _mapper.Map<Prescription>(request);

            newPrescription.CreatedAt= DateTime.UtcNow;
            newPrescription.CreatedBy = GetCurrentUserIdOrThrow();
            

            _sqlUnitOfWork.PrescriptionRepository.Add(newPrescription);
            await _sqlUnitOfWork.SaveChangesAsync();

            var result=_mapper.Map<PrescriptionResponse>(newPrescription);

            return new Result<PrescriptionResponse> { Data= result };
        }
    }
}
