using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Labs.Api.ViewModels;
using Labs.Domain.Miscellaneous.Commands;
using Labs.Domain.OrdensServico.Commands;
using Labs.Domain.OrdensServico.Handlers;
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
      var result = new OrdemServicoViewModel
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
        DataRetirada = ordemServico.DataRetirada,
        Exames = new List<OrdemServicoExameViewModel>()
      };

      ordemServico.Exames.ForEach(x =>
      {
        result.Exames.Add(
          new OrdemServicoExameViewModel
          {
            Id = x.Id,
            OrdemServicoId = x.OrdemServicoId,
            ExameId = x.ExameId,
            ExameNome = x.Exame.Descricao,
            Preco = x.Preco
          });
      });

      return Ok(result);
    }

    [HttpPost]
    public ActionResult<CommandResult> Post(
      [FromBody] AddOrdemServicoCommand command,
      [FromServices] OrdemServicoHandler handler)
    {
      return Ok((CommandResult)handler.Handle(command));
    }

    [HttpPut("{id:Guid}")]
    public ActionResult<CommandResult> Put(
      Guid id,
      [FromBody] UpdateOrdemServicoCommand command,
      [FromServices] OrdemServicoHandler handler)
    {
      if (id != command.Id)
        return BadRequest(new CommandResult(false, "Id diferente do cabeçalho da requisição", null));

      return Ok((CommandResult)handler.Handle(command));
    }

    [HttpDelete("{id:Guid}")]
    public async Task<ActionResult<bool>> Delete(Guid id)
    {
      await _ordemServicoRepository.RemoveAsync(id);

      return Ok(Task.CompletedTask);
    }
  }
}