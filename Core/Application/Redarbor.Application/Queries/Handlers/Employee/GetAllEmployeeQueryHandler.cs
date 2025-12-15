using MediatR;
using Redarbor.Application.Queries.Employee;
using Redarbor.Application.Queries.Employee.Models;
using Redarbor.Application.Shared.Wrappers;
using Redarbor.Domain.Services;
using EmployeeEntity = Redarbor.Domain.Entities.Employee;

namespace Redarbor.Application.Queries.Handlers.Employee;

public class GetAllEmployeeQueryHandler(IGetEmployeeService getEmployeeService) : IRequestHandler<GetAllEmployeeQuery, Response<GetEmployeeResponseModel>>
{
    public async Task<Response<GetEmployeeResponseModel>> Handle(GetAllEmployeeQuery request, CancellationToken cancellationToken)
    {
        List<EmployeeEntity> employees = await getEmployeeService.GetEmployees(cancellationToken);

        return new Response<GetEmployeeResponseModel>(new GetEmployeeResponseModel
        {
            Employees = employees
        });
    }
}
