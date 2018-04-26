import {NgModule} from "@angular/core";
import {Routes, RouterModule} from '@angular/router';
import { AppComponent } from "./app.component";
import { ForTestingComponent } from "./for-testing/for-testing.component";


const appRoutes: Routes = [
    // {path: '', redirectTo: 'signin', pathMatch: 'full'}
];

@NgModule({
    imports: [RouterModule.forRoot(appRoutes)],
    exports: [RouterModule]
})

export class AppRoutingModule {
}