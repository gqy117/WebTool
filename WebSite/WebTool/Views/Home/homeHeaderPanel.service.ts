module M {
    "use strict";

    export class homeHeaderPanelService implements IHeadPanelService {
        // inject
        static $inject = ["gaService"];

        // constructor
        constructor(private gaService: gaService) { }

        // methods
        public navigation1(): void {
            this.gaService.Track("Index", "Home");
            console.log("Tracking Home...");
        }

        public navigation2(): void {
            this.gaService.Track("Index", "Dashboard");
            console.log("Tracking Dashboard...");
        }
    }

    // init
    angular.module("mainApp")
        .service("headerPanelService", homeHeaderPanelService);
}