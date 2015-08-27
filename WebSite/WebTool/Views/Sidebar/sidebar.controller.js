"use strict";
var M;
(function (M) {
    var sidebarController = (function () {
        // constructor
        function sidebarController(sidebarService) {
            this.sidebarService = sidebarService;
            // properties
            this.activePanel = new M.activePanel();
        }
        // methods
        sidebarController.prototype.LeftPanel_Dashboard_Click = function () {
            this.sidebarService.LeftPanel_Dashboard();
        };

        sidebarController.prototype.LeftPanel_WOL_Click = function () {
            this.sidebarService.LeftPanel_WOL();
        };
        sidebarController.$inject = ["sidebarService"];
        return sidebarController;
    })();
    M.sidebarController = sidebarController;
})(M || (M = {}));

// init
angular.module('mainApp').factory('sidebarController', M.sidebarController);
//# sourceMappingURL=sidebar.controller.js.map
