import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ClassinfoListComponent } from './classinfo-list.component';

describe('ClassinfoListComponent', () => {
  let component: ClassinfoListComponent;
  let fixture: ComponentFixture<ClassinfoListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ClassinfoListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ClassinfoListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
