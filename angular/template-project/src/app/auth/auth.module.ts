import { BasicAuthService } from './services/basic-auth.service';
import { CommonModule } from '@angular/common';

import { NgModule } from '@angular/core';
import { API_ENDPOINT } from '../shared/constants';
import { SignUpComponent } from './sign-up/sign-up.component';
import { SignInComponent } from './sign-in/sign-in.component';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { TokenInterceptor } from './token.interceptor';
import { AuthRoutingModule } from './auth-routing.module';

const production = false;
const DEV_BASE_URL = "https://jsonplaceholder.typicode.com/posts/1";
const PROD_BASE_URL = "http://www.google.com/";

@NgModule({
    declarations: [
        SignInComponent,
        SignUpComponent
    ],
    imports: [
        CommonModule,
        AuthRoutingModule
    ],
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
})
export class AuthModule {

}