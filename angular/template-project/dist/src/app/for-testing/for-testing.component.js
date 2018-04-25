import { Component } from '@angular/core';
import { ForTestingService } from './for-testing.service';
var ForTestingComponent = (function () {
    function ForTestingComponent(fsService) {
        // get service
        this._fsService = fsService;
    }
    ForTestingComponent.prototype.ngOnInit = function () {
        this._fsService.testGet();
    };
    ForTestingComponent.decorators = [
        { type: Component, args: [{
                    selector: 'for-testing',
                    templateUrl: './for-testing.component.html'
                },] },
    ];
    // component body...
    /** @nocollapse */
    ForTestingComponent.ctorParameters = function () { return [
        { type: ForTestingService, },
    ]; };
    return ForTestingComponent;
}());
export { ForTestingComponent };
