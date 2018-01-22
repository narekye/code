import {Component, OnInit} from '@angular/core';
import {ActivatedRoute, Router} from "@angular/router";

import {RecipeService} from './../recipe.service';
import {Recipe} from './../recipe.model';
import {OnDestroy} from '@angular/core/src/metadata/lifecycle_hooks';
import {Subscription} from 'rxjs/Subscription';
import {AuthService} from "../../auth/auth.service";

@Component({
  selector: 'app-recipe-list',
  templateUrl: './recipe-list.component.html',
  styleUrls: ['./recipe-list.component.css']
})
export class RecipeListComponent implements OnInit, OnDestroy {
  Subscription: Subscription;
  recipes: Recipe[];

  constructor(private recipeService: RecipeService, private router: Router,
              private route: ActivatedRoute) {
  }

  ngOnInit() {
    this.Subscription = this.recipeService.recipesChanged.subscribe((recipes: Recipe[]) => {
      this.recipes = recipes;
    });
    this.recipes = this.recipeService.getRecipes();
  }

  onNewRecipe() {
    this.router.navigate(['new'], {relativeTo: this.route});
  }

  ngOnDestroy() {
    this.Subscription.unsubscribe();
  }
}
