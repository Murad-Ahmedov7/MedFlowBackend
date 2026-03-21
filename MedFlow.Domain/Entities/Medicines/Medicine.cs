
using Domain.Entities.Base;
using Domain.Entities.Medicines.Enums;
using Domain.Entities.Prescriptions;


namespace Domain.Entities.Medicines;
public class Medicine : BaseEntity
{
    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public MedicineForm Form { get; set; }

    public MedicineUnit Unit { get; set; }

    public List<PrescriptionItem> PrescriptionItems { get; set; } = null!;
}
