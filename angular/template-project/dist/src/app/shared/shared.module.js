import { BaseService } from './base-service';
import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
var SharedModule = (function () {
    function SharedModule() {
    }
    SharedModule.decorators = [
        { type: NgModule, args: [{
                    imports: [HttpClientModule],
                    providers: [BaseService]
                },] },
    ];
    return SharedModule;
}());
export { SharedModule };
