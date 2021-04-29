import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CaixasComponent } from './caixas/caixas.component';
import { NotasComponent } from './notas/notas.component';

const routes: Routes = [
  {path: 'notas',component:NotasComponent},
  {path: '', redirectTo: 'caixas', pathMatch: 'full'},
  {path: '**', redirectTo: 'caixas', pathMatch: 'full'},
  {path: 'caixas',component:CaixasComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
