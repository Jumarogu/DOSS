import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Routes, RouterModule } from '@angular/router';
import { AMaterialModule } from '../material/material.module';
import { SignInComponent } from './signin.component';

const routes: Routes = [
    {path: 'signin', component: SignInComponent}
];

@NgModule({
    declarations: [
        SignInComponent
    ],
    exports: [
        SignInComponent
    ],
    imports: [
        CommonModule,
        FormsModule,
        AMaterialModule,
        RouterModule.forChild(routes)
    ],
    providers: []
})

export class SignInModule { }