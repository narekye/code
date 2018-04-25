var BasicAuthService = (function () {
    function BasicAuthService() {
        this.header = "Authentication";
    }
    BasicAuthService.prototype.getTokenOrDefault = function () {
        return "";
    };
    return BasicAuthService;
}());
export { BasicAuthService };
