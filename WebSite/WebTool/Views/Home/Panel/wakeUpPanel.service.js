﻿"use strict";
var M;
(function (M) {
    var wakeUpPanelService = (function () {
        // constructor
        function wakeUpPanelService($window, $http) {
            this.$window = $window;
            this.$http = $http;
        }
        // methods
        wakeUpPanelService.prototype.hideMessage = function () {
            this.isShowAlertWakeUpSuccess = false;
        };

        wakeUpPanelService.prototype.wakeUp = function () {
            var context = this;

            this.$window.Track("Index", "Panel3_ViewMore");

            this.$http.post(this.$window.App.baseUrl + "Tool/WakeUp").then(function () {
                context.isShowAlertWakeUpSuccess = true;
            });
        };
        wakeUpPanelService.$inject = ["$window", "$http"];
        return wakeUpPanelService;
    })();
    M.wakeUpPanelService = wakeUpPanelService;

    // init
    angular.module("mainApp").factory("wakeUpPanelService", wakeUpPanelService);
})(M || (M = {}));
//# sourceMappingURL=wakeUpPanel.service.js.map
