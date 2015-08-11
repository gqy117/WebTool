(function () {
    angular.module("mainApp")
         .controller('wolController', wolController);

    wolController.$inject = ['wolService', 'sidebarService'];

    function wolController(wolService, sidebarService) {

        this.activePanel = sidebarService.activePanel;
        this.activePanel.wol = true;
    }

    CreateTable("#WOLTable", App.baseUrl + 'Tool/WOLTable');
}());