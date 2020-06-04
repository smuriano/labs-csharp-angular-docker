using System.Threading.Tasks;

namespace Labs.Infra.Transactions
{
  public interface IUoW
  {
    Task<int> CommitAsync();
    Task<bool> RollbackAsync();
  }
}