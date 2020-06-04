using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Labs.Domain.PostosColeta.Entities;
using Labs.Domain.PostosColeta.Repositories;
using Labs.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Labs.Infra.Repositories
{
  public class PostoColetaRepository : IPostoColetaRepository, IDisposable
  {
    private readonly LabsContext _context;

    public PostoColetaRepository(LabsContext context)
    {
      _context = context;
    }

    public async Task<IEnumerable<PostoColeta>> GetAllAsync() => await _context.PostosColeta.AsNoTracking().OrderBy(x => x.Descricao).ToListAsync();

    public async Task<PostoColeta> GetByIdAsync(Guid id) => await _context.PostosColeta.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
    public async Task<IEnumerable<PostoColeta>> FindByAsync(Expression<Func<PostoColeta, bool>> predicate) => await _context.PostosColeta.AsNoTracking().Where(predicate).ToListAsync();

    public async Task AddAsync(PostoColeta PostoColeta) => await _context.PostosColeta.AddAsync(PostoColeta);

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
