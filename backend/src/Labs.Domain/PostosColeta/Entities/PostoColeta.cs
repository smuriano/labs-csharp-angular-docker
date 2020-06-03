using System;
using FluentValidation;
using Labs.Domain.Miscellaneous.ValueObjects;
using Labs.Shared.Entities;

namespace Labs.Domain.PostosColeta.Entities
{
  public class PostoColeta : Entity
  {
    protected PostoColeta() { }

    public PostoColeta(Guid labId, string descricao, Endereco endereco)
    {
      LabId = labId;
      Descricao = descricao;
      Endereco = endereco;

      Validate(this, new PostoColetaValidator());
    }

    public Guid LabId { get; private set; }
    public string Descricao { get; private set; }
    public Endereco Endereco { get; private set; }
  }

  public class PostoColetaValidator : AbstractValidator<PostoColeta>
  {
    public PostoColetaValidator() { }
  }
}