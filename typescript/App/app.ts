class Greeter {
    element: HTMLElement;
    span: HTMLElement;
    timerToken: number;

    constructor(element: HTMLElement) {
        this.element = element;
        this.element.innerHTML += "The time is: ";
        this.span = document.createElement('span');
        this.element.appendChild(this.span);
        this.span.innerText = new Date().toUTCString();
    }

    start() {
        this.timerToken = setInterval(() => this.span.innerHTML = new Date().toUTCString(), 500);
		var request = new XMLHttpRequest();
		request.open('GET', 'URL', true);

		if (request.status === 200) {
			var element = document.getElementById('content');
			var result = request.response;
			var json = JSON.stringify(result);
			alert(typeof json);
			element.innerHTML = '<h1>' + json + '</h1>';
		}
    }
	
    stop() {
        clearTimeout(this.timerToken);
    }

}

window.onload = () => {
    var el = document.getElementById('content');
    var greeter = new Greeter(el);
    greeter.start();
};