import { NgModule } from '@angular/core';
import { MatToolbarModule } from '@angular/material';
import { MatCardModule } from '@angular/material';
import { MatIconModule } from '@angular/material';
import {MatInputModule} from '@angular/material/input';
import {MatCheckboxModule} from '@angular/material/checkbox';
import {MatButtonModule} from '@angular/material/button';

@NgModule({
    imports: [
        MatCardModule,
        MatToolbarModule,
        MatIconModule,
        MatInputModule,
        MatCheckboxModule,
        MatButtonModule
    ],
    exports: [
        MatCardModule,
        MatToolbarModule,
        MatIconModule,
        MatInputModule,
        MatCheckboxModule,
        MatButtonModule
    ]
})
export class AMaterialModule { }