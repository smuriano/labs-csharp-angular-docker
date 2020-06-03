using System;
using FluentValidation;
using Labs.Shared.Entities;

namespace Labs.Domain.Medicos.Entities
{
  public class Medico : Entity
  {
    protected Medico() { }

    public Medico(string nome, string crm, string especialidade)
    {
      Nome = nome;
      CRM = crm;
      Especialidade = especialidade;

      Validate(this, new MedicoValidator());
    }

    public string Nome { get; private set; }
    public string CRM { get; private set; }
    public string Especialidade { get; private set; }

    public void Update(string nome, string crm, string especialidade)
    {
      Nome = nome;
      CRM = crm;
      Especialidade = especialidade;

      Validate(this, new MedicoValidator());
    }

    public override string ToString() => $"{Nome} | {CRM}";
  }

  public class MedicoValidator : AbstractValidator<Medico>
  {
    public MedicoValidator()
    {
      RuleFor(x => x.Id)
          .NotEqual(Guid.Empty).WithMessage($"Id é obrigatório");

      RuleFor(x => x.Nome)
          .NotEmpty().WithMessage($"Nome é obrigatório")
          .MaximumLength(60).WithMessage($"Nome deve ter no máximo 60 caracteres");

      RuleFor(x => x.CRM)
          .NotEmpty().WithMessage($"CRM é obrigatório")
          .MaximumLength(10).WithMessage($"CRM deve ter no máximo 10 caracteres");

      RuleFor(x => x.Especialidade)
          .NotEmpty().WithMessage($"Especialidade é obrigatório")
          .MaximumLength(30).WithMessage($"Especialidade deve ter no máximo 30 caracteres");
    }
  }
}