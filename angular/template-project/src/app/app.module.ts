import { SharedModule } from './shared/shared.module'
import { HttpClientModule } from '@angular/common/http';
import { BaseService } from './shared/base-service';
import {BrowserModule} from '@angular/platform-browser';
import {NgModule} from "@angular/core";
import {AppRoutingModule} from './app-routing.module';
import {AppComponent} from "./app.component";
import {ForTestingModule} from './for-testing/for-testing.module';
import { AuthModule } from './auth/auth.module';

@NgModule({
    declarations: [AppComponent],
    imports: [
        ForTestingModule,
        BrowserModule,
        AppRoutingModule,
        SharedModule,
        AuthModule
    ],
    bootstrap: [AppComponent]
})
export class AppModule {

}