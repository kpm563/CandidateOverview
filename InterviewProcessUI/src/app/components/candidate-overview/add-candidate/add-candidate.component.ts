import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { CandidateService } from 'src/app/services/candidate.service';

@Component({
  selector: 'app-add-candidate',
  templateUrl: './add-candidate.component.html',
  styleUrls: ['./add-candidate.component.scss']
})
export class AddCandidateComponent implements OnInit {
  form: FormGroup = new FormGroup({});

  files: File[] = [];

  @Output() onCancle: EventEmitter<any> = new EventEmitter();


  constructor(private fb: FormBuilder, private toaster: ToastrService, private candidateService: CandidateService) {
    this.form = fb.group({
      name: new FormControl(null),
      address: new FormControl(null),
      mobile: new FormControl(null, [Validators.required, Validators.pattern("^((\\+91-?)|0)?[0-9]{10}$")]),
      email: new FormControl(null),
    });

  }

  ngOnInit(): void {

  }

  onSelect(event: any) {
    console.log(event);
    this.files.push(...event.addedFiles);
  }

  onRemove(event: any) {
    console.log(event);
    this.files.splice(this.files.indexOf(event), 1);
  }

  onFileSelect(event: any) {
    if (event.rejectedFiles.length > 0) {
      let msg: string = '';
      event.rejectedFiles.map((x: any) => msg += `File name : ${x.fileName} rejected. Reason : ${x.reason}.`);
      this.toaster.error(msg);
      return;
    }

    event.addedFiles.map((x: any) => this.files.push(x));
  }

  onFileRemove(event: any) {
    this.files.splice(this.files.indexOf(event), 1);
  }

  onSubmit() {
    if (this.validateData()) {
      const extension = `.${this.files[0].name.split('.').pop()}`;

      const form = new FormData();
      form.append('name', this.form.value['name']);
      form.append('address', this.form.value['address']);
      form.append('mobile', this.form.value['mobile']);
      form.append('email', this.form.value['email']);

      form.append('fileData', this.files[0], this.files[0].name);
      form.append('fileName', this.files[0].name);
      form.append('fileExtension', extension);
      form.append('fileSize', this.files[0].size as any);
      form.append('fileType', this.files[0].type);

      this.candidateService.createCandidate$(form)
        .subscribe(x => {
          this.toaster.success('Cadidate details created.');
          this.onCanle();
        },
          (err) => this.toaster.error('Candidate create failed.'));
    }
  }

  validateData(): boolean {
    if (this.form.valid && this.files.length == 1) {
      return true;
    }

    return false;
  }

  onCanle() {
    this.form.reset();
    this.files = [];

    this.onCancle.emit();
  }

  get f() {
    return this.form.controls;
  }

  numberOnly(event: any): boolean {
    const charCode = (event.which) ? event.which : event.keyCode;
    if (charCode > 31 && (charCode < 48 || charCode > 57)) {
      return false;
    }
    return true;

  }

}
