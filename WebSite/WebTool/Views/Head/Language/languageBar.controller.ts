"use strict";

module M {
    export class languageBarController {
        // inject
        static $inject = ["languageBarService"];

        // constructor
        constructor(private languageBarService: languageBarService) { }

        // methods
        public changeLanguage(languageCode: string): void {
            this.languageBarService.changeLanguage(languageCode);
        }
    }

    // init
    angular.module("mainApp")
        .controller('languageBarController', languageBarController);
}