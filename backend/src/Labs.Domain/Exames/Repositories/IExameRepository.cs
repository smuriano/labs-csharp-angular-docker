using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Labs.Domain.Exames.Entities;

namespace Labs.Domain.Exames.Repositories
{
  public interface IExameRepository
  {
    Task<IEnumerable<Exame>> GetAllAsync();
    Task<Exame> GetByIdAsync(Guid id);
    Task<IEnumerable<Exame>> FindByAsync(Expression<Func<Exame, bool>> predicate);

    Task AddAsync(Exame exame);
  }
}