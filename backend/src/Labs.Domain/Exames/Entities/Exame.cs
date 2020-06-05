using FluentValidation;
using Labs.Shared.Entities;

namespace Labs.Domain.Exames.Entities
{
  public class Exame : Entity
  {
    protected Exame() { }

    public Exame(string descricao, decimal preco)
    {
      Descricao = descricao;
      Preco = preco;

      Validate(this, new ExameValidator());
    }

    public string Descricao { get; private set; }
    public decimal Preco { get; private set; }
  }

  public class ExameValidator : AbstractValidator<Exame>
  {
    public ExameValidator() { }
  }
}