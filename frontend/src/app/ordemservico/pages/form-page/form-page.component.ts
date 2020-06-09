import { find } from 'rxjs/operators';
import { OrdemServicoExame } from './../../models/ordemservicoexame.model';
import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { BsDatepickerConfig, BsLocaleService } from 'ngx-bootstrap/datepicker';
import { defineLocale, formatDate } from 'ngx-bootstrap/chronos';
import { ptBrLocale } from 'ngx-bootstrap/locale';

import { PostoColetaViewModel } from './../../../postocoleta/models/postocoletaviewmodel.model';
import { MedicoViewModel } from './../../../medico/models/medicoviewmodel.model';
import { ExameViewModel } from '../../../exame/models/exameviewmodel.model';
import { PacienteViewModel } from '../../../paciente/models/pacienteviewmodel.model';

import { OrdemServicoService } from '../../services/ordemservico.service';
import { PostoColetaService } from './../../../postocoleta/services/postocoleta.service';
import { MedicoService } from './../../../medico/services/medico.service';
import { ExameService } from './../../../exame/services/exame.service';
import { PacienteService } from './../../../paciente/services/paciente.service';
import { OrdemServico } from '../../models/ordemservico.model';

@Component({
  selector: 'app-form-page',
  templateUrl: './form-page.component.html'
})
export class FormPageComponent implements OnInit {

  public dpConfig: Partial<BsDatepickerConfig> = new BsDatepickerConfig();

  public ordemServicoForm: FormGroup;
  public ordemServicoExameForm: FormGroup;
  public ordemServico: OrdemServico;

  public postoColetas$: Observable<PostoColetaViewModel[]> = null;
  public medicos$: Observable<MedicoViewModel[]> = null;
  public exames$: Observable<ExameViewModel[]> = null;
  public pacientes$: Observable<PacienteViewModel[]> = null;

  public exameList: ExameViewModel[];
  public modalRef: BsModalRef;
  public index: number;

  constructor(
    private formBuilder: FormBuilder,
    private formBuilderExame: FormBuilder,
    private modalService: BsModalService,
    private localeService: BsLocaleService,
    private router: Router,
    private route: ActivatedRoute,
    private postoColetaService: PostoColetaService,
    private medicoService: MedicoService,
    private exameService: ExameService,
    private pacienteService: PacienteService
  ) { }

  ngOnInit(): void {
    defineLocale('pt-br', ptBrLocale);
    this.localeService.use('pt-br');

    this.dpConfig.isAnimated = true;
    this.dpConfig.containerClass = 'theme-dark-blue';
    this.dpConfig.dateInputFormat = 'DD/MM/YYYY';
    this.dpConfig.returnFocusToInput = true;

    this.postoColetas$ = this.postoColetaService.getPostoColetas();
    this.medicos$ = this.medicoService.getMedicos();
    this.exames$ = this.exameService.getExames();
    this.pacientes$ = this.pacienteService.getPacientes();

    this.exames$.forEach(element => {
      this.exameList = element;
    });

    this.ordemServicoForm = this.formBuilder.group({
      id: [null],
      postoColetaId: [null],
      dataExame: [new Date()],
      pacienteId: [null],
      convenio: [null],
      medicoId: [null],
      dataRetirada: [new Date()]
    });

    this.ordemServicoExameForm = this.formBuilderExame.group({
      id: [null],
      exameId: [null],
      preco: [0]
    });

    this.ordemServico = this.route.snapshot.data['ordemServico'];
    if (this.ordemServico !== null) {
      this.ordemServicoForm.patchValue({
        id: this.ordemServico.id,
        postoColetaId: this.ordemServico.postoColetaId,
        dataExame: new Date(this.ordemServico.dataExame),
        pacienteId: this.ordemServico.pacienteId,
        convenio: this.ordemServico.convenio,
        medicoId: this.ordemServico.medicoId,
        dataRetirada: new Date(this.ordemServico.dataRetirada)
      });
    }
  }

  closeForm(): void {
    this.router.navigate(['/ordens/consulta']);
  }

  onOpenModalExameItem(i: number, template: TemplateRef<any>): void {
    this.index = i;
    if (this.index === -1) {
      this.ordemServicoExameForm.reset();
    }
    else {
      let exame = this.ordemServico.exames[this.index];
      console.log('Edit', exame);

      this.ordemServicoExameForm.patchValue({
        id: exame.id,
        exameId: exame.exameId,
        preco: exame.preco
      });
    }

    this.modalRef = this.modalService.show(template, Object.assign({}, { class: 'modal-dialog-centered modal-dialog-scrollable modal-lg' }));
  }

  onAddOrEditExame(): void {
    let exame = this.exameList.find(x => x.id === this.ordemServicoExameForm.get('exameId').value);

    if (this.index && this.index === -1) {
      this.ordemServico.exames.push(
        new OrdemServicoExame(
          this.ordemServicoExameForm.get('id').value,
          null,
          exame.id,
          exame.descricao,
          exame.preco
        )
      );
    } else {
      this.ordemServico.exames[this.index].exameId = exame.id;
      this.ordemServico.exames[this.index].exameNome = exame.descricao;
      this.ordemServico.exames[this.index].preco = exame.preco;
    }

    this.closeModal();
  }

  onDeleteExame(i: number) {
    if (confirm('Deseja excluir o exame da ordem de serviço?')) {
      this.ordemServico.exames.splice(i, 1);
    }
  }

  closeModal(): void {
    this.modalRef.hide();
  }

  updatePreco(event): void {
    if (event === null) {
      this.ordemServicoExameForm.get('preco').setValue(0);
    }
    else {
      let exame = this.exameList.find(x => x.id === event);
      this.ordemServicoExameForm.get('preco').setValue(exame.preco);
    }
  }
}
