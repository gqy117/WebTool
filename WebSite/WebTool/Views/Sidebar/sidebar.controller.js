(function () {
    "use strict";

    angular.module("mainApp")
         .controller('sidebarController', sidebarController);

    sidebarController.$inject = ['sidebarService'];

    function sidebarController(sidebarService) {

        this.activePanel = sidebarService.activePanel;

        this.LeftPanel_Dashboard_Click = sidebarService.LeftPanel_Dashboard;
        this.LeftPanel_WOL_Click = sidebarService.LeftPanel_WOL;
    }
}());
