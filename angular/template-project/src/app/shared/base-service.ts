import { HttpClient } from '@angular/common/http';
import { Injectable, Inject } from '@angular/core';
import { Constants } from './constants';

@Injectable()
export abstract class BaseService {

    private _baseUrl: string;
    private _httpClient: HttpClient;

    constructor(httpClient: HttpClient, baseUrl?: string) {
        this._baseUrl = baseUrl;
        this._httpClient = httpClient;
    }

    get BaseUrl():string {
        return this._baseUrl;
    }

    get HttpClient():HttpClient {
        return this._httpClient;
    }
}