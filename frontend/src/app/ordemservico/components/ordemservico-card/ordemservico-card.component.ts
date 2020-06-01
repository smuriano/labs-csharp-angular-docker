import { Component, OnInit, Input } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

import { OrdemServicoList } from './../../models/ordemservico.list.model';

@Component({
  selector: 'app-ordemservico-card',
  templateUrl: './ordemservico-card.component.html'
})
export class OrdemServicoCardComponent implements OnInit {

  @Input() ordemServicoList: OrdemServicoList;

  constructor(private toastr: ToastrService) { }

  ngOnInit(): void {
  }

}
