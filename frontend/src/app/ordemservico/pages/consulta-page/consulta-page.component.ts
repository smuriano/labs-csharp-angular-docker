import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';

import { OrdemServicoListViewModel } from '../../models/ordemservicolistviewmodel.model';
import { OrdemServicoService } from './../../services/ordemservico.service';

@Component({
  selector: 'app-consulta-page',
  templateUrl: './consulta-page.component.html'
})
export class ConsultaPageComponent implements OnInit {

  public ordemServicosList$: Observable<OrdemServicoListViewModel[]> = null;

  constructor(private ordemServicoService: OrdemServicoService) { }

  ngOnInit(): void {
    this.ordemServicosList$ = this.ordemServicoService.getOrdens();
  }
}
