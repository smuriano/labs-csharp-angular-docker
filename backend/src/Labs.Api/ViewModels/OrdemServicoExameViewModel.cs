using System;

namespace Labs.Api.ViewModels
{
  public class OrdemServicoExameViewModel
  {
    public Guid Id { get; set; }
    public Guid OrdemServicoId { get; set; }
    public Guid ExameId { get; set; }
    public string ExameNome { get; set; }
    public decimal Preco { get; set; }
  }
}