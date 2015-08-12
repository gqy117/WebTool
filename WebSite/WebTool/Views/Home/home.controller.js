(function () {
    "use strict";

    angular.module("mainApp")
         .controller('homeController', homeController);

    homeController.$inject = ['homeService', 'sidebarService'];

    function homeController(homeService, sidebarService) {

        this.activePanel = sidebarService.activePanel;
        this.activePanel.dashboard = true;
    }
}());