import { Component } from '@angular/core';
import { Http } from "@angular/http"

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  constructor(private http: Http) {
    this.get();
  }
  data: any;
  get(): void {
    console.log("aaa");
    this.http.get("http://crmbetd.azurewebsites.net/api/contacts").subscribe(data => console.log(data), error => console.log(error));
  }
  title = 'app';
}
