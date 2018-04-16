export class Constants {
    
    private static _apiKey: string = "API_ENDPOINT";

    public static get API_ENDPOINT(): string {
        return this._apiKey;
    }
}