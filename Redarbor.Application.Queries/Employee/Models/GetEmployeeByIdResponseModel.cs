using EmployeeEntity = Redarbor.Domain.Entities.Employee;

namespace Redarbor.Application.Queries.Employee.Models;

public class GetEmployeeByIdResponseModel
{
    public EmployeeEntity? Employee { get; set; } = null!;
}
