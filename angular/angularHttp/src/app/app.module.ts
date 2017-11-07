import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { DataTablesModule } from 'angular-datatables';
import { HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { AppComponent } from './app.component';
import { ComponentMyComponent } from './component-my/component-my.component';
import { LoginComponent } from './login/login.component';
import { HttpProviderService } from './http-provider.service';
import { LoginModel } from './models/loginMod';
@NgModule({
  declarations: [
    AppComponent,
    ComponentMyComponent,
    LoginComponent,
    LoginModel
  ],
  imports: [
    BrowserModule,
    DataTablesModule,
    HttpClientModule,
    CommonModule
  ],
  providers: [HttpProviderService],
  bootstrap: [AppComponent]
})
export class AppModule { }
