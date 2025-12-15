using EmployeeEntity = Redarbor.Domain.Entities.Employee;

namespace Redarbor.Application.Queries.Employee.Models;

public class GetEmployeeResponseModel
{
    public List<EmployeeEntity> Employees { get; set; } = [];
}
