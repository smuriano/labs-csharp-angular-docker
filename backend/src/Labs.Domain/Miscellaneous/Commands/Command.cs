using Newtonsoft.Json;
using FluentValidation;
using FluentValidation.Results;
using Labs.Shared.Commands;

namespace Labs.Domain.Miscellaneous.Commands
{
  public abstract class Command : ICommand
  {
    [JsonIgnore]
    public virtual ValidationResult ValidationResult { get; private set; }
    public virtual bool IsValid { get; private set; }

    public bool Validade<T>(T command, AbstractValidator<T> validator)
    {
      ValidationResult = validator.Validate(command);
      return IsValid = ValidationResult.IsValid;
    }
  }
}