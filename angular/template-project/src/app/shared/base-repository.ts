import { HttpClient } from '@angular/common/http';

export abstract class BaseRepository {

    private _baseUrl: string;
    private _httpClient: HttpClient;

    constructor(baseUrl: string, httpClient: HttpClient) {
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