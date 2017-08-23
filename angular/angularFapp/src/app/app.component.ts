import { Component } from "@angular/core";
import { Http } from "@angular/http";
import { User } from "./Models/User";
// import data from '../assets/data.js';
import { HttpService } from "../helpers/httpService";
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  providers: [HttpService]
})
export class AppComponent {


  private service: HttpService;
  constructor(service: HttpService) {
    this.service = service;
    this.get()
  }
  public users: User[] = [new User("a", "b"), new User("c", "d")];
  get(): void {
    let t = this.service.getContacts();
    // console.log(t);
    
  }
  title = 'app';
}