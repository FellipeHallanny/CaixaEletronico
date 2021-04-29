import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CaixasComponent } from './caixas/caixas.component';
import { NotasComponent } from './notas/notas.component';
import { SaqueComponent } from './saque/saque.component';

const routes: Routes = [
  {path: 'notas',component:NotasComponent},
  {path: 'saque',component:SaqueComponent},
  {path: 'caixas',component:CaixasComponent},
  {path: '', redirectTo: 'caixas', pathMatch: 'full'},
  {path: '**', redirectTo: 'caixas', pathMatch: 'full'}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
