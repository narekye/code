var Users = (function () {
    function Users() {
        this.userList = new Array();
    }
    Users.prototype.load = function () {
        var _this = this;
        $.getJSON('http://localhost:3237/Home/GetAllUsers', function (data) {
            _this.userList = data;
            alert('Data Loaded');
        });
    };
    Users.prototype.displayUsers = function () {
        var table = '<table class="table">';
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
    };
    return Users;
}());
var User = (function () {
    function User() {
    }
    return User;
}());
window.onload = function () {
    var userList = new Users();
    $("#loadBtn").click(function () { userList.load(); });
    $("#displayBtn").click(function () { userList.displayUsers(); });
};
//# sourceMappingURL=app.js.map