"use strict";
var M;
(function (M) {
    var headerPanelController = (function () {
        // constructor
        function headerPanelController(headerPanelService) {
            this.headerPanelService = headerPanelService;
        }
        // methods
        headerPanelController.prototype.navigation1Click = function () {
            this.headerPanelService.navigation1();
        };

        headerPanelController.prototype.navigation2Click = function () {
            this.headerPanelService.navigation2();
        };
        headerPanelController.$inject = ["headerPanelService"];
        return headerPanelController;
    })();
    M.headerPanelController = headerPanelController;

    // init
    angular.module('mainApp').service('headerPanelController', headerPanelController);
})(M || (M = {}));
//# sourceMappingURL=headerPanel.controller.js.map
