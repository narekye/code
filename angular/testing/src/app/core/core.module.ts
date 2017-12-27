/**
 * Created by narek.yegoryan on 27/12/2017.
 */

import {NgModule} from "@angular/core";

import {HeaderComponent} from "./header/header.component";
import {HomeComponent} from "./home/home.component";
import {SharedModule} from "../shared/shared.module";
import {AppRoutingModule} from "../app-routing.module";
import {ShoppingListService} from "../shopping-list/shopping-list.service";
import {RecipeService} from "../recipes/recipe.service";
import {DataStorageService} from "../shared/data-storage.service";
import {AuthService} from "../auth/auth.service";
import {AuthGuard} from "../auth/auth-guard.service";

@NgModule({
  declarations: [
    HeaderComponent,
    HomeComponent
  ],
  imports: [
    SharedModule,
    AppRoutingModule
  ],
  exports: [
    AppRoutingModule,
    HeaderComponent
  ],
  providers: [
    ShoppingListService,
    RecipeService,
    DataStorageService,
    AuthService,
    AuthGuard
  ]
})
export class CoreModule {
}
