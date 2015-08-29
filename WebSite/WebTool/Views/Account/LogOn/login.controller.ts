"use strict";

module M {
    export class loginController {
        // inject
        static $inject = ["loginService", "$window"];

        // constructor
        constructor(private loginService: loginService, private $window) {
            angular.element(document).ready(() => {
                $window.App.initLogin();
            });
        }

        //  methods
        public formLogOnSubmit(): void {
            this.loginService.formLogOnSubmit();
        }

        public formLogOnPasswordKeyup($event): void {
            this.loginService.formLogOnPasswordKeyup($event);
        }

        public signUpNow(): void {
            this.loginService.signUpNow();
        }
    }

    // init
    angular.module("mainApp")
        .controller('loginController', loginController);
}