"use strict";

module M {
    export class wakeUpPanelController {
        // inject
        static $inject = ["wakeUpPanelService"];

        // properties
        public isShowAlertWakeUpSuccess: boolean = false;

        // constructor
        constructor(public wakeUpPanelService: wakeUpPanelService) { }

        // methods
        public wakeUp_Click(): void {
            this.wakeUpPanelService.wakeUp(this.showSuccessMessage);
        }

        public hideSuccessMessage(): void {
            this.isShowAlertWakeUpSuccess = false;
        }

        public showSuccessMessage(): void {
            this.isShowAlertWakeUpSuccess = true;
        }
    }

    // init
    angular.module("mainApp")
        .controller('wakeUpPanelController', wakeUpPanelController);
}
