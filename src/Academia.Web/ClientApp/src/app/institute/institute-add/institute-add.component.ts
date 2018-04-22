import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormControl } from '@angular/forms';
import { Router } from '@angular/router';

import { Institute } from '../../model/institute';
import { InstituteService } from '../../model/institute.service';

@Component({
  selector: 'app-institute-add',
  templateUrl: './institute-add.component.html',
  styleUrls: ['./institute-add.component.css']
})
export class InstituteAddComponent implements OnInit {

  instituteForm: FormGroup;

  constructor(
    private fb: FormBuilder,
    private instituteService: InstituteService,
    private router: Router) { }

  ngOnInit() {
    this.createForm();
  }

  saveInstitute() {
    const institute: Institute = this.instituteForm.value;
    this.instituteService.addInstitute(institute)
      .subscribe(() =>
        this.goToList()
      );
  }

  cancel() {
    this.goToList();
  };

  goToList() {
    this.router.navigate(['/institute']);
  }

  createForm() {
    this.instituteForm = this.fb.group({
      name: '',
      address: '',
      email: ''
    });
  }

}
