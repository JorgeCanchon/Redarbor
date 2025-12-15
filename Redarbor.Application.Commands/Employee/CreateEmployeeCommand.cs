using MediatR;
using Redarbor.Application.Shared.Wrappers;

namespace Redarbor.Application.Commands.Employee;

public class CreateEmployeeCommand : IRequest<Response<Guid>>
{
}
