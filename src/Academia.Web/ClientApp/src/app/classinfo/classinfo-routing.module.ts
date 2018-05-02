import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router'

import { ClassinfoListComponent } from './classinfo-list/classinfo-list.component'

const routes: Routes = [
  { path: '', component: ClassinfoListComponent }
];

@NgModule({
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [
    RouterModule
  ]
})
export class ClassinfoRoutigModule { }
