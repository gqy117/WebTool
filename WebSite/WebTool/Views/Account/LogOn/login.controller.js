(function (angular, app, document) {
    'use strict';

    angular.module("mainApp")
         .controller('loginController', loginController);

    loginController.$inject = ['loginService'];

    function loginController(loginService) {

        this.formLogOnSubmit = loginService.formLogOnSubmit;
        this.formLogOnPasswordKeyup = loginService.formLogOnPasswordKeyup;
        this.signUpNow = loginService.signUpNow;

        angular.element(document).ready(function () {
            app.initLogin();
        });
    }
}(angular, App, document));