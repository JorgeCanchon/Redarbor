using MediatR;
using Redarbor.Application.Shared.Wrappers;

namespace Redarbor.Application.Commands.Employee;

public class DeleteEmployeeCommand : IRequest<Response<Guid>>
{
    public Guid Id { get; set; }
}
