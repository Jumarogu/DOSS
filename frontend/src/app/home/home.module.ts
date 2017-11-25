import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Routes, RouterModule } from '@angular/router';
import { AMaterialModule } from '../material/material.module';
import { HomeComponent } from './home.component';
import { dnutChart} from './dnutChart/dnutChart.component';
import { baseChart} from './baseChart/baseChart.component';
import {TableComponent} from './table/table.component';

import { ChartsModule } from 'ng2-charts/ng2-charts';

const routes: Routes = [
    {path: 'home', component: HomeComponent}
];

@NgModule({
    declarations: [
        HomeComponent,
        dnutChart,
        baseChart,
        TableComponent,
        
     
    ],
    exports: [
        HomeComponent,
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
    providers: []
})

export class HomeModule { 

    tiles = [
        {text: 'One', cols: 3, rows: 1, color: 'lightblue'},
        {text: 'Two', cols: 1, rows: 2, color: 'lightgreen'},
        {text: 'Three', cols: 1, rows: 1, color: 'lightpink'},
        {text: 'Four', cols: 2, rows: 1, color: '#DDBDF1'},
      ];

}