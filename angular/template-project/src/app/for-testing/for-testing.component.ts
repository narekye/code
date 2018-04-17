import {Component, OnInit} from '@angular/core';
import {ForTestingService} from './for-testing.service';

@Component({
    selector: 'for-testing',
    templateUrl: './for-testing.component.html'
})

export class ForTestingComponent implements OnInit {

    private _fsService: ForTestingService;

    ngOnInit(): void {
        this._fsService.testGet();
    }

    constructor(fsService: ForTestingService) {
        // get service
        this._fsService = fsService;
    }

    // component body...
}
