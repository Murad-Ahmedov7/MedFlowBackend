


using Application.Business.Medicines.Responses;
using Domain.ResponseModel;
using MediatR;

namespace Application.Business.Medicines.Requests;

public record class CreateMedicineRequest : IRequest<Result<MedicineResponse>>
{
    public string Name { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public byte Form { get; set; }

    public byte Unit { get; set; }
}

