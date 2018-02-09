import { Component } from "@angular/core";

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})
export class AppComponent {

    constructor() {
        console.log(OperationKindEnum.ADD_PLAYER as number);
    }


}

export enum OperationKindEnum {
    ADD_PLAYER = 0,
    REMOVE_PLAYER = 1
}