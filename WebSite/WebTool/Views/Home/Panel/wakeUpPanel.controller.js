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
            var context = this;
            this.wakeUpPanelService.wakeUp(context);
        };
        wakeUpPanelController.prototype.hideSuccessMessage = function () {
            var context = this;
            this.wakeUpPanelService.hideSuccessMessage(context);
        };
        wakeUpPanelController.prototype.showSuccessMessage = function () {
            var context = this;
            this.wakeUpPanelService.showSuccessMessage(context);
        };
        // inject
        wakeUpPanelController.$inject = ["wakeUpPanelService"];
        return wakeUpPanelController;
    })();
    M.wakeUpPanelController = wakeUpPanelController;
    // init
    angular.module("mainApp")
        .controller("wakeUpPanelController", wakeUpPanelController);
})(M || (M = {}));
