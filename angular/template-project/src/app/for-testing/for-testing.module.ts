import {NgModule} from '@angular/core';
import {ForTestingComponent} from './for-testing.component';
import {CommonModule} from '@angular/common';

@NgModule({
    declarations: [ForTestingComponent],
    imports: [
        CommonModule
    ],
    exports: [ForTestingComponent] // if component needs to be used in app component, just addd export component node.
})

export class ForTestingModule {

}