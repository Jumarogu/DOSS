import { NgModule } from '@angular/core';
import { MatToolbarModule } from '@angular/material';
import { MatCardModule } from '@angular/material';
import { MatIconModule } from '@angular/material';
import {MatInputModule} from '@angular/material/input';
import {MatButtonModule} from '@angular/material';

@NgModule({
    imports: [
        MatCardModule,
        MatToolbarModule,
        MatIconModule,
        MatInputModule,
        MatButtonModule

    ],
    exports: [
        MatCardModule,
        MatToolbarModule,
        MatIconModule,
        MatInputModule,
        MatButtonModule
    ]
})
export class AMaterialModule { }