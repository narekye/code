import { SharedModule } from './shared/shared.module';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from "@angular/core";
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from "./app.component";
import { ForTestingModule } from './for-testing/for-testing.module';
import { AuthModule } from './auth/auth.module';
var AppModule = (function () {
    function AppModule() {
    }
    AppModule.decorators = [
        { type: NgModule, args: [{
                    declarations: [AppComponent],
                    imports: [
                        ForTestingModule,
                        BrowserModule,
                        AppRoutingModule,
                        SharedModule,
                        AuthModule
                    ],
                    bootstrap: [AppComponent]
                },] },
    ];
    return AppModule;
}());
export { AppModule };
