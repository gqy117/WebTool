var M;
(function (M) {
    "use strict";
    var mainController = (function () {
        // constructor
        function mainController($window, uiModelService) {
            this.$window = $window;
            this.uiModelService = uiModelService;
            angular.element(document).ready(function () {
                $window.App.init();
                uiModelService.init();
            });
        }
        // inject
        mainController.$inject = ["$window", "uiModelService"];
        return mainController;
    }());
    M.mainController = mainController;
    // init
    angular.module("mainApp")
        .controller("mainController", mainController);
})(M || (M = {}));
