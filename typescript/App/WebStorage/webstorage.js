"use strict";
var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var StorageMy = (function (_super) {
    __extends(StorageMy, _super);
    function StorageMy() {
        return _super.call(this) || this;
    }
    StorageMy.prototype.setlocal = function (key, value, stringify) {
        if (stringify) {
            var temp = value;
            value = JSON.stringify(temp);
        }
        localStorage.setItem(key, value);
    };
    StorageMy.prototype.getlocal = function (key) {
        return localStorage.getItem(key);
    };
    StorageMy.prototype.setsession = function (key, value, stringify) {
        if (stringify) {
            var temp = value;
            sessionStorage.setItem(key, JSON.stringify(temp));
        }
        sessionStorage.setItem(key, value);
    };
    return StorageMy;
}(Object));
exports.StorageMy = StorageMy;
//# sourceMappingURL=webstorage.js.map