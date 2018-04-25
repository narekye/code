import { BasicAuthService } from './services/basic-auth.service';
import { CommonModule } from '@angular/common';
import { AppRoutingModule } from '../app-routing.module';
import { NgModule } from '@angular/core';
import { API_ENDPOINT } from '../shared/constants';
import { SignUpComponent } from './sign-up/sign-up.component';
import { SignInComponent } from './sign-in/sign-in.component';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { TokenInterceptor } from './token.interceptor';
var production = false;
var DEV_BASE_URL = "https://jsonplaceholder.typicode.com/posts/1";
var PROD_BASE_URL = "http://www.google.com/";
var AuthModule = (function () {
    function AuthModule() {
    }
    AuthModule.decorators = [
        { type: NgModule, args: [{
                    declarations: [
                        SignInComponent,
                        SignUpComponent
                    ],
                    imports: [
                        CommonModule,
                        AppRoutingModule
                    ],
                    exports: [AppRoutingModule],
                    providers: [
                        BasicAuthService,
                        { provide: API_ENDPOINT, useValue: production ? PROD_BASE_URL : DEV_BASE_URL },
                        {
                            provide: HTTP_INTERCEPTORS,
                            useClass: TokenInterceptor,
                            multi: true,
                            deps: [BasicAuthService]
                        }
                    ]
                },] },
    ];
    return AuthModule;
}());
export { AuthModule };
