"use strict";

module M {
    export class mainController {
        // inject
        static $inject = ["$window", "uiModelService"];

        // constructor
        constructor(private $window, private uiModelService: uiModelService) {
            angular.element(document).ready(() => {
                $window.App.init();
                uiModelService.init();
            });
        }
    }

    // init
    angular.module("mainApp")
        .controller("mainController", mainController);
}