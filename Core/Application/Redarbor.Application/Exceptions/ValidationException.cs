using FluentValidation.Results;
using Redarbor.Application._Resources;

namespace Redarbor.Application.Exceptions;

public class ValidationException : Exception
{
    public List<string> Errors { get; }

    public ValidationException() : base(ApplicationErrors.HasValidationError)
    {
        Errors = [];
    }

    public ValidationException(IEnumerable<ValidationFailure> failures) : this()
    {
        Errors = [.. failures.Select(f => f.ErrorMessage)];
    }
}
