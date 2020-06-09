using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Labs.Domain.Miscellaneous.Commands;
using Labs.Domain.OrdensServico.Commands;
using Labs.Domain.OrdensServico.Entities;
using Labs.Domain.OrdensServico.Repositories;
using Labs.Domain.Transactions;
using Labs.Shared.Commands;
using Labs.Shared.Handlers;

namespace Labs.Domain.OrdensServico.Handlers
{
  public class OrdemServicoHandler :
    IHandler<AddOrdemServicoCommand>,
    IHandler<UpdateOrdemServicoCommand>,
    IHandler<RemoveOrdemServicoCommand>
  {
    public readonly IOrdemServicoRepository _ordemServicoRepository;
    public readonly IUoW _uow;

    public OrdemServicoHandler(IOrdemServicoRepository ordemServicoRepository, IUoW uow)
    {
      _ordemServicoRepository = ordemServicoRepository;
      _uow = uow;
    }

    public async Task<ICommandResult> Handle(AddOrdemServicoCommand command)
    {
      try
      {
        // RN
        var ordemServico = new OrdemServico(command.PostoColetaId, command.DataExame, command.PacienteId, command.Convenio, command.MedicoId, command.DataRetirada);
        foreach (var exame in command.Exames)
        {
          ordemServico.AddExame(new OrdemServicoExame(ordemServico.Id, exame.ExameId, exame.Preco));
        }

        if (ordemServico.IsValid)
        {
          await _ordemServicoRepository.AddAsync(ordemServico);
          await _uow.CommitAsync();
        }

        return new CommandResult(true, "Ordem de servico incluída com sucesso", ordemServico);
      }
      catch (Exception e)
      {
        await _uow.RollbackAsync();
        return new CommandResult(false, $"Problema com a inclusão, tente mais tarde. Erro ${e.Message}", null);
      }
    }

    public async Task<ICommandResult> Handle(UpdateOrdemServicoCommand command)
    {
      try
      {
        var ordemServico = _ordemServicoRepository.GetByIdAsync(command.Id).GetAwaiter().GetResult();
        ordemServico.Update(command.PostoColetaId, command.PacienteId, command.Convenio, command.MedicoId, command.DataRetirada);

        foreach (var exame in ordemServico.Exames.ToList())
        {
          if (!command.Exames.Any(x => x.Id == exame.Id))
            ordemServico.Exames.Remove(exame);
        };

        foreach (var exame in command.Exames)
        {
          var ordemServicoExame = ordemServico.Exames.FirstOrDefault(x => x.Id == exame.Id);

          if (ordemServicoExame == null)
          {
            ordemServico.AddExame(new OrdemServicoExame(ordemServico.Id, exame.ExameId, exame.Preco));
          }
          else
          {
            ordemServicoExame.Update(exame.ExameId, exame.Preco);
          }
        }

        if (ordemServico.IsValid)
        {
          await _ordemServicoRepository.UpdateAsync(ordemServico);
          await _uow.CommitAsync();
        }

        return new CommandResult(true, "Ordem de servico atualizada com sucesso", ordemServico);
      }
      catch (Exception e)
      {
        await _uow.RollbackAsync();
        return new CommandResult(false, $"Problema com a atualização, tente mais tarde. Erro ${e.Message}", null);
      }
    }

    public async Task<ICommandResult> Handle(RemoveOrdemServicoCommand command)
    {
      try
      {
        await _ordemServicoRepository.RemoveAsync(command.Id);
        await _uow.CommitAsync();
        return new CommandResult(true, "Ordem de servico excluída com sucesso", null);
      }
      catch (Exception e)
      {
        await _uow.RollbackAsync();
        return new CommandResult(false, $"Problema com a exclusão, tente mais tarde. Erro ${e.Message}", null);
      }
    }
  }
}