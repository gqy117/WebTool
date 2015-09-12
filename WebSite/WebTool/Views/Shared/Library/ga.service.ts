module M {
    "use strict";

    export class gaService {
        // inject
        static $inject = ["$window"];

        // constructor
        constructor(private $window: angular.IWindowService) { }

        // methods
        public Track(category: string, action: string): void {
            this.$window._gaq.push(["_trackEvent", category, action]);
        }
    }

    // init
    angular.module("mainApp")
        .service("gaService", gaService);
} 