using System.Threading.Tasks;

namespace Labs.Domain.Transactions
{
  public interface IUoW
  {
    Task<int> ClearDatabaseAsync();
    Task<int> CommitAsync();
    Task<bool> RollbackAsync();
  }
}