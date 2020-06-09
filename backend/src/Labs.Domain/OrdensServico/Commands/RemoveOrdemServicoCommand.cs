using System;
using Labs.Domain.Miscellaneous.Commands;

namespace Labs.Domain.OrdensServico.Commands
{
  public class RemoveOrdemServicoCommand : Command
  {
    public Guid Id { get; set; }
  }
}