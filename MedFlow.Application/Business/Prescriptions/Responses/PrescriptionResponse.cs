
namespace Application.Business.Prescriptions.Responses;

public class PrescriptionResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public Guid ExaminationId { get; set; }
}
