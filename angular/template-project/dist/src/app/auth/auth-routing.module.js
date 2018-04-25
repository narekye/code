import { NgModule } from '@angular/core';
import { SignInComponent } from './sign-in/sign-in.component';
import { SignUpComponent } from './sign-up/sign-up.component';
var authRoutes = [
    { path: 'signin', component: SignInComponent },
    { path: 'signup', component: SignUpComponent }
];
var AuthRoutingModule = (function () {
    function AuthRoutingModule() {
    }
    AuthRoutingModule.decorators = [
        { type: NgModule, args: [{},] },
    ];
    return AuthRoutingModule;
}());
export { AuthRoutingModule };
