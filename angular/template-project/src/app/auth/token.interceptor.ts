import {HttpStatusCode} from '../shared/enums';
import { IAuthServiceBase } from './services/base-auth.service';

import {
    HttpInterceptor,
    HttpHandler,
    HttpRequest,
    HttpSentEvent,
    HttpHeaderResponse,
    HttpProgressEvent,
    HttpResponse,
    HttpUserEvent,
    HttpEvent,
    HttpErrorResponse, HttpEventType
} from '@angular/common/http';

import {Injectable} from '@angular/core';
import {Observable} from 'rxjs/Observable';
import 'rxjs/add/operator/do';


@Injectable()
export class TokenInterceptor implements HttpInterceptor {

    constructor(private auth: IAuthServiceBase) {

    }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpSentEvent | HttpHeaderResponse | HttpProgressEvent | HttpResponse<any> | HttpUserEvent<any>> {
        req = req.clone({
            setHeaders: {
                [this.auth.header]: this.auth.getTokenOrDefault()
            }
        });

        return next.handle(req).do((event: HttpEvent<any>) => {

        }, (error: any) => {
            if (error instanceof HttpErrorResponse) {
                let err = error as HttpErrorResponse;
                if (err.status == HttpStatusCode.UnAuthorized) {
                    alert("Pls login");
                }
            }
        });
    }
}