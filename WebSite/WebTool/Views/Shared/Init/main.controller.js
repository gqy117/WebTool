(function () {
    "use strict";

    angular.module('mainApp')
        .controller('mainController', mainController);

    mainController.$inject = ['uiModelService'];

    function mainController(uiModelService) {

        angular.element(document).ready(documentReady);

        function documentReady() {
            App.init();
            uiModelService.init();
        }
    }
})();