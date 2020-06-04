using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Labs.Api.ViewModels;
using Labs.Domain.OrdensServico.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Labs.Api.Controllers
{
  [ApiController]
  [Route("v1/[controller]")]
  public class OrdensServicoController : ControllerBase
  {
    private readonly IOrdemServicoRepository _ordemServicoRepository;

    public OrdensServicoController(IOrdemServicoRepository ordemServicoRepository)
    {
      _ordemServicoRepository = ordemServicoRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<OrdemServicoListViewModel>>> GetAll()
    {
      var ordemServicoList = await _ordemServicoRepository.GetAllAsync();
      var result = new List<OrdemServicoListViewModel>();

      foreach (var ordemServico in ordemServicoList)
      {
        result.Add(
          new OrdemServicoListViewModel
          {
            Id = ordemServico.Id,
            PostoColetaId = ordemServico.PostoColetaId,
            PostoColetaNome = ordemServico.PostoColeta.Descricao,
            DataExame = ordemServico.DataExame,
            PacienteId = ordemServico.PacienteId,
            PacienteNome = ordemServico.Paciente.Nome,
            Convenio = ordemServico.Convenio,
            MedicoId = ordemServico.MedicoId,
            MedicoNome = ordemServico.Medico.Nome,
            DataRetirada = ordemServico.DataRetirada
          });
      }

      return Ok(result);
    }

    [HttpGet("{id:Guid}")]
    public async Task<ActionResult<OrdemServicoListViewModel>> GetById(Guid id)
    {
      var ordemServico = await _ordemServicoRepository.GetByIdAsync(id);
      var result = new OrdemServicoListViewModel
      {
        Id = ordemServico.Id,
        PostoColetaId = ordemServico.PostoColetaId,
        PostoColetaNome = ordemServico.PostoColeta.Descricao,
        DataExame = ordemServico.DataExame,
        PacienteId = ordemServico.PacienteId,
        PacienteNome = ordemServico.Paciente.Nome,
        Convenio = ordemServico.Convenio,
        MedicoId = ordemServico.MedicoId,
        MedicoNome = ordemServico.Medico.Nome,
        DataRetirada = ordemServico.DataRetirada
      };

      return Ok(result);
    }
  }
}