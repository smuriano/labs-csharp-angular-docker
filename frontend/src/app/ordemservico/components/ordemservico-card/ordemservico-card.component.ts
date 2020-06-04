import { Component, OnInit, Input } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

import { OrdemServicoListViewModel } from '../../models/ordemservicolistviewmodel.model';

@Component({
  selector: 'app-ordemservico-card',
  templateUrl: './ordemservico-card.component.html'
})
export class OrdemServicoCardComponent implements OnInit {

  @Input() ordemServicoList: OrdemServicoListViewModel;

  constructor(private toastr: ToastrService) { }

  ngOnInit(): void {
  }

}
