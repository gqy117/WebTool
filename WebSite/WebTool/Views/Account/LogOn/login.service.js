"use strict";
var M;
(function (M) {
    var loginService = (function () {
        // constructor
        function loginService($window) {
            this.$window = $window;
        }
        //  methods
        loginService.prototype.formLogOnSubmit = function () {
            this.$window.Track('LogOn', 'LogOn');
            this.$window.jQuery('#FormLogin').submit();
        };
        loginService.prototype.formLogOnPasswordKeyup = function ($event) {
            if ($event.keyCode === 13) {
                this.formLogOnSubmit();
            }
        };
        loginService.prototype.signUpNow = function () {
            this.$window.Track('LogOn', 'SignUpNow');
            this.$window.location.href = this.$window.App.baseUrl + 'Register/Index';
        };
        // inject
        loginService.$inject = ["$window"];
        return loginService;
    })();
    M.loginService = loginService;
    // init
    angular.module('mainApp')
        .service('loginService', loginService);
})(M || (M = {}));
