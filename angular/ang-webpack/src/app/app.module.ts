// core modules
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from "@angular/core";

// added modules
import { HomeComponent } from './home.component';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from "./app.component";


@NgModule({
    declarations: [AppComponent, HomeComponent],
    imports: [
        BrowserModule,
        AppRoutingModule
    ],
    providers: [],
    bootstrap: [
        AppComponent
    ]
})
export class AppModule {

}