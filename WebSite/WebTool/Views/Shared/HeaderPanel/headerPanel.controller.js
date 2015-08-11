(function () {
    angular
    .module("mainApp")
    .controller('headerPanelController', headerPanelController);

    headerPanelController.$inject = ['headerPanelService'];

    function headerPanelController(headerPanelService) {
        this.navigation1Click = headerPanelService.navigation1;
        this.navigation2Click = headerPanelService.navigation2;
    }
}());
