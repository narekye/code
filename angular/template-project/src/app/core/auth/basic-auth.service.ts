import { IAuthServiceBase } from './base-auth.service';

export class BasicAuthService implements IAuthServiceBase {
    header: string = "Authentication";
    public getToken(): string {
        return "";
    }
}