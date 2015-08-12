(function (window) {
    "use strict";

    angular
        .module('mainApp')
        .factory('registerService', registerService);

    function registerService() {
        return {
            submit: function submit() {
                $('#FormRegister').submit();
                window.Track('Register', 'Register');
            },

            formRegister_Password_keyup: function formRegisterPasswordKeyup($event) {
                if ($event.keyCode === 13) {
                    this.submit();
                }
            }
        };
    }
}(window));