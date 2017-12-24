import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { RecipeService } from '../recipes/recipe.service';
import 'rxjs/Rx';
import { Recipe } from '../recipes/recipe.model';

const baseUrl = 'https://recipe-book-66513.firebaseio.com/';

@Injectable()
export class DataStorageService {
    constructor(private http: Http, private recipeService: RecipeService) { }

    // tslint:disable-next-line:no-shadowed-variable
    storeRecipes() {
        return this.http.put('https://recipe-book-66513.firebaseio.com/recipes.json', this.recipeService.getRecipes());
    }

    getRecipes() {
        this.http.get('https://recipe-book-66513.firebaseio.com/recipes.json')
            .map(
            (response: Response) => {
                const recipes = response.json();
                for (let recipe of recipes) {
                    if (!recipe['ingredients']) {
                        recipe['ingredients'] = [];
                    }
                }
                return recipes;
            })
            .subscribe(
                (recipes: Recipe[]) => {
                this.recipeService.setRecipes(recipes);
            });
    }
}
