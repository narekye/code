import { NgModule } from '@angular/core';
import { TokenInterceptor } from './token.interceptor';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { BasicAuthService } from './auth/basic-auth.service';

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
        }
    ]
})

export class CoreModule { }
