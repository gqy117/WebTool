"use strict";
var M;
(function (M) {
    var homeService = (function () {
        function homeService() {
        }
        return homeService;
    })();
    M.homeService = homeService;
    // Init
    angular.module("mainApp")
        .service("homeService", homeService);
})(M || (M = {}));
