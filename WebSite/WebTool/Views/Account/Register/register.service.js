var M;
(function (M) {
    "use strict";
    var registerService = (function () {
        // constructor
        function registerService($window, jQuery, gaService) {
            this.$window = $window;
            this.jQuery = jQuery;
            this.gaService = gaService;
        }
        // methods
        registerService.prototype.submit = function () {
            this.jQuery("#FormRegister").submit();
            this.gaService.Track("Register", "Register");
        };
        registerService.prototype.formRegister_Password_keyup = function ($event) {
            if ($event.keyCode === 13) {
                this.submit();
            }
        };
        // inject
        registerService.$inject = ["$window", "jQuery", "gaService"];
        return registerService;
    })();
    M.registerService = registerService;
    // init
    angular.module("mainApp")
        .service("registerService", registerService);
})(M || (M = {}));
