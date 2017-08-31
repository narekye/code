import { Component } from "@angular/core";
import { Http } from "@angular/http";
import { User } from "./Models/User";
import { Contact } from "../Models/contact";
import { HttpService } from "../helpers/httpService";
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  providers: [HttpService]
})
export class AppComponent {
  private service: HttpService;
  // data: Array<Contact>;
  constructor(service: HttpService) {
    this.service = service;
  }
  get(): Array<Contact> {
    let array = this.service.getContacts();
    return array;
  };
  title = 'app';
  data: Contact[];
  ngOnInit() {
    this.data = this.get();
  }
}