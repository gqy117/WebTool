module M {
    "use strict";
    import WindowService = angular.IWindowService;
    import HttpService = angular.IHttpService;

    export class wakeUpPanelService {
        // inject
        static $inject = ["$window", "$http"];

        // constructor
        constructor(private $window: WindowService, private $http: HttpService) { }

        // methods
        public wakeUp(wakeUpStatus: IWakeUpStatus): void {
            this.$window.Track("Index", "Panel3_ViewMore");

            this.$http.post(this.$window.App.baseUrl + "Tool/WakeUp")
                .then(() => {
                    wakeUpStatus.isShowAlertWakeUpSuccess = true;
                });
        }

        public showSuccessMessage(wakeUpStatus: IWakeUpStatus): void {
            wakeUpStatus.isShowAlertWakeUpSuccess = true;
        }

        public hideSuccessMessage(wakeUpStatus: IWakeUpStatus): void {
            wakeUpStatus.isShowAlertWakeUpSuccess = false;
        }
    }

    // init
    angular.module("mainApp")
        .service("wakeUpPanelService", wakeUpPanelService);
}