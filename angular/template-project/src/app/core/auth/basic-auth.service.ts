import { IAuthServiceBase } from './base-auth.service';
import { Injectable } from '@angular/core';

export class BasicAuthService implements IAuthServiceBase {
    header: string = "Authentication";
    getToken(): string {
        return "";
    }
}