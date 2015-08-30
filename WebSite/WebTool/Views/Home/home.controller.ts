module M {
    "use strict";

    export class homeController {
        // inject
        static $inject = ["homeService", "sidebarService"];

        // properties
        public activePanel: activePanel;

        // constructor
        constructor(
            private  homeService: homeService,
            private sidebarService: sidebarService
        ) {
            this.activePanel = this.sidebarService.activePanel;
            this.activePanel.dashboard = true;
        }
    }

    // init
    angular.module("mainApp")
        .controller("homeController", homeController);
}