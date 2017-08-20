import {Component} from "@angular/core";
import {Http} from "@angular/http";
import {User} from "./Models/Models";

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
  public flag: boolean = true;
  public users: User[] = [new User("a", "b"), new User("c", "d")];

  // data: any;
  // private lastname: any;

  get(): void {
    // console.log("aaa");
    this.connection.get("http://crmbetd.azurewebsites.net/api/contacts").subscribe(data => console.log(data), error => console.log(error));
    // let users: User[];
    // this.users = ;
  }


  title = 'app';
}
