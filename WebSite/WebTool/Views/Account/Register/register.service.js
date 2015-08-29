"use strict";
var M;
(function (M) {
    var registerService = (function () {
        // constructor
        function registerService($window) {
            this.$window = $window;
        }
        // methods
        registerService.prototype.submit = function () {
            this.$window.jQuery('#FormRegister').submit();
            this.$window.Track('Register', 'Register');
        };
        registerService.prototype.formRegister_Password_keyup = function ($event) {
            if ($event.keyCode === 13) {
                this.submit();
            }
        };
        // inject
        registerService.$inject = ['$window'];
        return registerService;
    })();
    M.registerService = registerService;
    // init
    angular.module('mainApp')
        .service('registerService', registerService);
})(M || (M = {}));
