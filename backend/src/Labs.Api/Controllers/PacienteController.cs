using System.Collections.Generic;
using System.Threading.Tasks;
using Labs.Api.ViewModels;
using Labs.Domain.Pacientes.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Labs.Api.Controllers
{
  [ApiController]
  [Route("v1/[controller]")]
  public class PacientesController : ControllerBase
  {
    private readonly IPacienteRepository _pacienteRepository;

    public PacientesController(IPacienteRepository pacienteRepository)
    {
      _pacienteRepository = pacienteRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PacienteViewModel>>> GetAll()
    {
      var pacienteList = await _pacienteRepository.GetAllAsync();
      var result = new List<PacienteViewModel>();

      foreach (var paciente in pacienteList)
      {
        result.Add(
          new PacienteViewModel
          {
            Id = paciente.Id,
            Nome = paciente.Nome,
            Celular = paciente.Celular
          });
      }

      return Ok(result);
    }
  }
}