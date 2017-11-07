import { Injectable } from '@angular/core';
import { Http } from '@angular/http'
import { LoginModel } from './models/loginMod';

@Injectable()
export class HttpProviderService {
  
  constructor(private http: Http) {

  }

  public static prepareRequest() {
    // TODO: 
  }

  sendRequest() {

  }
  
}
