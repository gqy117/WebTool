(function (window) {
    "use strict";

    angular
    .module('mainApp')
    .factory('headerPanelService', headerPanelService);

    function headerPanelService() {
        return {
            navigation1: function _navigation1() {
                window.Track('Index', 'Home');
                console.log('Tracking Home...');
            },
            navigation2: function _navigation2() {
                window.Track('Index', 'Dashboard');
                console.log('Tracking Dashboard...');
            }
        };
    }
}(window));