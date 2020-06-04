export class OrdemServicoListViewModel {
  constructor(
    public id: string,
    public postoColetaId: string,
    public postoColetaNome: string,
    public dataExame: Date,
    public pacienteId: string,
    public pacienteNome: string,
    public convenio: string,
    public medicoId: string,
    public medicoNome: string,
    public dataRetirada: Date
  ) { }
}
