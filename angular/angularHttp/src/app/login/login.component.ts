import { Component, OnInit } from '@angular/core';
import { LoginModel } from '../models/loginMod';
import { HttpProviderService } from '../http-provider.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})

export class LoginComponent implements OnInit {
  public username: string;
  public password: string;

  types = [{
    'name': "a",
    "value": 1
  }];

  type: {};

  constructor() { }

  ngOnInit() {
  }

  login() {
    if (this.username === undefined || this.password === undefined) {
      alert("Please type in fields correct information");
    }
    var user = new LoginModel(this.username, this.password);

  }

  print() {
    console.log(this.type);
  }

}
