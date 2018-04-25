import { BaseService } from './base-service';
import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';

@NgModule({
    imports: [HttpClientModule],
    providers: [BaseService]
})
export class SharedModule {

}