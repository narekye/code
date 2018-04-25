import { API_ENDPOINT } from './constants';
import { HttpClient } from '@angular/common/http';
import { Injectable, Inject } from '@angular/core';
var BaseService = (function () {
    function BaseService(httpClient) {
        this._httpClient = httpClient;
        var url = Inject(API_ENDPOINT);
    }
    Object.defineProperty(BaseService.prototype, "BaseUrl", {
        get: function () {
            return this._baseUrl;
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(BaseService.prototype, "HttpClient", {
        get: function () {
            return this._httpClient;
        },
        enumerable: true,
        configurable: true
    });
    BaseService.decorators = [
        { type: Injectable },
    ];
    /** @nocollapse */
    BaseService.ctorParameters = function () { return [
        { type: HttpClient, },
    ]; };
    return BaseService;
}());
export { BaseService };
