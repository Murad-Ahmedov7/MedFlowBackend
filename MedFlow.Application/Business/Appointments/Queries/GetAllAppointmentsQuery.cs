


using Application.Business.Appointments.Requests;
using Application.Business.Appointments.Responses;
using Application.Business.Patients.Responses;
using Application.Infrastructure;
using AutoMapper;
using DataAccess.Core;
using Domain.ResponseModel;

namespace Application.Business.Appointments.Queries
{
    internal sealed class GetAllAppointmentsQuery : SysRequestHandler<GetAllAppointmentsRequest, ListResult<AppointmentResponse>>
    {
        private readonly SqlUnitOfWork _sqlUnitOfWork;

        private readonly IMapper _mapper;


        public GetAllAppointmentsQuery(SqlUnitOfWork sqlUnitOfWork, IMapper mapper)
        {
            _sqlUnitOfWork = sqlUnitOfWork;
            _mapper = mapper;
        }
        public override async Task<ListResult<AppointmentResponse>> Handle(GetAllAppointmentsRequest request, CancellationToken cancellationToken)
        {
            var appointments = await _sqlUnitOfWork.AppointmentRepository.GetAllAppointmentsAsync(cancellationToken);

            var response = _mapper.Map<List<AppointmentResponse>>(appointments);

            return new ListResult<AppointmentResponse> { Data=response };

        }
    }
}
