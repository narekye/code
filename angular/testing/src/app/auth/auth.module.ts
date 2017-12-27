/**
 * Created by narek.yegoryan on 27/12/2017.
 */

import {NgModule} from "@angular/core";
import {SigninComponent} from "./signin/signin.component";
import {SignupComponent} from "./signup/signup.component";
import {FormsModule} from "@angular/forms";
import {AuthRoutingModule} from "./auth-routing.module";

@NgModule({
  declarations: [
    SigninComponent,
    SignupComponent
  ],
  imports: [
    FormsModule,
    AuthRoutingModule
  ]
})

export class AuthModule {

}
