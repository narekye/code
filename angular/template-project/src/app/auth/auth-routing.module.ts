import { Routes } from '@angular/router';
import { NgModule } from '@angular/core';
import { SignInComponent } from './sign-in/sign-in.component'
import { SignUpComponent } from './sign-up/sign-up.component'

const authRoutes: Routes = [
    { path: 'signin', component: SignInComponent },
    { path: 'signup', component: SignUpComponent }
];

@NgModule({

})
export class AuthRoutingModule { }