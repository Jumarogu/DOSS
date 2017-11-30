import { NgModule } from '@angular/core';
import { MatToolbarModule } from '@angular/material';
import { MatCardModule } from '@angular/material';
import { MatIconModule } from '@angular/material';
import {MatInputModule} from '@angular/material/input';
import {MatCheckboxModule} from '@angular/material/checkbox';
import {MatButtonModule} from '@angular/material/button';
import {MatSlideToggleModule} from '@angular/material/slide-toggle';
import {MatGridListModule} from '@angular/material/grid-list';
import {MatSidenavModule} from '@angular/material/sidenav';
import {MatTableModule} from '@angular/material/table';
import {MatTableDataSource} from '@angular/material';
import {MatSelectModule} from '@angular/material/select';



@NgModule({
    imports: [
        MatCardModule,
        MatToolbarModule,
        MatIconModule,
        MatInputModule,
        MatCheckboxModule,
        MatButtonModule,
        MatSlideToggleModule,
        MatGridListModule,
        MatSidenavModule,
        MatTableModule,
        MatSelectModule
    ],
    exports: [
        MatCardModule,
        MatToolbarModule,
        MatIconModule,
        MatInputModule,
        MatCheckboxModule,
        MatButtonModule,
        MatSlideToggleModule,
        MatGridListModule,
        MatSidenavModule,
        MatTableModule,
        MatSelectModule
    ]
})
export class AMaterialModule { }