using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Labs.Domain.Pacientes.Entities;

namespace Labs.Domain.Pacientes.Repositories
{
  public interface IPacienteRepository
  {
    Task<IEnumerable<Paciente>> GetAllAsync();
    Task<Paciente> GetByIdAsync(Guid id);
    Task<IEnumerable<Paciente>> FindByAsync(Expression<Func<Paciente, bool>> predicate);

    Task AddAsync(Paciente paciente);
  }
}