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

    signIn() {
        this.route.navigate(['signin'], { relativeTo: this.activeRoute })
    }

    signUp() {
        this.route.navigate(['signup'], { relativeTo: this.activeRoute });
    }
}