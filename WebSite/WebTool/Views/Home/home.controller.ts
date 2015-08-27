"use strict";

module M {
    export class homeController {
        // inject
        static $inject = ["homeService", "sidebarService"];

        // properties
        public activePanel: activePanel;

        // constructor
        constructor(
            public homeService: homeService,
            public sidebarService: sidebarService
        ) {
            this.activePanel = new activePanel();
            this.activePanel.dashboard = true;
        }
    }
}

// init
angular.module("mainApp")
    .controller("homeController", M.homeController);