import {CoreModule} from './core/core.module';
import {BrowserModule} from '@angular/platform-browser';
import {NgModule} from "@angular/core";
import {AppRoutingModule} from './app-routing.module';
import {AppComponent} from "./app.component";
import {ForTestingModule} from './for-testing/for-testing.module';

@NgModule({
    declarations: [AppComponent],
    imports: [
        ForTestingModule,
        BrowserModule,
        AppRoutingModule,
        CoreModule
    ],
    bootstrap: [AppComponent]
})
export class AppModule {

}