import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CandidateOverviewComponent } from './candidate-overview.component';

const routes: Routes = [
  {
    path: '',
    component: CandidateOverviewComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CandidateOverviewRoutingModule {

}
