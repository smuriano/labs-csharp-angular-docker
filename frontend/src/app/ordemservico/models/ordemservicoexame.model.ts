export class OrdemServicoExame {
  constructor(
    public id: string,
    public ordemServicoId: string,
    public exameId: string,
    public exameNome: string,
    public preco: number
  ) { }
}
