import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { NotFoundComponent } from './notfound/notfound.component';
import { MenuComponent } from './menu/menu.component';
import { SobreComponent } from './sobre/sobre.component';
import { HomeComponent } from './home/home.component';




@NgModule({
  declarations: [
    NotFoundComponent,
    MenuComponent,
    SobreComponent,
    HomeComponent
  ],
  imports: [
    CommonModule,
    RouterModule
  ],
  exports: [
    NotFoundComponent,
    MenuComponent,
    SobreComponent,
    HomeComponent
  ]
})
export class NavegacaoModule { }
