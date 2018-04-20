import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router'

import { InstituteListComponent } from './institute-list/institute-list.component'
import { Router } from '@angular/router/src/router';
import { InstituteAddComponent } from './institute-add/institute-add.component';

const routes: Routes = [
  { path: '', component: InstituteListComponent },
  { path: 'add', component: InstituteAddComponent }
];

@NgModule({
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [
    RouterModule
  ]
})
export class InstituteRoutingModule { }
