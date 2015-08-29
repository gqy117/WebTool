"use strict";
var M;
(function (M) {
    var sidebarService = (function () {
        // constructor
        function sidebarService($window) {
            this.$window = $window;
            // properties
            this.activePanel = new M.activePanel();
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
        // inject
        sidebarService.$inject = ["$window"];
        return sidebarService;
    })();
    M.sidebarService = sidebarService;
    // init
    angular.module('mainApp')
        .service('sidebarService', sidebarService);
})(M || (M = {}));
