module M {
    "use strict";
    import WindowService = angular.IWindowService;

    export class homeHeaderPanelService implements IHeadPanelService {
        // inject
        static $inject = ["$window"];

        // constructor
        constructor(private $window: WindowService) { }

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