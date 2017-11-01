import { CommonModule } from "@angular/common";
import { FormsModule } from "@angular/forms";
import { NgModule } from "@angular/core";
import { LayoutRouting } from "./layout.routing";
import {MatSidenavModule} from '@angular/material';
import { NavComponent } from './nav/nav.component';
import { LayoutComponent } from "./layout.component";
import { MatToolbarModule } from '@angular/material';

@NgModule ({
    declarations: [
        LayoutComponent,
        NavComponent
    ],
    exports: [
        LayoutComponent
    ],
    imports: [
        CommonModule,
        LayoutRouting,
        //SignInModule,
        MatSidenavModule,
        FormsModule,
        MatToolbarModule
    ],
    providers: []
})

export class LayoutModule {  }