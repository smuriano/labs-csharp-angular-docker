export class OrdemServicoList {
  constructor(
    public id: string,
    public postoColetaId: string,
    public postoColetaNome: string,
    public data: Date,
    public pacienteId: string,
    public pacienteNome: string,
    public convenio: string,
    public medicoId: string,
    public medicoNome: string,
    public dataRetirada: Date
  ) { }
}
