import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import { AppComponent } from './app.component';
import { AppRouting } from './app.routing';
import { AMaterialModule } from './material/material.module';
import { LayoutModule } from './layout/layout.module';
import { SignUpModule } from './signup/signup.module';
import { SignInModule } from './signin/signin.module'; 
import {HttpClientModule} from '@angular/common/http';
import { DataService } from './services/data.service';
import { AuthService } from './services/auth/auth.service';


@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AMaterialModule,
    AppRouting,
    LayoutModule,
    SignInModule,
    SignUpModule,
    HttpClientModule
  ],
  providers: [ 
    DataService,
    AuthService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
