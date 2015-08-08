(function () {
    angular.module("mainApp")
         .controller('wakeUpPanelController', ['wakeUpPanelService', wakeUpPanelController]);

    function wakeUpPanelController(wakeUpPanelService) {

        this.wakeUp_Click = wakeUpPanelService.wakeUp;
    }
}());