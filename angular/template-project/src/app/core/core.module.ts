import {NgModule} from '@angular/core';
import {TokenInterceptor} from './token.interceptor';
import {HTTP_INTERCEPTORS, HttpClientModule} from '@angular/common/http';
import {BasicAuthService} from './auth/basic-auth.service';
import {ForTestingService} from './../for-testing/for-testing.service';
import {CommonModule} from '@angular/common';
import {API_ENDPOINT} from '../shared/constants';
import {IAuthServiceBase} from "./auth/base-auth.service";

const production = false;
const DEV_BASE_URL = "https://jsonplaceholder.typicode.com/posts/1";
const PROD_BASE_URL = "http://base-URL.com/";

@NgModule({
    declarations: [],
    imports: [
        CommonModule,
        HttpClientModule
    ],
    providers: [
        ForTestingService,
        IAuthServiceBase,
        BasicAuthService,
        {
            provide: HTTP_INTERCEPTORS,
            useClass: TokenInterceptor,
            multi: true,
            deps: [BasicAuthService]
        },
        {provide: API_ENDPOINT, useValue: production ? PROD_BASE_URL : DEV_BASE_URL}
        // usage @Inject(Constants.ApiKey) url : string in ctor, like services, choose env mode {production}.
    ]
})

export class CoreModule {
}