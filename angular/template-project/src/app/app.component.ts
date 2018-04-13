import { HttpModule, Http } from '@angular/http';
import { Component } from "@angular/core";
import { Response } from '@angular/http';
import 'rxjs/Rx';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})

export class AppComponent {
    constructor(private http: Http) {
        this.http.get('https://jsonplaceholder.typicode.com/posts/1').map((response: Response) => {
            return ""; 
        }).subscribe((result: string) /* depends on the type of returning map function */ => { });
    }
}