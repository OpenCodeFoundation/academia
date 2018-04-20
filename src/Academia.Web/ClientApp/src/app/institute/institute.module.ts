import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InstituteRoutingModule } from './institute-routing.module';
import { InstituteListComponent } from './institute-list/institute-list.component';
import { InstituteAddComponent } from './institute-add/institute-add.component';

@NgModule({
  imports: [
    CommonModule,
    InstituteRoutingModule
  ],
  declarations: [InstituteListComponent, InstituteAddComponent]
})
export class InstituteModule { }
