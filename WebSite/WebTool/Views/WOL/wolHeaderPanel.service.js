var M;
(function (M) {
    "use strict";
    var wolHeaderPanelService = (function () {
        // constructor
        function wolHeaderPanelService(gaService) {
            this.gaService = gaService;
        }
        // methods
        wolHeaderPanelService.prototype.navigation1 = function () {
            this.gaService.Track("WOL", "WOL");
            console.log("Tracking WOL...");
        };
        wolHeaderPanelService.prototype.navigation2 = function () {
            this.gaService.Track("WOL", "WOL");
            console.log("Tracking WOL...");
        };
        // inject
        wolHeaderPanelService.$inject = ["gaService"];
        return wolHeaderPanelService;
    }());
    M.wolHeaderPanelService = wolHeaderPanelService;
    // init
    angular.module("mainApp")
        .service("headerPanelService", wolHeaderPanelService);
})(M || (M = {}));
