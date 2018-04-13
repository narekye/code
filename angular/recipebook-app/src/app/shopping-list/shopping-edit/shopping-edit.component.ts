import { ShoppingListService } from './../shopping-list.service';
import { Component, OnInit, ViewChild } from '@angular/core';
import { Ingridient } from './../../shared/ingridient.model';
import { NgForm } from '@angular/forms';
import { Subscription } from 'rxjs/Subscription';
import { OnDestroy } from '@angular/core/src/metadata/lifecycle_hooks';


@Component({
  selector: 'app-shopping-edit',
  templateUrl: './shopping-edit.component.html',
  styleUrls: ['./shopping-edit.component.css']
})
export class ShoppingEditComponent implements OnInit, OnDestroy {

  @ViewChild('fo') slForm: NgForm;
  subscription: Subscription;
  editMode: Boolean = false;
  editedItemIndex: number;
  editedItem: Ingridient;
  constructor(private slService: ShoppingListService) { }

  ngOnInit() {
    this.subscription = this.slService.startedEditing.subscribe(
      (value: number) => {
        this.editedItemIndex = value;
        this.editMode = true;
        this.editedItem = this.slService.getIngredient(value);
        this.slForm.setValue({
          name: this.editedItem.name,
          amount: this.editedItem.amount
        });
      }
    );
  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }

  onClear() {
    this.slForm.reset();
    this.editMode = false;
  }

  onDelete () {
    this.onClear();
    console.log(this.editedItemIndex);
    this.slService.removeIngredient(this.editedItemIndex);
  }

  onSubmit(form: NgForm) {
    const value = form.value;
    const newIngridient = new Ingridient(value.name, value.amount);
    if (this.editMode) {
      this.slService.updateIngredient(this.editedItemIndex, newIngridient);
    }
    else {
      this.slService.addIngredient(newIngridient);
    }
    this.editMode = false;
    this.slForm.reset();
  }
}
