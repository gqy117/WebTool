﻿(function (angular, app, document) {
    'use strict';

    angular.module("mainApp")
         .controller('loginController', loginController);

    loginController.$inject = ['loginService'];

    function loginController(loginService) {

        this.formLoginSubmit = loginService.formLoginSubmit;
        this.formLoginPasswordKeyup = loginService.formLoginPasswordKeyup;
        this.signUpNow = loginService.signUpNow;

        angular.element(document).ready(function () {
            app.initLogin();
        });
    }
}(angular, App, document));