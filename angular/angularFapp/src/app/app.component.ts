import {Component} from "@angular/core";
import {Http} from "@angular/http";
import {User} from "./Models/User";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  // fields
  private connection: Http;
  constructor(http: Http) {
    this.connection = http;
    this.get();
  }
  public users: User[] = [new User("a", "b"), new User("c", "d")];
  get(): void {
    this.connection.get("http://crmbetd.azurewebsites.net/api/contacts").subscribe(data => console.log(data), error => console.log(error));
  }
  title = 'app';
}
