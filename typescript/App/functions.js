var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var User = (function () {
    function User() {
    }
    // implementation
    User.prototype.getinfo = function () { };
    User.prototype.setinfo = function () { };
    return User;
}());
function Add(first, second) {
    var user = new User();
}
var lambda;
var Prime = (function (_super) {
    __extends(Prime, _super);
    function Prime() {
        _super.call(this);
        lambda = function (x, y) {
            if (this.isPrototypeOf(Object)) {
                var user = new User();
            }
            return x + y;
        };
    }
    return Prime;
}(User));
//# sourceMappingURL=functions.js.map