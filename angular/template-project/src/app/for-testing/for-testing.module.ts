import {NgModule} from '@angular/core';
import {ForTestingComponent} from './for-testing.component';
import {CommonModule} from '@angular/common';

@NgModule({
    declarations: [ForTestingComponent],
    imports: [
        CommonModule
    ],
    exports: [ForTestingComponent] // if component needs to be used in outside of module where defined, just add export component node.
})

export class ForTestingModule {

}