using Application.Business.Medicines.Requests;
using Application.Business.Medicines.Responses;
using Application.Infrastructure;
using AutoMapper;
using DataAccess.Core;
using Domain.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Business.Medicines.Queries
{
    public sealed class GetAllMedicinesQuery : SysRequestHandler<GetAllMedicinesRequest, ListResult<MedicineResponse>>
    {
        private readonly SqlUnitOfWork _sqlUnitOfWork;

        private readonly IMapper _mapper;

        public GetAllMedicinesQuery(SqlUnitOfWork sqlUnitOfWork, IMapper mapper)
        {
            _sqlUnitOfWork = sqlUnitOfWork;
            _mapper = mapper;
        }

        public override async Task<ListResult<MedicineResponse>> Handle(GetAllMedicinesRequest request, CancellationToken cancellationToken)
        {
            var medicines = await _sqlUnitOfWork.MedicineRepository.GetAllAsync(cancellationToken);

            var response = _mapper.Map<List<MedicineResponse>>(medicines);

            return new ListResult<MedicineResponse> { Data = response };

        }
    }
}
