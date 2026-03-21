

using Domain.Entities.Medicines;

namespace Domain.Entities.Prescriptions;

public class PrescriptionItem
{
    public Guid Id { get; set; }
    public Guid PrescriptionId { get; set; }
    public Guid MedicineId { get; set; }

    public decimal Dose { get; set; }
    public int DurationInDays { get; set; }
    public int Frequency { get; set; }
    public string? UsageInstruction { get; set; }

    public Prescription Prescription { get; set; } = null!;
    public Medicine Medicine { get; set; } = null!;

}


