import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Routes, RouterModule, CanActivate } from '@angular/router';
import { AMaterialModule } from '../material/material.module';
import { ProfessorsComponent } from './professors.component';
import { dnutChart} from './dnutChart/dnutChart.component';
import { baseChart} from './baseChart/baseChart.component';
import {TableComponent} from './table/table.component';
import { ChartsModule } from 'ng2-charts';
import { AuthGuardService as AuthGuard } from '../services/auth/auth-guard.service';
import { AuthService } from '../services/auth/auth.service';

const routes: Routes = [
    {path: 'professor', component: ProfessorsComponent, canActivate: [AuthGuard]}
];

@NgModule({
    declarations: [
        ProfessorsComponent,
        dnutChart,
        baseChart,
        TableComponent,
        
     
    ],
    exports: [
        ProfessorsComponent,
        dnutChart,
        baseChart,
        
     
    ],
    imports: [
        CommonModule,
        FormsModule,
        AMaterialModule,
        ChartsModule,
        
        RouterModule.forChild(routes)
    ],
    providers: [ 
        AuthGuard,
        AuthService
    ]
})

export class ProfessorsModule { 

    tiles = [
        {text: 'One', cols: 3, rows: 1, color: 'lightblue'},
        {text: 'Two', cols: 1, rows: 2, color: 'lightgreen'},
        {text: 'Three', cols: 1, rows: 1, color: 'lightpink'},
        {text: 'Four', cols: 2, rows: 1, color: '#DDBDF1'},
      ];

}