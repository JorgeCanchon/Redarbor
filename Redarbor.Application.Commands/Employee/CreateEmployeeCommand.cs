using MediatR;
using Redarbor.Application.Shared.Wrappers;
using Redarbor.Domain.Shared.Enums;

namespace Redarbor.Application.Commands.Employee;

public class CreateEmployeeCommand : IRequest<Response<Guid>>
{
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Telephone { get; set; } = null!;
    public string Fax { get; set; } = null!;
    public Guid PortalId { get; set; } 
    public Guid CompanyId { get; set; }
    public Guid RoleId { get; set; }
    //public Guid UserId {  get; set; }
    public Status Status { get; set; }
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
}
