"use strict";

module M {
    export class homeHeaderPanelService implements IHeadPanelService {
        // inject
        static $inject = ["$window"];

        // constructor
        constructor(private $window) { }

        // methods
        public navigation1(): void {
            this.$window.Track("Index", "Home");
            console.log("Tracking Home...");
        }

        public navigation2(): void {
            this.$window.Track("Index", "Dashboard");
            console.log("Tracking Dashboard...");
        }
    }

    // init
    angular.module("mainApp")
        .service("headerPanelService", homeHeaderPanelService); 
}