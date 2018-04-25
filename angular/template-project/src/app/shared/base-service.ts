import { API_ENDPOINT } from './constants';
import { HttpClient } from '@angular/common/http';
import { Injectable, Inject } from '@angular/core';


@Injectable()
export class BaseService {

    private _baseUrl: string;
    private _httpClient: HttpClient;

    constructor(httpClient: HttpClient) {
        this._httpClient = httpClient;
    }

    get BaseUrl(): string {
        return this._baseUrl;
    }
    set BaseUrl(value: string) {
        this._baseUrl = value;
    }

    get HttpClient(): HttpClient {
        return this._httpClient;
    }
}