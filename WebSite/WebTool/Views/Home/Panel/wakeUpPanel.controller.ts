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
            this.wakeUpPanelService.wakeUp(this);
        }

        public hideSuccessMessage(): void {
            this.wakeUpPanelService.hideMessage();
        }
    }

    // init
    angular.module("mainApp")
        .controller('wakeUpPanelController', wakeUpPanelController);
}
