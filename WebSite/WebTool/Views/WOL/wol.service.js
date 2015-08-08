(function () {
    angular
    .module('mainApp')
    .factory('wolService', wolService);

    function wolService() {
        return {
            wol: function _wol() {
                Track('WOL', 'WOL');
                console.log('Tracking WOL...');
            }
        };
    }
}());


Add_JS_Content('ActiveCurrentPanel("WOL");');

CreateTable("#WOLTable", App.baseUrl + 'Tool/WOLTable');