export class Constants {
    
    private static _apiKey: string = "API_ENDPOINT";

    public static get Api(): string {
        return this._apiKey;
    }
}