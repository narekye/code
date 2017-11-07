export class LoginModel {
    public username: string;
    public password: string;
    public grant_type: string = "grant_type";

    constructor(username: string, password: string) {
        this.username = username;
        this.password = password;
    }
}