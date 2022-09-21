import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

let headers = new HttpHeaders();
headers.append('Content-Type', 'multipart/form-data');
headers.append('Accept', 'application/json');

const headerOptions = {
  headers: headers,
  // observe: 'response' as 'body',
}

@Injectable({
  providedIn: 'root'
})
export class CandidateService {

  constructor(private http: HttpClient, private toaster: ToastrService) {

  }

  createCandidate$(form: any) {
    const url: string = 'https://localhost:7144/api/Candidate/CreateCandidate';
    return this.http.post<any>(url, form, headerOptions);
  }

  AllCandidates$() {
    const url: string = 'https://localhost:7144/api/Candidate/Candidates';
    return this.http.get<any>(url);
  }

}
