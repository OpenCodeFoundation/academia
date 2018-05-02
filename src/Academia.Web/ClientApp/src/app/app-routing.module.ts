import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router'


const routes: Routes = [
  { path: '', redirectTo: 'institute', pathMatch: 'full' },
  { path: 'institute', loadChildren: 'app/institute/institute.module#InstituteModule' },
  { path: 'classinfo', loadChildren: 'app/classinfo/classinfo.module#ClassinfoModule' }
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [
    RouterModule
  ]
})
export class AppRoutingModule { }
