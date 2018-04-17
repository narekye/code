import {BaseService} from "../shared/base-service";
import {HttpClient} from '@angular/common/http';
import {Injectable, Inject} from "@angular/core";
import  {API_ENDPOINT} from '../shared/constants';

@Injectable()
export class ForTestingService extends BaseService {
    constructor(httpClient: HttpClient, @Inject(API_ENDPOINT) baseUrl: string) {
        super(httpClient, baseUrl);
    }

    public testGet() {
        this.HttpClient.get<any>(this.BaseUrl).subscribe((response: any) => {
        });
    }

    // service body...
}