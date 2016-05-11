var M;
(function (M) {
    "use strict";
    var headService = (function () {
        // constructor
        function headService($window, gaService) {
            this.$window = $window;
            this.gaService = gaService;
        }
        // methods
        headService.prototype.brand = function () {
            this.gaService.Track("IndexHead", "brand");
        };
        headService.prototype.myProfile = function () {
            this.gaService.Track("IndexHead", "MyProfile");
        };
        headService.prototype.logOut = function () {
            this.gaService.Track("IndexHead", "LogOut");
            this.$window.location.href = this.$window.App.baseUrl + "Account/Login";
        };
        // inject
        headService.$inject = ["$window", "gaService"];
        return headService;
    }());
    M.headService = headService;
    // init
    angular.module("mainApp")
        .service("headService", headService);
})(M || (M = {}));
