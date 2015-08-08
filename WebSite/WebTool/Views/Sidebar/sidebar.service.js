(function () {
    angular
    .module('mainApp')
    .factory('sidebarService', sidebarService);

    function sidebarService() {
        return {
            LeftPanel_Dashboard: function _LeftPanel_Dashboard() {
                Track('Index', 'LeftPanel_Dashboard');
                window.location.href = App.baseUrl + 'Home/Index';
            },

            LeftPanel_WOL: function _LeftPanel_WOL() {
                Track('Index', 'LeftPanel_WOL');
                window.location.href = App.baseUrl + 'Tool/WOL';
            }
        };
    }
}());