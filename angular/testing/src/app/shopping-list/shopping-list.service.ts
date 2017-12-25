import { Ingridient } from './../shared/ingridient.model';
import {Subject} from "rxjs/Subject";

export class ShoppingListService {
    ingredientsChanged = new Subject<Ingridient[]>()
    private ingredients: Ingridient[] = [
        new Ingridient('Apples', 5),
        new Ingridient('Tomatoes', 10)
    ];

    public getIngredients(): Ingridient[] {
        return this.ingredients.slice();
    }

    public addIngredient(ingredient: Ingridient) {
        this.ingredients.push(ingredient);
        this.ingredientsChanged.next(this.ingredients.slice());
    }

    public addIngredients(ingredients: Ingridient[]) {
        // for (let ingredient of ingredients) {
        //     this.addIngredient(ingredient);
        // }
        // many events

        this.ingredients.push(...ingredients);
        this.ingredientsChanged.next(this.ingredients.slice());
    }
}
