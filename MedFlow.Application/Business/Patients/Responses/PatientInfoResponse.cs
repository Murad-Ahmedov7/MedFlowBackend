
namespace Application.Business.Patients.Responses;

public class PatientInfoResponse
{
    public Guid Id { get; set; }

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string Fullname {  get; set; } = string.Empty;
}
