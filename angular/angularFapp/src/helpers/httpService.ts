import { Http } from "@angular/http";
import { Contact } from "../Models/Contact";
import urls from '../assets/data.js';
import { Injectable } from "@angular/core";
import "rxjs/add/operator/map";
@Injectable()
export class HttpService {
    private _client: Http;
    private array: Contact[];
    constructor(public http: Http) {
        this._client = http;
    }

    getContacts(): Contact[] {
        // let array: Array<Contact>;
        let data = this._client.get(urls.baseUrl + urls.Contacts)
            .subscribe(
            (success) => {
                let json: any = JSON.parse(success["_body"]);
                let array = new Array<Contact>();
                for (let i in json) {
                    this.array[i] = new Contact(json[i]);
                    
                }
                return array;
                // console.log(this.array);
            },
            (error) => {
                console.log(error);
                console.log("sorry");
            });
        console.log(this.array);
        // return data.unsubscribe;
        return null;
    }

}