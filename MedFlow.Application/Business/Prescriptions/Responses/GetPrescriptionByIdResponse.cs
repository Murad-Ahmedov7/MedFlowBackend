



namespace Application.Business.Prescriptions.Responses;

public class GetPrescriptionByIdResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public Guid ExaminationId { get; set; }
    public DateTime CreatedAt { get; set; }
    public List<GetPrescriptionItemsResponse> PrescriptionItems { get; set; } = new();
}