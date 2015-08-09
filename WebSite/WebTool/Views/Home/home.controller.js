(function () {
    angular.module("mainApp")
         .controller('homeController', ['homeService', 'sidebarService', homeController]);

    function homeController(homeService, sidebarService) {

        this.activePanel = sidebarService.activePanel;
        this.activePanel.dashboard = true;
    }
}());