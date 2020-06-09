import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { ToastrModule } from 'ngx-toastr';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';

import { OrdemServicoRoutingModule } from './ordemservico.routing';
import { OrdemServicoAppComponent } from './ordemservico.app.component';
import { ConsultaPageComponent } from './pages/consulta-page/consulta-page.component';
import { FormPageComponent } from './pages/form-page/form-page.component';

@NgModule({
  declarations: [
    OrdemServicoAppComponent,
    ConsultaPageComponent,
    FormPageComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    OrdemServicoRoutingModule,
    ToastrModule.forRoot(),
    BsDatepickerModule.forRoot()
  ]
})
export class OrdemServicoModule { }
