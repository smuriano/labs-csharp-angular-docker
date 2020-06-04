using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Labs.Domain.PostosColeta.Entities;

namespace Labs.Domain.PostosColeta.Repositories
{
  public interface IPostoColetaRepository
  {
    Task<IEnumerable<PostoColeta>> GetAllAsync();
    Task<PostoColeta> GetByIdAsync(Guid id);
    Task<IEnumerable<PostoColeta>> FindByAsync(Expression<Func<PostoColeta, bool>> predicate);

    Task AddAsync(PostoColeta postoColeta);
  }
}