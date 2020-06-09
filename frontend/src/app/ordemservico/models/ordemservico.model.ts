import { OrdemServicoExame } from './ordemservicoexame.model';

export class OrdemServico {
  constructor(
    public id: string,
    public postoColetaId: string,
    public dataExame: Date,
    public pacienteId: string,
    public convenio: string,
    public medicoId: string,
    public dataRetirada: Date,
    public exames: OrdemServicoExame[] = []
  ) { }
}
