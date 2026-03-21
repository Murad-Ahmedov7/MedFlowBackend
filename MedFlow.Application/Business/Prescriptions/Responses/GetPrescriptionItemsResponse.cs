

using Application.Business.Medicines.Responses;

namespace Application.Business.Prescriptions.Responses;

public class GetPrescriptionItemsResponse
{
    public Guid Id { get; set; }

    public decimal Dose { get; set; }

    public int DurationInDays { get; set; }

    public int Frequency { get; set; }

    public string? UsageInstruction { get; set; }

    public MedicineResponse Medicine { get; set; } = new();
}
