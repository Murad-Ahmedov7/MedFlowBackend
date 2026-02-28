using Application.Business.Patients.Requests;
using Application.Business.Patients.Responses;
using Application.Infrastructure;
using AutoMapper;
using DataAccess.Core;
using Domain.ResponseModel;


namespace Application.Business.Patients.Queries
{
    internal sealed class GetPatientsByPhoneQuery : SysRequestHandler<GetPatientsByPhoneRequest, ListResult<PatientResponse>>
    {

        private readonly SqlUnitOfWork _sqlUnitOfWork;
        private readonly IMapper _mapper;


        public GetPatientsByPhoneQuery(SqlUnitOfWork sqlUnitOfWork, IMapper mapper)
        {
            _sqlUnitOfWork = sqlUnitOfWork;
            _mapper = mapper;

        }

        public override async Task<ListResult<PatientResponse>> Handle(GetPatientsByPhoneRequest request, CancellationToken cancellationToken)
        {
            var patients = await _sqlUnitOfWork.PatientRepository.GetPatientsByPhoneAsync(request.Phone, cancellationToken);

          

            var response = _mapper.Map<List<PatientResponse>>(patients);

            return new ListResult<PatientResponse> { Data = response };
        }
    }
}
