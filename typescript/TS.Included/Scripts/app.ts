class Users {
	private userList: Array<User> = new Array<User>();

	load(): void {
		$.getJSON('http://localhost:3237/Home/GetAllUsers',
			(data) => {
				this.userList = data;
				alert('Data Loaded');

			});
	}

	displayUsers(): void {

		var table = '<table class="table">'
		for (var i = 0; i < this.userList.length; i++) {

			var tableRow = '<tr>' +
				'<td>' + this.userList[i].Id + '</td>' +
				'<td>' + this.userList[i].Name + '</td>' +
				'<td>' + this.userList[i].Age + '</td>' +
				'</tr>';
			table += tableRow;
		}
		table += '</table>';
		$('#content').html(table);
	}
}

class User {
	Id: number;
	Name: string;
	Age: number;
}

window.onload = () => {
	var userList: Users = new Users();
	$("#loadBtn").click(() => { userList.load(); });
	$("#displayBtn").click(() => { userList.displayUsers(); });
};