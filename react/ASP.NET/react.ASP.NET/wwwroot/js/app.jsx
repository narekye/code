﻿class Hello extends React.Component {
	render() {
		return (<h1> Hello react</h1>);
	}
}

ReactDOM.render(
	<Hello />,
	document.getElementById('content')
);