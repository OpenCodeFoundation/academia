import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { ViewInstituteComponent } from './components/viewinstitute/viewinstitute.component';
import { AddInstituteComponent } from './components/addinstitute/addinstitute.component';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        ViewInstituteComponent,
        AddInstituteComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'view-institute', pathMatch: 'full' },
            { path: 'view-institute', component: ViewInstituteComponent },
            { path: 'add-institute', component: AddInstituteComponent },
            { path: '**', redirectTo: 'view-institute' }
        ])
    ]
})
export class AppModuleShared {
}
