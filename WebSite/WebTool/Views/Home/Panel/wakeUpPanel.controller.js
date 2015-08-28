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
            this.wakeUpPanelService.wakeUp(function (isShow) {
                context.isShowAlertWakeUpSuccess = isShow;
            });
        };
        wakeUpPanelController.prototype.hideSuccessMessage = function () {
            this.isShowAlertWakeUpSuccess = false;
        };
        wakeUpPanelController.prototype.showSuccessMessage = function () {
            this.isShowAlertWakeUpSuccess = true;
        };
        // inject
        wakeUpPanelController.$inject = ["wakeUpPanelService"];
        return wakeUpPanelController;
    })();
    M.wakeUpPanelController = wakeUpPanelController;
    // init
    angular.module("mainApp")
        .controller('wakeUpPanelController', wakeUpPanelController);
})(M || (M = {}));
