"use strict";

module M {
    export class sidebarController {
        // inject
        static $inject = ["sidebarService"];

        // properties
        public activePanel: activePanel = new activePanel();

        // constructor
        constructor(public sidebarService: sidebarService) {
        }

        // methods
        public LeftPanel_Dashboard_Click(): void {
            this.sidebarService.LeftPanel_Dashboard();
        }

        public LeftPanel_WOL_Click(): void {
            this.sidebarService.LeftPanel_WOL();
        }
    }
}

// init
angular.module('mainApp')
    .controller('sidebarController', M.sidebarController);