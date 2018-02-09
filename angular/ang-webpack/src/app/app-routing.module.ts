import { NgModule } from "@angular/core";
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home.component';

const appRoutes: Routes = [
    { path: '', component: HomeComponent },
    // { path: 'someUrl', loadChildren: 'someModule' } // ;azy
];

@NgModule({
    imports: [RouterModule.forRoot(appRoutes)],
    exports: [RouterModule]
})

export class AppRoutingModule { }