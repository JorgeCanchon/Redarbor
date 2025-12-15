using MediatR;
using Redarbor.Application.Queries.Employee;
using Redarbor.Application.Queries.Employee.Models;
using Redarbor.Application.Shared.Wrappers;
using Redarbor.Domain.Services;
using EmployeeEntity = Redarbor.Domain.Entities.Employee;

namespace Redarbor.Application.Queries.Handlers.Employee;

public class GetEmployeeByIdQueryHandler(IGetEmployeeService getEmployeeService ): IRequestHandler<GetEmployeeByIdQuery, Response<GetEmployeeByIdResponseModel>>
{
    public async Task<Response<GetEmployeeByIdResponseModel>> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
    {
        EmployeeEntity? employee = await getEmployeeService.GetEmployeeById(request.Id, cancellationToken);

        return new Response<GetEmployeeByIdResponseModel>(new GetEmployeeByIdResponseModel
        {
            Employee = employee
        });
    }
}
