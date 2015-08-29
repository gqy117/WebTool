"use strict";

module M {
    export class wakeUpPanelController implements  IWakeUpStatus {
        // inject
        static $inject = ["wakeUpPanelService"];

        // properties
        public isShowAlertWakeUpSuccess: boolean = false;

        // constructor
        constructor(private  wakeUpPanelService: wakeUpPanelService) { }

        // methods
        public wakeUp_Click(): void {
            var context: IWakeUpStatus = this;

            this.wakeUpPanelService.wakeUp(context);
        }

        public hideSuccessMessage(): void {
            var context: IWakeUpStatus = this;

            this.wakeUpPanelService.hideSuccessMessage(context);
        }

        public showSuccessMessage(): void {
            var context: IWakeUpStatus = this;

            this.wakeUpPanelService.showSuccessMessage(context);
        }
    }

    // init
    angular.module("mainApp")
        .controller('wakeUpPanelController', wakeUpPanelController);
}
