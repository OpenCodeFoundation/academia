import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientTestingModule } from '@angular/common/http/testing';

import { InstituteAddComponent } from './institute-add.component';
import { InstituteService } from '../../model/institute.service';

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
        HttpClientTestingModule
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
});
