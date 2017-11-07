'use strict';
import { Component, Output, EventEmitter } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { DataTablesModule } from 'angular-datatables';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import 'rxjs/Rx';
import { Observable } from 'rxjs/Rx';
// import { LoginComponent } from '../app/login/login.component';import  '../app/login/login.component.css';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent {
  public data: Array<object> = new Array<object>();
  public flag: boolean;
  public asa: string;
  constructor(private http: HttpClient) {

  }

  @Output() fla = new EventEmitter();



  changeFlag() {
    this.flag = !this.flag;
    // this.fla.emit(this.flag);
    this.asa = "anjataca";
  }
  ngOnInit() {
    // var header = new HttpHeaders().set('Authentication', 'wl_hDS_k83L9D_vGHfeb40YU7MZI0RXEhBNFke3JMq_Fycp0Kqb3_C1o-IIMrcSxiRfLyXSwyUqryxK7V6eObWA6s_LwSNa7HTOwN25j-TwrDQ9yPKkKmyAb1d4TLClpoQibZhP0WzNN1kOAfrTc-vOl-15tu77OuKvYDtAMUCert06l85Es57OgOAemXcy4RtQfwLoxQ8mC6wDISuzDBlTzsgHz_gAXv06HDDdrcMr2XIXKJRwX4GYMxHTtJ8ZZVKi4YXAhDdokQoI_Ganq0h5CeyUHNuFsollyapxFd3Sf1EyZBvVUHwhHX8DQNa_Z');
    this.flag = true;
    this.http.get('http://jsonplaceholder.typicode.com/posts/1').subscribe((res: Response) => {
      console.log(res);
      this.data.push(res);
      this.flag = false;
      this.asa = "miacaca";
    })
  }

  login() {
    let body = {
      grant_type: 'password',
      username: 'narekye',
      password: 'Anlegala88%2B'
    };

    let headers = new HttpHeaders()
      .set('Content-Type', 'x-www-from-urlencoded')
      .set('Access-Control-Allow-Origin', '*')
      .set('Postman-Token', '731b0a79-e4e7-818a-43c0-e19d7e3d2c4b');
    this.http.post("http://crmbetd.azurewebsites.net/api/token", body, {
      headers: headers
    }
    ).subscribe((res: Response) => {
      console.log(res);
    });
  }
  title = 'app';
}