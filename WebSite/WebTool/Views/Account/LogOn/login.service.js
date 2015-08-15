(function (angular, $, app, window) {
    'use strict';

    angular
        .module('mainApp')
        .factory('loginService', loginService);

    function loginService() {
        return {
            formLogOnSubmit: function formLogOnSubmit() {
                window.Track('LogOn', 'LogOn');
                $('#FormLogin').submit();
            },

            formLogOnPasswordKeyup: function formLogOnPasswordKeyup($event) {
                if ($event.keyCode === 13) {
                    this.formLogOnSubmit();
                }
            },

            signUpNow: function signUpNow() {
                window.Track('LogOn', 'SignUpNow');
                window.location.href = app.baseUrl + 'Register/Index';
            }
        };
    }
}(angular, jQuery, App, window));