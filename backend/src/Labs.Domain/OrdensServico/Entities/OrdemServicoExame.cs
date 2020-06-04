using System;
using FluentValidation;
using Labs.Domain.Exames.Entities;
using Labs.Shared.Entities;

namespace Labs.Domain.OrdensServico.Entities
{
  public class OrdemServicoExame : Entity
  {
    public OrdemServicoExame(Guid ordemServicoId, Guid exameId, decimal preco)
    {
      OrdemServicoId = ordemServicoId;
      ExameId = exameId;
      Preco = preco;
    }

    public Guid OrdemServicoId { get; private set; }
    public Guid ExameId { get; private set; }
    public decimal Preco { get; private set; }

    public virtual OrdemServico OrdemServico { get; private set; }
    public virtual Exame Exame { get; private set; }
  }
  public class OrdemServicoExameValidator : AbstractValidator<OrdemServicoExame>
  {
    public OrdemServicoExameValidator()
    {
      RuleFor(x => x.Id)
          .NotEqual(Guid.Empty).WithMessage($"Id é obrigatório");

      RuleFor(x => x.OrdemServicoId)
          .NotEqual(Guid.Empty).WithMessage($"Id da Ordem de Serviço é obrigatório");

      RuleFor(x => x.ExameId)
          .NotEqual(Guid.Empty).WithMessage($"Id do Exame é obrigatório");

      RuleFor(x => x.Preco)
          .GreaterThan(0).WithMessage($"Preço do Exame deve ser maior que $0,00");
    }
  }
}