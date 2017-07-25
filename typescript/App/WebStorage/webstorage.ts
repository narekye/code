export class StorageMy extends Object {
	constructor() {
		super();
	}
	setlocal(key: string, value: any, stringify?: boolean): void {
		if (stringify) {
			var temp = value;
			value = JSON.stringify(temp);
		}
		localStorage.setItem(key, value);
	}
	getlocal(key: string): any {
		return localStorage.getItem(key);
	}
	setsession(key: string, value: any, stringify?: boolean): void {
		if (stringify) {
			var temp = value;
			sessionStorage.setItem(key, JSON.stringify(temp));
		}
		sessionStorage.setItem(key, value);
	}
}