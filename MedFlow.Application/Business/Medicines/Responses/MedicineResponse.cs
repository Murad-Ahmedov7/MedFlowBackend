

namespace Application.Business.Medicines.Responses;

public class MedicineResponse
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public byte Form { get; set; }

    public byte Unit { get; set; }
}

