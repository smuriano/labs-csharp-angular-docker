using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Labs.Domain.Pacientes.Entities;
using Labs.Domain.Pacientes.Repositories;
using Labs.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Labs.Infra.Repositories
{
  public class PacienteRepository : IPacienteRepository, IDisposable
  {
    private readonly LabsContext _context;

    public PacienteRepository(LabsContext context)
    {
      _context = context;
    }

    public async Task<IEnumerable<Paciente>> GetAllAsync() => await _context.Pacientes.AsNoTracking().OrderBy(x => x.Nome).ToListAsync();

    public async Task<Paciente> GetByIdAsync(Guid id) => await _context.Pacientes.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);

    public async Task AddAsync(Paciente Paciente) => await _context.Pacientes.AddAsync(Paciente);

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
