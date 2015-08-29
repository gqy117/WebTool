"use strict";
var M;
(function (M) {
    var wolService = (function () {
        function wolService() {
        }
        return wolService;
    })();
    M.wolService = wolService;
    // init
    angular.module("mainApp")
        .service("wolService", wolService);
})(M || (M = {}));
