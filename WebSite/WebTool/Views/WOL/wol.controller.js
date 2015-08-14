(function () {
    "use strict";

    angular.module("mainApp")
         .controller('wolController', wolController);

    wolController.$inject = ['wolService', 'sidebarService', 'myDataTableService'];

    function wolController(wolService, sidebarService, myDataTableService) {

        this.activePanel = sidebarService.activePanel;
        this.activePanel.wol = true;

        myDataTableService.createTable("#WOLTable", App.baseUrl + 'Tool/WOLTable');
    }
}());