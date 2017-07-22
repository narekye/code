class User implements IUser {
	// implementation
	public getinfo() {}
	public setinfo() {}
	public id: number;

	// let lambda: (x: number, y: number) => number;
}

function Add(first: number, second?: string): void {
	var user = new User();
}

let lambda: (x: number, y: number) => number;

abstract class Prime extends  User {
	constructor() {
		super();
		lambda = function (x: number, y: number): number {
			if (this.isPrototypeOf(Object)) {
				let user: IUser = new User();
			}
			return x + y;
		}
	}
}