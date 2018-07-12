import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ClassinfoListComponent } from './classinfo-list/classinfo-list.component';
import { ClassinfoRoutigModule } from './classinfo-routing.module';

@NgModule({
  imports: [
    CommonModule,
    ClassinfoRoutigModule
  ],
  declarations: [ClassinfoListComponent]
})
export class ClassinfoModule { }
