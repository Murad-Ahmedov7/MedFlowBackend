
using Domain.Entities.Base;
using Domain.Entities.Examinations;

namespace Domain.Entities.Prescriptions;

public class Prescription : BaseEntity
{
    public string Title { get; set; } = null!;

    public Guid ExaminationId { get; set; }

    public Examination Examination { get; set; } = null!;

    public List<PrescriptionItem> PrescriptionItems { get; set; } = null!;
}
