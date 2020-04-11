import { Component } from '@angular/core';
import { Repository } from "../models/repository"
import { HttpClient } from '@angular/common/http';
import { FormGroup, FormControl, Validators } from '@angular/forms';



@Component({
  templateUrl: 'fileupload.component.html'
})
export class FileUploadComponent {
  isSingleUploaded: boolean;
  isFileUploaded: boolean;
  myForm = new FormGroup({
    name: new FormControl('', [Validators.required, Validators.minLength(3)]),
    file: new FormControl('', [Validators.required]),
    fileSource: new FormControl('', [Validators.required])
  });
  constructor(private repo: Repository,
    private http: HttpClient) { }


  onFileChange(event) {

    if (event.target.files.length > 0) {
      const file = event.target.files[0];
      this.myForm.patchValue({
        fileSource: file
      });
    }
  }

  submit() {

    const formData = new FormData();
    formData.append('file', this.myForm.get('fileSource').value);
    if (this.myForm.get('fileSource').value === "") {
      this.isFileUploaded = false;
      alert("Please select a file to upload");
    } else {

      this.http.post('api/file', formData)
        .subscribe(res => { this.isSingleUploaded = true; });
    }
  }


}
