"use strict";

module M {
    export class wakeUpPanelService {
        // inject
        static $inject = ["$window", "$http"];

        // properties
        public isShowAlertWakeUpSuccess: boolean;

        // constructor
        constructor(private $window, private $http) { }

        // methods
        public hideMessage(): void {
            this.isShowAlertWakeUpSuccess = false;
        }

        public wakeUp(context: wakeUpPanelController): void {

            //var context: wakeUpPanelController = this;

            this.$window.Track("Index", "Panel3_ViewMore");
            
            this.$http.post(this.$window.App.baseUrl + "Tool/WakeUp")
                .then(() => {
                    console.log('Waking up...');
                    context.isShowAlertWakeUpSuccess = true;
                });
        }
    }

    // init
    angular.module("mainApp")
        .service("wakeUpPanelService", wakeUpPanelService);
}