(function () {
    angular.module("mainApp")
         .controller('wolController', ['wolService', 'sidebarService', wolController]);

    function wolController(wolService, sidebarService) {

        this.activePanel = sidebarService.activePanel;
        this.activePanel.wol = true;
    }
}());

CreateTable("#WOLTable", App.baseUrl + 'Tool/WOLTable');