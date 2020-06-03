import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, RouterStateSnapshot, Resolve } from '@angular/router';
import { Observable, of } from 'rxjs';

import { OrdemServicoService } from './../services/ordemservico.service';
import { OrdemServico } from '../models/ordemservico.model';

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

    return of({
      id: null,
      postoColetaId: null,
      data: null,
      pacienteId: null,
      convenio: null,
      medicoId: null,
      dataRetirada: null,
      exames: null
    });
  }
}
