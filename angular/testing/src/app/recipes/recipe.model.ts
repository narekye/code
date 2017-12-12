import { Ingridient } from './../shared/ingridient.model';

export class Recipe {
    public name: string;
    public description: string;
    public imagePath: string;
    public ingredients: Ingridient[];

    constructor(name: string, description: string, imagePath: string, ingredients: Ingridient[]) {
        this.name = name;
        this.description = description;
        this.imagePath = imagePath;
        this.ingredients = ingredients;
    }
}
