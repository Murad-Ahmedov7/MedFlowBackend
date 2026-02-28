using Application.Business.Patients.Responses;
using Domain.ResponseModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Business.Patients.Requests;

public record class CreatePatientRequest:IRequest<Result<PatientResponse>>
{
    public string FirstName { get; set; }=string.Empty;

    public string LastName { get; set; }= string.Empty;

    public string Fin {  get; set; }=string.Empty;

    public string Phone { get; set; }=string.Empty;

    public string? Address {  get; set; }

    public DateTime BirthDate {  get; set; }

    public short Gender { get; set; }      // 1 = Male, 2 = Female
    public short BloodGroup { get; set; }  // 0–8

    public string? Allergies { get; set; }

}

