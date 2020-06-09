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
    private readonly OrdemServicoHandler _handler;

    public OrdensServicoController(IOrdemServicoRepository ordemServicoRepository, OrdemServicoHandler handler)
    {
      _ordemServicoRepository = ordemServicoRepository;
      _handler = handler;
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

      if (ordemServico != null)
      {
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
      else
      {
        return NotFound();
      }
    }

    [HttpPost]
    public async Task<ActionResult<CommandResult>> Post(
      [FromBody] AddOrdemServicoCommand command)
    {
      return Ok((CommandResult)await _handler.Handle(command));
    }

    [HttpPut("{id:Guid}")]
    public async Task<ActionResult<CommandResult>> Put(
      Guid id,
      [FromBody] UpdateOrdemServicoCommand command)
    {
      if (id != command.Id)
        return BadRequest(new CommandResult(false, "Id diferente do cabeçalho da requisição", null));

      return Ok((CommandResult)await _handler.Handle(command));
    }

    [HttpDelete("{id:Guid}")]
    public async Task<ActionResult<CommandResult>> Delete(Guid id)
    {
      return Ok((CommandResult)await _handler.Handle(new RemoveOrdemServicoCommand { Id = id }));
    }
  }
}