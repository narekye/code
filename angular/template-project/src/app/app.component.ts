import { ActivatedRoute } from '@angular/router';

import { Router } from '@angular/router';
import { Component } from "@angular/core";

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})

export class AppComponent {
    constructor(private route: Router, private activeRoute: ActivatedRoute) {

    }

    click() {
        this.route.navigate(['signin'], { relativeTo: this.activeRoute })
    }
}