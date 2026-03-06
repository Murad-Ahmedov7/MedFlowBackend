using Application.Business.Patients.Requests;
using Application.Business.Patients.Responses;
using Application.Infrastructure;
using AutoMapper;
using DataAccess.Core;
using Domain.ResponseModel;


namespace Application.Business.Patients.Queries
{
    internal sealed class GetPatientByFinQuery : SysRequestHandler<GetPatientByFinRequest, Result<PatientResponse>>
    {
        private readonly SqlUnitOfWork _sqlUnitOfWork;
        private readonly IMapper _mapper;

        public GetPatientByFinQuery(SqlUnitOfWork sqlUnitOfWork, IMapper mapper)
        {
            _sqlUnitOfWork = sqlUnitOfWork;
            _mapper = mapper;
        }

        public override async Task<Result<PatientResponse>> Handle(GetPatientByFinRequest request, CancellationToken cancellationToken)
        {
            var patient = await _sqlUnitOfWork.PatientRepository.GetPatientByFinAsync(request.Fin, cancellationToken);
            //ThrowUserErrorIfNull(patient, "Pasiyent tapılmadı");

            ThrowNotFoundIfNull(patient, "Pasiyent tapılmadı");

            var response = _mapper.Map<PatientResponse>(patient);

            return new Result<PatientResponse> { Data = response };
        }
    }
}
