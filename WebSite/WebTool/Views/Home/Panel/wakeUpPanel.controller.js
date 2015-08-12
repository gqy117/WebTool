(function () {
    "use strict";

    angular.module("mainApp")
         .controller('wakeUpPanelController', wakeUpPanelController);

    wakeUpPanelController.$inject = ['wakeUpPanelService'];

    function wakeUpPanelController(wakeUpPanelService) {
        this.isShowAlertWakeUpSuccess = false;

        this.wakeUp_Click = wakeUpPanelService.wakeUp;

        this.hideSuccessMessage = wakeUpPanelService.hideMessage;
    }
}());