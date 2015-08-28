"use strict";
var M;
(function (M) {
    var wakeUpPanelController = (function () {
        // constructor
        function wakeUpPanelController(wakeUpPanelService) {
            this.wakeUpPanelService = wakeUpPanelService;
            // properties
            this.isShowAlertWakeUpSuccess = false;
        }
        // methods
        wakeUpPanelController.prototype.wakeUp_Click = function () {
            this.wakeUpPanelService.wakeUp(this);
        };

        wakeUpPanelController.prototype.hideSuccessMessage = function () {
            this.wakeUpPanelService.hideMessage();
        };
        wakeUpPanelController.$inject = ["wakeUpPanelService"];
        return wakeUpPanelController;
    })();
    M.wakeUpPanelController = wakeUpPanelController;

    // init
    angular.module("mainApp").controller('wakeUpPanelController', wakeUpPanelController);
})(M || (M = {}));
//# sourceMappingURL=wakeUpPanel.controller.js.map
