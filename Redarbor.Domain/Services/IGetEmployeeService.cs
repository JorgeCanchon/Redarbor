using Redarbor.Domain.Entities;

namespace Redarbor.Domain.Services;

public interface IGetEmployeeService
{
    public Task<List<Employee>> GetEmployees(CancellationToken cancellationToken);
    public Task<Employee?> GetEmployeeById(Guid employeeId, CancellationToken cancellationToken);
}
