
using Application.Business.Doctors.Requests;
using Application.Business.Doctors.Responses;
using Application.Infrastructure;
using AutoMapper;
using DataAccess.Core;
using Domain.ResponseModel;

namespace Application.Business.Doctors.Queries;

    internal sealed class GetAllDoctorsQuery : SysRequestHandler<GetAllDoctorsRequest, ListResult<DoctorResponse>>
    {
        private readonly SqlUnitOfWork _sqlUnitOfWork;
        private readonly IMapper _mapper;

        public GetAllDoctorsQuery(SqlUnitOfWork sqlUnitOfWork, IMapper mapper)
        {
            _sqlUnitOfWork = sqlUnitOfWork;
            _mapper = mapper;
        }

        public override async Task<ListResult<DoctorResponse>> Handle(GetAllDoctorsRequest request, CancellationToken cancellationToken)
        {
        var doctors = await _sqlUnitOfWork.DoctorRepository.GetAllAsync(cancellationToken);

            var response = _mapper.Map<List<DoctorResponse>>(doctors);

            return new ListResult<DoctorResponse> { Data = response };
        }
    }

