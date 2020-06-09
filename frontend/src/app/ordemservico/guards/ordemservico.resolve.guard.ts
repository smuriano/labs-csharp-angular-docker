import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, RouterStateSnapshot, Resolve } from '@angular/router';
import { Observable, of } from 'rxjs';

import { OrdemServicoService } from './../services/ordemservico.service';
import { OrdemServico } from '../models/ordemservico.model';
import { OrdemServicoExame } from '../models/ordemservicoexame.model';

@Injectable({
  providedIn: 'root'
})
export class OrdemServicoResolverGuard implements Resolve<OrdemServico> {

  constructor(private ordemServicoService: OrdemServicoService) { }

  resolve(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<OrdemServico> {
    if (route.params && route.params['id']) {
      return this.ordemServicoService.getOrdemById(route.params['id']);
    }

    let ordemServico = new OrdemServico('', '', new Date(), '', '', '', new Date());
    return of(ordemServico);

    // return of({
    //   id: '',
    //   postoColetaId: '',
    //   dataExame: new Date(),
    //   pacienteId: '',
    //   convenio: '',
    //   medicoId: '',
    //   dataRetirada: new Date(),
    //   exames: new OrdemServicoExame[]
    // });
  }
}
