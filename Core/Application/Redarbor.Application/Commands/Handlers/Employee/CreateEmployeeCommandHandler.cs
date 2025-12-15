using MediatR;
using Redarbor.Application.Commands.Employee;
using Redarbor.Application.Shared.Wrappers;
using Redarbor.Domain.Services.Persistence;
using EmployeeEntity = Redarbor.Domain.Entities.Employee;

namespace Redarbor.Application.Commands.Handlers.Employee;

public class CreateEmployeeCommandHandler(IRepositoryAsync<EmployeeEntity> repositoryAsync) : IRequestHandler<CreateEmployeeCommand, Response<Guid>>
{
    public async Task<Response<Guid>> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = EmployeeEntity.Create(
            request.Name,
            request.Email,
            request.Telephone,
            request.Fax,
            request.PortalId,
            request.CompanyId,
            request.RoleId,
            request.Status
        );

        employee.AddUser(request.Username, request.Password);

        var data = await repositoryAsync.AddAsync(employee, cancellationToken);
        return new Response<Guid>(data.Id);
    }
}
