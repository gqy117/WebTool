var M;
(function (M) {
    "use strict";
    var homeHeaderPanelService = (function () {
        // constructor
        function homeHeaderPanelService(gaService) {
            this.gaService = gaService;
        }
        // methods
        homeHeaderPanelService.prototype.navigation1 = function () {
            this.gaService.Track("Index", "Home");
            console.log("Tracking Home...");
        };
        homeHeaderPanelService.prototype.navigation2 = function () {
            this.gaService.Track("Index", "Dashboard");
            console.log("Tracking Dashboard...");
        };
        // inject
        homeHeaderPanelService.$inject = ["gaService"];
        return homeHeaderPanelService;
    })();
    M.homeHeaderPanelService = homeHeaderPanelService;
    // init
    angular.module("mainApp")
        .service("headerPanelService", homeHeaderPanelService);
})(M || (M = {}));
