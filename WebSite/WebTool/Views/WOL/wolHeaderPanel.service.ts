module M {
    "use strict";

    export class wolHeaderPanelService implements IHeadPanelService {
        // inject
        static $inject = ["gaService"];

        // constructor
        constructor(private gaService: gaService) { }

        // methods
        public navigation1(): void {
            this.gaService.Track("WOL", "WOL");
            console.log("Tracking WOL...");
        }

        public navigation2(): void {
            this.gaService.Track("WOL", "WOL");
            console.log("Tracking WOL...");
        }
    }

    // init
    angular.module("mainApp")
        .service("headerPanelService", wolHeaderPanelService);
}