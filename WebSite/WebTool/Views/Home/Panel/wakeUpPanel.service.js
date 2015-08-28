"use strict";
var M;
(function (M) {
    var wakeUpPanelService = (function () {
        // constructor
        function wakeUpPanelService($window, $http) {
            this.$window = $window;
            this.$http = $http;
        }
        // methods
        wakeUpPanelService.prototype.wakeUp = function (afterWakeUp) {
            this.$window.Track("Index", "Panel3_ViewMore");
            this.$http.post(this.$window.App.baseUrl + "Tool/WakeUp").then(function () {
                afterWakeUp();
            });
        };
        // inject
        wakeUpPanelService.$inject = ["$window", "$http"];
        return wakeUpPanelService;
    })();
    M.wakeUpPanelService = wakeUpPanelService;
    // init
    angular.module("mainApp").service("wakeUpPanelService", wakeUpPanelService);
})(M || (M = {}));
