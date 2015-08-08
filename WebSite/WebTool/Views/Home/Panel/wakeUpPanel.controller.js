(function () {
    angular.module("mainApp")
         .controller('wakeUpPanelController', ['wakeUpPanelService', wakeUpPanelController]);

    function wakeUpPanelController(wakeUpPanelService) {
        this.isShowAlertWakeUpSuccess = false;

        this.wakeUp_Click = wakeUpPanelService.wakeUp;

        this.hideSuccessMessage = wakeUpPanelService.hideMessage;
    }
}());