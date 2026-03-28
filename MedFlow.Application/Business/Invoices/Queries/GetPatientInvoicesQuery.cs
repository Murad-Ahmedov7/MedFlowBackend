
using Application.Business.Invoices.Requests;
using Application.Business.Invoices.Responses;
using Application.Infrastructure;
using AutoMapper;
using DataAccess.Core;
using Domain.ResponseModel;

namespace Application.Business.Invoices.Queries;

internal sealed class GetPatientInvoicesQuery : SysRequestHandler<GetPatientInvoicesRequest, ListResult<PatientInvoiceResponse>>
{
    private readonly SqlUnitOfWork _sqlUnitOfWork;

    private readonly IMapper _mapper;

    public GetPatientInvoicesQuery(SqlUnitOfWork sqlUnitOfWork, IMapper mapper)
    {
        _sqlUnitOfWork = sqlUnitOfWork;
        _mapper = mapper;
    }

    public override async Task<ListResult<PatientInvoiceResponse>> Handle(GetPatientInvoicesRequest request, CancellationToken cancellationToken)
    {

        var patientInvoices = await _sqlUnitOfWork.InvoiceRepository.GetPatientInvoicesAsync(request.Id, cancellationToken);

        if (patientInvoices.Count == 0)
        {
            var patient = await _sqlUnitOfWork.PatientRepository.GetByIdAsync(request.Id, cancellationToken);
            ThrowNotFoundIfNull(patient, "Patient not found");
        }

        var response = _mapper.Map<List<PatientInvoiceResponse>>(patientInvoices);


        foreach (var x in response)
        {
            x.RemainingAmount = x.TotalAmount - x.PaidAmount;
        }

        return new ListResult<PatientInvoiceResponse> { Data = response };
    }
}