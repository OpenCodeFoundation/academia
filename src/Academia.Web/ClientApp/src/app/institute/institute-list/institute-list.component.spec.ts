import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { InstituteListComponent } from './institute-list.component';
import { InstituteService } from '../../model/institute.service';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { RouterTestingModule } from '@angular/router/testing';

describe('InstituteListComponent', () => {
  let component: InstituteListComponent;
  let fixture: ComponentFixture<InstituteListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [InstituteListComponent],
      providers: [InstituteService],
      imports: [HttpClientTestingModule, RouterTestingModule]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InstituteListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
