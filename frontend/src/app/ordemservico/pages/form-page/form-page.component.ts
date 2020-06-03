import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Observable, EMPTY, of } from 'rxjs';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';

import { PostoColeta } from './../../../postocoleta/models/postocoleta.model';
import { Medico } from 'src/app/medico/models/medico.model';
import { Exame } from './../../../exame/models/exame.model';
import { Paciente } from './../../../paciente/models/paciente.model';
import { OrdemServicoExame } from './../../models/ordemservicoexame.model';

import { OrdemServicoService } from '../../services/ordemservico.service';
import { PostoColetaService } from './../../../postocoleta/services/postocoleta.service';
import { MedicoService } from './../../../medico/services/medico.service';
import { ExameService } from './../../../exame/services/exame.service';
import { PacienteService } from './../../../paciente/services/paciente.service';

@Component({
  selector: 'app-form-page',
  templateUrl: './form-page.component.html'
})
export class FormPageComponent implements OnInit {

  public ordemServicoForm: FormGroup;
  public items: OrdemServicoExame[] = [];

  public postoColetas$: Observable<PostoColeta[]> = null;
  public medicos$: Observable<Medico[]> = null;
  public exames$: Observable<Exame[]> = null;
  public pacientes$: Observable<Paciente[]> = null;

  public modalRef: BsModalRef;
  public index: number;

  constructor(
    private formBuilder: FormBuilder,
    private modalService: BsModalService,
    private route: ActivatedRoute,
    private ordemServicoService: OrdemServicoService,
    private postoColetaService: PostoColetaService,
    private medicoService: MedicoService,
    private exameService: ExameService,
    private pacienteService: PacienteService
  ) { }

  ngOnInit(): void {
    this.postoColetas$ = this.postoColetaService.getPostoColetas();
    this.medicos$ = this.medicoService.getMedicos();
    this.exames$ = this.exameService.getExames();
    this.pacientes$ = this.pacienteService.getPacientes();

    const ordemServico = this.route.snapshot.data['ordemServico'];

    this.ordemServicoForm = this.formBuilder.group({
      id: [ordemServico.id],
      postoColetaId: [ordemServico.postoColetaId],
      data: [ordemServico.data],
      pacienteId: [ordemServico.pacienteId],
      convenio: [ordemServico.convenio],
      medicoId: [ordemServico.medicoId],
      dataRetirada: [ordemServico.dataRetirada],
      valorOrdem: [0]
    });
  }

  onOpenModalExameItem(i: number, template: TemplateRef<any>) {
    this.index = i;
    this.modalRef = this.modalService.show(template, Object.assign({}, { class: 'modal-dialog-centered modal-dialog-scrollable modal-lg' }));
  }

  closeModal() {
    this.modalRef.hide();
  }

  onAddOrEditExames(): void {
    if (this.index && this.index === 0)
      this.items.push(new OrdemServicoExame(0, 0, 'Exame {{index}', 0));
    console.log("sucesso");
    this.closeModal();
  }

  updateTotal(): void {
    this.ordemServicoForm.patchValue('valorOrdem') = this.items.reduce((total, item) => total + (item.preco), 0);
  }
}
