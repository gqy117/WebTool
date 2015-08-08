(function () {
    angular
    .module('mainApp')
    .factory('headerPanelService', ['wolService', headerPanelService]);

    function headerPanelService(wolService) {
        return {
            navigation1Click: function _navigation1Click() {
                wolService.wol();
            }
        };
    }
}());