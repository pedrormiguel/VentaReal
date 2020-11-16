import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { Authen } from './security/Auth/auth.guard';

const routes: Routes = [

  { path: '', redirectTo:  '/home', pathMatch: 'full' },
  { path: 'home', component: HomeComponent, canActivate: [Authen] },
  { path: 'login', component: LoginComponent}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }
