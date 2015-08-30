var M;
(function (M) {
    "use strict";
    var homeHeaderPanelService = (function () {
        // constructor
        function homeHeaderPanelService($window) {
            this.$window = $window;
        }
        // methods
        homeHeaderPanelService.prototype.navigation1 = function () {
            this.$window.Track("Index", "Home");
            console.log("Tracking Home...");
        };
        homeHeaderPanelService.prototype.navigation2 = function () {
            this.$window.Track("Index", "Dashboard");
            console.log("Tracking Dashboard...");
        };
        // inject
        homeHeaderPanelService.$inject = ["$window"];
        return homeHeaderPanelService;
    })();
    M.homeHeaderPanelService = homeHeaderPanelService;
    // init
    angular.module("mainApp")
        .service("headerPanelService", homeHeaderPanelService);
})(M || (M = {}));
