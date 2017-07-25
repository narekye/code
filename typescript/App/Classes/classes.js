var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var Classes;
(function (Classes) {
    var Operation = (function () {
        function Operation() {
        }
        Operation.prototype.getField = function () {
            return this.field;
        };
        Operation.prototype.setField = function (field) {
            this.field = field;
        };
        return Operation;
    }());
    Operation.name = 3.14;
    var SecondOPeration = (function (_super) {
        __extends(SecondOPeration, _super);
        function SecondOPeration() {
            return _super !== null && _super.apply(this, arguments) || this;
        }
        // @override
        SecondOPeration.prototype.getField = function () { return _super.prototype.getField.call(this); };
        // @override
        SecondOPeration.prototype.setField = function (field) { _super.prototype.setField.call(this, field); };
        return SecondOPeration;
    }(Operation));
})(Classes || (Classes = {}));
//# sourceMappingURL=classes.js.map