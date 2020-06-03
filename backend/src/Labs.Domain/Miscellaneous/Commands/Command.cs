using FluentValidation;
using FluentValidation.Results;
using Labs.Shared.Commands;

namespace Labs.Domain.Miscellaneous.Commands
{
  public abstract class Command : ICommand
  {
    public ValidationResult ValidationResult { get; private set; }
    public bool IsValid { get; private set; }

    public bool Validade<T>(T command, AbstractValidator<T> validator)
    {
      ValidationResult = validator.Validate(command);
      return IsValid = ValidationResult.IsValid;
    }
  }
}