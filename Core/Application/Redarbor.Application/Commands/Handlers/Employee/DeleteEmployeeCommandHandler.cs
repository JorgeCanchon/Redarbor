using MediatR;
using Redarbor.Application._Resources;
using Redarbor.Application.Commands.Employee;
using Redarbor.Application.Shared.Wrappers;
using Redarbor.Domain.Services.Persistence;
using EmployeeEntity = Redarbor.Domain.Entities.Employee;

namespace Redarbor.Application.Commands.Handlers.Employee;

public class DeleteEmployeeCommandHandler(IRepositoryAsync<EmployeeEntity> employeeRepositoryAsync) : IRequestHandler<DeleteEmployeeCommand, Response<Guid>>
{
    public async Task<Response<Guid>> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
    {
        EmployeeEntity employeeEntity = await employeeRepositoryAsync.FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken) ?? throw new KeyNotFoundException(string.Format(ApplicationErrors.EntityNotFound, nameof(EmployeeEntity), request.Id));
        employeeEntity.LogicalDelete();
        await employeeRepositoryAsync.UpdateAsync(employeeEntity, cancellationToken);
        return new Response<Guid>(employeeEntity.Id);
    }
}
