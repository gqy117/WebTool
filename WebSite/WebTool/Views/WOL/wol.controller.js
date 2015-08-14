(function () {
    "use strict";

    angular.module("mainApp")
         .controller('wolController', wolController);

    wolController.$inject = ['wolService', 'sidebarService'];

    function wolController(wolService, sidebarService) {

        this.activePanel = sidebarService.activePanel;
        this.activePanel.wol = true;
    }

    window.myDataTable.createTable("#WOLTable", App.baseUrl + 'Tool/WOLTable');
}());