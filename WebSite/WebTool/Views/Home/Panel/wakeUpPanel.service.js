var M;
(function (M) {
    "use strict";
    var wakeUpPanelService = (function () {
        // constructor
        function wakeUpPanelService($window, $http, gaService) {
            this.$window = $window;
            this.$http = $http;
            this.gaService = gaService;
        }
        // methods
        wakeUpPanelService.prototype.wakeUp = function (wakeUpStatus) {
            this.gaService.Track("Index", "Panel3_ViewMore");
            this.$http.post(this.$window.App.baseUrl + "Tool/WakeUp")
                .then(function () {
                wakeUpStatus.isShowAlertWakeUpSuccess = true;
            });
        };
        wakeUpPanelService.prototype.showSuccessMessage = function (wakeUpStatus) {
            wakeUpStatus.isShowAlertWakeUpSuccess = true;
        };
        wakeUpPanelService.prototype.hideSuccessMessage = function (wakeUpStatus) {
            wakeUpStatus.isShowAlertWakeUpSuccess = false;
        };
        // inject
        wakeUpPanelService.$inject = ["$window", "$http", "gaService"];
        return wakeUpPanelService;
    }());
    M.wakeUpPanelService = wakeUpPanelService;
    // init
    angular.module("mainApp")
        .service("wakeUpPanelService", wakeUpPanelService);
})(M || (M = {}));
