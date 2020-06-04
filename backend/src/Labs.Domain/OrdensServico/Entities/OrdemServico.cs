using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation;
using Labs.Domain.Medicos.Entities;
using Labs.Domain.Pacientes.Entities;
using Labs.Domain.PostosColeta.Entities;
using Labs.Shared.Entities;

namespace Labs.Domain.OrdensServico.Entities
{
  public class OrdemServico : Entity
  {
    private readonly IList<OrdemServicoExame> _exames;

    protected OrdemServico() { }
    public OrdemServico(Guid postoColetaId, DateTime dataExame, Guid pacienteId, string convenio, Guid medicoId, DateTime dataRetirada)
    {
      PostoColetaId = postoColetaId;
      DataExame = dataExame;
      PacienteId = pacienteId;
      Convenio = convenio;
      MedicoId = medicoId;
      DataRetirada = dataRetirada;

      _exames = new List<OrdemServicoExame>();

      Validate(this, new OrdemServicoValidator());
    }

    public Guid PostoColetaId { get; private set; }
    public DateTime DataExame { get; private set; }
    public Guid PacienteId { get; private set; }
    public string Convenio { get; private set; }
    public Guid MedicoId { get; private set; }
    public DateTime DataRetirada { get; private set; }
    public IReadOnlyCollection<OrdemServicoExame> Exames { get; private set; }

    public decimal Total() => Exames.Sum(x => x.Preco);

    public virtual PostoColeta PostoColeta { get; private set; }
    public virtual Paciente Paciente { get; private set; }
    public virtual Medico Medico { get; private set; }

    public void AddExames(List<OrdemServicoExame> exames)
    {
      exames.ForEach(exame => AddExame(exame));
    }

    public void AddExame(OrdemServicoExame exame)
    {
      if (exame.IsValid)
        _exames.Add(exame);
    }
  }

  public class OrdemServicoValidator : AbstractValidator<OrdemServico>
  {
    public OrdemServicoValidator()
    {
      RuleFor(x => x.Id)
          .NotEqual(Guid.Empty).WithMessage($"Id é obrigatório");

      RuleFor(x => x.PostoColetaId)
          .NotEqual(Guid.Empty).WithMessage($"Id do Posto de Coleta é obrigatório");

      RuleFor(x => x.DataExame)
          .NotEmpty().WithMessage("Data do exame é obrigatório")
          .GreaterThan(new DateTime(2019, 12, 31)).WithMessage("Data do exame deve ser maior que 31/12/2019");

      RuleFor(x => x.PacienteId)
          .NotEqual(Guid.Empty).WithMessage($"Id do Paciente é obrigatório");

      RuleFor(x => x.Convenio)
          .NotEmpty().WithMessage("Convênio é obrigatório")
          .MaximumLength(30).WithMessage($"Convênio deve ter no máximo 30 caracteres");

      RuleFor(x => x.MedicoId)
          .NotEqual(Guid.Empty).WithMessage($"Id do Médico é obrigatório");

      RuleFor(x => x.DataRetirada)
          .NotEmpty().WithMessage("Data da retirada é obrigatório")
          .GreaterThan(x => x.DataExame).WithMessage("Data da retirada deve ser maior que a data do exame");

      RuleForEach(x => x.Exames)
        .SetValidator(new OrdemServicoExameValidator());
    }
  }
}