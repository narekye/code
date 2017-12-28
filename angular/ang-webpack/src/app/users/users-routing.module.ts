import { RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { UsersComponent } from './users.component';

@NgModule({
    imports: [RouterModule.forChild([{path: '', component: UsersComponent}])],
    exports: [RouterModule]
})
export class UsersRoutingModule {

}