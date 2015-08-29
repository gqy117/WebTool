var M;
(function (M) {
    "use strict";
    var registerController = (function () {
        // constructor
        function registerController(registerService) {
            this.registerService = registerService;
        }
        // methods
        registerController.prototype.submit = function () {
            this.registerService.submit();
        };
        registerController.prototype.formRegister_Password_keyup = function ($event) {
            this.registerService.formRegister_Password_keyup($event);
        };
        // inject
        registerController.$inject = ["registerService"];
        return registerController;
    })();
    M.registerController = registerController;
    // init
    angular.module("mainApp")
        .controller("registerController", registerController);
})(M || (M = {}));
