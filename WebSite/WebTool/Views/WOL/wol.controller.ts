module M {
    "use strict";
    import WindowService = angular.IWindowService;

    export class wolController {
        // inject
        static $inject = ["$window", "wolService", "sidebarService", "myDataTableService"];

        // properties
        public activePanel: activePanel;

        // constructor
        constructor(private $window: WindowService,
            private wolService: wolService,
            private sidebarService: sidebarService,
            private myDataTableService: any) {

            this.activePanel = this.sidebarService.activePanel;
            this.activePanel.wol = true;

            this.myDataTableService.createTable("#WOLTable", this.$window.App.baseUrl + "Tool/WOLTable");
        }
    }

    // init
    angular.module("mainApp")
        .controller("wolController", wolController);
}