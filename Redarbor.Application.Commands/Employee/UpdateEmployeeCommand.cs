using MediatR;
using Redarbor.Application.Shared.Wrappers;

namespace Redarbor.Application.Commands.Employee;

public class UpdateEmployeeCommand : IRequest<Response<Guid>>
{
    public Guid Id { get; set; }
}
