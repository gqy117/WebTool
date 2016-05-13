var M;
(function (M) {
    "use strict";
    var homeService = (function () {
        function homeService() {
        }
        return homeService;
    }());
    M.homeService = homeService;
    // init
    angular.module("mainApp")
        .service("homeService", homeService);
})(M || (M = {}));
