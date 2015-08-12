﻿(function (window) {
    "use strict";

    angular
    .module('mainApp')
    .factory('sidebarService', sidebarService);

    function sidebarService() {
        return {
            activePanel: { dashboard: false, wol: false },

            LeftPanel_Dashboard: function _LeftPanel_Dashboard() {
                window.Track('Index', 'LeftPanel_Dashboard');
                window.location.href = App.baseUrl + 'Home/Index';
            },

            LeftPanel_WOL: function _LeftPanel_WOL() {
                window.Track('Index', 'LeftPanel_WOL');
                window.location.href = App.baseUrl + 'Tool/WOL';
            }
        };
    }
}(window));