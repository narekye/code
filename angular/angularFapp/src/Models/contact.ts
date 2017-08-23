export class Contact {
    constructor(object: any) {
        if (object === null) return;
        this.fullName = object["Full Name"];
        this.companyName = object["Company Name"];
        this.guid = object["GuID"];
        this.country = object["Country"];
        this.position = object["Position"];
        this.email = object["Email"];
    }
    public fullName: string;
    public companyName: string;
    public guid: string;
    public position: string;
    public country: string;
    public email: string;
}