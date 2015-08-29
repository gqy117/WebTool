"use strict";

(function () {
    jQueryService.$inject = ['$window'];

    function jQueryService($window) {
        return $window.jQuery;
    }

    // init
    angular.module('mainApp')
        .service('jQuery', jQueryService);
})();