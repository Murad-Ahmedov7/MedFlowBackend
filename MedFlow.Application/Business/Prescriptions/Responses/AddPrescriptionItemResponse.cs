

namespace Application.Business.Prescriptions.Responses;

public class AddPrescriptionItemResponse
{
    public Guid Id { get; set; }
    public Guid PrescriptionId { get; set; }

    public Guid MedicineId { get; set; }

    public decimal Dose { get; set; }

    public int DurationInDays { get; set; }

    public int Frequency { get; set; }

    public string? UsageInstruction { get; set; }
}

