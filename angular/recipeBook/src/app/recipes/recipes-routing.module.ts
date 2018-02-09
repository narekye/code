import {NgModule} from "@angular/core";
import {Routes, RouterModule} from "@angular/router";

import {RecipesComponent} from "./recipes.component";
import {RecipeStartComponent} from "./recipe-start/recipe-start.component";
import {RecipeEditComponent} from "./recipe-edit/recipe-edit.component";
import {RecipeDetailComponent} from "./recipe-detail/recipe-detail.component";
import {AuthGuard} from "../auth/auth-guard.service";

const recipeRoutes: Routes = [
  {
    path: '', component: RecipesComponent,
    children: [
      {path: '', component: RecipeStartComponent}, // recipe/
      {path: 'new', component: RecipeEditComponent, canActivate: [AuthGuard]}, // recipe/new
      {path: ':id', component: RecipeDetailComponent}, // recipe/1
      {path: ':id/edit', component: RecipeEditComponent, canActivate: [AuthGuard]} // recipe/1/edit
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(recipeRoutes)],
  exports: [RouterModule],
  providers: [AuthGuard]
})
export class RecipesRoutingModule {

}
