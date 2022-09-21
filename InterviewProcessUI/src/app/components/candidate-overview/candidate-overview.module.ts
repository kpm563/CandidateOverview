import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CandidateOverviewRoutingModule } from './candidate-overview-routing.module';
import { AddCandidateComponent } from './add-candidate/add-candidate.component';
import { CandidateOverviewComponent } from './candidate-overview.component';
import { ReactiveFormsModule } from '@angular/forms';
import { NgxDropzoneModule } from 'ngx-dropzone';
import { AgGridModule } from 'ag-grid-angular';
import { GridModule } from '@syncfusion/ej2-angular-grids';


@NgModule({
  declarations: [
    AddCandidateComponent,
    CandidateOverviewComponent
  ],
  imports: [
    CommonModule,
    CandidateOverviewRoutingModule,
    ReactiveFormsModule,
    NgxDropzoneModule,
    AgGridModule,
    GridModule,
  ]
})
export class CandidateOverviewModule { }
