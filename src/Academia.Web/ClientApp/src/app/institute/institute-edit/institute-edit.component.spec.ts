import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { ReactiveFormsModule } from '@angular/forms';

import { InstituteEditComponent } from './institute-edit.component';
import { InstituteService } from '../../model/institute.service';

describe('InstituteEditComponent', () => {
  let component: InstituteEditComponent;
  let fixture: ComponentFixture<InstituteEditComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [InstituteEditComponent],
      imports: [
        RouterTestingModule,
        HttpClientTestingModule,
        ReactiveFormsModule
      ],
      providers: [
        InstituteService
      ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InstituteEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
