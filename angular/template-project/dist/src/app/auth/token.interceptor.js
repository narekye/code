import { HttpStatusCode } from '../shared/enums';
import { IAuthServiceBase } from './services/base-auth.service';
import { HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import 'rxjs/add/operator/do';
var TokenInterceptor = (function () {
    function TokenInterceptor(auth) {
        this.auth = auth;
    }
    TokenInterceptor.prototype.intercept = function (req, next) {
        req = req.clone({
            setHeaders: (_a = {},
                _a[this.auth.header] = this.auth.getTokenOrDefault(),
                _a)
        });
        return next.handle(req).do(function (event) {
        }, function (error) {
            if (error instanceof HttpErrorResponse) {
                var err = error;
                if (err.status == HttpStatusCode.UnAuthorized) {
                    alert("Pls login");
                }
            }
        });
        var _a;
    };
    TokenInterceptor.decorators = [
        { type: Injectable },
    ];
    /** @nocollapse */
    TokenInterceptor.ctorParameters = function () { return [
        { type: IAuthServiceBase, },
    ]; };
    return TokenInterceptor;
}());
export { TokenInterceptor };
