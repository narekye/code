import { HttpStatusCode } from './../shared/enums';
import { IAuthServiceBase } from './../core/auth/base-auth.service';
import { HttpInterceptor, HttpHandler, HttpRequest, HttpSentEvent, HttpHeaderResponse, HttpProgressEvent, HttpResponse, HttpUserEvent, HttpHeaders, HttpEvent, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/do';

@Injectable()
export class TokenInterceptor implements HttpInterceptor {

    constructor(private auth: IAuthServiceBase) { }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpSentEvent | HttpHeaderResponse | HttpProgressEvent | HttpResponse<any> | HttpUserEvent<any>> {
        req = req.clone({
            setHeaders: {
                [this.auth.header]: this.auth.getToken()
            }
        });
        
        return next.handle(req).do((error: HttpEvent<any>) => {
            if (error instanceof HttpErrorResponse) {
                if (error.status == HttpStatusCode.UnAuthorized) {
                    // meanwhile u can cast it to base model
                    // after that display an modal or error
                    // redirect to login or registation page
                }
            }
        });
    }
}