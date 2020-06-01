import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { SobreComponent } from './navegacao/sobre/sobre.component';
import { NotFoundComponent } from './navegacao/notfound/notfound.component';
import { HomeComponent } from './navegacao/home/home.component';

const routes: Routes = [
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  {
    path: 'ordens',
    loadChildren: () => import('./ordemservico/ordemservico.module')
      .then(m => m.OrdemServicoModule)
  },
  { path: 'home', component: HomeComponent },
  { path: 'sobre', component: SobreComponent },
  { path: '**', component: NotFoundComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
