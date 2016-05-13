var M;
(function (M) {
    "use strict";
    var loginController = (function () {
        // constructor
        function loginController(loginService, $window) {
            this.loginService = loginService;
            this.$window = $window;
            angular.element(document).ready(function () {
                $window.App.initLogin();
            });
        }
        //  methods
        loginController.prototype.formLogOnSubmit = function () {
            this.loginService.formLogOnSubmit();
        };
        loginController.prototype.formLogOnPasswordKeyup = function ($event) {
            this.loginService.formLogOnPasswordKeyup($event);
        };
        loginController.prototype.signUpNow = function () {
            this.loginService.signUpNow();
        };
        // inject
        loginController.$inject = ["loginService", "$window"];
        return loginController;
    }());
    M.loginController = loginController;
    // init
    angular.module("mainApp")
        .controller("loginController", loginController);
})(M || (M = {}));
