using System.Collections.Generic;
using System.Threading.Tasks;
using Labs.Api.ViewModels;
using Labs.Domain.Medicos.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Labs.Api.Controllers
{
  [ApiController]
  [Route("v1/[controller]")]
  public class MedicosController : ControllerBase
  {
    private readonly IMedicoRepository _medicoRepository;

    public MedicosController(IMedicoRepository medicoRepository)
    {
      _medicoRepository = medicoRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<MedicoViewModel>>> GetAll()
    {
      var medicoList = await _medicoRepository.GetAllAsync();
      var result = new List<MedicoViewModel>();

      foreach (var medico in medicoList)
      {
        result.Add(
          new MedicoViewModel
          {
            Id = medico.Id,
            Nome = medico.Nome
          });
      }

      return Ok(result);
    }
  }
}