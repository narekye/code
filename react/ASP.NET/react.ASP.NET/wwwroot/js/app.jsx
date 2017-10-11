class Hello extends React.Component {
	render() {
		let t = fetch('http://crmbetd.azurewebsites.net/api/template', { method: "GET" }).then(function (resp) {
			console.log(resp);
			// let res = JSON.parse(resp);
			// console.log(res);
		});

		console.log(t);
		return (<h1> Hello react</h1>);
	}
}

ReactDOM.render(
	<Hello />,
	document.getElementById('content')
);