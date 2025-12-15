using MediatR;
using Redarbor.Application.Queries.Employee.Models;
using Redarbor.Application.Shared.Wrappers;

namespace Redarbor.Application.Queries.Employee;

public class GetEmployeeByIdQuery : IRequest<Response<GetEmployeeByIdResponseModel>>
{
    public Guid Id { get; set; }
}
