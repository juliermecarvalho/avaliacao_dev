import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FrmInvestmentsComponent } from './frm-investments/frm-investments.component';

const routes: Routes = [

  {
    path: '',
    component: FrmInvestmentsComponent
  },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
