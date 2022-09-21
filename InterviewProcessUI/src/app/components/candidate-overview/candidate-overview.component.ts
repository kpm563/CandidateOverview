import { Component, OnDestroy, OnInit } from '@angular/core';
import { ColDef } from 'ag-grid-community';
import { ToastrService } from 'ngx-toastr';
import { Subscription } from 'rxjs';
import { CandidateService } from 'src/app/services/candidate.service';

@Component({
  selector: 'app-candidate-overview',
  templateUrl: './candidate-overview.component.html',
  styleUrls: ['./candidate-overview.component.scss']
})
export class CandidateOverviewComponent implements OnInit, OnDestroy {

  showAddCandidate: boolean = false;
  subscriptions: Subscription[] = [];
  candidates: any[] = [];

  // columnDefs: ColDef[] = [
  //   { field: 'make' },
  //   { field: 'model' },
  //   { field: 'price' }
  // ];

  // rowData = [
  //   { make: 'Toyota', model: 'Celica', price: 35000 },
  //   { make: 'Ford', model: 'Mondeo', price: 32000 },
  //   { make: 'Porsche', model: 'Boxster', price: 72000 }
  // ];


  constructor(private toaster: ToastrService, private candidateService: CandidateService) {

  }

  ngOnInit(): void {
    this.loadData();
  }

  loadData() {
    const sub = this.candidateService.AllCandidates$()
      .subscribe(x => {
        debugger
        this.candidates = x.result.candidates;
      },
        err => {
          // this.toaster.error()
          console.error(err);
        });
  }

  onAddCandidateClick() {
    this.showAddCandidate = true;
  }

  onCancle() {
    this.showAddCandidate = false;
    this.loadData();
  }



  ngOnDestroy(): void {

  }
}
