import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';

import { OrdemServicoListViewModel } from '../../models/ordemservicolistviewmodel.model';
import { OrdemServicoService } from './../../services/ordemservico.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-consulta-page',
  templateUrl: './consulta-page.component.html'
})
export class ConsultaPageComponent implements OnInit {

  public ordemServicosList$: Observable<OrdemServicoListViewModel[]> = null;

  constructor(
    private ordemServicoService: OrdemServicoService,
    private toastr: ToastrService) { }

  ngOnInit(): void {
    this.onRefresh();
  }

  onRefresh(): void {
    this.ordemServicosList$ = this.ordemServicoService.getOrdens();
  }

  onDelete(id: string) {
    if (confirm('Deseja excluir ordem de serviço?')) {
      this.ordemServicoService.deleteOrdem(id)
        .subscribe(
          success => {
            this.onRefresh();
            this.toastr.success("Exclusão com sucesso", "Clinical Labs");
          },
          error => {
            console.error(error);
            this.toastr.error("Problema com a exclusão", "Clinical Labs");
          });
    }
  }
}
