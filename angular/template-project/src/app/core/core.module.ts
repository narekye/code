import { Constants } from './../shared/constants';
import { NgModule } from '@angular/core';
import { TokenInterceptor } from './token.interceptor';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { BasicAuthService } from './auth/basic-auth.service';

const production = false;
const BASE_URL_DEV = "http://localhost:{port}/";
const PROD_BASE_URL = "http://base-URL.com/";

@NgModule({
    declarations: [],
    imports: [],
    providers: [
        BasicAuthService,
        {
            provide: HTTP_INTERCEPTORS,
            useClass: TokenInterceptor,
            multi: true,
            deps: [BasicAuthService]
        },
        { provide: Constants.ApiKey, useValue: production ? BASE_URL_DEV : PROD_BASE_URL } // usage @Inject(Constants.ApiKey) url : string in ctor, like services, choose env mode {production}.
    ]
})

export class CoreModule { }