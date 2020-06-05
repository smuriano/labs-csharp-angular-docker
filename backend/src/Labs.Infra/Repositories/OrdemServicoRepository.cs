using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Labs.Domain.OrdensServico.Entities;
using Labs.Domain.OrdensServico.Repositories;
using Labs.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Labs.Infra.Repositories
{
  public class OrdemServicoRepository : IOrdemServicoRepository, IDisposable
  {
    private readonly LabsContext _context;

    public OrdemServicoRepository(LabsContext context)
    {
      _context = context;
    }

    public async Task<IEnumerable<OrdemServico>> GetAllAsync() =>
      await _context.OrdensServico
        .Include(x => x.PostoColeta)
        .Include(x => x.Paciente)
        .Include(x => x.Medico)
        .AsNoTracking()
        .OrderByDescending(x => x.DataRetirada)
        .ToListAsync();

    public async Task<OrdemServico> GetByIdAsync(Guid id) =>
      await _context.OrdensServico
        .Include(x => x.PostoColeta)
        .Include(x => x.Paciente)
        .Include(x => x.Medico)
        .Include(x => x.Exames)
        .AsNoTracking()
        .SingleOrDefaultAsync(x => x.Id == id);

    public async Task<IEnumerable<OrdemServico>> FindByAsync(Expression<Func<OrdemServico, bool>> predicate) => await _context.OrdensServico.AsNoTracking().Where(predicate).ToListAsync();

    public async Task AddAsync(OrdemServico ordemServico)
    {
      await _context.OrdensServico.AddAsync(ordemServico);
    }

    public async Task AddExameAsync(OrdemServicoExame ordemServicoExame)
    {
      await _context.OrdemServicoExames.AddAsync(ordemServicoExame);
    }

    public async Task UpdateAsync(OrdemServico ordemServico)
    {
      var entityExist = await GetByIdAsync(ordemServico.Id);

      if (entityExist == null)
        return;

      _context.Entry(entityExist).State = EntityState.Modified;
      _context.Entry(entityExist).CurrentValues.SetValues(ordemServico);
    }

    public async Task RemoveAsync(Guid id)
    {
      var entityExist = await GetByIdAsync(id);

      if (entityExist == null)
        return;

      _context.OrdensServico.Remove(entityExist);
    }

    #region IDisposable Support
    private bool disposedValue = false; // To detect redundant calls

    protected virtual void Dispose(bool disposing)
    {
      if (!disposedValue)
      {
        if (disposing)
        {
          _context.Dispose();
        }

        disposedValue = true;
      }
    }

    // This code added to correctly implement the disposable pattern.
    public void Dispose()
    {
      // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
      Dispose(true);
      GC.SuppressFinalize(this);
    }
    #endregion
  }
}
