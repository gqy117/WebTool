"use strict";
var M;
(function (M) {
    var sidebarController = (function () {
        // constructor
        function sidebarController(sidebarService) {
            this.sidebarService = sidebarService;
            this.activePanel = this.sidebarService.activePanel;
        }
        // methods
        sidebarController.prototype.LeftPanel_Dashboard_Click = function () {
            this.sidebarService.LeftPanel_Dashboard();
        };
        sidebarController.prototype.LeftPanel_WOL_Click = function () {
            this.sidebarService.LeftPanel_WOL();
        };
        // inject
        sidebarController.$inject = ["sidebarService"];
        return sidebarController;
    })();
    M.sidebarController = sidebarController;
    // init
    angular.module("mainApp")
        .controller("sidebarController", sidebarController);
})(M || (M = {}));
