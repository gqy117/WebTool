(function () {
    "use strict";

    angular.module("mainApp")
        .factory("jQuery", jQueryService);


    jQueryService.$inject = ["$window"];


    function jQueryService($window: angular.IWindowService) {
        return $window.jQuery;
    }
}());