
using Application.Business.Patients.Responses;
using Domain.Entities.Patients.Enums;
using Domain.ResponseModel;
using MediatR;

namespace Application.Business.Patients.Requests;

public record class CreatePatientRequest:IRequest<Result<CreatePatientResponse>>
{
    public string FirstName { get; set; }=string.Empty;

    public string LastName { get; set; }= string.Empty;

    public string Fin {  get; set; }=string.Empty;

    public string Phone { get; set; }=string.Empty;

    public string? Address {  get; set; }

    public DateTime BirthDate {  get; set; }

    public Gender Gender { get; set; } // 1 = Male, 2 = Female

    public BloodGroup BloodGroup { get; set; } // 0–8

    public string? Allergies { get; set; }

}