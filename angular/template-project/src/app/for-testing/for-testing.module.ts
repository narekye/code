import { HttpClientModule } from '@angular/common/http';
import { ForTestingService } from './for-testing.service';
import {NgModule} from '@angular/core';
import {ForTestingComponent} from './for-testing.component';
import {CommonModule} from '@angular/common';

@NgModule({
    declarations: [ForTestingComponent],
    exports: [ForTestingComponent],
    providers: [ForTestingService]
     // if component needs to be used in outside of module where defined, just add export component node.
})

export class ForTestingModule {

}