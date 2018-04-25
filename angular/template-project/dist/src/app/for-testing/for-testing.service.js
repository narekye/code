var __extends = (this && this.__extends) || (function () {
    var extendStatics = Object.setPrototypeOf ||
        ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
        function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
import { BaseService } from "../shared/base-service";
import { HttpClient } from '@angular/common/http';
import { Injectable, Inject } from "@angular/core";
import { API_ENDPOINT } from '../shared/constants';
var ForTestingService = (function (_super) {
    __extends(ForTestingService, _super);
    function ForTestingService(httpClient, baseUrl) {
        return _super.call(this, httpClient) || this;
    }
    ForTestingService.prototype.testGet = function () {
        this.HttpClient.get(this.BaseUrl).subscribe(function (response) {
            console.log(response);
        });
    };
    ForTestingService.decorators = [
        { type: Injectable },
    ];
    // service body...
    /** @nocollapse */
    ForTestingService.ctorParameters = function () { return [
        { type: HttpClient, },
        { type: undefined, decorators: [{ type: Inject, args: [API_ENDPOINT,] },] },
    ]; };
    return ForTestingService;
}(BaseService));
export { ForTestingService };
