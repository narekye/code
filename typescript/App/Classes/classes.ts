namespace Classes {
	class Operation {
		static name: number = 3.14;

		field: number;

		getField(): number {
			return this.field;
		}

		setField(field: number): void {
			this.field = field;
		}
	}



	class SecondOPeration extends Operation {
		// @override
		getField(): number { return super.getField(); }
		// @override
		setField(field: number): void { super.setField(field); }
	}
}