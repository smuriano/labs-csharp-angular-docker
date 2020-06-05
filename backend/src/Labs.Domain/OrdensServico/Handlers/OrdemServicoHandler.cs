using System;
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
    IHandler<UpdateOrdemServicoCommand>
  {
    public readonly IOrdemServicoRepository _ordemServicoRepository;
    public readonly IUoW _uow;

    public OrdemServicoHandler(IOrdemServicoRepository ordemServicoRepository, IUoW uow)
    {
      _ordemServicoRepository = ordemServicoRepository;
      _uow = uow;
    }

    public ICommandResult Handle(AddOrdemServicoCommand command)
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
          _ordemServicoRepository.AddAsync(ordemServico);
          // ordemServico.Exames.ForEach(x =>
          // {
          //   _ordemServicoRepository.AddExameAsync(x);
          // });

          _uow.CommitAsync();
        }

        return new CommandResult(true, "Ordem de servico salva com sucesso", ordemServico);
      }
      catch
      {
        _uow.RollbackAsync();
        return new CommandResult(false, "Problema com a gravação, tente mais tarde", null);
      }
    }

    public ICommandResult Handle(UpdateOrdemServicoCommand command)
    {
      try
      {
        var ordemServico = _ordemServicoRepository.GetByIdAsync(command.Id).GetAwaiter().GetResult();
        ordemServico.RemoveAllExame();
        foreach (var exame in command.Exames)
        {
          ordemServico.AddExame(new OrdemServicoExame(ordemServico.Id, exame.ExameId, exame.Preco));
        }

        if (ordemServico.IsValid)
          _ordemServicoRepository.UpdateAsync(ordemServico);

        _uow.CommitAsync();
        return new CommandResult(true, "Ordem de servico salva com sucesso", ordemServico);
      }
      catch
      {
        _uow.RollbackAsync();
        return new CommandResult(false, "Problema com a gravação, tente mais tarde", null);
      }
    }
  }
}