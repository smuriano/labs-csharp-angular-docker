using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Labs.Domain.Exames.Entities;
using Labs.Domain.Exames.Repositories;
using Labs.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Labs.Infra.Repositories
{
  public class ExameRepository : IExameRepository, IDisposable
  {
    private readonly LabsContext _context;

    public ExameRepository(LabsContext context)
    {
      _context = context;
    }

    public async Task<IEnumerable<Exame>> GetAllAsync() => await _context.Exames.AsNoTracking().OrderBy(x => x.Descricao).ToListAsync();

    public async Task<Exame> GetByIdAsync(Guid id) => await _context.Exames.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);

    public async Task AddAsync(Exame exame) => await _context.Exames.AddAsync(exame);

    public async Task UpdateAsync(Exame exame)
    {
      var entityExist = await GetByIdAsync(exame.Id);

      if (entityExist == null)
        return;

      _context.Entry(entityExist).State = EntityState.Modified;
      _context.Entry(entityExist).CurrentValues.SetValues(exame);
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
