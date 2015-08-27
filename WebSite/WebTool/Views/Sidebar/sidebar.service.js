"use strict";
var M;
(function (M) {
    var sidebarService = (function () {
        // constructor
        function sidebarService($window) {
            this.$window = $window;
        }
        // methods
        sidebarService.prototype.LeftPanel_Dashboard = function () {
            this.$window.Track('Index', 'LeftPanel_Dashboard');
            this.$window.location.href = this.$window.App.baseUrl + 'Home/Index';
        };

        sidebarService.prototype.LeftPanel_WOL = function () {
            this.$window.Track('Index', 'LeftPanel_WOL');
            this.$window.location.href = this.$window.App.baseUrl + 'Tool/WOL';
        };
        sidebarService.$inject = ["$window"];
        return sidebarService;
    })();
    M.sidebarService = sidebarService;
})(M || (M = {}));

// init
angular.module('mainApp').factory('sidebarService', M.sidebarService);
//# sourceMappingURL=sidebar.service.js.map
