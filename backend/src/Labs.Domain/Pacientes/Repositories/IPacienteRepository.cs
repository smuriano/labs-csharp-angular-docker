using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Labs.Domain.Pacientes.Entities;

namespace Labs.Domain.Pacientes.Repositories
{
  public interface IPacienteRepository
  {
    Task<IEnumerable<Paciente>> GetAllAsync();
    Task<Paciente> GetByIdAsync(Guid id);

    Task AddAsync(Paciente paciente);
  }
}