(function () {
    "use strict";

    angular
        .module('mainApp')
        .factory('registerService', registerService);

    registerService.$inject = ['$window'];

    function registerService($window) {
        return {
            submit: function submit() {
                $('#FormRegister').submit();
                $window.Track('Register', 'Register');
            },

            formRegister_Password_keyup: function formRegisterPasswordKeyup($event) {
                if ($event.keyCode === 13) {
                    this.submit();
                }
            }
        };
    }
}());