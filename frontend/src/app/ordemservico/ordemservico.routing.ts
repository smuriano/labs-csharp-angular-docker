import { OrdemServicoResolverGuard } from './guards/ordemservico.resolve.guard';
import { FormPageComponent } from './pages/form-page/form-page.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { OrdemServicoAppComponent } from './ordemservico.app.component';
import { ConsultaPageComponent } from './pages/consulta-page/consulta-page.component';

const ordemServicoRoutes: Routes = [
  {
    path: '',
    component: OrdemServicoAppComponent,
    children: [
      { path: 'consulta', component: ConsultaPageComponent },
      { path: 'novo', component: FormPageComponent, resolve: { ordemServico: OrdemServicoResolverGuard } },
      { path: ':id', component: FormPageComponent, resolve: { ordemServico: OrdemServicoResolverGuard } }
    ]
  }
]

@NgModule({
  imports: [RouterModule.forChild(ordemServicoRoutes)],
  exports: [RouterModule]
})
export class OrdemServicoRoutingModule { }
