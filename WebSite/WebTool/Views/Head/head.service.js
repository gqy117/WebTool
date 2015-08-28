"use strict";
var M;
(function (M) {
    var headService = (function () {
        // constructor
        function headService($window) {
            this.$window = $window;
        }
        // methods
        headService.prototype.brand = function () {
            this.$window.Track("IndexHead", "brand");
        };
        headService.prototype.myProfile = function () {
            this.$window.Track("IndexHead", "MyProfile");
        };
        headService.prototype.logOut = function () {
            this.$window.Track("IndexHead", "LogOut");
            this.$window.location.href = this.$window.App.baseUrl + "Account/Login";
        };
        // inject
        headService.$inject = ["$window"];
        return headService;
    })();
    M.headService = headService;
})(M || (M = {}));
// init
angular.module("mainApp")
    .service("headService", M.headService);
