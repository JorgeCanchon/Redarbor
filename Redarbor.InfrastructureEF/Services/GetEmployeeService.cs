using Microsoft.EntityFrameworkCore;
using Redarbor.Domain.Entities;
using Redarbor.Domain.Services;
using Redarbor.Domain.Shared.Enums;
using Redarbor.InfrastructureEF.Persistence;

namespace Redarbor.InfrastructureEF.Services;

public class GetEmployeeService(Context context) : IGetEmployeeService
{
    public async Task<Employee?> GetEmployeeById(Guid employeeId, CancellationToken cancellationToken)
    => await context.Employees
            .Include(e => e.Role)
            .Include(e => e.Company)
            .Include(e => e.Portal)
            .Include(e => e.User)
            .FirstOrDefaultAsync(e => e.Id == employeeId, cancellationToken);

    public async Task<List<Employee>> GetEmployees(CancellationToken cancellationToken)
    {
       return await context.Employees
            .Include(e => e.Role)
            .Include(e => e.Company)
            .Include(e => e.Portal)
            .Include(e => e.User)
            .Where(e => e.Status != Status.Inactive).ToListAsync(cancellationToken);
    }
}
