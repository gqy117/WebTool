module M {
    "use strict";

    export class wolHeaderPanelService implements IHeadPanelService {
        // inject
        static inject = ["$window"];

        // constructor
        constructor(private $window) { }

        // methods
        public navigation1(): void {
            this.$window.Track("WOL", "WOL");
            console.log("Tracking WOL...");
        }

        public navigation2(): void {
            this.$window.Track("WOL", "WOL");
            console.log("Tracking WOL...");
        }
    }

    // init
    angular.module("mainApp")
        .service("headerPanelService", wolHeaderPanelService);
}