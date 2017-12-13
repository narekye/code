import {ShoppingListService} from './../shopping-list/shopping-list.service';
import {Ingridient} from './../shared/ingridient.model';
import {EventEmitter, Injectable} from '@angular/core';
import {Recipe} from './recipe.model';

@Injectable()
export class RecipeService {
  public recipeSelected = new EventEmitter<Recipe>();
  private recipes: Recipe[] = [
    new Recipe(
      'Tasty Schnitzel',
      'Just awesome',
      'http://www.seriouseats.com/recipes/assets_c/2016/05/20160503-fava-carrot-ricotta-salad-recipe-1-thumb-1500xauto-431710.jpg',
      [new Ingridient('Meat', 1),
        new Ingridient('French fries', 20)]),
    new Recipe(
      'Big fat burger',
      'What else need to say?',
      'https://d36wnpk9e3wo84.cloudfront.net/menu-item-images/400/web-butter-burger-deluxe-double.jpg',
      [new Ingridient('Meat', 3),
        new Ingridient('Buns', 2)])
  ];

  constructor(private slService: ShoppingListService) {
  }

  public getRecipes(): Recipe[] {
    return this.recipes.slice(); // get copy
  }

  public addIngredientsToShoppingList(ingedients: Ingridient[]) {
    this.slService.addIngredients(ingedients);
  }

  public getRecipe(index: number) {
      return this.recipes[index];
  }
}
