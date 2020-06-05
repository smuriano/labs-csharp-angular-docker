using System;
using System.Collections.Generic;

namespace Labs.Api.ViewModels
{
  public class OrdemServicoViewModel
  {
    public Guid Id { get; set; }
    public Guid PostoColetaId { get; set; }
    public string PostoColetaNome { get; set; }
    public DateTime DataExame { get; set; }
    public Guid PacienteId { get; set; }
    public string PacienteNome { get; set; }
    public string Convenio { get; set; }
    public Guid MedicoId { get; set; }
    public string MedicoNome { get; set; }
    public DateTime DataRetirada { get; set; }
    public ICollection<OrdemServicoExameViewModel> Exames { get; set; }
  }
}