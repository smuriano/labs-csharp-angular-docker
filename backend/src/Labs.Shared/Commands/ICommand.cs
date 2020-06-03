using FluentValidation;

namespace Labs.Shared.Commands
{
  public interface ICommand
  {
    bool Validade<T>(T command, AbstractValidator<T> validator);
  }
}