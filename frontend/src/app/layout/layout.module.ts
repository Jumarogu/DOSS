import { CommonModule } from "@angular/common";
import { FormsModule } from "@angular/forms";
import { NgModule } from "@angular/core";
import { LayoutRouting } from "./layout.routing";
import { AMaterialModule } from '../material/material.module';
import { NavComponent } from './nav/nav.component';
import { LayoutComponent } from "./layout.component";

@NgModule ({
    declarations: [
        LayoutComponent,
        NavComponent
    ],
    exports: [
        LayoutComponent,
        NavComponent
    ],
    imports: [
        CommonModule,
        LayoutRouting,
        //SignInModule,
        FormsModule,
        AMaterialModule
    ],
    providers: []
})

export class LayoutModule {  }