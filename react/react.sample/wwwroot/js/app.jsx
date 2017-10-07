// A '.tsx' file enables JSX support in the TypeScript compiler, 
// for more information see the following page on the TypeScript wiki:
// https://github.com/Microsoft/TypeScript/wiki/JSX


class Hello extends React.Component {
	render() {
		return (<h1>Hello world </h1>);
	}
}

ReactDOM.render(
	<Hello />,
	document.getElementById("content")
);