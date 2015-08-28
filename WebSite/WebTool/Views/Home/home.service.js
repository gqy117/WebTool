"use strict";
var M;
(function (M) {
    var homeService = (function () {
        function homeService() {
        }
        return homeService;
    })();
    M.homeService = homeService;
})(M || (M = {}));
// Init
angular.module("mainApp")
    .service("homeService", M.homeService);
