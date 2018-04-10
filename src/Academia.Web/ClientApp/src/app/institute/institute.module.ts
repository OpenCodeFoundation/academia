import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InstituteRoutingModule } from './institute-routing.module';
import { InstituteListComponent } from './institute-list/institute-list.component';

@NgModule({
  imports: [
    CommonModule,
    InstituteRoutingModule
  ],
  declarations: [InstituteListComponent]
})
export class InstituteModule { }
