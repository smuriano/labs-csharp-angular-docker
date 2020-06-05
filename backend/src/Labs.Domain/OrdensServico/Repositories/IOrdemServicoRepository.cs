using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Labs.Domain.OrdensServico.Entities;

namespace Labs.Domain.OrdensServico.Repositories
{
  public interface IOrdemServicoRepository
  {
    Task<IEnumerable<OrdemServico>> GetAllAsync();
    Task<OrdemServico> GetByIdAsync(Guid id);
    Task<IEnumerable<OrdemServico>> FindByAsync(Expression<Func<OrdemServico, bool>> predicate);

    Task AddAsync(OrdemServico ordemServico);
    Task AddExameAsync(OrdemServicoExame ordemServicoExame);
    Task UpdateAsync(OrdemServico ordemServico);
    Task RemoveAsync(Guid id);
  }
}