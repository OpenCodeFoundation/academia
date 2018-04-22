import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { RouterTestingModule } from '@angular/router/testing';

import { InstituteAddComponent } from './institute-add.component';
import { InstituteService } from '../../model/institute.service';
import { Institute } from '../../model/institute';

describe('InstituteAddComponent', () => {
  let component: InstituteAddComponent;
  let fixture: ComponentFixture<InstituteAddComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [
        InstituteAddComponent
      ],
      imports: [
        ReactiveFormsModule, 
        HttpClientTestingModule,
        RouterTestingModule
      ],
      providers: [
        InstituteService
      ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InstituteAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should create a valid form', () => {
    expect(component.instituteForm.valid).toBeTruthy();
  });

  it('should have empty values when initialized', () => {
    var institute: Institute = {
      name: '',
      address: '',
      email: ''
    };

    expect(component.instituteForm.value).toEqual(institute);
  });

});
