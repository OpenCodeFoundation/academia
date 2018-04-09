import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { InstituteListComponent } from './institute-list.component';
import { InstituteService } from '../../model/institute.service';
import { HttpClientModule } from '@angular/common/http';

describe('InstituteListComponent', () => {
  let component: InstituteListComponent;
  let fixture: ComponentFixture<InstituteListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [InstituteListComponent],
      providers: [InstituteService],
      imports: [HttpClientModule]
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
