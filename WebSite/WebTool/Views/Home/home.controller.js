﻿(function () {
    "use strict";

    // init
    angular.module("mainApp").controller('homeController', homeController);

    // inject
    homeController.$inject = ['homeService', 'sidebarService'];

    // class
    function homeController(homeService, sidebarService) {
        this.activePanel = sidebarService.activePanel;
        this.activePanel.dashboard = true;
    }
}());
//# sourceMappingURL=home.controller.js.map
