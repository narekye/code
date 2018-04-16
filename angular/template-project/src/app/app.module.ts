import { HttpClient, HttpClientModule } from '@angular/common/http';
import { CoreModule } from './core/core.module';

// core modules
import { HttpModule } from '@angular/http';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from "@angular/core";

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from "./app.component";
import { ForTestingModule } from './for-testing/for-testing.module';

@NgModule({
    declarations: [AppComponent],
    imports: [
        ForTestingModule,
        BrowserModule,
        AppRoutingModule,
        CoreModule
    ],
    providers: [
    ],
    bootstrap: [
        AppComponent
    ]
})
export class AppModule {

}