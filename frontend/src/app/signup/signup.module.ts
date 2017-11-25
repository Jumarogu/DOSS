import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Routes, RouterModule } from '@angular/router';
import { AMaterialModule } from '../material/material.module';
import { SignUpComponent } from './signup.component';
import {HttpClientModule} from '@angular/common/http';
import { DataService } from '../services/data.service';
import { AuthService } from '../services/auth/auth.service';

const routes: Routes = [
    { path: 'signup', component: SignUpComponent }
];

@NgModule({
    declarations: [
        SignUpComponent
    ],
    exports: [
        SignUpComponent
    ],
    imports: [
        CommonModule,
        FormsModule,
        AMaterialModule,
        HttpClientModule,
        RouterModule.forChild(routes)
    ],
    providers: [
        DataService,
        AuthService
    ]
})

export class SignUpModule { }