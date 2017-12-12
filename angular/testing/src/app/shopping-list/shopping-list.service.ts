import { EventEmitter } from '@angular/core';
import { Ingridient } from './../shared/ingridient.model';

export class ShoppingListService {
    ingredientsChanged = new EventEmitter<Ingridient[]>()
    private ingredients: Ingridient[] = [
        new Ingridient('Apples', 5),
        new Ingridient('Tommatoos', 10)
    ];

    public getIngredients(): Ingridient[] {
        return this.ingredients.slice();
    }

    public addIngredient(ingredient: Ingridient) {
        this.ingredients.push(ingredient);
        this.ingredientsChanged.emit(this.ingredients.slice());
    }

    public addIngredients(ingredients: Ingridient[]) {
        // for (let ingredient of ingredients) {
        //     this.addIngredient(ingredient);
        // }
        // many events

        this.ingredients.push(...ingredients);
        this.ingredientsChanged.emit(this.ingredients.slice());
        console.log('end');
    }
}