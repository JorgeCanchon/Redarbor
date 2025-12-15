using FluentValidation;
using Redarbor.Application._Resources;
using Redarbor.Application.Commands.Employee;
using Redarbor.Domain.Services.Persistence;
using EmployeeEntity = Redarbor.Domain.Entities.Employee;

namespace Redarbor.Application.Commands.Validations.Employee;

public class DeleteEmployeeValidator :AbstractValidator<DeleteEmployeeCommand>
{
    public DeleteEmployeeValidator(IRepositoryAsync<EmployeeEntity> employeeRepositoryAsync)
    {
        RuleFor(c => c.Id)
            .NotNull()
            .NotEmpty().WithMessage(c => string.Format(ValidationMessages.IsRequired, nameof(c.Id)))
            .MustAsync(async (id, cancellation) =>
            {
                var employee = await employeeRepositoryAsync.GetByIdAsync(id, cancellation);
                return employee is not null;
            }).WithMessage(c => string.Format(ApplicationErrors.EntityNotFound, nameof(EmployeeEntity), c.Id));
    }
}
