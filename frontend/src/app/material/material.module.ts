import { NgModule } from '@angular/core';
import { MatToolbarModule } from '@angular/material';
import { MatCardModule } from '@angular/material';
import { MatIconModule } from '@angular/material';

@NgModule({
    imports: [
        MatCardModule,
        MatToolbarModule,
        MatIconModule
    ],
    exports: [
        MatCardModule,
        MatToolbarModule,
        MatIconModule
    ]
})
export class AMaterialModule { }