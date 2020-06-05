using System;
using System.Collections.Generic;
using Labs.Domain.Miscellaneous.Commands;

namespace Labs.Domain.OrdensServico.Commands
{
  public class AddOrdemServicoCommand : Command
  {
    public Guid PostoColetaId { get; set; }
    public DateTime DataExame { get; set; }
    public Guid PacienteId { get; set; }
    public string Convenio { get; set; }
    public Guid MedicoId { get; set; }
    public DateTime DataRetirada { get; set; }
    public ICollection<OrdemServicoExameCommand> Exames { get; set; }
  }
}