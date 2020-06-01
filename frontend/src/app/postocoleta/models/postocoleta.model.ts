export class PostoColeta {
  constructor(
    public id: string,
    public labId: string,
    public descricao: string,
    public endereco_cep: string,
    public endereco_endereco: string,
    public endereco_numero: number,
    public endereco_complemento: string,
    public endereco_bairro: string,
    public endereco_cidade: string,
    public endereco_estado: string
  ) { }
}
