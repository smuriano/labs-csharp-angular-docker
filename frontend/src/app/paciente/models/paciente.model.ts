export class Paciente {
  constructor(
    public id: string,
    public nome: string,
    public cpf: string,
    public rg: string,
    public dataNascimento: Date,
    public sexo: string,
    public endereco_cep: string,
    public endereco_endereco: string,
    public endereco_numero: number,
    public endereco_complemento: string,
    public endereco_bairro: string,
    public endereco_cidade: string,
    public endereco_estado: string,
    public celular: string
  ) { }
}
