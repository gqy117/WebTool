(function () {
    angular.module("mainApp")
         .controller('headerPanelController', ['headerPanelService', headerPanelController]);

    function headerPanelController(headerPanelService) {

        this.navigation1Click = headerPanelService.navigation1;
    }
}());
