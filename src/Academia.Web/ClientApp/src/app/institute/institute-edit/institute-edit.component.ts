import { Component, OnInit, Input } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import { Institute } from '../../model/institute';
import { InstituteService } from '../../model/institute.service';

@Component({
  selector: 'app-institute-edit',
  templateUrl: './institute-edit.component.html',
  styleUrls: ['./institute-edit.component.css']
})
export class InstituteEditComponent implements OnInit {

  constructor(
    private instituteService: InstituteService,
    private route: ActivatedRoute,
    private router: Router,
    private fb: FormBuilder) { }

  instituteForm: FormGroup;

  ngOnInit() {
    // get institute when `id` param changes
    this.route.paramMap.subscribe(pmap => this.getInstitute(pmap.get('id')));
    this.createForm();
  }

  updateInstitute() {
    const institute: Institute = this.instituteForm.value;
    console.log('The instute is {}', institute);
    this.instituteService.updateInstitute(this.instituteForm.value)
      .subscribe(() =>
        this.goToList()
      );
  }

  private getInstitute(id: string): void {
    this.instituteService.getInstitute(id)
      .subscribe(institute => {
        this.instituteForm.setValue(institute);
        console.log('institute for this url is {}', institute);
      });
  }

  goToList() {
    this.router.navigate(['/institute']);
  }

  cancel() {
    this.goToList();
  }

  createForm() {
    this.instituteForm = this.fb.group({
      id: '',
      name: ['', Validators.required],
      address: '',
      email: ''
    });
  }
}
