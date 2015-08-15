(function (angular, $, app, window) {
    'use strict';

    angular
        .module('mainApp')
        .factory('loginService', loginService);

    function loginService() {
        return {
            formLoginSubmit: function formLoginSubmit() {
                window.Track('LogOn', 'LogOn');
                $('#FormLogin').submit();
            },

            formLoginPasswordKeyup: function formLoginPasswordKeyup($event) {
                if ($event.keyCode === 13) {
                    this.formLoginSubmit();
                }
            },

            signUpNow: function signUpNow() {
                window.Track('LogOn', 'SignUpNow');
                window.location.href = app.baseUrl + 'Register/Index';
            }
        };
    }
}(angular, jQuery, App, window));