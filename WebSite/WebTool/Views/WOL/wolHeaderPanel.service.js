(function (window) {
    "use strict";

    angular
    .module('mainApp')
    .factory('headerPanelService', headerPanelService);

    function headerPanelService() {
        return {
            navigation1: function _navigation1() {
                window.Track('WOL', 'WOL');
                console.log('Tracking WOL...');
            },
            navigation2: function _navigation2() {
                window.Track('WOL', 'WOL');
                console.log('Tracking WOL...');
            }
        };
    }
}(window));