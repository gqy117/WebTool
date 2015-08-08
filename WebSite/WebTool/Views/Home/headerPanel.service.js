(function () {
    angular
    .module('mainApp')
    .factory('headerPanelService', headerPanelService);

    function headerPanelService() {
        return {
            navigation1: function _navigation1() {
                Track('Index', 'Home');
                console.log('Tracking Home...');
            },
            navigation2: function _navigation2() {
                Track('Index', 'Dashboard');
                console.log('Tracking Dashboard...');
            }
        };
    }
}());