(function () {
    angular
    .module('mainApp')
    .factory('headerPanelService', headerPanelService);

    function headerPanelService() {
        return {
            navigation1: function _navigation1() {
                Track('WOL', 'WOL');
                console.log('Tracking WOL...');
            },
            navigation2: function _navigation2() {
                Track('WOL', 'WOL');
                console.log('Tracking WOL...');
            }
        };
    }
}());