(function () {
    "use strict";

    angular
    .module('mainApp')
    .factory('sidebarService', sidebarService);

    sidebarService.$inject = ['$window'];

    function sidebarService($window) {
        return {
            activePanel: { dashboard: false, wol: false },

            LeftPanel_Dashboard: function _LeftPanel_Dashboard() {
                $window.Track('Index', 'LeftPanel_Dashboard');
                $window.location.href = $window.App.baseUrl + 'Home/Index';
            },

            LeftPanel_WOL: function _LeftPanel_WOL() {
                $window.Track('Index', 'LeftPanel_WOL');
                $window.location.href = $window.App.baseUrl + 'Tool/WOL';
            }
        };
    }
}());