(function (app) {
    'use strict';

    angular
        .module('mainApp')
        .factory('loginService', loginService);

    loginService.$inject = ['$window'];

    function loginService($window) {
        return {
            formLogOnSubmit: function formLogOnSubmit() {
                $window.Track('LogOn', 'LogOn');
                $window.jQuery('#FormLogin').submit();
            },
            
            formLogOnPasswordKeyup: function formLogOnPasswordKeyup($event) {
                if ($event.keyCode === 13) {
                    this.formLogOnSubmit();
                }
            },

            signUpNow: function signUpNow() {
                $window.Track('LogOn', 'SignUpNow');
                $window.location.href = app.baseUrl + 'Register/Index';
            }
        };
    }
}(App));