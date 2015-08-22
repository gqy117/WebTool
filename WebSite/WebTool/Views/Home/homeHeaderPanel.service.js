(function () {
    "use strict";

    angular
    .module('mainApp')
    .factory('headerPanelService', headerPanelService);

    headerPanelService.$inject = ['$window'];

    function headerPanelService($window) {
        return {
            navigation1: function _navigation1() {
                $window.Track('Index', 'Home');
                console.log('Tracking Home...');
            },
            navigation2: function _navigation2() {
                $window.Track('Index', 'Dashboard');
                console.log('Tracking Dashboard...');
            }
        };
    }
}());