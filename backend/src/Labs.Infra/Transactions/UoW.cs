using System.Threading.Tasks;
using Labs.Domain.Transactions;
using Labs.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Labs.Infra.Transactions
{
  public class UoW : IUoW
  {
    private readonly LabsContext _context;

    public UoW(LabsContext context)
    {
      _context = context;
    }

    public async Task<int> ClearDatabaseAsync()
    {
      var ordemServicoExames = await _context.OrdemServicoExames.AsNoTracking().ToListAsync();
      ordemServicoExames.ForEach(x => _context.OrdemServicoExames.Remove(x));

      var ordemServico = await _context.OrdensServico.AsNoTracking().ToListAsync();
      ordemServico.ForEach(x => _context.OrdensServico.Remove(x));

      var pacientes = await _context.Pacientes.AsNoTracking().ToListAsync();
      pacientes.ForEach(x => _context.Pacientes.Remove(x));

      var medicos = await _context.Medicos.AsNoTracking().ToListAsync();
      medicos.ForEach(x => _context.Medicos.Remove(x));

      var exames = await _context.Exames.AsNoTracking().ToListAsync();
      exames.ForEach(x => _context.Exames.Remove(x));

      var postosColeta = await _context.PostosColeta.AsNoTracking().ToListAsync();
      postosColeta.ForEach(x => _context.PostosColeta.Remove(x));

      return await _context.SaveChangesAsync();
    }
    public async Task<int> CommitAsync() => await _context.SaveChangesAsync();

    public async Task<bool> RollbackAsync()
    {
      await Task.CompletedTask;
      return true;
    }
  }
}