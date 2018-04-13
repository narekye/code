import { HttpModule, Http } from '@angular/http';
import { Component } from "@angular/core";
import { HttpClient } from '@angular/common/http'
import { Response } from '@angular/http';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})

export class AppComponent {
    constructor(private http: HttpClient) {
        this.http.get('https://jsonplaceholder.typicode.com/posts/1').subscribe((response: Response) => { });
    }
}