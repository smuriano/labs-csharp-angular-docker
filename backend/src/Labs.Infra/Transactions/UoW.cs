using System.Threading.Tasks;
using Labs.Domain.Transactions;
using Labs.Infra.Contexts;

namespace Labs.Infra.Transactions
{
  public class UoW : IUoW
  {
    private readonly LabsContext _context;

    public UoW(LabsContext context)
    {
      _context = context;
    }

    public async Task<int> CommitAsync() => await _context.SaveChangesAsync();

    public async Task<bool> RollbackAsync()
    {
      await Task.CompletedTask;
      return true;
    }
  }
}