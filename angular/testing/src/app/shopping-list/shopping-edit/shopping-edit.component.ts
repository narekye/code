import { Component, OnInit, ElementRef, ViewChild, EventEmitter, Output } from '@angular/core';
// import { ElementRef } from '@angular/core/src/linker/element_ref';
import { Ingridient } from './../../shared/ingridient.model';


@Component({
  selector: 'app-shopping-edit',
  templateUrl: './shopping-edit.component.html',
  styleUrls: ['./shopping-edit.component.css']
})
export class ShoppingEditComponent implements OnInit {
  @ViewChild('nameInput') nameInputRef: ElementRef;
  @ViewChild('amountInput') amountInputRef: ElementRef;

  @Output() ingredientAdded = new EventEmitter<Ingridient>();
  constructor() { }

  ngOnInit() {
  }

  onAddItem() {
    const name = this.nameInputRef.nativeElement.value;
    const amount = this.amountInputRef.nativeElement.value;
    const newIngridient = new Ingridient
      (name, amount);
    this.ingredientAdded.emit(newIngridient);
  }
}
