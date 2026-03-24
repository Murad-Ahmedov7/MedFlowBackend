
using Application.Business.Services.Requests;
using Application.Business.Services.Responses;
using Application.Infrastructure;
using AutoMapper;
using DataAccess.Core;
using Domain.Entities.Services;
using Domain.Exceptions;
using Domain.ResponseModel;

namespace Application.Business.Services.Commands;

internal sealed class CreateServiceCommand : SysRequestHandler<CreateServiceRequest, Result<CreateServiceResponse>>
{
    private readonly SqlUnitOfWork _sqlUnitOfWork;
    private readonly IMapper _mapper;

    public CreateServiceCommand(SqlUnitOfWork sqlUnitOfWork, IMapper mapper, ICurrentUserService currentUserService)
        : base(currentUserService)
    {
        _sqlUnitOfWork = sqlUnitOfWork;
        _mapper = mapper;
    }

    public override async Task<Result<CreateServiceResponse>> Handle(CreateServiceRequest request, CancellationToken cancellationToken)
    {

        var service = await _sqlUnitOfWork.ServiceRepository.ExistsByNameAsync(request.Name, cancellationToken);

        if (service) throw new ConflictException("Service already exists");


        var newService = _mapper.Map<Service>(request);

        newService.CreatedAt = DateTime.UtcNow;

        newService.CreatedBy = GetCurrentUserIdOrThrow();

        _sqlUnitOfWork.ServiceRepository.Add(newService);

        await _sqlUnitOfWork.SaveChangesAsync();

        var result = _mapper.Map<CreateServiceResponse>(newService);

        return new Result<CreateServiceResponse> { Data = result };
    }
}
