import { NgModule } from "@angular/core";
import { RouterModule } from '@angular/router';
import { AppComponent } from "./app.component";
var appRoutes = [
    { path: '', component: AppComponent }
];
var AppRoutingModule = (function () {
    function AppRoutingModule() {
    }
    AppRoutingModule.decorators = [
        { type: NgModule, args: [{
                    imports: [RouterModule.forRoot(appRoutes)],
                    exports: [RouterModule]
                },] },
    ];
    return AppRoutingModule;
}());
export { AppRoutingModule };
