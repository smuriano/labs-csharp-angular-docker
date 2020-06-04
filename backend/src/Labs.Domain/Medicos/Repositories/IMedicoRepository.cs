using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Labs.Domain.Medicos.Entities;

namespace Labs.Domain.Medicos.Repositories
{
  public interface IMedicoRepository
  {
    Task<IEnumerable<Medico>> GetAllAsync();
    Task<Medico> GetByIdAsync(Guid id);
    Task<IEnumerable<Medico>> FindByAsync(Expression<Func<Medico, bool>> predicate);

    Task AddAsync(Medico medico);
  }
}