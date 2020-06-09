using System.Threading.Tasks;
using Labs.Shared.Commands;

namespace Labs.Shared.Handlers
{
  public interface IHandler<T> where T : ICommand
  {
    Task<ICommandResult> Handle(T command);
  }
}