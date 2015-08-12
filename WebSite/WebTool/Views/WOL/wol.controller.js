(function (window) {
    "use strict";

    angular.module("mainApp")
         .controller('wolController', wolController);

    wolController.$inject = ['wolService', 'sidebarService'];

    function wolController(wolService, sidebarService) {

        this.activePanel = sidebarService.activePanel;
        this.activePanel.wol = true;
    }

    window.CreateTable("#WOLTable", App.baseUrl + 'Tool/WOLTable');
}(window));