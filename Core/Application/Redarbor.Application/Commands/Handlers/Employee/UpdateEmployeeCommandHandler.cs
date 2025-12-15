using MediatR;
using Redarbor.Application._Resources;
using Redarbor.Application.Commands.Employee;
using Redarbor.Application.Shared.Wrappers;
using Redarbor.Domain.Services.Persistence;
using EmployeeEntity = Redarbor.Domain.Entities.Employee;

namespace Redarbor.Application.Commands.Handlers.Employee;

public class UpdateEmployeeCommandHandler(IRepositoryAsync<EmployeeEntity> employeeRepositoryAsync) : IRequestHandler<UpdateEmployeeCommand, Response<Guid>>
{
    public async Task<Response<Guid>> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
    {
        EmployeeEntity employeeEntity = await employeeRepositoryAsync.FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken) ?? throw new KeyNotFoundException(string.Format(ApplicationErrors.EntityNotFound, nameof(EmployeeEntity), request.Id));
        employeeEntity.Update(request.Name, request.Email, request.Telephone, request.Fax, request.PortalId, request.CompanyId, request.RoleId, request.UserId, request.Status);
        await employeeRepositoryAsync.UpdateAsync(employeeEntity, cancellationToken);
        return new Response<Guid>(employeeEntity.Id);
    }
}
