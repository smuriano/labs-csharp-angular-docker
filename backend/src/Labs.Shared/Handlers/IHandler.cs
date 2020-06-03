using Labs.Shared.Commands;

namespace Labs.Shared.Handlers
{
  public interface IHandler<T> where T : ICommand
  {
    ICommandResult Handle(T command);
  }
}