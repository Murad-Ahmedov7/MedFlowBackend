using Application.Business.Departments.Requests;
using Application.Business.Departments.Responses;
using Application.Infrastructure;
using AutoMapper;
using DataAccess.Core;
using Domain.Entities.Departments;
using Domain.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Business.Departments.Commands
{
    internal sealed class CreateDepartmentCommand : SysRequestHandler<CreateDepartmentRequest, Result<DepartmentResponse>>
    {
        private readonly SqlUnitOfWork _sqlUnitOfWork;

        private readonly IMapper _mapper;


        public CreateDepartmentCommand(SqlUnitOfWork sqlUnitOfWork, IMapper mapper, ICurrentUserService currentUserService)
            : base(currentUserService)
        {
            _sqlUnitOfWork = sqlUnitOfWork;
            _mapper = mapper;
        }

        public override async Task<Result<DepartmentResponse>> Handle(CreateDepartmentRequest request, CancellationToken cancellationToken)
        {
            var newDepartment = _mapper.Map<Department>(request);

            newDepartment.CreatedAt = DateTime.UtcNow;

            newDepartment.CreatedBy = GetCurrentUserIdOrThrow();

            _sqlUnitOfWork.DepartmentRepository.Add(newDepartment);

            await _sqlUnitOfWork.SaveChangesAsync();

            var mappedNewDepartment = _mapper.Map<DepartmentResponse>(newDepartment);

            return new Result<DepartmentResponse> { Data = mappedNewDepartment };

        }
    }
}
