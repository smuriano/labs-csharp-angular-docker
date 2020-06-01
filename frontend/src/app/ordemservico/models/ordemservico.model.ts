import { OrdemServicoItem } from './ordemservicoitem.model';

export class OrdemServico {
  constructor(
    public id: string,
    public postoColetaId: string,
    public data: Date,
    public pacienteId: string,
    public convenio: string,
    public medicoId: string,
    public dataRetirada: Date,
    public items: OrdemServicoItem[] = []
  ) { }
}
