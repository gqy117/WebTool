var M;
(function (M) {
    "use strict";
    var loginService = (function () {
        // constructor
        function loginService($window, jQuery, gaService) {
            this.$window = $window;
            this.jQuery = jQuery;
            this.gaService = gaService;
        }
        //  methods
        loginService.prototype.formLogOnSubmit = function () {
            this.gaService.Track("LogOn", "LogOn");
            this.jQuery("#FormLogin").submit();
        };
        loginService.prototype.formLogOnPasswordKeyup = function ($event) {
            if ($event.keyCode === 13) {
                this.formLogOnSubmit();
            }
        };
        loginService.prototype.signUpNow = function () {
            this.gaService.Track("LogOn", "SignUpNow");
            this.$window.location.href = this.$window.App.baseUrl + "Register/Index";
        };
        // inject
        loginService.$inject = ["$window", "jQuery", "gaService"];
        return loginService;
    }());
    M.loginService = loginService;
    // init
    angular.module("mainApp")
        .service("loginService", loginService);
})(M || (M = {}));
