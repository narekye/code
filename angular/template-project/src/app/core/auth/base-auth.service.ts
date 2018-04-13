export interface IAuthServiceBase {
    header : string;
    getToken(): string;
}