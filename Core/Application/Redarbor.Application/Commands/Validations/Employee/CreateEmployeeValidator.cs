using FluentValidation;
using Redarbor.Application._Resources;
using Redarbor.Application.Commands.Employee;
using Redarbor.Domain.Entities;
using Redarbor.Domain.Services.Persistence;

namespace Redarbor.Application.Commands.Validations.Employee;

public class CreateEmployeeValidator : AbstractValidator<CreateEmployeeCommand>
{
    public CreateEmployeeValidator(IRepositoryAsync<Portal> portalRepositoryAsync, IRepositoryAsync<Company> companyRepositoryAsync, IRepositoryAsync<Role> roleRepositoryAsync
        )
    {
        RuleFor(c => c.Name)
            .NotNull()
            .NotEmpty().WithMessage(c => string.Format(ValidationMessages.IsRequired, nameof(c.Name)));

        RuleFor(c => c.Email)
            .NotNull()
            .NotEmpty().WithMessage(c => string.Format(ValidationMessages.IsRequired, nameof(c.Email)));

        RuleFor(c => c.Username)
            .NotNull()
            .NotEmpty().WithMessage(c => string.Format(ValidationMessages.IsRequired, nameof(c.Username)));

        RuleFor(c => c.Password)
            .NotNull()
            .NotEmpty().WithMessage(c => string.Format(ValidationMessages.IsRequired, nameof(c.Password)));

        RuleFor(c => c.Status)
            .IsInEnum()
            .NotNull()
            .NotEmpty().WithMessage(c => string.Format(ValidationMessages.IsRequired, nameof(c.Status)));

        RuleFor(c => c.PortalId)
            .NotNull()
            .NotEmpty().WithMessage(c => string.Format(ValidationMessages.IsRequired, nameof(c.PortalId)))
            .MustAsync(async (id, cancellation) =>
            {
                var user = await portalRepositoryAsync.GetByIdAsync(id, cancellation);
                return user is not null;
            }).WithMessage(c => string.Format(ApplicationErrors.EntityNotFound, nameof(User), c.PortalId));

        RuleFor(c => c.CompanyId)
            .NotNull()
            .NotEmpty().WithMessage(c => string.Format(ValidationMessages.IsRequired, nameof(c.CompanyId)))
            .MustAsync(async (id, cancellation) =>
            {
                var user = await companyRepositoryAsync.GetByIdAsync(id, cancellation);
                return user is not null;
            }).WithMessage(c => string.Format(ApplicationErrors.EntityNotFound, nameof(User), c.CompanyId));

        RuleFor(c => c.RoleId)
            .NotNull()
            .NotEmpty().WithMessage(c => string.Format(ValidationMessages.IsRequired, nameof(c.RoleId)))
            .MustAsync(async (id, cancellation) =>
            {
                var user = await roleRepositoryAsync.GetByIdAsync(id, cancellation);
                return user is not null;
            }).WithMessage(c => string.Format(ApplicationErrors.EntityNotFound, nameof(User), c.RoleId));
    }
}
