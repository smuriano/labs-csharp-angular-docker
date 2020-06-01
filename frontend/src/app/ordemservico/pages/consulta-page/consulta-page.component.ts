import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';

import { OrdemServicoList } from './../../models/ordemservico.list.model';
import { OrdemServicoService } from './../../services/ordemservico.service';

@Component({
  selector: 'app-consulta-page',
  templateUrl: './consulta-page.component.html'
})
export class ConsultaPageComponent implements OnInit {

  public ordemServicosList$: Observable<OrdemServicoList[]> = null;

  constructor(private ordemServicoService: OrdemServicoService) { }

  ngOnInit(): void {
    this.ordemServicosList$ = this.ordemServicoService.getOrdens();
  }

}
