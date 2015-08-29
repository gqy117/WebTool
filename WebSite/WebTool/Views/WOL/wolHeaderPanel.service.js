"use strict";
var M;
(function (M) {
    var wolHeaderPanelService = (function () {
        // constructor
        function wolHeaderPanelService($window) {
            this.$window = $window;
        }
        // methods
        wolHeaderPanelService.prototype.navigation1 = function () {
            this.$window.Track("WOL", "WOL");
            console.log("Tracking WOL...");
        };
        wolHeaderPanelService.prototype.navigation2 = function () {
            this.$window.Track("WOL", "WOL");
            console.log("Tracking WOL...");
        };
        // inject
        wolHeaderPanelService.inject = ["$window"];
        return wolHeaderPanelService;
    })();
    M.wolHeaderPanelService = wolHeaderPanelService;
    // init
    angular.module("mainApp")
        .service("headerPanelService", wolHeaderPanelService);
})(M || (M = {}));
