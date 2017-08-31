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
        this.array = new Array<Contact>();
    }

    getContacts(): Contact[] {
        this._client.get(urls.baseUrl + urls.Contacts)
            .subscribe(
            (success) => {
                if (success === undefined || success === null) return;
                let json: any = JSON.parse(success["_body"]);
                for (let i in json) {
                    this.array.push(new Contact(json[i]));
                }
                return this.array;
            },
            (error) => {
                console.log(error);
            });
        return this.array;
    }

}