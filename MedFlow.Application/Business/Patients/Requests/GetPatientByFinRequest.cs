using Application.Business.Patients.Responses;
using Domain.ResponseModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Business.Patients.Requests;

public record class GetPatientByFinRequest : IRequest<Result<PatientResponse>>
{
    public string Fin { get; set; } = string.Empty;
}

