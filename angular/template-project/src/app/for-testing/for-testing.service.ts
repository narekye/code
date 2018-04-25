import { API_ENDPOINT } from './../shared/constants';
import { BaseService } from "../shared/base-service";
import { HttpClient } from '@angular/common/http';
import { Injectable, Inject } from "@angular/core";

@Injectable()
export class ForTestingService extends BaseService {
    constructor(httpClient: HttpClient, @Inject(API_ENDPOINT) baseUrl: string) {
        super(httpClient);
        this.BaseUrl = baseUrl;
    }

    public testGet() {
        this.HttpClient.get<any>(this.BaseUrl).subscribe((response: any) => {
            console.log(response);
        });
    }

    // service body...
}