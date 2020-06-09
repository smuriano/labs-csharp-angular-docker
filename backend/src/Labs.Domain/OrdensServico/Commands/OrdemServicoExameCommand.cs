using System;
using Labs.Domain.Miscellaneous.Commands;

namespace Labs.Domain.OrdensServico.Commands
{
  public class OrdemServicoExameCommand : Command
  {
    public Guid Id { get; set; }
    public Guid ExameId { get; set; }
    public decimal Preco { get; set; }
  }
}