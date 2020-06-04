using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Labs.Domain.Medicos.Entities;
using Labs.Domain.Medicos.Repositories;
using Labs.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Labs.Infra.Repositories
{
  public class MedicoRepository : IMedicoRepository, IDisposable
  {
    private readonly LabsContext _context;

    public MedicoRepository(LabsContext context)
    {
      _context = context;
    }

    public async Task<IEnumerable<Medico>> GetAllAsync() => await _context.Medicos.AsNoTracking().OrderBy(x => x.Nome).ToListAsync();

    public async Task<Medico> GetByIdAsync(Guid id) => await _context.Medicos.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
    public async Task<IEnumerable<Medico>> FindByAsync(Expression<Func<Medico, bool>> predicate) => await _context.Medicos.AsNoTracking().Where(predicate).ToListAsync();

    public async Task AddAsync(Medico medico) => await _context.Medicos.AddAsync(medico);

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
