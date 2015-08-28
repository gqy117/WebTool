"use strict";
var M;
(function (M) {
    var homeController = (function () {
        // constructor
        function homeController(homeService, sidebarService) {
            this.homeService = homeService;
            this.sidebarService = sidebarService;
            this.activePanel = this.sidebarService.activePanel;
            this.activePanel.dashboard = true;
        }
        homeController.$inject = ["homeService", "sidebarService"];
        return homeController;
    })();
    M.homeController = homeController;

    // init
    angular.module("mainApp").controller("homeController", homeController);
})(M || (M = {}));
//# sourceMappingURL=home.controller.js.map
