﻿module M {
    "use strict";

    import WindowService = angular.IWindowService;
    import AngularEvent = angular.IAngularEvent;

    export class loginController {
        // inject
        static $inject = ["loginService", "$window"];

        // constructor
        constructor(private loginService: loginService, private $window: WindowService) {
            angular.element(document).ready(() => {
                $window.App.initLogin();
            });
        }

        //  methods
        public formLogOnSubmit(): void {
            this.loginService.formLogOnSubmit();
        }

        public formLogOnPasswordKeyup($event: AngularEvent): void {
            this.loginService.formLogOnPasswordKeyup($event);
        }

        public signUpNow(): void {
            this.loginService.signUpNow();
        }
    }

    // init
    angular.module("mainApp")
        .controller("loginController", loginController);
}