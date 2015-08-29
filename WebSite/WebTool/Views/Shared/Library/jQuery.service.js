(function () {
    'use strict';
    angular.module('mainApp')
        .factory('jQuery', jQueryService);
    jQueryService.$inject = ['$window'];
    function jQueryService($window) {
        return $window.jQuery;
    }
}());
