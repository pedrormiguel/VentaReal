import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';  

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { CarComponent } from './car/car.component';
import { DialogComponent } from './common/dialog/dialog.component';


import { MatSidenavModule } from '@angular/material/sidenav';
import { MatTableModule } from '@angular/material/table';
import { MatDialogModule } from '@angular/material/dialog';
import { MatButtonModule } from '@angular/material/button';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatCardModule } from '@angular/material/card';
import { MatInputModule } from '@angular/material/input';

import { Authen } from './security/Auth/auth.guard';
import { LoginComponent } from './login/login.component';
import { JWTInterceptor } from './services/jwt.interceptor';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    CarComponent,
    DialogComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    
    MatSidenavModule,
    MatTableModule,
    MatDialogModule,
    MatButtonModule,
    MatSnackBarModule,
    MatCardModule,
    MatInputModule,

    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [ 
    Authen,
    { provide: HTTP_INTERCEPTORS, useClass: JWTInterceptor, multi:true}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
