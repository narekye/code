export class IAuthServiceBase {
    header: string;

    getToken(): string {
        return "";
    }
}