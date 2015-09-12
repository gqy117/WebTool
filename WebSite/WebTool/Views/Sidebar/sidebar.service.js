var M;
(function (M) {
    "use strict";
    var sidebarService = (function () {
        // constructor
        function sidebarService($window, gaService) {
            this.$window = $window;
            this.gaService = gaService;
            // properties
            this.activePanel = new M.activePanel();
        }
        // methods
        sidebarService.prototype.LeftPanel_Dashboard = function () {
            this.gaService.Track("Index", "LeftPanel_Dashboard");
            this.$window.location.href = this.$window.App.baseUrl + "Home/Index";
        };
        sidebarService.prototype.LeftPanel_WOL = function () {
            this.gaService.Track("Index", "LeftPanel_WOL");
            this.$window.location.href = this.$window.App.baseUrl + "Tool/WOL";
        };
        // inject
        sidebarService.$inject = ["$window", "gaService"];
        return sidebarService;
    })();
    M.sidebarService = sidebarService;
    // init
    angular.module("mainApp")
        .service("sidebarService", sidebarService);
})(M || (M = {}));
