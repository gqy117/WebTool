"use strict";
var M;
(function (M) {
    var homeController = (function () {
        // constructor
        function homeController(homeService, sidebarService) {
            this.homeService = homeService;
            this.sidebarService = sidebarService;
            this.activePanel = new M.activePanel();
            this.activePanel.dashboard = true;
        }
        homeController.$inject = ["homeService", "sidebarService"];
        return homeController;
    })();
    M.homeController = homeController;
})(M || (M = {}));

// init
angular.module("mainApp").controller("homeController", M.homeController);
//# sourceMappingURL=home.controller.js.map
