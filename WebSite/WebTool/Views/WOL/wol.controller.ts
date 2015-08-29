"use strict";

module M {
    export class wolController {
        // inject
        static $inject = ["$window", "wolService", "sidebarService", "myDataTableService"];

        // properties
        public activePanel: activePanel;

        // constructor
        constructor(private $window, private wolService: wolService, private sidebarService: sidebarService, private myDataTableService) {
            this.activePanel = this.sidebarService.activePanel;
            this.activePanel.wol = true;

            this.myDataTableService.createTable("#WOLTable", this.$window.App.baseUrl + 'Tool/WOLTable');
        }
    }

    // init
    angular.module("mainApp")
        .controller("wolController", wolController);
}