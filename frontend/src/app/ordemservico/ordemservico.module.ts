import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { OrdemServicoRoutingModule } from './ordemservico.routing';
import { OrdemServicoAppComponent } from './ordemservico.app.component';
import { ConsultaPageComponent } from './pages/consulta-page/consulta-page.component';
import { FormPageComponent } from './pages/form-page/form-page.component';
import { OrdemServicoCardComponent } from './components/ordemservico-card/ordemservico-card.component';

@NgModule({
  declarations: [
    OrdemServicoAppComponent,
    ConsultaPageComponent,
    FormPageComponent,
    OrdemServicoCardComponent
  ],
  imports: [
    CommonModule,
    OrdemServicoRoutingModule
  ]
})
export class OrdemServicoModule { }
