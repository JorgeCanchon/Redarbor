using MediatR;
using Redarbor.Application.Shared.Wrappers;
using Redarbor.Domain.Shared.Enums;

namespace Redarbor.Application.Commands.Employee;

public class UpdateEmployeeCommand : IRequest<Response<Guid>>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? Telephone { get; set; } 
    public string? Fax { get; set; }
    public Guid PortalId { get; set; }
    public Guid CompanyId { get; set; }
    public Guid RoleId { get; set; }
    public Guid UserId {  get; set; }
    public Status Status { get; set; }
}
