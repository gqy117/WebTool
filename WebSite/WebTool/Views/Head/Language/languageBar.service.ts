﻿module M {
    "use strict";

    export class languageBarService {
        // inject
        static $inject = ["$window"];

        // constructor
        constructor(private $window) { }

        // methods
        public changeLanguage(languageCode: string): void {
            this.$window.Track("IndexHead", "ChangeLanguage");
            console.log("Tracking ChangeLanguage...");

            this.$window.jQuery.cookie("WebToolLanguage", languageCode, {
                expires: 10000,
                path: "/"
            });

            this.$window.location.reload();
        }
    }

    // init
    angular.module("mainApp")
        .service("languageBarService", languageBarService);
}