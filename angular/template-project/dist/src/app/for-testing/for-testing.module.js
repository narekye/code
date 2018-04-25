import { NgModule } from '@angular/core';
import { ForTestingComponent } from './for-testing.component';
var ForTestingModule = (function () {
    function ForTestingModule() {
    }
    ForTestingModule.decorators = [
        { type: NgModule, args: [{
                    declarations: [ForTestingComponent],
                    exports: [ForTestingComponent]
                    // if component needs to be used in outside of module where defined, just add export component node.
                },] },
    ];
    return ForTestingModule;
}());
export { ForTestingModule };
