using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Labs.Domain.Exames.Entities;

namespace Labs.Domain.Exames.Repositories
{
  public interface IExameRepository
  {
    Task<IEnumerable<Exame>> GetAllAsync();
    Task<Exame> GetByIdAsync(Guid id);

    Task AddAsync(Exame exame);
  }
}