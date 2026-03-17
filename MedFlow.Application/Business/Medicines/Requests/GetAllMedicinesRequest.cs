
using Application.Business.Medicines.Responses;
using Domain.ResponseModel;
using MediatR;

namespace Application.Business.Medicines.Requests;

public record class GetAllMedicinesRequest : IRequest<ListResult<MedicineResponse>>
{

}

