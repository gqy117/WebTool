var M;
(function (M) {
    "use strict";
    var gaService = (function () {
        // constructor
        function gaService($window) {
            this.$window = $window;
        }
        // methods
        gaService.prototype.Track = function (category, action) {
            this.$window._gaq.push(["_trackEvent", category, action]);
        };
        // inject
        gaService.$inject = ["$window"];
        return gaService;
    })();
    M.gaService = gaService;
    // init
    angular.module("mainApp")
        .service("gaService", gaService);
})(M || (M = {}));
