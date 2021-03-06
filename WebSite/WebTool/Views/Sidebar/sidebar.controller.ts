﻿module M {
    "use strict";

    export class sidebarController {
        // inject
        static $inject = ["sidebarService"];

        // properties
        public activePanel: activePanel;

        // constructor
        constructor(public sidebarService: sidebarService) {
            this.activePanel = this.sidebarService.activePanel;
        }

        // methods
        public LeftPanel_Dashboard_Click(): void {
            this.sidebarService.LeftPanel_Dashboard();
        }

        public LeftPanel_WOL_Click(): void {
            this.sidebarService.LeftPanel_WOL();
        }
    }

    // init
    angular.module("mainApp")
        .controller("sidebarController", sidebarController);
}